namespace DesignPatternTuto.Behavioral.Strategy
{
    public partial class Car
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
