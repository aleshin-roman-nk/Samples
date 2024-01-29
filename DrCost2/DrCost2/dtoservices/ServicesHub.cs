using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace DrCost2.dtoservices
{
    public class ServicesHub
    {
        Dictionary<string, IDtoService> services = new Dictionary<string, IDtoService>();

        // Methods table
        Dictionary<string, MethodInfo> _methods = new Dictionary<string, MethodInfo>();

        public DtoMessage Send(DtoMessage m)
        {
            var cmp = services[m.to];

            string mName = $"{m.to}.{m.method}";

            if (!_methods.ContainsKey(mName)) throw new InvalidOperationException($"could not find method {mName}");

            MethodInfo method = _methods[mName];

            // Invoke the method on the class instance
            return method.Invoke(cmp, new object[] { m }) as DtoMessage;
        }

        public void RegisterService(IDtoService serv)
        {
            if (services.ContainsKey(serv.name)) throw new InvalidOperationException($"{serv.name} already exists in the registry");

            services[serv.name] = serv;

            makeMethodsTable(serv);
        }

        private void makeMethodsTable(IDtoService serv)
        {
            var targetType = serv.GetType();

            foreach (MethodInfo methodInfo in targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                HandlerMethodAttribute attribute = methodInfo.GetCustomAttribute<HandlerMethodAttribute>();
                if (attribute != null)
                {
                    string mName = $"{serv.name}.{attribute.Name}";

                    _methods.Add(mName, methodInfo);
                }
            }
        }
    }
}
