using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entity
{
    public class ProductType : IDbEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public ProductCategory category { get; set; }
    }
}
