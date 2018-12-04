using ShapeDrawer.Common.Message;
using ShapeDrawer.Common.Shape;
using System;

namespace ShapeDrawer.Server
{
    public class ShapeSeletedEventArgs : EventArgs
    {
        public IShape Shape { get; private set; }
        public EnumUiDrawer UiDrawer { get; private set; }

        public ShapeSeletedEventArgs(IShape shape, EnumUiDrawer uiDrawer)
        {
            Shape = shape ?? throw new ArgumentNullException(nameof(shape));
            UiDrawer = uiDrawer;
        }
    }
}