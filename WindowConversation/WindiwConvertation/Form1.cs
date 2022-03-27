using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindiwConvertation
{
	public partial class Form1 : Form, IMainView
	{
		BindingSource bs = new BindingSource();

		public Form1()
		{
			InitializeComponent();

			dataGridView1.DataSource = bs;
		}

		public event EventHandler<Man> StartEdit;

		public void DisplayMen(IEnumerable<Man> men)
		{
			bs.DataSource = men;
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				StartEdit?.Invoke(this, bs.Current as Man);
				e.Handled = true;
			}
		}
	}
}
