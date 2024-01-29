using DrCost2.controllers;
using DrCost2.dtoservices;
using DrCost2.HubService;
using DrCost2.ViewHubService;
using DrCost2.viewParticipants;
using Microsoft.Extensions.DependencyInjection;

namespace DrCost2
{
    internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.

			ApplicationConfiguration.Initialize();

			//ServicesHub servicesHub = new ServicesHub();
			//ViewHub viewHub = new ViewHub();

			IServiceProvider serviceProvider = new ServiceCollection()
				.BuildServiceProvider();

			ParticipantsHub hub = new ParticipantsHub();

			var mainForm = new Form1(hub);

			hub.Register(new ProductController(hub));
			hub.Register(mainForm);
			hub.Register(new ProductForm(hub));
			hub.Register(new ProductTypeSelectForm(hub));

			Application.Run(mainForm);
		}
	}
}