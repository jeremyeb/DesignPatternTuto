using System;

namespace DesignPatternTuto.Behavioral.Observer
{
    public class ObserverClass : IObserver<ObservableClass>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ObservableClass value)
        {
            throw new NotImplementedException();
        }
    }
}
