using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorDetectionMouseMove
{
    public class RadiusVisualizerForm : Form
    {
        private int radius;
        private Point center;

        public RadiusVisualizerForm(int initialRadius)
        {
            this.radius = initialRadius;
            this.center = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.TopMost = true;
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime; // Make the form transparent
            this.ShowInTaskbar = false;
        }

        public void UpdateRadius(int newRadius)
        {
            this.radius = newRadius;
            this.Invalidate(); // Redraw the form to update the circle
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                Pen pen = new Pen(Color.Blue, 1);
                g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                pen.Dispose();
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
    }
}
