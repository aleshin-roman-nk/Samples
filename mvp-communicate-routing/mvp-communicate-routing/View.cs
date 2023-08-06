using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    internal class View: IComp
    {
        Hub _hub;
        public View(Hub h) 
        {
            _hub = h;
        }

        public string Name => "view-thing";

        public void DoRequest()
        {
            Console.WriteLine($"::view '{Name}' : requesting to service-db");
            _hub.Send(new Message { from = Name, to = "service-db", data = "give me data", method = "get" });
        }

        public void PutMessage(Message m)
        {
            Console.WriteLine($"<== view-client '{Name}'");
            Console.WriteLine($"from: {m.from}");
            Console.WriteLine($"data: {m.data}");
        }
    }
}
