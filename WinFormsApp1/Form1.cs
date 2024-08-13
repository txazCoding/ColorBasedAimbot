using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorDetectionMouseMove
{
    public partial class Form1 : Form
    {
        private const int RIM_TYPEMOUSE = 0;
        private const int RID_INPUT = 0x10000003;

        struct RAWINPUTHEADER
        {
            public int dwType;
            public int dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWMOUSE
        {
            public ushort usFlags;
            public uint ulButtons;
            public ushort usButtonFlags;
            public ushort usButtonData;
            public uint ulRawButtons;
            public int lLastX;
            public int lLastY;
            public uint ulExtraInformation;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct RAWINPUT
        {
            [FieldOffset(0)]
            public RAWINPUTHEADER header;
            [FieldOffset(16)]
            public RAWMOUSE mouse;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUTDEVICE
        {
            public ushort usUsagePage;
            public ushort usUsage;
            public int dwFlags;
            public IntPtr hwndTarget;
        }

        private int colorTolerance = 88; // Default sensitivity

        private Color selectedColor = Color.Red; // Default color
        private int detectionRadius = 50;
        private bool isRunning = false;
        private System.Windows.Forms.Timer timer;
        private RadiusVisualizerForm radiusVisualizer;

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblSelectedColor.BackColor = selectedColor;

            // Initialize the timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1; // Set interval to 1 millisecond for near-instant detection
            timer.Tick += Timer_Tick;

            // Initialize the radius visualizer form
            radiusVisualizer = new RadiusVisualizerForm(detectionRadius);
            radiusVisualizer.Show();
        }

        private void btnColor1_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Red;
            lblSelectedColor.BackColor = selectedColor;
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Yellow;
            lblSelectedColor.BackColor = selectedColor;
        }

        private void btnColor3_Click(object sender, EventArgs e)
        {
            selectedColor = Color.Purple;
            lblSelectedColor.BackColor = selectedColor;
        }

        private void trackBarRadius_Scroll(object sender, EventArgs e)
        {
            detectionRadius = trackBarRadius.Value;
            lblRadiusValue.Text = "Radius: " + detectionRadius;
            radiusVisualizer.UpdateRadius(detectionRadius); // Update the visualizer
        }

        private void trackBarTolerance_Scroll(object sender, EventArgs e)
        {
            colorTolerance = trackBarTolerance.Value;
            lblToleranceValue.Text = "Tolerance: " + colorTolerance;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isRunning = true;
            lblStatus.Text = "Status: Detecting...";
            timer.Start(); // Start the timer
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isRunning = false;
            lblStatus.Text = "Status: Stopped";
            timer.Stop(); // Stop the timer
        }

      private void Timer_Tick(object sender, EventArgs e)
{
    if (!isRunning)
        return;

    Point screenCenter = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
    using (Bitmap bmpScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
    {
        using (Graphics g = Graphics.FromImage(bmpScreen))
        {
            g.CopyFromScreen(Point.Empty, Point.Empty, bmpScreen.Size);
        }

        Point? targetPoint = null;

        for (int x = screenCenter.X - detectionRadius; x < screenCenter.X + detectionRadius; x++)
        {
            for (int y = screenCenter.Y - detectionRadius; y < screenCenter.Y + detectionRadius; y++)
            {
                if (IsWithinCircle(screenCenter, new Point(x, y), detectionRadius) &&
                    IsColorMatch(bmpScreen.GetPixel(x, y), selectedColor))
                {
                    targetPoint = new Point(x, y);
                    break;
                }
            }
            if (targetPoint.HasValue) break;
        }

        if (targetPoint.HasValue)
        {
            int deltaX = targetPoint.Value.X - screenCenter.X;
            int deltaY = targetPoint.Value.Y - screenCenter.Y;

            // Move the cursor proportionally to the detected target's position
            int moveX = screenCenter.X + deltaX;
            int moveY = screenCenter.Y + deltaY;

            SetCursorPos(moveX, moveY);
        }
    }
}


        private bool IsColorMatch(Color pixelColor, Color targetColor)
        {
            return Math.Abs(pixelColor.R - targetColor.R) <= colorTolerance &&
                   Math.Abs(pixelColor.G - targetColor.G) <= colorTolerance &&
                   Math.Abs(pixelColor.B - targetColor.B) <= colorTolerance;
        }

        private bool IsWithinCircle(Point center, Point point, int radius)
        {
            int dx = point.X - center.X;
            int dy = point.Y - center.Y;
            return (dx * dx + dy * dy) <= (radius * radius);
        }
    }
}
