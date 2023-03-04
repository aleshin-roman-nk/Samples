using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingRectangles
{
    class MyObj
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public override string ToString()
        {
            return $"Hello! My name is {Name}, I am {Age} years old.";
        }
    }
}
