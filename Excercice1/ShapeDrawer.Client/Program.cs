using ShapeDrawer.Client.Controller;
using System;
using System.Windows.Forms;

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
            var controller = new ShapeDrawerController();
            var app = new App(controller);

            ShapeReciever.Instance.Start("127.0.0.1", 1111);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.ShapeDrawer(controller));
        }
    }
}
