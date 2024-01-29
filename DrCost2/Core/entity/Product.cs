using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entity
{
    public class Product : IDbEntity
    {
        public int id { get; set; }
        public ProductType type { get; set; }
        public decimal price { get; set; }
        public decimal count { get; set; }
        public DateTime Date { get; set; }
        public int currId { get; set; }
    }
}
