
const int REQUEST_COUNT = 100;


Console.OutputEncoding = System.Text.Encoding.UTF8;

var client = new HttpClient();
string url = "http://localhost:5262/api/test/async"; // или /sync

Console.WriteLine("press enter to start requesting");
Console.ReadLine();

Console.WriteLine("🚀 Отправляем 10 параллельных запросов...");

var tasks = new Task<string>[REQUEST_COUNT];

for (int i = 0; i < REQUEST_COUNT; i++)
{
	int index = i + 1;
	tasks[i] = SendRequestAsync(client, url, index);
}

var results = await Task.WhenAll(tasks);

Console.WriteLine("\n📦 Результаты:");
foreach (var res in results)
{
	Console.WriteLine(res);
}

client.Dispose();



static async Task<string> SendRequestAsync(HttpClient client, string url, int number)
{
	var start = DateTime.Now;
	try
	{
		var response = await client.GetStringAsync(url);
		var end = DateTime.Now;
		var elapsed = (end - start).TotalMilliseconds;
		return $"✅ [{number}] ответ получен за {elapsed:F0} мс";
	}
	catch (Exception ex)
	{
		return $"❌ [{number}] ошибка: {ex.Message}";
	}
}