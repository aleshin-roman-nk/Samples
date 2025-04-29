using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices.Dto
{
	public class CreateAnimalDto
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public bool? isBird { get; set; }
	}
}
