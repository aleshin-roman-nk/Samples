using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockLesson
{
	public class BufferService
	{
		private readonly string dbPath = "buffer.db";

		private static readonly object _lock = new();

		public void Add(Receipt receipt)
		{
			lock (_lock)
			{
				using var db = new LiteDB.LiteDatabase(dbPath);
				var col = db
					.GetCollection<Receipt>("receipts")
					.Insert(receipt);
			}
		}

		public List<Receipt> GetAll()
		{
			lock (_lock)
			{
				using var db = new LiteDB.LiteDatabase(dbPath);
				return db.GetCollection<Receipt>("receipts").FindAll().ToList();
			}
		}

		public void Remove(Guid id)
		{
			lock (_lock)
			{
				using var db = new LiteDB.LiteDatabase(dbPath);
				db.GetCollection<Receipt>("receipts").Delete(id);
			}
		}
	}
}
