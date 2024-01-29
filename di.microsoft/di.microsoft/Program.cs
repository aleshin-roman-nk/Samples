using di.microsoft;
using Microsoft.Extensions.DependencyInjection;


IServiceProvider serviceProvider = new ServiceCollection()

	.AddSingleton<ProductController>()
	.AddSingleton<IProductView, ProductView>()

	.BuildServiceProvider();

var view = serviceProvider.GetService<IProductView>();


view.add();

view = serviceProvider.GetService<IProductView>();

view.add();
view.add();
view.add();
view.add();

Console.WriteLine();

view = serviceProvider.GetService<IProductView>();
view.add();

Console.ReadLine();