using System;
using System.Collections.Generic;

namespace DesignPatternTuto.Behavioral.Observer
{
    public class ObservableClass : IObservable<ObservableClass>
    {
        private readonly List<IObserver<ObservableClass>> observerList;
        public int Value { get; private set; }

        public ObservableClass()
        {
            observerList = new List<IObserver<ObservableClass>>();
        }

        public void Increase()
        {
            Value++;
            NotifyObserver();
        }

        public void Decrease()
        {
            Value--;
            NotifyObserver();
        }

        protected void NotifyObserver()
        {
            foreach (var observer in observerList)
            {
                observer.OnNext(this);
            }
        }


        public IDisposable Subscribe(IObserver<ObservableClass> observer)
        {
            if (observer == null)
                return new Tools.UnObserver<IObserver<ObservableClass>>(null, null);

            if (!observerList.Contains(observer))
                observerList.Add(observer);

            return new Tools.UnObserver<IObserver<ObservableClass>>(observerList, observer);
        }
    }
}
