using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    /*
     * В данном решении все исполнители стоят за хабом
     * все роуты собраны через хаб
     * для добавления новой функции, просто пишется новый сервис-медиатр, который получает запрос,
     * обращается к сервисам ядра и возвращает результат
     * 
     */

    internal class ServicesHub
    {
        Dictionary<string, IUIService> services = new Dictionary<string, IUIService>();

        // Methods table
        Dictionary<string, MethodInfo> _methods = new Dictionary<string, MethodInfo>();

        public object Send(Message m)
        {
            var cmp = services[m.to];

			//MethodInfo method = GetMethodByAttributeName(cmp, m.method);

			string mName = $"{m.to}.{m.method}";

			if(!_methods.ContainsKey(mName)) throw new InvalidOperationException($"could not find method {mName}");

			MethodInfo method = _methods[mName];

			Console.WriteLine($"Hub.Send: {mName}");
			// Invoke the method on the class instance
			return method.Invoke(cmp, new object[] { m });
        }

        public void RegisterService(IUIService serv)
        {
            if(services.ContainsKey(serv.Name)) throw new InvalidOperationException($"{serv.Name} already exists in the registry");

            services[serv.Name] = serv;

			makeMethodsTable(serv);
		}

		private void makeMethodsTable(IUIService serv)
        {
            var targetType = serv.GetType();

			foreach (MethodInfo methodInfo in targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
			{
				HandlerMethodAttribute attribute = methodInfo.GetCustomAttribute<HandlerMethodAttribute>();
				if (attribute != null)
				{
					string mName = $"{serv.Name}.{attribute.Name}";

					_methods.Add(mName, methodInfo);
                    Console.WriteLine($"{mName} is registered");
                }
			}
		}
	}
}
