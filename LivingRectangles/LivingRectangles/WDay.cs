using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingRectangles
{
    internal class WDay
    {
        List<Cell> _cells;

        public DateTime name { get; }

        public IEnumerable<Cell> Cells => _cells;

        public Rectangle Rect { get; set; }
        public Rectangle HeaderRect { get; set; }

        public void AddCell(Cell c)
        {
            _cells.Add(c);
        }

        public WDay(DateTime nam)
        {
            name = nam;
            _cells = new List<Cell>();
        }
    }
}
