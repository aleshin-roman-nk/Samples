using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyLesson
{
    internal class matrix
    {
        public int id { get; set; }
        public string name { get; set; }
        public string descr { get; set; }
        public ICollection<word> words { get; set; } = new List<word>();
    }
}
