using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingRectangles
{
    internal class WWeek
    {
        //*********************************************************
        const int col_count = 7;
        //*********************************************************

        Dictionary<DateTime, WDay> _daysDict;

        public WWeek(DateTime Monday)
        {
            _daysDict = new Dictionary<DateTime, WDay>();

            for (DateTime i = Monday; i < Monday.AddDays(col_count); i = i.AddDays(1))
            {
                _daysDict.Add(i, new WDay(i));
            }
        }

        public void InjectKeyCode(Keys key_code)
        {

        }

        // better move it to constr and disable the adding after the instance is created.
        // better move it to constr and turn off append after instantiation.
        public void AddCells(IEnumerable<Cell> cls)
        {
            // allocate all cells into their days.

            foreach (Cell c in cls)
            {
                if (_daysDict.ContainsKey(c.date))
                    _daysDict[c.date].AddCell(c);
            }
        }

        public WDay SelectedDay { get; private set; }
        public Cell SelectedCell { get; private set; }

        public void hitTest(int x, int y)
        {
            foreach (var day in _daysDict.Values)
            {
                if(day.Rect.Contains(x, y))
                {
                    SelectedDay = day;
                    SelectedCell = _hitCellTest(day, x, y);
                    return;
                }
            }

            SelectedDay = null;
            SelectedCell = null;
        }

        public void clearSelection()
        {
            SelectedDay = null;
            SelectedCell = null;
        }

        private Cell _hitCellTest(WDay d, int x, int y)
        {
            foreach (var item in d.Cells)
            {
                if (x >= item.Rect.X && x < item.Rect.X + item.Rect.Width &&
                    y >= item.Rect.Y && y < item.Rect.Y + item.Rect.Height)
                    return item;
            }

            return null;
        }

        public void renderWeek(Graphics graph, int width, int height)
        {
            const int dayHeadHeight = 30;
            
            const int day_column_space_x = 5;

            const int week_margin_x = 4;
            const int week_margin_y = 4;
            // расчитывается по ширине контрола, деленное на 7 (7 дней в неделе)
            //const int item_width = 80;
            int day_column_width = ((width - week_margin_x * 2 - 3) / col_count) - day_column_space_x;

            //*********************************************
            // Прямоугольники на всю высоту.
            //*********************************************
            // the 3 is to provide pixel space, pointed in week_margin_y
            int day_column_height = height - 2 * week_margin_y - 3;
            /// прямоугольники на всю высоту контрола
            /// 

            int i = 0;
            foreach (var __day in _daysDict.Values)
            {
                Rectangle dayRect = new Rectangle(week_margin_x + 1 + i * (day_column_width + day_column_space_x + 1), week_margin_y + 1, day_column_width, day_column_height);
                Rectangle dayHeaderRect = new Rectangle(dayRect.X, dayRect.Y, dayRect.Width, dayHeadHeight);

                _daysDict[__day.name.Date].Rect = dayRect;
                _daysDict[__day.name.Date].HeaderRect = dayHeaderRect;

                if (i % 2 == 0)
                    graph.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Gray, Color.Transparent), dayRect);
                else
                    graph.FillRectangle(new HatchBrush(HatchStyle.ForwardDiagonal, Color.Gray, Color.Transparent), dayRect);

                // голова колонки
                //graph.FillRectangle(new LinearGradientBrush(recHeader, Color.Yellow, Color.Green, 0.0F), recHeader);
                graph.FillRectangle(new SolidBrush(FlatColors.DayHeaderBack), dayHeaderRect);
                graph.DrawRectangle(new Pen(FlatColors.Gray), dayHeaderRect);

                // заголовок дня
                // текст ячейки
                Font drawFont = new Font("Roboto Condensed", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                graph.DrawString($"{_daysDict[__day.name.Date].name.ToShortDateString()}", drawFont, drawBrush, dayHeaderRect);

                // весь столбец дня
                graph.DrawRectangle(new Pen(FlatColors.Gray), dayRect);

                renderCells(graph, _daysDict[__day.name.Date]);
                i++;
            }

            if (SelectedDay != null)
                graph.DrawRectangle(new Pen(FlatColors.SelectedDayBorder, 3), SelectedDay.Rect);
        }

        private void renderCells(Graphics graph, WDay day)
        {
            /*
             * >>> 10-02-2022 01:44
             * Ячейкам нет права устанавливать свою ширину, так как она должна вписываться в прямоугольноик дня.
             * 
             */

            const int cell_height = 60;

            int cell_width = day.Rect.Width;

            int x_pos = day.Rect.X;
            int y_pos = day.HeaderRect.Y + day.HeaderRect.Height;

            foreach (var cell in day.Cells)
            {
                cell.Rect = new Rectangle(x_pos, y_pos, cell_width, cell_height);

                // сама ячейка
                graph.FillRectangle(new SolidBrush(FlatColors.CellBackground), cell.Rect);
                graph.DrawRectangle(new Pen(FlatColors.CellBorder, 1), cell.Rect);

                // текст ячейки
                Font drawFont = new Font("Roboto Condensed", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                graph.DrawRectangle(new Pen(FlatColors.CellBorder, 1), new Rectangle(x_pos + 2, y_pos + 2, cell.Rect.Width - 4, 18));
                graph.DrawString((cell.data as MyObj).Name, drawFont, drawBrush, new RectangleF(x_pos + 2, y_pos + 2, cell.Rect.Width - 4, 18));

                // обновить x_pos и y_pos
                y_pos = y_pos + cell.Rect.Height;

                // отрисоывть выделенную ячейку.
                if (SelectedCell != null)
                    graph.DrawRectangle(new Pen(FlatColors.SelectedCellBorder, 2), SelectedCell.Rect);
            }
        }
    }
}
