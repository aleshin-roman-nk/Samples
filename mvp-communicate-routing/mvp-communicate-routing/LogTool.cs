using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
	internal class LogTool
	{
		public static void Print(object o)
		{
			string jsonString = JsonSerializer.Serialize(o);
            Console.WriteLine(jsonString);
        }
	}
}
