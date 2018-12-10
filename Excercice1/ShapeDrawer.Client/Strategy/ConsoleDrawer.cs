using ShapeDrawer.Client.Utils;
using ShapeDrawer.Common.Shape;
using System;

namespace ShapeDrawer.Client.Strategy
{
    public class ConsoleDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine(ConsoleShapeDrawer.Draw(shape));
        }
    }
}
