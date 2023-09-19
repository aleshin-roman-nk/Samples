using PlayEF_Sqlite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayEF_Sqlite.Repos
{
	internal class ThoughtRepo
	{
		private readonly AppData db;

		public ThoughtRepo(AppData db)
		{
			this.db = db;
		}

		public IEnumerable<Thought> GetAll()
		{
			return db.Thoughts.ToList();
		}

		public IEnumerable<Thought> GetThoughtsWOCard()
		{
			return db.Thoughts.Where(thought => !db.Cards.Any(card => card.ThoughtId == thought.id)).ToList();
		}


	}
}
