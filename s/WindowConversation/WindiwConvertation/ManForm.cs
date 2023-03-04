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
	public partial class ManForm : Form, IManView
	{
		Action<ViewResult> _resultHandler;
		Man _ent;

		public ManForm()
		{
			InitializeComponent();
		}

		public void Go(Man m, Action<ViewResult> resultHandler)
		{
			_resultHandler = resultHandler;
			_set(m);
			Show();
		}

		void _set(Man m)
		{
			textBox1.Text = m.Name;
			_ent = m;
		}

		Man _get()
		{
			_ent.Name = textBox1.Text;
			return _ent;
		}

		private void button1ok_Click_1(object sender, EventArgs e)
		{
			_resultHandler(new ViewResult { Ok = true, Data = _get()});
			Close();
		}

		private void button2cancel_Click_1(object sender, EventArgs e)
		{
			_resultHandler(new ViewResult { Ok = false, Data = null });
			Close();
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			MessageBox.Show($"I am destroyed {_ent.Name}");
			base.OnHandleDestroyed(e);
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				_resultHandler(new ViewResult { Ok = true, Data = _get() });
				e.Handled = true;
				Close();
			}
		}
	}
}
