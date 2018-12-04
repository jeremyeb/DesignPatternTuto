using ShapeDrawer.Server.Logger;

namespace ShapeDrawer.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            using(var el = new ShapeSender(new ShadeRandomSelector(),logger))
            {
                el.Start(1111);
            }
        }
    }
}
