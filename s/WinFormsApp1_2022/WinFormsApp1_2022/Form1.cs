using Newtonsoft.Json;

namespace WinFormsApp1_2022
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(JsonConvert.SerializeObject(new Class1 { id = 200, Name = "Roman"}, Formatting.Indented));
		}
	}
}