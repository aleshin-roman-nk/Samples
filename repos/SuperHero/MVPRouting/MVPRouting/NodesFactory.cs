using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPRouting
{
    public class NodesFactory
    {
        Dictionary<string, Func<object>> members = new Dictionary<string, Func<object>>();

        public void AddNodeType<NType>()
            where NType : new()
        {
            var t = typeof(NType);
            members.Add(t.Name, () => new NType());
        }

        public object CreateNode(string tname)
        {
            return members[tname]();
        }

        public IEnumerable<string> Members => members.Select(x => x.Key);
    }
}
