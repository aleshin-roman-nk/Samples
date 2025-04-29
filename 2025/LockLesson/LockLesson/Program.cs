using System;
using LockLesson;

class Program
{
	// 🔒 Общий lock для потокобезопасного вывода в консоль
	readonly static object _consoleLock = new();

	static void Main()
	{
		Console.WriteLine("Hello, World!");

		BufferService bufferService = new BufferService();
		SenderService senderService = new SenderService(bufferService);

		senderService.status = (x) => print(3, x);
		senderService.printOut = (x) => print(4, x);

		senderService.Start();

		var inputString = "";

		while (!inputString.Equals("exit", StringComparison.OrdinalIgnoreCase))
		{
			print(0, "=== (threads) ===");
			inputString = read(1, "start/stop/name : ");

			inputString ??= "-";

			if (inputString.Equals("start", StringComparison.OrdinalIgnoreCase))
				senderService.Start();
			else if (inputString.Equals("stop", StringComparison.OrdinalIgnoreCase))
				senderService.Stop();
			else if (!inputString.Equals("exit", StringComparison.OrdinalIgnoreCase))
				bufferService.Add(new Receipt { Name = inputString });

			print(2, $"result: {inputString}");
		}
	}

	static void print(int line, string str)
	{
		lock (_consoleLock)
		{
			Console.SetCursorPosition(0, line);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, line);
			Console.Write(str);
		}
	}

	static string? read(int line, string? promt = null)
	{
		lock (_consoleLock)
		{
			Console.SetCursorPosition(0, line);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, line);
			if (promt != null) Console.Write(promt);
		}

		return Console.ReadLine();
	}
}
