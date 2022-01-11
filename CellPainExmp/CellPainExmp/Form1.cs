using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellPainExmp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			catBindingSource.DataSource = Cat.GetList();
		}

		decimal getProgress(int v_curr, int v_100, int fullLenght)
		{
			return (decimal)v_curr / (decimal)v_100 * fullLenght;
		}

		private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex >= 0 && dataGridView1.Columns["ageDataGridViewTextBoxColumn"].Index == e.ColumnIndex)
			{
				Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
					e.CellBounds.Y + 1, e.CellBounds.Width - 4,
					e.CellBounds.Height - 4);


				var vall = (dataGridView1.Rows[e.RowIndex].DataBoundItem as Cat).Age;

				int width = Convert.ToInt32(getProgress(vall, 14, e.CellBounds.Width - 10));

				Rectangle timeRect = new Rectangle(
						e.CellBounds.X + 4, e.CellBounds.Y + e.CellBounds.Height - 11,
						e.CellBounds.Width - 10, 6
					);

				Rectangle timeRectVal = new Rectangle(
					e.CellBounds.X + 4 + 1, e.CellBounds.Y + e.CellBounds.Height - 11 + 1,
					width, 6 - 1);

				using (
					Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
					backColorBrush = new SolidBrush(e.CellStyle.BackColor))
				{
					using (Pen gridLinePen = new Pen(gridBrush))
					{
						e.PaintBackground(newRect, true);
						//Erase the cell.
						//e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
						e.Graphics.DrawRectangle(Pens.Aqua, timeRect);
						e.Graphics.FillRectangle(Brushes.Red, timeRectVal);

						//Draw the grid lines(only the right and bottom lines;
						//DataGridView takes care of the others).

						//e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
						//	e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
						//	e.CellBounds.Bottom - 1);

						//e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
						//	e.CellBounds.Top, e.CellBounds.Right - 1,
						//	e.CellBounds.Bottom);

						//	Draw the inset highlight box.
						//e.Graphics.DrawRectangle(Pens.White, newRect);



						//	Draw the text content of the cell, ignoring alignment.

						if (e.Value != null)
						{
							//e.PaintContent(newRect);

							

							e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
								Brushes.Yellow, e.CellBounds.X + e.CellBounds.Width - 30,
								e.CellBounds.Y + 2, StringFormat.GenericDefault);
						}

						
						e.Handled = true;
					}
				}
			}
		}
	}
}
