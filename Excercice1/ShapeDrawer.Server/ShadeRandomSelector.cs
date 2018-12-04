using ShapeDrawer.Common.Message;
using ShapeDrawer.Common.Shape;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShapeDrawer.Server
{
    public class ShadeRandomSelector
    {
        private readonly ManualResetEvent manualResetEvent;
        public bool IsStated { get; private set; }

        public event EventHandler<ShapeSeletedEventArgs> OnShadeSelected;

        public ShadeRandomSelector()
        {
            manualResetEvent = new ManualResetEvent(false);
            IsStated = false;
        }

        public void Start()
        {
            if (IsStated) return;
            IsStated = true;
            manualResetEvent.Reset();
            Task.Factory.StartNew(Run);
        }

        private void Run()
        {
            var random = new Random();
            var uiDrawerCounter = 1;
            var uiDrawer = EnumUiDrawer.Console;
            while (IsStated)
            {
                var newShape = RandomShape(random);
                if(--uiDrawerCounter <= 0)
                {
                    var posibleValue = (EnumUiDrawer[])Enum.GetValues(typeof(EnumUiDrawer));
                    uiDrawer = posibleValue.First( e => e != uiDrawer);
                    uiDrawerCounter = random.Next(2, 6);
                }
                OnShadeSelected?.Invoke(this, new ShapeSeletedEventArgs(newShape, uiDrawer));
                manualResetEvent.WaitOne(1000);
            }
        }

        private IShape RandomShape(Random random)
        {
            const int MAX = 3;
            switch (random.Next(0, MAX))
            {
                case 0:
                    return new Rectangle { Width = random.Next(1, 10), Height = random.Next(1, 10) };
                case 1:
                    return new Circle { Radious = random.Next(1, 6) };
                default:
                    return new Square { Size = random.Next(1, 10) };
            }
        }

        public void Stop()
        {
            IsStated = false;
            manualResetEvent.Set();
        }
    }
}
