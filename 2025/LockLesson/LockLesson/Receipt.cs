using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockLesson
{
	public class Receipt
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string? Name { get; set; }
	}
}
