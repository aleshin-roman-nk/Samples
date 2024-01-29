using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_event_bus
{
	internal class Controller
	{
		private DataService _service;
		private EventBus _eventBus;

		public Controller(DataService service, EventBus eventBus)
		{
			_service = service;
			_eventBus = eventBus;
			_eventBus.Subscribe("request_data", OnDataRequest);
		}

		public void OnDataRequest(object arg)
		{
			string data = _service.FetchData();
			_eventBus.Emit("data_fetched", data);
		}
	}
}
