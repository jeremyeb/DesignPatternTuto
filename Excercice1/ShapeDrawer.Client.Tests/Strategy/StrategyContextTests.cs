using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ShapeDrawer.Client.Logger;
using ShapeDrawer.Client.Strategy;
using ShapeDrawer.Common.Message;
using ShapeDrawer.Common.Shape;
using Unity;

namespace ShapeDrawer.Client.Tests.Strategy
{
    [TestClass]
    public class StrategyContextTests
    {
        private IUnityContainer uc;

        [TestInitialize]
        public void Init()
        {
            var uc = new UnityContainer();
        }
       
        [TestMethod]
        public void WhenTryingToDrawWithNoDrawerThanAErroMessageShouldBeLogged()
        {
            //Prepare
            var fakelogger = Substitute.For<ILogger>();
            uc.RegisterInstance(fakelogger);


            var strategyContext = uc.Resolve<StrategyContext>();

            //Act
            var square = new Square { Size = 6 };
            strategyContext.Draw(square);

            //Assert
            fakelogger.Received(1).Error(Arg.Is<string>("Cannot Draw since the drawer is null"));

        }
    }
}
