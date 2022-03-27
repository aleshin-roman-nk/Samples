using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingRectangles
{
    internal class CirclePlan : Control
    {
        public CirclePlan()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.UserPaint, true);
            DoubleBuffered = true;


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Graphics graph = e.Graphics;

            int center_x = Width / 2;
            int center_y = Height / 2;

            int d = 260;
            int dCenter = 20;

            Rectangle rect = new Rectangle(center_x - d / 2, center_y - d / 2, d, d);
           

            graph.FillPie(Brushes.Black, rect, 0, 30);

            graph.DrawEllipse(Pens.Black, center_x - dCenter / 2, center_y - dCenter / 2, dCenter, dCenter);
        }
    }
}
