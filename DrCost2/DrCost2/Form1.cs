

using DrCost2.dtoservices;
using DrCost2.HubService;
using DrCost2.ViewHubService;

namespace DrCost2
{
    public partial class Form1 : Form, IBusParticipant
	{
		private readonly ParticipantsHub hub;

		public Form1(ParticipantsHub hub)
		{
			InitializeComponent();
			this.hub = hub;
		}

		public string name => "main-view";

		public void PutMessage(ParticMessage msg)
		{
			Text = msg.Data.ToString();
		}

		private void createProduct_Click(object sender, EventArgs e)
		{
			hub.Publish(new ParticMessage(name, "product-view", "new", "000"));
		}
	}
}