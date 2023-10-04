using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkoff.InvestApi.V1;

namespace Tinkoff.InvestApi.Sample
{
	public class MyShares
	{
		private readonly InvestApiClient _service;

		public MyShares(InvestApiClient service)
		{
			_service = service;
		}

		public async Task Print(CancellationToken cancellationToken)
		{
			var accounts = await _service.Users.GetAccountsAsync();
			var accountId = accounts.Accounts.First().Id;

			var positions = await _service.Operations.GetPositionsAsync(new PositionsRequest { AccountId = accountId }, cancellationToken: cancellationToken);

			var portfolio = await _service.Operations.GetPortfolioAsync(new PortfolioRequest { AccountId = accountId }, cancellationToken: cancellationToken);

			var shares = await _service.Instruments.SharesAsync(cancellationToken: cancellationToken);

			var rusShares = shares.Instruments.Where(x => x.Currency.Equals("rub")).ToArray();

			int sharesCnt = 0;
			Console.WriteLine();
			Console.WriteLine("=== Shares ===");
			Console.WriteLine();
			foreach (var item in rusShares)
			{
				Console.WriteLine($"{item}");
				Console.WriteLine();
				sharesCnt++;
			}

			Console.WriteLine($"shares: {sharesCnt}");

			//Console.WriteLine();
			//Console.WriteLine("=== BRANDS ===");
			//var brands = await _service.Instruments.GetBrandsAsync(new GetBrandsRequest { }, cancellationToken: cancellationToken);
			//foreach (var item in brands.Brands)
			//{
			//	Console.WriteLine(item);
			//	Console.WriteLine();
			//}

			int c = 0;

			Console.WriteLine();
			Console.WriteLine("=== Portfolio ===");
			Console.WriteLine();
			foreach (var item in portfolio.Positions)
			{
				Console.WriteLine($"{item}");
				Console.WriteLine();
				Console.WriteLine();
				c++;
			}

			Console.WriteLine($"total: {c}");

			Console.WriteLine();
			Console.WriteLine("=== Positions ===");
			Console.WriteLine();
			foreach (var item in positions.Securities)
			{
				Console.WriteLine($"{item}");
				Console.WriteLine();
				Console.WriteLine();
			}
			//foreach (var pos in portfolio.Positions)
			//{
			//	Console.WriteLine($"{pos.CurrentPrice}");
			//} 
		}
	}
}
