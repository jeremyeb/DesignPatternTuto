using System;

namespace ShapeDrawer.Client.Controller
{
    public class ShapeDrawerFormController
    {
        public event EventHandler<ShapeEventArgs> OnDraw;
        private Client client;

        public ShapeDrawerFormController()
        {
            client = new Client();
            client.Start("127.0.0.1", 1111);
            client.OnShadeSelected += (o, e) => OnDraw?.Invoke(this, new ShapeEventArgs(e.Message.Shape));
        }
    }
}
