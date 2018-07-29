namespace DesignPatternTuto.Structural.Decorator
{
    public class TeaCream : TeaDecorator
    {
        public TeaCream(Tea tea) : base(tea, 1.0f)
        {
        }
    }
}
