using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.entity;

namespace Core
{
    public interface IProductRepo: IRepo<Product>
	{
		public IEnumerable<Product> Get(int year, int month);
	}
}
