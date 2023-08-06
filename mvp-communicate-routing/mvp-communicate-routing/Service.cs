using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    internal class Service: IComp
    {
        Hub _hub;
        public Service(Hub h) 
        { 
            _hub = h;
        }

        public string Name => "service-db";

        public void PutMessage(Message m)
        {
            Console.WriteLine($"=> service '{Name}'");
            Console.WriteLine($"request from: {m.from}");

            _hub.Send( new Message { from = Name, to = m.from, data = "processed data" } );
        }

        // [пометить имя метода компонента; hub будет искать метод, имя которого указано в сообщении]
        [MethodName("some-command")]
        public void some_command(Message m)
        {
            Console.WriteLine($"=> service '{Name}'/some-command");
            Console.WriteLine($"request from: {m.from}");

            _hub.Send(new Message { from = Name, to = m.from, data = "processed data" });
        }
    }
}
