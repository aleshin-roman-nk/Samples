using Core;
using DrCost2.dtoservices;
using DrCost2.HubService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.controllers
{
    public class ProductController : IBusParticipant
    {
		private readonly ParticipantsHub hub;

		public string name => "products-controller";

		public ProductController(ParticipantsHub hub)
		{
			this.hub = hub;
		}

		public void PutMessage(ParticMessage msg)
		{
			hub.Publish(new ParticMessage(from: name, to: msg.From, method: "put", "object is added"));
		}

		//[HandlerMethod("add")]
		//public DtoMessage addProduct(DtoMessage m)
		//{
		//    //var res = new List<Product>();

		//    //res.Add(new Product { price = 12, count = 123, currId = 1 });
		//    //res.Add(new Product { price = 126, count = 1236, currId = 1 });
		//    //res.Add(new Product { price = 123, count = 23, currId = 1 });
		//    //res.Add(new Product { price = 122, count = 623, currId = 1 });

		//    return new DtoMessage(name, m.from, "put", "object is added");
		//}


	}
}
