using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNA.Service
{
	public class DNode
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string DNA { get; set; }
		public int parentId { get; set; }
	}
}
