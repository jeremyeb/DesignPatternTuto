using System;

namespace DesignPatternTuto.Concept.NullObjectPattern
{
    public class Cat : PetBase
    {
        public override void Pee()
        {
            Console.WriteLine("Pee on the floor, Because I wanted to");
        }
    }
}
