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
	public partial class ObjForm : Form, IEntityInstanceWindow
	{
		private readonly Obj _obj;
		private bool _closed = false;

		private ObjForm()
		{
			InitializeComponent();
		}

		public ObjForm(Obj o)
		{
			InitializeComponent();

			_obj = o;
			_set(_obj);
		}

		void _set(Obj o)
		{
			textBox1.Text = o.data;
		}

		Obj _get()
		{
			_obj.data = textBox1.Text;
			return _obj;
		}

		public int ObjId => _obj.id;

		public event EventHandler<ViewResponce<Obj>> Completed;

		public void Restore()
		{
			Show();
			WindowState = FormWindowState.Normal;
			Focus();
		}

		void OnCompleted()
		{
			if(DialogResult == DialogResult.OK)
			{
				Completed?.Invoke(this, new ViewResponce<Obj> { Data = _get(), Ok = true });
			}
			else
			{
				Completed?.Invoke(this, new ViewResponce<Obj> { Ok = false });
			}

			_closed = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult= DialogResult.Cancel;
			Close();
		}

		private void ObjForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			OnCompleted();
		}

		private void btnHide_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
