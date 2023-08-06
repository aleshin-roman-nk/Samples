using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    internal interface IComp
    {
        string Name { get; }
        void PutMessage(Message m);
    }
}
