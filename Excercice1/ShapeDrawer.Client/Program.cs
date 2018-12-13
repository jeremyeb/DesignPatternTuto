using ShapeDrawer.Client.Controller;
using ShapeDrawer.Client.Logger;
using ShapeDrawer.Client.Strategy;
using ShapeDrawer.Client.Utils;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ShapeDrawer.Client
{
    static class Program
    {
         
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var uc = ConfigureDI();
            var app = uc.Resolve<App>();
            var shapeReciever = uc.Resolve<IShapeReciever>();

            shapeReciever.Subscribe(app);
            shapeReciever.Start("127.0.0.1", 1111);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(uc.Resolve<Forms.ShapeDrawer>());
        }

        private static IUnityContainer ConfigureDI()
        {
            var uc = new UnityContainer();
            uc.CreateSingleton<ILogger, Logger.Logger>();
            uc.CreateSingleton<IShapeReciever, ShapeReciever>();
            uc.RegisterType<IConsoleDrawer, ConsoleDrawer>();
            uc.RegisterType<IFormDrawer, FormDrawer>();
            uc.CreateSingleton<ShapeDrawerController>();

            return uc;
        }
    }
}
