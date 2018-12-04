using System;
using ShapeDrawer.Common.Shape;

namespace ShapeDrawer.Common.Message
{
    public class Message
    {
        public IShape Shape { get; private set; }
        public EnumUiDrawer UiDrawer { get; private set; }

        public Message(IShape shape, EnumUiDrawer uiDrawer)
        {
            Shape = shape ?? throw new ArgumentNullException(nameof(shape));
            UiDrawer = uiDrawer;
        }
    }
}
