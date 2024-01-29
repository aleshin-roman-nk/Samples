using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_find_class
{
	[ViewBusPartic("viewProduct")]
	internal class ProductController: IViewBusParticipant
	{
		private readonly Hub h;

		public ProductController(Hub h)
		{
			this.h = h;
		}

		public void hide()
		{
            Console.WriteLine("viewProduct is hidden");
        }

		public void oper()
		{
			throw new NotImplementedException();
		}

		public void PutMessage(ViewBusMessage msg)
		{
			rise();

			Console.WriteLine($"ProductController.PutMessage: processing data from {msg.From}");

            Console.WriteLine($"ProductController.PutMessage: method is {msg.Method}");

            h.Publish(new ViewBusMessage(msg.To, msg.From, "completed", "new data from db"));
			hide();
        }

		public void rise()
		{
			Console.WriteLine("viewProduct is rised");
		}
	}
}
