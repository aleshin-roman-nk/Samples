using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithoutMySQLConfig
{
	[Table("buffer")]
	public class buffer_empl
	{
		public int id { get; set; }
		public int empl_id { get; set; }
		[ForeignKey("empl_id")]
		public Employee Employee { get; set; }
	}
}
