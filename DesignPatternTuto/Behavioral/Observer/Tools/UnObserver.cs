using System;
using System.Collections.Generic;

namespace DesignPatternTuto.Behavioral.Observer.Tools
{
    public sealed class UnObserver<T> : IDisposable
    {
        private List<T> observerList;
        private T observer;

        public UnObserver(List<T> observerList, T observer)
        {
            this.observerList = observerList;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observerList == null || observer == null) return;
            if (observerList.Contains(observer))
                observerList.Remove(observer);
            observerList = null;
            observer = default(T);
        }
    }
}
