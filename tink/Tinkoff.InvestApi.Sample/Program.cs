using Microsoft.Extensions.Configuration.UserSecrets;
using Tinkoff.InvestApi.Sample;

var builder = Host.CreateDefaultBuilder(args);
var host = builder
    .ConfigureServices((context, services) =>
    {
        if (context.Configuration.GetValue<bool>("Sync"))
            services.AddHostedService<SyncSample>();
        else
            services.AddHostedService<AsyncSample>();

        services.AddInvestApiClient((_, settings) => { settings.AccessToken = "t.bgNV6s3lRpGUOshQce4gWQi_eBRHYhb45DvhD7Nxlb9kzUjKYwSN4BwqCbFoyQUlbuilhyoRqXScGCUKXZumiA"; context.Configuration.Bind(settings); });
    })
    .Build();

await host.RunAsync();

Console.ReadLine();