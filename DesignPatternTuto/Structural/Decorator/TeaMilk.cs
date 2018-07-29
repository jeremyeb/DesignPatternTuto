namespace DesignPatternTuto.Structural.Decorator
{
    public class TeaMilk : TeaDecorator
    {
        public TeaMilk(Tea tea) : base(tea, 0.5f)
        {
        }
    }
}
