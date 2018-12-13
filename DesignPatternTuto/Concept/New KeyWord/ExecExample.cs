using DesignPatternTuto.Concept.NullObjectPattern;

namespace DesignPatternTuto.Concept.New_KeyWord
{
    public class ExecExample
    {
        public void Exec()
        {
            IPet cat1 = new DetroyerCat();

            cat1.Pee();


            DetroyerCat cat2 = new DetroyerCat();

            cat2.Pee();
        }
    }
}
