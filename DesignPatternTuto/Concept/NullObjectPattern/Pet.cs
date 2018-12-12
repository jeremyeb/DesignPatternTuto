namespace DesignPatternTuto.Concept.NullObjectPattern
{
    public abstract class PetBase : IPet
    {
        public static readonly IPet Empty = new PetToy();

        public abstract void Pee();

        public static bool IsNullOrEmpty(IPet pet)
        {
            return pet == null || pet == Empty || pet is PetToy;
        }
    }
}
