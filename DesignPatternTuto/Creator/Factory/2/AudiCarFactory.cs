using DesignPatternTuto.Behavioral.Strategy;
using DesignPatternTuto.Creator.Factory._1;

namespace DesignPatternTuto.Creator.Factory._2
{
    public static class AudiCarFactory
    {
        public static ICar CreateA4()
        {
            return new AudiA4(new MotorV6());
        }

        public static ICar CreateA6()
        {
            return new AudiA6(new MotorV8());
        }
    }
}
