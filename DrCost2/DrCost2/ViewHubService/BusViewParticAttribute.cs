using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost2.ViewHubService
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BusViewParticAttribute : Attribute
    {
        public string name { get; }
        public BusViewParticAttribute(string name)
        {
            this.name = name;
        }
    }
}
