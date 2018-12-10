using ShapeDrawer.Client.Utils;
using ShapeDrawer.Common.Shape;
using System;

namespace ShapeDrawer.Client.Controller
{
    public class ShapeDrawerController
    {
        public event EventHandler<ShapeEventArgs> OnDraw;
        private Client client;

        public ShapeDrawerController()
        {
            client = new Client();
            client.Start("127.0.0.1", 1111);
            client.OnShadeSelected += (o, e) => 
            {
                ShapeDrawerPaint(e.Message.Shape);
                OnDraw?.Invoke(this, new ShapeEventArgs(e.Message.Shape));
            };
        }

        private void ShapeDrawerPaint(IShape shape)
        {
            Console.WriteLine(ConsoleShapeDrawer.Draw(shape));
        }
    }
}
