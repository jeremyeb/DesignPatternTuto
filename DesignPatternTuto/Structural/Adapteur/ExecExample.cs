namespace DesignPatternTuto.Structural.Adapteur
{
    public class ExecExample
    {
        public void Exec()
        {
            IAdapters adapters = new Adapters();
            adapters.TargetMethod();
        }
    }
}
