using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayEF_Sqlite.Entities
{
	internal class Card
	{
		public int id {  get; set; }
		public string text { get; set; }
		[ForeignKey("Thought")]
		public int ThoughtId { get; set; }
		public Thought Thought { get; set; }
		public int scores { get; set; }
	}
}
