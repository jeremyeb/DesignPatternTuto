using DesignPatternTuto.Behavioral.Strategy;

namespace DesignPatternTuto.Creator.Factory._2
{
    internal class AudiA6 : Car, ICar
    {
        public AudiA6(IMotor motor) : base(motor)
        {
        }
    }
}