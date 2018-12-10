using ShapeDrawer.Client.Controller;
using ShapeDrawer.Client.Strategy;
using ShapeDrawer.Common.Message;
using System;

namespace ShapeDrawer.Client
{
    public class App : IObserver<Message>
    {
        private readonly ConsoleDrawer consoleDrawer;
        private readonly FormDrawer formDrawer;
        private readonly StrategyContext strategyContext;

        public App(ShapeDrawerController controller)
        {
            consoleDrawer = new ConsoleDrawer();
            formDrawer = new FormDrawer(controller);
            strategyContext = new StrategyContext();

            ShapeReciever.Instance.Subscribe(this);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(Message value)
        {
            Logger.Logger.Instance.Info($"Message recieved Shape {value.Shape.GetType()} and DrawerType {value.UiDrawer.ToString()}");
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
