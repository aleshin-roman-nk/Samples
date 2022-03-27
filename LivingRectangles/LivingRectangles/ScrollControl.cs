using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingRectangles
{
    internal class ScrollControl: Control
    {
        public ScrollControl()
        {
            SetStyle(
                      ControlStyles.AllPaintingInWmPaint
                    | ControlStyles.OptimizedDoubleBuffer
                    | ControlStyles.ResizeRedraw
                    | ControlStyles.SupportsTransparentBackColor
                    | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            //ScrollBarRenderer
        }


    }
}
