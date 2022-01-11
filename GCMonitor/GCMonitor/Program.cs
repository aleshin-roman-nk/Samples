using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMonitor
{
	class Program
	{
		static void Main(string[] args)
		{
			AAA aa = new AAA();
			aa = new AAA();
			aa = new AAA();
			aa = new AAA();
			aa = new AAA();
			aa = new AAA();
			aa = new AAA();
			aa = new AAA();
			aa = new AAA();

			GC.Collect();

			Console.ReadLine();
		}
	}

	class AAA
	{
		public AAA()
		{
			Console.WriteLine("created");
		}

		~AAA()
		{
			Console.WriteLine("destroyed");
		}
	}
}
