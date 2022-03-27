using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingRectangles
{
    class Cell
    {
        public Cell(object o)
        {
            data = o;
        }
        public Rectangle Rect { get; set; }
        public int id { get; set; }
        //public int minutes { get; set; }

        public DateTime date { get; set; }

        public object data { get; }

        public override string ToString()
        {
            return $"ID = {id}, {Rect}";
        }
        public override int GetHashCode()
        {
            return id;
        }
        public override bool Equals(object obj)
        {
            if (obj is Cell)
                return id == (obj as Cell).id;
            return false;
        }
    }
}
