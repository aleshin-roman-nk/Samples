using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoCFromOtherProject.Ctrls
{
	public class ClaendarX: Control
	{
        public ClaendarX()
		{
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(300, 400);

            //Font = new Font("Verdana", 8.25F, FontStyle.Regular);

            Cursor = Cursors.Hand;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics graph = e.Graphics;
			graph.SmoothingMode = SmoothingMode.HighQuality;
			graph.InterpolationMode = InterpolationMode.HighQualityBicubic;

			graph.Clear(Parent.BackColor);

			Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

			Brush headerBrush = new SolidBrush(Color.DarkCyan);

			GraphicsPath rectPath = RoundedRectangle(rect, 1);

			graph.DrawPath(new Pen(headerBrush, 4), rectPath);

			//Rectangle rect1 = new Rectangle(20, 20, 60, 60);
			//Rectangle rect1 = new Rectangle(0, 0, Width - 1, Height - 1);
			//graph.DrawRectangle(new Pen(Color.Yellow, 1), rect1);

			//Rectangle rect1 = new Rectangle(5, 5, Width - 1, Height - 1);

			drawAllDays(graph);
			graph.DrawString(Text, Font, new SolidBrush(Color.Purple), rect);

			//Text = $"{g++}";
		}

		private void drawAllDays(Graphics gr)
		{
			Brush headerBrush = new SolidBrush(Color.DarkGreen);
			Pen pen = new Pen(headerBrush, 1.6F);

			//int columnsCount = 7;
			//int rowsCount = 6;

			//Rectangle[][] rectangles = new Rectangle[6][7]();

			List<Rectangle> rectangles = new List<Rectangle>();

			int x0 = 5;
			int y0 = 5;
			int w = 30;
			int h = 40;
			

			// days of week
			for (int x = 0; x < 7; x++)
			{
				// weeks
				for (int y = 0; y < 6; y++)
				{
					//rectangles.Add(new Rectangle(x0 + x * w, y0 + y * h, w, h));
					var rec = new Rectangle(x0 + x * (w + 5), y0 + y * (h + 5), w, h);

					gr.DrawRectangle(pen, rec);
					gr.DrawString($"{7 * y + x}", Font, new SolidBrush(Color.DarkCyan), rec);
				}
			}
		}

		int g = 0;

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Text = $"{e.Location} - {g++}";
			this.Refresh();
		}

		private GraphicsPath RoundedRectangle(Rectangle rect, float RoundSize)
		{
			GraphicsPath gp = new GraphicsPath();

			gp.AddArc(rect.X, rect.Y, RoundSize, RoundSize, 180, 90);
			gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y, RoundSize, RoundSize, 270, 90);
			gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 0, 90);
			gp.AddArc(rect.X, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 90, 90);

			gp.CloseFigure();

			return gp;
		}
	}
}
