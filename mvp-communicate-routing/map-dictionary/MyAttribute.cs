using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace map_dictionary
{
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	internal class MyAttribute: Attribute
	{
		public MyAttribute(string name)
		{
			Name = name;
		}

		public string Name { get; }
	}
}
