using ShapeDrawer.Common.Shape;
using System;

namespace ShapeDrawer.Client.Controller
{
    public class ShapeEventArgs : EventArgs
    {
        public IShape Shape { get; private set; }

        public ShapeEventArgs(IShape shape)
        {
            Shape = shape ?? throw new ArgumentNullException(nameof(shape));
        }
    }
}