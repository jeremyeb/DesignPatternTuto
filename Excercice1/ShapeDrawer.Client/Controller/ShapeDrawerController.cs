using ShapeDrawer.Common.Shape;
using System;

namespace ShapeDrawer.Client.Controller
{
    public class ShapeDrawerController : IObserver<IShape>
    {
        public event EventHandler<ShapeEventArgs> OnDraw;

        public void OnNext(IShape shape)
        {
            OnDraw?.Invoke(this, new ShapeEventArgs(shape));
        }

        public void OnError(Exception error)
        {
        }

        public void OnCompleted()
        {
        }
    }
}
