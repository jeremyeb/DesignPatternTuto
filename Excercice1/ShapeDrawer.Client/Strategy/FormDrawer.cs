using ShapeDrawer.Client.Controller;
using ShapeDrawer.Common.Shape;
using System;

namespace ShapeDrawer.Client.Strategy
{
    public class FormDrawer : IFormDrawer
    {
        private readonly ShapeDrawerController controller;

        public FormDrawer(ShapeDrawerController controller)
        {
            this.controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public void Draw(IShape shape)
        {
            controller.OnNext(shape);
        }
    }
}
