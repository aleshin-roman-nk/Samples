using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtoMultiObjectEdit
{
	public partial class Form1 : Form, IMainView
	{

		BindingSource bs = new BindingSource();

		int _openedWindowsCount = 0;
		public int OpenWindowCount
		{
			get
			{
				return _openedWindowsCount;
			}
			set
			{
				_openedWindowsCount = value;
				lblOpenedWindiwsCount.Text = _openedWindowsCount.ToString();
			}
		}

		public Form1()
		{
			InitializeComponent();

			dataGridView1.DataSource = bs;
		}

		public event EventHandler<Obj> OpenDoc;

		public void Display(IEnumerable<Obj> objs)
		{
			bs.DataSource = objs;
			bs.ResetBindings(true);
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				OnOpenObj(bs.Current as Obj);
				e.Handled = true;
			}
		}

		protected void OnOpenObj(Obj obj)
		{
			OpenDoc?.Invoke(this, obj);
		}
	}
}
