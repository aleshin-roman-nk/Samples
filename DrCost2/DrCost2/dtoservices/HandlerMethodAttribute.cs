using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.dtoservices
{
    internal class HandlerMethodAttribute : Attribute
    {
        public string Name { get; }
        public HandlerMethodAttribute(string n) { Name = n; }
    }
}
