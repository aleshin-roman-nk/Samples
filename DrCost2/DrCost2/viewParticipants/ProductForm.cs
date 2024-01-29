using Core.entity;
using DrCost2.dtoservices;
using DrCost2.HubService;
using DrCost2.ViewHubService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrCost2.viewParticipants
{
    //[BusViewPartic("product")]
    public partial class ProductForm : Form, IBusParticipant
	{
		private readonly ParticipantsHub hub;

		public string name => "product-view";

		public void Create(Func<Product> fnc)
		{

		}

		public ProductForm(ParticipantsHub hub)
		{
			InitializeComponent();
			this.hub = hub;
		}

		private void clear()
		{

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		// 
		private void btnCreate_Click(object sender, EventArgs e)
		{
			this.Hide();
			// answer 
			hub.Publish(from: name, to: "main-view", "product-created", $"new Product price: {numberPrice.Value}");
		}

		private void ProductView_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			hub.Publish(new ParticMessage(from: name, to: "product-type-view", method: "", data: ""));
		}

		public void PutMessage(ParticMessage msg)
		{
			if (msg.Method == "new")
			{
				this.ShowDialog();
			}
			else if (msg.Method == "product-type-selected")
			{
				var d = msg.Cast<ProductType>();

				textProductName.Text = d.name;
			}
		}
	}
}
