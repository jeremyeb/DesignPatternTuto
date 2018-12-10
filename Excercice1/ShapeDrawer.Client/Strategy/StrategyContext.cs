using System;
using ShapeDrawer.Common.Shape;

namespace ShapeDrawer.Client.Strategy
{

    public class StrategyContext
    {
        private IDrawer drawer;

        internal void SetDrawer(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        internal void Draw(IShape shape)
        {
            if (shape == null)
            {
                Logger.Logger.Instance.Error("Cannot Draw a null Shape");
            }

            if(drawer == null)
            {
                Logger.Logger.Instance.Error("Cannot Draw since the drawer is null");
            }
            else
            {
                Logger.Logger.Instance.Info($"Drawing {shape.GetType()} with Drawer {drawer.GetType()}");
                drawer.Draw(shape);
            }
        }
    }
}
