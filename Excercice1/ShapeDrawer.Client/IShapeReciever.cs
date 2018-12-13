using ShapeDrawer.Common.Message;
using System;

namespace ShapeDrawer.Client
{
    public interface IShapeReciever :  IObservable<Message>
    {
        bool IsStarted { get; }

        void Start(string hostname, int port);
        void Stop();
    }
}