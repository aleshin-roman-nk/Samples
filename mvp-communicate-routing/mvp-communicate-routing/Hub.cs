using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mvp_communicate_routing
{
    internal class Hub
    {
        Dictionary<string, IComp> comps = new Dictionary<string, IComp>();

        public void Send(Message m)
        {
            var cmp = comps[m.to];
            
            MethodInfo methodInfo = FindMethodWithAttribute(cmp.GetType(), typeof(MethodNameAttribute));

            if (methodInfo != null)
            {
                // Invoke the method on the class instance
                methodInfo.Invoke(cmp, new object[] { m });
            }

            //.PutMessage(m);
        }

        public void Register(IComp c)
        {
            comps[c.Name] = c;
        }

        private MethodInfo FindMethodWithAttribute(Type type, Type attributeType)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (var method in methods)
            {
                if (method.GetCustomAttributes(attributeType, false).Length > 0)
                {
                    return method;
                }
            }

            return null;
        }
    }
}
