namespace DesignPatternTuto.Structural.Decorator
{
    public abstract class TeaDecorator : Tea
    {
        private readonly Tea tea;

        public float OptionPrice { get; private set; }

        public TeaDecorator(Tea tea, float optionPrice)
        {
            this.tea = tea;
            OptionPrice = optionPrice;
        }

        public override float Price { get { return tea.Price + OptionPrice; } }

    }
}
