using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithoutMySQLConfig
{
	class Program
	{
		static void Main(string[] args)
		{
			baseFunc(select_one_column);

			Console.ReadLine();
		}

		static void select_one_column(AppContext context)
		{
			var items = context.Employees.Select(x => x.name).ToList();

			foreach (var item in items)
			{
				Console.WriteLine(item);
			}

			show_obj(items);
		}

		static void sql_delete(AppContext context)
		{
			context.Database.ExecuteSqlCommand("delete from buffer where id = 1");
		}

		static void create(AppContext context)
		{
			buffer_empl e = new buffer_empl { empl_id = 3 };

			context.Entry(e).State = System.Data.Entity.EntityState.Added;
			context.SaveChanges();
		}

		static void exp03(AppContext context)
		{
			buffer_empl ent;

			using (AppContext c1 = new AppContext("cn"))
			{
				ent = c1.buffer_Empls.Include("Employee").FirstOrDefault(x => x.empl_id == 2);
			}

			using (AppContext c2 = new AppContext("cn"))
			{
				if (ent != null)
				{
					Console.WriteLine($"{ent.Employee.name} / {ent.Employee.tags}");
					c2.Entry(ent).State = System.Data.Entity.EntityState.Deleted;
					c2.SaveChanges();
				}
			}
		}

		static void exp02(AppContext context)
		{
			var items = context.buffer_Empls.Include("Employee").ToList();

			foreach (var item in items)
			{
				Console.WriteLine($"#{item.Employee.name} - {item.Employee.tags}");
			}
		}

		static void exp01(AppContext context)
		{
			var items = context.Employees.Where(x => x.tags.Contains("<prg>") || x.tags.Contains("<wman>")).ToList();

			foreach (var item in items)
			{
				Console.WriteLine($"#{item.id} - {item.name}");
			}
		}

		static void baseFunc(Action<AppContext> prc)
		{
			AppContext context = new AppContext("cn");

			context.Database.Log = Console.WriteLine;

			try
			{
				prc(context);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				ex = ex.InnerException;

				while (ex != null)
				{
					Console.WriteLine("=======================");
					Console.WriteLine(ex.Message);
					ex = ex.InnerException;
				}
			}
		}

		static void show_obj(object o)
		{
			var j = JsonConvert.SerializeObject(o, Formatting.Indented);
			Console.WriteLine(j);
		}
	}
}
