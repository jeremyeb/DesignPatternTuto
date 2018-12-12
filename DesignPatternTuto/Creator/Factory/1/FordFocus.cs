using DesignPatternTuto.Behavioral.Strategy;

namespace DesignPatternTuto.Creator.Factory._1
{
    internal class FordFocus : Car, ICar
    {
        public FordFocus(IMotor motor) : base(motor)
        {
        }
    }
}