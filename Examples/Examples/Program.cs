using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Examples
{
	class Program
	{
		static void Main(string[] args)
		{
			AADD aADD = new AADD();
			aADD.Name = "Roman";

            Console.WriteLine(aADD.Name);


			Console.WriteLine("Press any key to exit...");
			Console.ReadLine();
		}

		class AADD
        {
			private string _name = "Roman";
			public string Name
            {
                get
                {
					return _name;
                }
                set
                {
					_name = value + "20056";
                }
            }
        };


		static void f2()
		{
			List<Cat> cats = new List<Cat>();

			Cat one = new Cat { id = 2 };

			cats.Add(new Cat { id = 1 });
			cats.Add(one);
			cats.Add(new Cat { id = 3 });
			cats.Add(new Cat { id = 4 });

			foreach (var item in cats)
			{
				Console.WriteLine($"cat {item.id}");
			}

			Console.WriteLine("===============");

			cats.Clear();

			Console.WriteLine($"last cat is {one.id}");

			Console.WriteLine("Cats in the collection:");



			foreach (var item in cats)
			{
				Console.WriteLine($"cat {item.id}");
			}
		}

		static void f1()
		{
			int v = 0b100;
			Console.WriteLine((v & (int)Attr.smthe) == (int)Attr.smthe);
		}

		static void display(object p)
		{
			Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));
		}
	}

	//**************************

	public class Parent
	{
		public virtual object TestProperty { get; set; }
	}

	public class Child : Parent
	{
		private string _testValue = "Hello World!";

		public override object TestProperty
		{
			get { return _testValue; }
		}
	}

	public class Consumer
	{
		Parent p = new Child();

		public Consumer() { p.TestProperty = 3; }
	}

	//**************************

	class Paraw<T>
	{
		public T Data { get; set; }
	}

	class Request
	{
		public object Data { get; set; }
		public Response Response { get; }
	}

	class Response
	{
		public bool Ok { get; set; }
		public object Data { get; set; }
	}

	/*
	 * Таблица типов объектов
	 * 
	 * каждый объект показывает свой тип
	 * 
	 * ответ, запрос содержит этот тип
	 * 
	 * хаб ищет в таблице имя типа и вызывает на нем метод setResponse
	 * 
	 * в запросе поле данных имеет тип object и так же ответ содержит тип object. при получении просто распаковывать, то есть приводить к нужному, проведя проверку
	 *		соответсвия типа. Вместо обжект можно другое устройство обобщения.
	 * 
	 * Вариант: таблица команд, поддерживаемых хабом.
	 * Презентер регистрируется в хабе и получает доступ ко все командам.
	 * имена команд могут имет префиксы.
	 * 
	 * enum HubCommands
	 * {
	 *		
	 * }
	 * 
	 * чем лучше что презентер знает команды только и тем что ему передаются экземпляры других презентеров?
	 * в случае таблиц, презентер просто указывает имя адресата и параметры, отправляет на хаб.
	 * 
	 * 
	 * 
	 * 
	 */

	/*
	 * Ну и как организовать протокол сообщения?
	 * 
	 * 
	 * 
	 */

	class Empl
	{
		public string name { get; set; }
		public int age { get; set; }
	}

	class CatPresenter
	{
		/*
		 * получить запрос
		 * обработать
		 * отправить на хаб ответ
		 * 
		 */
	}

	class DogPresenter
	{
		/*
		 * отправить запрос на хаб
		 * получить ответ
		 * 
		 */
	}

	/*
	 * два разных enum
	 * + запросы
	 * + ответы
	 * 
	 */

	static class hub
	{
		/*
		 * получить запрос
		 * найти исполнителя
		 * 
		 * 
		 */


	}


	class Cat
	{
		public int id { get; set; }
		~Cat()
		{
			Console.WriteLine($"{id} destroyed");
		}

	}

	[Flags]
	public enum Attr
	{
		task = 0b001,
		note = 0b010,
		smthe = 0b100
	}

}