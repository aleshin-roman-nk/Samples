using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppLockThread
{
	class Program
	{
		static int x = 0;
		static object locker = new object();

		static Mutex mutex = new Mutex();

		static void Main(string[] args)
		{
			//for (int i = 0; i < 5; i++)
			//{
			//	Thread myThread = new Thread(Count);
			//	myThread.Name = "Поток " + i.ToString();
			//	myThread.Start();
			//}

			//new Thread(CreateAndSaveGPoint).Start();
			//new Thread(SaveGPoint).Start();

			//Thread.Sleep(5000);

			Task.Run(CreateAndSaveGPoint);
			Task.Run(SaveGPoint);

			Task.Run(CreateAndSaveGPoint);
			Task.Run(SaveGPoint);

			Console.WriteLine("Waiting for the threads to end");

			while (true)
			{

			}

			Console.ReadLine();
		}

		public static void CreateAndSaveGPoint()
		{
			lock (locker)
			{
				Console.Write("Creating GPoint in SQLite... ");
				Thread.Sleep(2000);
				Console.WriteLine("OK [new gpoint]");
				//x = 1;
				//for (int i = 1; i < 9; i++)
				//{
				//	Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
				//	x++;
				//	Thread.Sleep(100);
				//}
			}
		}

		public static void SaveGPoint()
		{
			lock (locker)
			{
				Console.Write("Just saving GPoint in SQLite... ");
				Thread.Sleep(2000);
				Console.WriteLine("OK [save gpoint]");
				//x = 1;
				//for (int i = 1; i < 9; i++)
				//{
				//	Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
				//	x++;
				//	Thread.Sleep(100);
				//}
			}
		}
	}
}
