using System;

namespace DesignPatternTuto.Concept.NullObjectPattern
{
    public class Dog : PetBase
    {
        public override void Pee()
        {
            Console.WriteLine("Pee only when you allow me to");
        }
    }
}
