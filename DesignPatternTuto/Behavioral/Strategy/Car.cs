namespace DesignPatternTuto.Behavioral.Strategy
{
    public class Car
    {
        protected readonly IMotor motor;

        public Car(IMotor motor)
        {
        }

        public void Start()
        {
            motor.Start();
        }
    }
}
