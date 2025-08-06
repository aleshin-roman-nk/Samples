using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesCore.Entities
{
	public class UpdateAnimalDto
	{
		public string? name { get; set; }
		public string? description { get; set; }
		public int? age { get; set; }
		public bool? isFlying { get; set; }
	}
}
