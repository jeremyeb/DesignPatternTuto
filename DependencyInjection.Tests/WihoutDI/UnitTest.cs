using DependencyInjection.WihtDI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace DependencyInjection.Tests.WihoutDI
{
    [TestClass]
    public class UnitTest
    {


        [TestMethod]
        public void TestMethod1()
        {

            var unityContainer = new UnityContainer();

            var fakeEmailProvider = NSubstitute.Substitute.For<IEmailProvider>();
            unityContainer.RegisterInstance<IEmailProvider>(fakeEmailProvider);

            var myApp = unityContainer.Resolve<UserInterface1>();

            //TODO
        }
    }
}
