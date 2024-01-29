using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
	internal class CategoryService: IUIService
	{
		public string Name => "categories";

		[HandlerMethod("get-categories")]
		public object getAllCategoties(Message m)
		{
			return new[]
			{
				new { name = "roman", id = 1 },
				new { name = "natasha", id = 2 },
			};
		}
	}
}
