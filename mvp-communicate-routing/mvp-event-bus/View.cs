using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_event_bus
{
	internal class View
	{
		private EventBus _eventBus;

		public View(EventBus eventBus)
		{
			_eventBus = eventBus;
			_eventBus.Subscribe("data_fetched", UpdateData);
		}

		public void RequestData()
		{
			Console.WriteLine("Data requested...");
			_eventBus.Emit("request_data", null);
		}

		public void UpdateData(object data)
		{
			Console.WriteLine($"View updated with data: {data}");
		}
	}
}
