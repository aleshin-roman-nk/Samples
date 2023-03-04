using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Examples
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Thing> things = new List<Thing> 
			{ 
				new Thing{ data = 1, name = new DateTime(2022, 12, 1)},
				new Thing{ data = 1, name = new DateTime(2022, 12, 1)},
				new Thing{ data = 1, name = new DateTime(2022, 12, 1)},
				new Thing{ data = 1, name = new DateTime(2022, 12, 4)},
				new Thing{ data = 1, name = new DateTime(2022, 12, 4)},
				new Thing{ data = 1, name = new DateTime(2022, 12, 6)},
				new Thing{ data = 1, name = new DateTime(2022, 12, 6)}
			};

			var lll = things.GroupBy(x => x.name.Day).Select(cc => new { k = cc.Key, dd = cc.First().name, sum = cc.Sum(xx => xx.data) });

			//var lll1 = things.GroupBy(x => x.name.Day);



			//foreach (var r in lll1)
			//{
				
			//}

            foreach (var item in lll)
			{
				Console.WriteLine($"{item.k} - {item.dd} - {item.sum}");

				//foreach (var item111 in item.)
				//{
				//	Console.WriteLine($"{item111.name} - {item111.data}");
				//}
			}

			Console.ReadLine();
		}
	}


	class Thing
	{
		public DateTime name { get; set; }
		public int data { get; set; }
	}
}