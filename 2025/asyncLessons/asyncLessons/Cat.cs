using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asyncLessons
{
	internal class Cat
	{

		public async Task Say()
		{
			Console.WriteLine($"start threadID : {Thread.CurrentThread.ManagedThreadId}");

			var r = await Task.Run(HeahyCalc);

			Console.WriteLine($"r : {r}");

			Console.WriteLine($"end threadID : {Thread.CurrentThread.ManagedThreadId}");

			float HeahyCalc()
			{
				var res = 0.1f;

				Console.WriteLine($"HeahyCalc threadID : {Thread.CurrentThread.ManagedThreadId}");

				for (int i = 0; i < 1000000; i++)
				{
					res += i * 0.1f;
				}

				return res;
			}
		}
	}
}
