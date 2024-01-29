using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_event_bus
{
	internal class EventBus
	{
		private Dictionary<string, List<Action<object>>> _handlers = new Dictionary<string, List<Action<object>>>();

		public void Subscribe(string eventType, Action<object> handler)
		{
			if (!_handlers.ContainsKey(eventType))
			{
				_handlers[eventType] = new List<Action<object>>();
			}
			_handlers[eventType].Add(handler);
		}

		public void Unsubscribe(string eventType, Action<object> handler)
		{
			if (_handlers.ContainsKey(eventType))
			{
				_handlers[eventType].Remove(handler);
			}
		}

		public void Emit(string eventType, object arg)
		{
			if (_handlers.ContainsKey(eventType))
			{
				foreach (var handler in _handlers[eventType])
				{
					handler(arg);
				}
			}
		}
	}
}
