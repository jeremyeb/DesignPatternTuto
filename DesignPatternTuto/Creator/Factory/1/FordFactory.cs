using DesignPatternTuto.Behavioral.Strategy;

namespace DesignPatternTuto.Creator.Factory._1
{
    public class FordFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new FordFocus(new MotorV6());
        }
    }
}
