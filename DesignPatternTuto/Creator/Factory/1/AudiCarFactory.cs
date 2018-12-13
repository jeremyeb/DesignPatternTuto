using DesignPatternTuto.Behavioral.Strategy;

namespace DesignPatternTuto.Creator.Factory._1
{
    public class AudiCarFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new AudiA4(new MotorV6());
        }
    }
}
