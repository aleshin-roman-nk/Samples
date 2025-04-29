using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAsyncVsSync.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		const int delay = 2000;

		[HttpGet("async")]
		public async Task<IActionResult> GetAsync()
		{
			var threadId = Environment.CurrentManagedThreadId;
			Console.WriteLine($"[ASYNC] Start at {DateTime.Now:T} on thread {threadId}");
			await Task.Delay(delay);
			Console.WriteLine($"[ASYNC] End   at {DateTime.Now:T} on thread {threadId}");
			return Ok("Асинхронный ответ через 2 секунды");
		}

		[HttpGet("sync")]
		public IActionResult GetSync()
		{
			var threadId = Environment.CurrentManagedThreadId;
			Console.WriteLine($"[SYNC] Start at {DateTime.Now:T} on thread {threadId}");
			Thread.Sleep(delay);
			Console.WriteLine($"[SYNC] End   at {DateTime.Now:T} on thread {threadId}");
			return Ok("Синхронный ответ через 2 секунды");
		}
	}
}
