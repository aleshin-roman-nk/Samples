using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_method
{
	[AttributeUsage(AttributeTargets.Method)]
	internal class NamedAttribute : Attribute
	{
		public string Name { get; }

		public NamedAttribute(string name)
		{
			Name = name;
		}
	}
}
