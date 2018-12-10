using ShapeDrawer.Client.Controller;
using ShapeDrawer.Client.Utils;
using System;
using System.Windows.Forms;

namespace ShapeDrawer.Client.Forms
{
    public partial class ShapeDrawer : Form
    {
        private readonly ShapeDrawerController controller;

        public ShapeDrawer(ShapeDrawerController controller)
        {
            this.controller = controller ?? throw new ArgumentNullException(nameof(controller));

            InitializeComponent();
        }

        private void ShapeDrawer_Load(object sender, EventArgs e)
        {
            controller.OnDraw += Controller_OnDraw;
        }

        private void Controller_OnDraw(object sender, ShapeEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => Controller_OnDraw(sender, e)));
                return;
            }
            var graphic = CreateGraphics();
            graphic.Clear(BackColor);
            graphic.Draw(e.Shape);
        }
    }
}
