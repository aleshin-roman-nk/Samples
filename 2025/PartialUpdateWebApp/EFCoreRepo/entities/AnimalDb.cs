using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRepo.entities
{
	public class AnimalDb
	{
		public int id {  get; set; }
		public string? name { get; set; }
		public string? description { get; set; }
		public int? age { get; set; }
		public bool? isFlying { get; set; }
	}
}
