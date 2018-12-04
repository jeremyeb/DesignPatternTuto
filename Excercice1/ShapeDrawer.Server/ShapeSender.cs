using ShapeDrawer.Common.Message;
using ShapeDrawer.Server.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ShapeDrawer.Server
{
    public class ShapeSender: IDisposable
    {
        private readonly List<TcpClient> clients;
        private readonly ShadeRandomSelector shadeRandomSelector;
        private readonly MessageEncoder messageEncoder;
        private readonly ILogger logger;
        private TcpListener listener;

        public ShapeSender(ShadeRandomSelector shadeRandomSelector, ILogger logger)
        {
            this.shadeRandomSelector = shadeRandomSelector ?? throw new ArgumentNullException(nameof(shadeRandomSelector));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            messageEncoder = new MessageEncoder();
            clients = new List<TcpClient>();
        }

        public void Start(int port)
        {
            if (TryToConnect(port))
            {
                shadeRandomSelector.Start();
                shadeRandomSelector.OnShadeSelected += ShadeRandomSelector_OnShadeSelected;
                ListenToConnection();
            }
        }

        private void ShadeRandomSelector_OnShadeSelected(object sender, ShapeSeletedEventArgs e)
        {
            var tasks = new List<Task>();
            var messageBytes = messageEncoder.Encode(e.Shape, e.UiDrawer);
            foreach (var client in GetClient().Where(c => c.Connected))
            {
                try
                {
                    tasks.Add(client.GetStream().WriteAsync(messageBytes).AsTask());
                }
                catch (Exception ex)
                {
                    logger.Error($"Cannot send information", ex);
                }
            }
            Task.WaitAll(tasks.ToArray());
        }

        private bool TryToConnect(int port)
        {
            if (listener != null) return true;
            try
            {
                listener = new TcpListener(IPAddress.Parse("0.0.0.0"), port);
                listener.Start();
            }
            catch (Exception ex)
            {
                logger.Error("Cannot listen to {port}", ex);
                listener = null;
            }
            return listener != null;
        }

        private void ListenToConnection()
        {
            try
            {
                while (true)
                {
                    var client = listener.AcceptTcpClient();
                    logger.Info("Connection accepted.");
                    AddClient(client);


                    Task.Factory.StartNew(() =>
                    {
                        var stream = client.GetStream();

                        try
                        {
                            int readNb = -1;
                            do
                            {
                                readNb = stream.ReadByte();
                            }
                            while (readNb != -1);
                        }
                        finally
                        {
                            logger.Info("Client Deconnected.");
                            RemoveClient(client);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                logger.Error("", ex);
            }
        }

        private void AddClient(TcpClient client)
        {
            lock (clients)
            {
                clients.Add(client);
            }
        }

        private void RemoveClient(TcpClient client)
        {
            lock (clients)
            {
                if(clients.Contains(client))
                    clients.Remove(client);
            }
        }

        private void ClearClient()
        {
            lock (clients)
            {
                clients.Clear();
            }
        }

        private IEnumerable<TcpClient> GetClient()
        {
            lock (clients)
            {
                return clients.ToList();
            }
        }

        public void Stop()
        {
            try
            {
                shadeRandomSelector.Stop();
                listener?.Stop();
            }
            finally
            {
                ClearClient();
                listener = null;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Stop();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ShapeSender() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
