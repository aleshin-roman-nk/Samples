using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LockLesson
{
	public class SenderService
	{
		private readonly BufferService _buffer;

		private bool _running = false;

		private Task _workerTask;
		private CancellationTokenSource _cts;

		public Action<string> printOut;
		public Action<string> status;

		public SenderService(BufferService b)
		{
			_buffer = b;
		}

		public void Start()
		{
			if(_running) return;

			_running = true;
			_cts = new CancellationTokenSource();
			_workerTask = Task.Run(() => ProcessLoop(_cts.Token));
		}

		public void Stop()
		{
			_running = false;
			_cts?.Cancel();
		}

		private async Task ProcessLoop(CancellationToken token)
		{
			status?.Invoke("SENDER ON");
			while (_running && !token.IsCancellationRequested)
			{
				var all = _buffer.GetAll();

				var str = new StringBuilder();
				foreach ( var item in all )
				{
					str.Append($"{item.Name}; ");
				}

				printOut?.Invoke(str.ToString());

				//foreach (var r in all)
				//{
				//	bool success = await TrySendAsync(r);
				//	if (success)
				//		_buffer.Remove(r.Id);
				//}

				try
				{
					await Task.Delay(2000, token);
				}
				catch (TaskCanceledException)
				{
					break;
				}
			}
			status?.Invoke("SENDER OFF");
		}

		private async Task<bool> TrySendAsync(Receipt r)
		{
			try
			{
				using var client = new HttpClient();
				var json = JsonSerializer.Serialize(r);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync("http://server/api/receipts", content);

				return response.IsSuccessStatusCode;
			}
			catch
			{
				return false;
			}
		}
	}
}
