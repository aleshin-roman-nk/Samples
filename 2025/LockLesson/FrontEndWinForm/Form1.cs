using LockLesson;

namespace FrontEndWinForm
{
	public partial class Form1 : Form
	{
		BufferService bufferService;
		SenderService senderService;

		public Form1()
		{
			InitializeComponent();

			bufferService = new BufferService();
			senderService = new SenderService(bufferService);
			senderService.status = (x) =>
			{
				Invoke(() => labelSenderStatus.Text = x);
			};
			senderService.printOut = (x) =>
			{
				Invoke(() => textBoxProducts.Text = x);
			};
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			senderService.Start();
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			senderService.Stop();
		}

		private void textBoxInputName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBoxInputName.Text))
			{
				bufferService.Add(new LockLesson.Receipt { Name = textBoxInputName.Text });
				textBoxInputName.Text = "";
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}
	}
}
