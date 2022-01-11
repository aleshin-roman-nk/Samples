using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogHistory
{
	public partial class LogEditForm : Form
	{
		public LogEditForm()
		{
			InitializeComponent();

			noteRecBindingSource.CurrentItemChanged += NoteRecBindingSource_CurrentItemChanged;
		}

		private void NoteRecBindingSource_CurrentItemChanged(object sender, EventArgs e)
		{
			richTextBox1.Text = (noteRecBindingSource.Current as NoteRec).Text;
		}

		private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.Enter)
			{
				(noteRecBindingSource.Current as NoteRec).Text = richTextBox1.Text;

				e.Handled = true;
			}
		}

		public void SetData(IEnumerable<NoteRec> notes)
		{
			noteRecBindingSource.DataSource = null;
			noteRecBindingSource.DataSource = notes;
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
