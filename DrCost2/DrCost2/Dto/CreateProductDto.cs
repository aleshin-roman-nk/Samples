using Core.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.Dto
{
    public class CreateProductDto
	{
		public ProductType ProductType { get; set; }
		public decimal price { get; set; }
		public decimal count { get; set; }
		public DateTime DateTime { get; set; }
	}
}
