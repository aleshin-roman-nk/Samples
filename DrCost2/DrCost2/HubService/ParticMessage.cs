using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.HubService
{
	public class ParticMessage
	{
		public ParticMessage(string from, string to, string method, object data)
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

		public TData Cast<TData>() where TData : class
		{
			return (TData)Data;
		}
	}
}
