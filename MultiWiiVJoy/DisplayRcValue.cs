using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiWiiVJoy
{
    public partial class DisplayRcValue : UserControl
    {

        private int rcValue = 1000;

        public int Value
        {
            get { return rcValue; }
            set 
            { 
                rcValue = value;
                this.Invalidate();
            }
        }

        protected SolidBrush fillColor = new SolidBrush(Color.Gray);

        public DisplayRcValue()
        {
            InitializeComponent();
        }

        private void DisplayRcValue_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            int width = (int)((double)(this.ClientSize.Width / 1000D) * (double)(rcValue - 1000));

            graphics.FillRectangle(fillColor, 0, 0, width, this.ClientSize.Height);
            TextRenderer.DrawText(graphics, Convert.ToString(rcValue), this.Font, new Point(5, 0), Color.Black);

        }
    }
}
