using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_find_class
{
	public class ViewBusMessage
	{
		public ViewBusMessage(string from, string to, string method, object data) 
		{
			From = from;
			To = to;
			Method = method;
			Data = data;
		}

		public string From { get; }
		public string To { get; }
		public string Method { get; }
		public object Data { get; }
	}
}
