namespace DesignPatternTuto.Structural.Decorator
{
    public class ExecExample
    {
        public void Exec()
        {
            Tea greanTea = new GreenTea();
            greanTea = new TeaCream(greanTea);
            greanTea = new TeaMilk(greanTea);

            var test1 = greanTea.Price;
        }
    }
}
