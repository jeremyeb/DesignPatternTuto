using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ShapeDrawer.Client.Logger;
using ShapeDrawer.Client.Strategy;
using ShapeDrawer.Common.Message;
using ShapeDrawer.Common.Shape;
using Unity;

namespace ShapeDrawer.Client.Tests
{
    [TestClass]
    public class AppTests
    {
        private IUnityContainer uc;

        [TestInitialize]
        public void Init()
        {
            var uc = new UnityContainer();
        }
       
        [TestMethod]
        public void WhenAppRecieveAConsoleMessageThenTheConsoleDrawerShouldBeUse()
        {
            //Prepare
            var fakelogger = Substitute.For<ILogger>();
            uc.RegisterInstance(fakelogger);

            var fakeConsoleDrawer = Substitute.For<IConsoleDrawer>();
            uc.RegisterInstance(fakeConsoleDrawer);

            var fakeFormDrawer = Substitute.For<IFormDrawer>();
            uc.RegisterInstance(fakeFormDrawer);



            var app = uc.Resolve<App>();

            //Act
            var square = new Square { Size = 6 };
            app.OnNext(new Message(square, EnumUiDrawer.Console));

            //Assert
            fakeConsoleDrawer.Received(1).Draw(Arg.Is<IShape>(square));

        }
    }
}
