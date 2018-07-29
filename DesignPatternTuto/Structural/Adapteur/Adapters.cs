namespace DesignPatternTuto.Structural.Adapteur
{
    public class Adapters : IAdapters
    {
        private readonly RealClass realClass;

        public Adapters()
        {
            realClass = new RealClass();
        }

        public void TargetMethod()
        {
            realClass.RealMethod();
        }
    }
}
