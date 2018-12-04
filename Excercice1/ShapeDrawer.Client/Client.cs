using ShapeDrawer.Common.Message;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ShapeDrawer.Client
{
    public class Client : IDisposable
    {
        private TcpClient client;

        public event EventHandler<MessageEventArgs> OnShadeSelected;

        public Client()
        {
        }

        public void Start(string hostname, int port)
        {
            if (client != null) return;

            if(TryToConnect(hostname, port))
            {
                Task.Factory.StartNew(() =>
                {
                    var messageDecoder = new MessageDecoder();
                    var stream = client.GetStream();
                    try
                    {
                        while (client.Connected)
                        {
                            var message = messageDecoder.Decode(stream);
                            OnShadeSelected?.Invoke(this, new MessageEventArgs(message));
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                    finally
                    {
                        Stop();
                    }
                });
            }
        }

        private bool TryToConnect(string hostname, int port)
        {
            if (client != null) return true;
            try
            {
                client = new TcpClient();
                client.Connect(hostname, port);
            }
            catch (Exception ex)
            {
                client = null;
            }
            return client != null;
        }

        public void Stop()
        {
            try
            {
                client?.Dispose();
            }
            finally
            {
                client = null;
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
                    Stop();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Client() {
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
