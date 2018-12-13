using System;
using ShapeDrawer.Client.Logger;
using ShapeDrawer.Common.Shape;

namespace ShapeDrawer.Client.Strategy
{

    public class StrategyContext
    {
        private readonly ILogger logger;
        private IDrawer drawer;

        public StrategyContext(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException();
        }

        public void SetDrawer(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public void Draw(IShape shape)
        {
            if (shape == null)
            {
                logger.Error("Cannot Draw a null Shape");
            }

            if(drawer == null)
            {
                logger.Error("Cannot Draw since the drawer is null");
            }
            else
            {
                logger.Info($"Drawing {shape.GetType()} with Drawer {drawer.GetType()}");
                drawer.Draw(shape);
            }
        }
    }
}
