using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_method
{
	internal class MyClass
	{
		[NamedAttribute("MethodA")]
		public void Method1() { }

		[NamedAttribute("MethodB")]
		public void Method2() { }

		public void Method3() { }
	}
}
