using ShapeDrawer.Common.Shape;

namespace ShapeDrawer.Client.Strategy
{
    public interface IDrawer
    {
        void Draw(IShape shape);
    }
}
