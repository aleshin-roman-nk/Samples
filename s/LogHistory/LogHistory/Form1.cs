using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogHistory
{
	public partial class Form1 : Form
	{
		OneSession oneSession = new OneSession();

		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter && e.Control)
			{
				var v = textBox1.Text.Trim();

				oneSession.AddNote(DateTime.Now, v);

				displayLog(oneSession);

				richTextBox1.Text = oneSession.data_source;

				e.Handled = true;
				textBox1.Clear();
			}
		}

		private void displayLog(OneSession o)
		{
			webBrowser1.DocumentText = o.Html;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LogEditForm logEditForm = new LogEditForm();
			logEditForm.SetData(oneSession.Items);
			logEditForm.ShowDialog();
			displayLog(oneSession);
		}

		private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && e.Control)
			{
				oneSession.data_source = richTextBox2.Text;

				displayLog(oneSession);
			}
		}
	}
}
