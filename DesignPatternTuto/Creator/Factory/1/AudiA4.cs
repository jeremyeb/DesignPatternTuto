using DesignPatternTuto.Behavioral.Strategy;

namespace DesignPatternTuto.Creator.Factory._1
{
    internal class AudiA4 : Car, ICar
    {
        public AudiA4(IMotor motor) : base(motor)
        {
        }
    }
}