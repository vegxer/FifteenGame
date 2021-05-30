using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLibrary
{
    public partial class Button : UserControl
    {
        StringFormat SF;

        public Button()
        {
            InitializeComponent();
        }

        private void CustomButton_Load(object sender, EventArgs e)
        {
            base.Text = "Custom Button";

            BackColor = Color.DeepSkyBlue;
            ForeColor = Color.FromArgb(255, 247, 15);

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            SF = new StringFormat();
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            Size = new Size(100, 30);
        }

        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle button = new Rectangle(0, 0, Width - 1, Height - 1);
            graph.DrawString(base.Text, Font, new SolidBrush(ForeColor), button, SF);
        }

        private void CustomButton_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.DodgerBlue;
        }

        private void CustomButton_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.DeepSkyBlue;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
    }
}
