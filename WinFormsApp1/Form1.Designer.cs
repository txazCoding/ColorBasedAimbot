namespace ColorDetectionMouseMove
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnColor1 = new Button();
            btnColor2 = new Button();
            btnColor3 = new Button();
            lblSelectedColor = new Label();
            trackBarRadius = new TrackBar();
            lblRadiusValue = new Label();
            btnStart = new Button();
            btnStop = new Button();
            lblStatus = new Label();
            trackBarTolerance = new TrackBar();
            lblToleranceValue = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTolerance).BeginInit();
            SuspendLayout();
            // 
            // btnColor1
            // 
            btnColor1.Location = new Point(12, 12);
            btnColor1.Name = "btnColor1";
            btnColor1.Size = new Size(75, 23);
            btnColor1.TabIndex = 0;
            btnColor1.Text = "Red";
            btnColor1.UseVisualStyleBackColor = true;
            btnColor1.Click += btnColor1_Click;
            // 
            // btnColor2
            // 
            btnColor2.Location = new Point(93, 12);
            btnColor2.Name = "btnColor2";
            btnColor2.Size = new Size(75, 23);
            btnColor2.TabIndex = 1;
            btnColor2.Text = "Green";
            btnColor2.UseVisualStyleBackColor = true;
            btnColor2.Click += btnColor2_Click;
            // 
            // btnColor3
            // 
            btnColor3.Location = new Point(174, 12);
            btnColor3.Name = "btnColor3";
            btnColor3.Size = new Size(75, 23);
            btnColor3.TabIndex = 2;
            btnColor3.Text = "Blue";
            btnColor3.UseVisualStyleBackColor = true;
            btnColor3.Click += btnColor3_Click;
            // 
            // lblSelectedColor
            // 
            lblSelectedColor.BorderStyle = BorderStyle.FixedSingle;
            lblSelectedColor.Location = new Point(12, 48);
            lblSelectedColor.Name = "lblSelectedColor";
            lblSelectedColor.Size = new Size(237, 23);
            lblSelectedColor.TabIndex = 3;
            // 
            // trackBarRadius
            // 
            trackBarRadius.Location = new Point(12, 90);
            trackBarRadius.Maximum = 200;
            trackBarRadius.Minimum = 2;
            trackBarRadius.Name = "trackBarRadius";
            trackBarRadius.Size = new Size(237, 45);
            trackBarRadius.TabIndex = 4;
            trackBarRadius.Value = 50;
            trackBarRadius.Scroll += trackBarRadius_Scroll;
            // 
            // lblRadiusValue
            // 
            lblRadiusValue.Location = new Point(12, 134);
            lblRadiusValue.Name = "lblRadiusValue";
            lblRadiusValue.Size = new Size(237, 23);
            lblRadiusValue.TabIndex = 5;
            lblRadiusValue.Text = "Radius: 50";
            lblRadiusValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 174);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 23);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start Detection";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(137, 174);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(112, 23);
            btnStop.TabIndex = 7;
            btnStop.Text = "Stop Detection";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(12, 211);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(237, 23);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status: Stopped";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBarTolerance
            // 
            trackBarTolerance.Location = new Point(12, 123);
            trackBarTolerance.Name = "trackBarTolerance";
            trackBarTolerance.Size = new Size(75, 45);
            trackBarTolerance.TabIndex = 9;
            // 
            // lblToleranceValue
            // 
            lblToleranceValue.AutoSize = true;
            lblToleranceValue.Location = new Point(30, 153);
            lblToleranceValue.Name = "lblToleranceValue";
            lblToleranceValue.Size = new Size(38, 15);
            lblToleranceValue.TabIndex = 10;
            lblToleranceValue.Text = "label1";
            // 
            // Form1
            // 
            ClientSize = new Size(264, 251);
            Controls.Add(lblToleranceValue);
            Controls.Add(trackBarTolerance);
            Controls.Add(lblStatus);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblRadiusValue);
            Controls.Add(trackBarRadius);
            Controls.Add(lblSelectedColor);
            Controls.Add(btnColor3);
            Controls.Add(btnColor2);
            Controls.Add(btnColor1);
            Name = "Form1";
            Text = "Color Detection";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarRadius).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTolerance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Button btnColor3;
        private System.Windows.Forms.Label lblSelectedColor;
        private System.Windows.Forms.TrackBar trackBarRadius;
        private System.Windows.Forms.Label lblRadiusValue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private TrackBar trackBarTolerance;
        private Label lblToleranceValue;
    }
}
