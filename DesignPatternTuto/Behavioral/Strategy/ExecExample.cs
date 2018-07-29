namespace DesignPatternTuto.Behavioral.Strategy
{
    public class ExecExample
    {
        public void Exec()
        {
            var motorv6 = new MotorV6();
            var motorv8 = new MotorV8();
            var car = new Car(motorv6);

            car.Start();
        }
    }
}
