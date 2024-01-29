using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_dictionary
{
	internal class SampleClass
	{
		[My("Method1Name")]
		public void Method1() { Console.WriteLine("execute Method1"); }

		[My("Method2Name")]
		public void Method2() { Console.WriteLine("execute Method2"); }

		public void MethodWithoutAttribute() { }
	}
}
