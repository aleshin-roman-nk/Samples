using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    public class MethodNameAttribute: Attribute
    {
        public string Name { get; set; }
        public MethodNameAttribute() { }
        public MethodNameAttribute(string n) { Name = n; }
    }
}
