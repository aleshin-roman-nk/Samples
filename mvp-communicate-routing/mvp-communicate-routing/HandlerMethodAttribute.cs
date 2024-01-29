using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    public class HandlerMethodAttribute: Attribute
    {
        public string Name { get; }
        public HandlerMethodAttribute(string n) { Name = n; }
    }
}
