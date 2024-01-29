using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
	internal class ProductService: IUIService
	{
		ServicesHub _hub;
		public ProductService(ServicesHub h) 
		{ 
			_hub = h;
		}

		public string Name => "service-db";

		[HandlerMethod("someCommand")]
		public object some_command(Message m)
		{
			Console.WriteLine("some_command works");
			return "processed data";
		}

		[HandlerMethod("add-product")]
		public object addProduct(Message m)
		{
			Console.WriteLine("add-product works");
			return new { name = "Roman", age = 44 };
		}
	}
}
