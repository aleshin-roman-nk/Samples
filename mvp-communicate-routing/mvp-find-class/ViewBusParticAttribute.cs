using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_find_class
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class ViewBusParticAttribute: Attribute
	{
		public string name { get; }
		public ViewBusParticAttribute(string name)
		{
			this.name = name;
		}
	}
}
