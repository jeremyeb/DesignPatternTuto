using ShapeDrawer.Common.Shape;
using System;
using System.Text;

namespace ShapeDrawer.Client.Utils
{
    public static class ConsoleShapeDrawer
    {
        public static string Draw(IShape shape)
        {
            if (shape == null) throw new System.ArgumentNullException(nameof(shape));
            if (shape is Circle)
            {
                return Draw(shape as Circle);
            }
            else if (shape is Square)
            {
                return Draw(shape as Square);
            }
            else if (shape is Rectangle)
            {
                return Draw(shape as Rectangle);
            }
            return "Unknow";
        }

        public static string Draw(Rectangle rectangle)
        {
            if (rectangle == null) throw new ArgumentNullException(nameof(rectangle));

            return DrawRectangle(rectangle.Width, rectangle.Height);
        }

        public static string Draw(Square quare)
        {
            if (quare == null) throw new ArgumentNullException(nameof(quare));

            return DrawRectangle(quare.Size, quare.Size);
        }

        public static string Draw(Circle circle)
        {
            if (circle == null) throw new ArgumentNullException(nameof(circle));

            return DrawCircle(circle.Radious);
        }

        /// <summary>
        /// Logic comming from https://stackoverflow.com/questions/28413018/how-to-display-a-simple-hollow-asterisk-rectangle-in-console
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string DrawRectangle(int width, int height, int locationX = 0, char symbol = '*')
        {
            const char SPACE = ' ';
            if (width <= 0) throw new ArgumentException(nameof(width));
            if (height <= 0) throw new ArgumentException(nameof(height));

            var strBuilder = new StringBuilder();
            var space = new StringBuilder();
            var temp = new StringBuilder();
            strBuilder.AppendLine();
            strBuilder.Append(symbol);

            for (int i = 0; i < width; i++)
            {
                space.Append(SPACE);
                strBuilder.Append(symbol);
            }

            strBuilder.AppendLine($"{symbol}");

            for (int j = 0; j < locationX; j++)
                temp.Append(SPACE);


            for (int i = 0; i < width; i++)
                strBuilder.AppendLine($"{temp}{symbol}{space}{symbol}");

            strBuilder.Append($"{temp}{symbol}");

            for (int i = 0; i < width; i++)
                strBuilder.Append(symbol);

            strBuilder.AppendLine($"{symbol}");

            return strBuilder.ToString();
        }

        /// <summary>
        /// Logic comming from https://www.csharp-console-examples.com/general/draw-a-circle-in-c-console-application/.
        /// </summary>
        /// <param name="radius">Radious of the Circle</param>
        /// <param name="thickness"></param>
        /// <returns></returns>
        public static string DrawCircle(int radius, double thickness = 0.4d, char symbol = '*')
        {
            if (radius <= 0) throw new ArgumentException(nameof(radius));
            if (thickness <= 0d) throw new ArgumentException(nameof(thickness));

            double rIn = radius - thickness;
            double rOut = radius + thickness;

            var strBuilder = new StringBuilder();
            strBuilder.AppendLine();

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                        strBuilder.Append(symbol);
                    else
                        strBuilder.Append(" ");
                }
                strBuilder.AppendLine();
            }

            return strBuilder.ToString();
        }
    }
}
