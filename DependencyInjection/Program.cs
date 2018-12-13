using Unity;
using Unity.Lifetime;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Main_WihoutDI(args);
            Main_WihtDI(args);
        }

        private static void Main_WihoutDI(string[] args)
        {
            var myApp = new WihoutDI.UserInterface();
        }

        private static void Main_WihtDI(string[] args)
        {
            var unityContainer = new UnityContainer();

            CreateSingleton<WihtDI.IEmailProvider, WihtDI.OutlookEmailProvider>(unityContainer);

            var myApp = unityContainer.Resolve<WihtDI.UserInterface1>();

            ///
        }



        //Create a Singleton
        public static LifetimeManager CreateSingleton<TFrom, TTo>(IUnityContainer container)
            where TTo : TFrom
        {
            https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff647854(v=pandp.10)
            var singletonLifeTimeManager = new ContainerControlledLifetimeManager();
            container.RegisterType<TFrom, TTo>(singletonLifeTimeManager);
            return singletonLifeTimeManager;
        }
    }
}
