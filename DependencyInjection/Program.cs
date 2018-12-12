using System;
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

            unityContainer.RegisterType<WihtDI.IEmailProvider, WihtDI.OutlookEmailProvider>();

            var myApp = unityContainer.Resolve<WihtDI.UserInterface1>();
        }
    }
}
