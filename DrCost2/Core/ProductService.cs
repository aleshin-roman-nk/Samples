using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.entity;

namespace Core
{
    public class ProductService
	{
		private readonly IProductRepo productRepo;

		public ProductService(IProductRepo productRepo)
		{
			this.productRepo = productRepo;
		}

		public Product Add(ProductType ptype, decimal price, decimal count, DateTime date)
		{
			var prod = new Product { count = count, price = price, Date = date, type = ptype };

			return productRepo.Add(prod);
		}

		public Product Update(Product prod)
		{
			return productRepo.Update(prod);
		}

		public void Delete(Product prod)
		{
			productRepo.Delete(prod);
		}

		public IEnumerable<Product> Get(int year, int month)
		{
			return productRepo.Get(year, month);
		}
	}
}
