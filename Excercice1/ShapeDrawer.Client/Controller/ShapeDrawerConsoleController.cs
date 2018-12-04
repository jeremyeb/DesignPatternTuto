using ShapeDrawer.Client.Utils;
using ShapeDrawer.Common.Shape;
using System;

namespace ShapeDrawer.Client.Controller
{
    public class ShapeDrawerConsoleController
    {
        private Client client;

        public ShapeDrawerConsoleController()
        {
            client = new Client();
            client.Start("127.0.0.1", 1111);
            client.OnShadeSelected += (o, e) => ShapeDrawerPaint(e.Message.Shape);
        }


        private void ShapeDrawerPaint(IShape shape)
        {
            Console.WriteLine(ConsoleShapeDrawer.Draw(shape));
        }
    }
}
