using ShapeDrawer.Common.Shape;
using System;
using System.Drawing;

namespace ShapeDrawer.Client.Utils
{
    public static class GraphicShapeDrawer
    {
        public static void Draw(this Graphics g, IShape shape)
        {
            if (shape == null) throw new System.ArgumentNullException(nameof(shape));
            if (shape is Circle)
            {
                g.Draw(shape as Circle);
            }
            else if (shape is Square)
            {
                g.Draw(shape as Square);
            }
            else if (shape is Common.Shape.Rectangle)
            {
                g.Draw(shape as Common.Shape.Rectangle);
            }
        }

        public static void Draw(this Graphics g, Circle circle)
        {
            if (circle == null) throw new System.ArgumentNullException(nameof(circle));

            var pixelRadious = (float)g.CentimeterToPixel(Convert.ToDouble(circle.Radious));
            g.DrawCircle(new Pen(Color.Black), pixelRadious + 1, pixelRadious + 1, pixelRadious);
        }

        /// <summary>
        /// https://stackoverflow.com/questions/1835062/drawing-circles-with-system-drawing
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <param name="radius"></param>
        public static void DrawCircle(this Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            if (radius <= 0) throw new System.ArgumentException(nameof(radius));

            g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        public static void Draw(this Graphics g, Common.Shape.Rectangle rectangle)
        {
            if (rectangle == null) throw new System.ArgumentNullException(nameof(rectangle));
            var width = (float)g.CentimeterToPixel(Convert.ToDouble(rectangle.Width));
            var height = (float)g.CentimeterToPixel(Convert.ToDouble(rectangle.Height));

            g.DrawRectangle(new Pen(Color.Black), 1, 1, width, height);
        }

        public static void Draw(this Graphics g, Common.Shape.Square square)
        {
            if (square == null) throw new System.ArgumentNullException(nameof(square));
            var size = (float)g.CentimeterToPixel(Convert.ToDouble(square.Size));
            g.DrawRectangle(new Pen(Color.Black), 1, 1, size, size);
        }

        public static double CentimeterToPixel(this Graphics g, double centimeter)
        {
            return centimeter * g.DpiY / 2.54d;
        }
    }
}
