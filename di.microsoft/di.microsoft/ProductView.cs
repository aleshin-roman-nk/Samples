using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.microsoft
{
	public class ProductView : IProductView
	{
		int _counter = 0;
		private readonly ProductController ctrl;

		public int counter => _counter;

		public ProductView(ProductController ctrl)
		{
			this.ctrl = ctrl;
		}

		public void add()
		{
			Console.WriteLine($"view : {this._counter}; controller: {ctrl.coiunter}");

			_counter++;
			ctrl.coiunter++;
        }
	}
}
