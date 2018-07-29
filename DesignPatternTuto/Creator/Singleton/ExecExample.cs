namespace DesignPatternTuto.Creator.Singleton
{
    public class ExecExample
    {
        public void Exec()
        {
            var test1 = SigletonClass.Instance.TestMethod();
            var test2 = SigletonClass.Instance.TestMethod();
        }
    }
}
