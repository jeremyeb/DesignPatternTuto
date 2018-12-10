﻿using ShapeDrawer.Common.Message;
using System;
using System.Collections.Generic;

namespace ShapeDrawer.Client
{
    public class ShapeReciever : IObservable<Message>
    {
        private static ShapeReciever instance;

        private readonly List<IObserver<Message>> observerList;
        private readonly Client client;

        public bool IsStarted { get; private set; }

        private ShapeReciever()
        {
            observerList = new List<IObserver<Message>>();
            client = new Client();
            IsStarted = false;
        }

        public static ShapeReciever Instance
        {
            get { return instance ?? (instance = new ShapeReciever()); }
        }

        public void Start(string hostname, int port)
        {
            if (IsStarted) return;
            IsStarted = true;
            client.Start(hostname, port);
            client.OnShadeSelected += Client_OnShadeSelected;
        }

        public void Stop()
        {
            if (!IsStarted) return;
            IsStarted = false;
            client.Stop();
            client.OnShadeSelected -= Client_OnShadeSelected;
        }


        private void Client_OnShadeSelected(object sender, MessageEventArgs e)
        {
            NotifyObserver(e.Message);
        }

        protected void NotifyObserver(Message message)
        {
            foreach (var observer in observerList)
            {
                try
                {
                    observer.OnNext(message);
                }
                catch (Exception ex)
                {
                    Logger.Logger.Instance.Error("Cannot notify Observer", ex);
                }
            }
        }


        public IDisposable Subscribe(IObserver<Message> observer)
        {
            if (observer == null)
                return new DesignPatternTuto.Behavioral.Observer.Tools.UnObserver<IObserver<Message>>(null, null);

            if (!observerList.Contains(observer))
                observerList.Add(observer);

            return new DesignPatternTuto.Behavioral.Observer.Tools.UnObserver<IObserver<Message>>(observerList, observer);
        }
    }
}
