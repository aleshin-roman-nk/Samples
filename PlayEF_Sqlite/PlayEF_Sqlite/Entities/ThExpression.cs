using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayEF_Sqlite.Entities
{
	public class ThExpression
	{
		public int id { get; set; }
		public int thoughtId { get; set; }
		public string name { get; set; }
	}
}
