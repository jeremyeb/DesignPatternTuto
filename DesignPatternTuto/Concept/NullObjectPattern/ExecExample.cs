using System.Collections.Generic;
using System.Linq;

namespace DesignPatternTuto.Concept.NullObjectPattern
{
    public class ExecExample
    {
        private readonly List<IPet> listOfPet = new List<IPet>();

        public void Exec()
        {
            IPet pet1 = FindPet_1();
            //Avoiding the NullPointer Exception
            //pet1 is null

            IPet pet2 = FindPet_2();
            //Pet2 is a Empty object

        }

        private IPet FindPet_1()
        {
            return listOfPet.FirstOrDefault();
        }

        private IPet FindPet_2()
        {
            return listOfPet.FirstOrDefault() ?? PetBase.Empty;
        }

        /// <summary>
        /// Example with an Actual DotNet type
        /// </summary>
        /// <param name="mySubject"></param>
        /// <returns></returns>
        private string TestString(string mySubject)
        {
            return string.IsNullOrEmpty(mySubject) ? string.Empty : mySubject;
        }
    }
}
