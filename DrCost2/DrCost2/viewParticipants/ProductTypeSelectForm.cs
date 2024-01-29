using DrCost2.HubService;
using DrCost2.ViewHubService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrCost2.viewParticipants
{
	//[BusViewPartic("product-type")]
	public partial class ProductTypeSelectForm : Form, IBusParticipant
	{
		private readonly ParticipantsHub hub;

		public string name => "product-type-view";

		public ProductTypeSelectForm(ParticipantsHub hub)
		{
			InitializeComponent();
			this.hub = hub;
		}

		private void ProductTypeSelectForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			hub.Publish(new ParticMessage(name, "product-view", "product-type-selected", new Core.entity.ProductType { name = textType.Text }));
			this.Hide();
		}

		public void PutMessage(ParticMessage msg)
		{
			this.ShowDialog();
		}
	}
}
