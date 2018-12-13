using ShapeDrawer.Client.Logger;
using ShapeDrawer.Client.Strategy;
using ShapeDrawer.Common.Message;
using System;

namespace ShapeDrawer.Client
{
    public class App : IObserver<Message>
    {
        private readonly IConsoleDrawer consoleDrawer;
        private readonly IFormDrawer formDrawer;
        private readonly StrategyContext strategyContext;
        private readonly ILogger logger;


        //We cannot unit test if the correct Drawer is use
        //public App(IShapeReciever shapeReciever, ShapeDrawerController controller)
        //{
        //    if (shapeReciever == null) throw new ArgumentNullException(nameof(shapeReciever));

        //    consoleDrawer = new ConsoleDrawer();
        //    formDrawer = new FormDrawer(controller);
        //    strategyContext = new StrategyContext();

        //    shapeReciever.Subscribe(this);
        //}


        public App(IConsoleDrawer consoleDrawer
            , IFormDrawer formDrawer
            , StrategyContext strategyContext
            , ILogger logger)
        {
            this.consoleDrawer = consoleDrawer ?? throw new ArgumentNullException(nameof(consoleDrawer));
            this.formDrawer = formDrawer ?? throw new ArgumentNullException(nameof(formDrawer));
            this.strategyContext = strategyContext ?? throw new ArgumentNullException(nameof(strategyContext));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(Message value)
        {
           logger.Info($"Message recieved Shape {value.Shape.GetType()} and DrawerType {value.UiDrawer.ToString()}");
            switch (value.UiDrawer)
            {
                case EnumUiDrawer.Console:
                    strategyContext.SetDrawer(consoleDrawer);
                    break;
                case EnumUiDrawer.Form:
                    strategyContext.SetDrawer(formDrawer);
                    break;
            }

            strategyContext.Draw(value.Shape);
        }
    }
}
