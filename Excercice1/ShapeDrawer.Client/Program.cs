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
            var consoleController = new ShapeDrawerConsoleController();
            var formController = new ShapeDrawerFormController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.ShapeDrawer(formController));
        }
    }
}
