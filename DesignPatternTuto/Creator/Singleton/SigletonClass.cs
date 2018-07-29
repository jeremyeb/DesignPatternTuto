namespace DesignPatternTuto.Creator.Singleton
{
    public class SigletonClass
    {
        private static SigletonClass instance;
        private static int instanceCount = 0;

        private SigletonClass()
        {
            instanceCount++;
        }

        public static SigletonClass Instance
        {
            get { return instance ?? (instance = new SigletonClass()); }
        }

        public int TestMethod()
        {
            return instanceCount;
        }
    }
}
