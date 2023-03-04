using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithoutMySQLConfig
{
	public class AppContext: DbContext
	{

		public AppContext(string cn): base(cn)
		{

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<buffer_empl> buffer_Empls { get; set; }

	}
}
