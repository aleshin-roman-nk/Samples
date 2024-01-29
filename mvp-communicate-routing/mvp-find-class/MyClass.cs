using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_find_class
{
	[ViewBusPartic("viewA")]
	internal class MyClass : IViewBusParticipant
	{
		private readonly Hub h;

		public MyClass(Hub h) 
		{
			this.h = h;
			rise();
		}

		public void hide()
		{
            Console.WriteLine("viewA is hidden");
        }

		public void oper()
		{
			h.Publish(new ViewBusMessage("viewA", "viewProduct", "create", "new object"));
		}

		public void PutMessage(ViewBusMessage msg)
		{
            Console.WriteLine($"message from {msg.From}");


			if (msg.Method == "completed")
			{
				Console.WriteLine($"viewA - data from server: {msg.Data}");
            }
		}

		public void rise()
		{
            Console.WriteLine("viewA is rised");
        }
	}
}
