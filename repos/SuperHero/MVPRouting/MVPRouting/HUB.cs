using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPRouting
{
    public class HUB
    {
        public List<HubMember> _members = new List<HubMember>();

        public HUB() { }

        public void AddMember<HMType>()
            where HMType : HubMember
        {
            //_members.Add(new HMType(this));
        }

        //public object Send(string host, string action, object data)
        //{

        //}
    }
}
