using Unity;
using Unity.Lifetime;

namespace ShapeDrawer.Client.Utils
{
    public static class UnityExtentions
    {
        //Create a Singleton
        public static LifetimeManager CreateSingleton<TFrom, TTo>(this IUnityContainer container)
            where TTo : TFrom
        {
            https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff647854(v=pandp.10)
            var singletonLifeTimeManager = new ContainerControlledLifetimeManager();
            container.RegisterType<TFrom, TTo>(singletonLifeTimeManager);
            return singletonLifeTimeManager;
        }

        //Create a Singleton
        public static LifetimeManager CreateSingleton<T>(this IUnityContainer container)
        {
            https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff647854(v=pandp.10)
            var singletonLifeTimeManager = new ContainerControlledLifetimeManager();
            container.RegisterType<T>(singletonLifeTimeManager);
            return singletonLifeTimeManager;
        }
    }
}
