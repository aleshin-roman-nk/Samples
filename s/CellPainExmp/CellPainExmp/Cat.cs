using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPainExmp
{
	public class Cat
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public static IEnumerable<Cat> GetList()
		{
			return new List<Cat>
			{
				new Cat{Name = "Murzik", Age = 5},
				new Cat{Name = "Shpula", Age = 7},
				new Cat{Name = "Kotia", Age = 3}
			};
		}
	}
}
