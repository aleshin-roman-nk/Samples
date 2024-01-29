using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    internal class View
    {
        ServicesHub _hub;
        public View(ServicesHub h)
        {
            _hub = h;
        }

        public string Name => "view-thing";

        public void DoRequest()
        {
            /*
             * по идее здесь, в клиенте, как это происходит в angular, и др фронтенд, ответ ожидается тут же
             * поэтому хаб должен тут же вернуть ответ
             * var res = _hub.Send(new Message {...})
             */
            //var res = _hub.Send(new Message { from = Name, to = "service-db", data = "give me data", method = "add-product" });
            var res = _hub.Send(new Message { from = Name, to = "categories", data = "", method = "get-categories" });

            LogTool.Print(res);

		}
    }
}
