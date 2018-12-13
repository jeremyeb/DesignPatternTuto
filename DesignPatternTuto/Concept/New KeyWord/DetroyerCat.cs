using DesignPatternTuto.Concept.NullObjectPattern;
using System;

namespace DesignPatternTuto.Concept.New_KeyWord
{
    public class DetroyerCat : Cat
    {
        public new void Pee()
        {
            //Using of the new Key Word
            Console.WriteLine("Pee on your pillow. Because you did not feed me");
        }
    }
}
