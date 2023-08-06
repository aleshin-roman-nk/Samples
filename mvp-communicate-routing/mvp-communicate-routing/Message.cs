using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    internal class Message
    {
        public string from;
        public string to;
        public object data;
        public string method;
    }
}
