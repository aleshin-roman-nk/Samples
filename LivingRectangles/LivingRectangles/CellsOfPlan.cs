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
    public class CellsOfPlan : Control
    {
        const int col_count = 7;

        WWeek wWeek = new WWeek(new DateTime(2022, 2, 7));

        public CellsOfPlan()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            string[] things = new string[] { "xorg", "prg", "tur", "eng", "publish", "study", "family_stady", "msc" };

            Random rnd = new Random();

            List<Cell> cells = new List<Cell>();
            for (int i = 0; i < 7; i++)
            {
                cells.Add(new Cell(new MyObj { Name = $"{things[rnd.Next(0, things.Length)]}", Age = $"42-{10 * i}" }) { date = new DateTime(2022, 2, rnd.Next(7, 7 + 7))});
            }
            wWeek.AddCells(cells);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            //wWeek.InjectKeyCode(e.KeyCode);

            //=======================================================

            if (Selected == null) return;

            if (e.KeyCode == Keys.Left)
            {
                var i = AnItems.FindIndex(x => x.id == Selected.id);

                if (i - 1 >= 0)
                    Selected = AnItems[i - 1];

                Invalidate();
            }
            else if (e.KeyCode == Keys.Right)
            {
                var i = AnItems.FindIndex(x => x.id == Selected.id);

                if (i + 1 < AnItems.Count)
                    Selected = AnItems[i + 1];

                Invalidate();
            }
            else if (e.KeyCode == Keys.Up)
            {
                var i = AnItems.FindIndex(x => x.id == Selected.id);

                if (i - col_count >= 0)
                    Selected = AnItems[i - col_count];

                Invalidate();
            }
            else if (e.KeyCode == Keys.Down)
            {
                var i = AnItems.FindIndex(x => x.id == Selected.id);

                if (i + col_count < AnItems.Count)
                    Selected = AnItems[i + col_count];

                Invalidate();
            }
        }

        // https://stackoverflow.com/questions/1646998/up-down-left-and-right-arrow-keys-do-not-trigger-keydown-event/7815185#7815185
        //protected override bool IsInputKey(Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        case Keys.Right:
        //        case Keys.Left:
        //        case Keys.Up:
        //        case Keys.Down:
        //            return true;
        //        //case Keys.Shift | Keys.Right:
        //        //case Keys.Shift | Keys.Left:
        //        //case Keys.Shift | Keys.Up:
        //        //case Keys.Shift | Keys.Down:
        //        //    return true;
        //    }

        //    return base.IsInputKey(keyData);
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            //graph.SmoothingMode = SmoothingMode.HighQuality;
            //graph.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            //Обводка
            graph.DrawRectangle(new Pen(FlatColors.Gray), rect);

            //renderItems(graph, AnItems, Width, Height);

            wWeek.renderWeek(graph, Width, Height);
        }

        //OnSizeChanged
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //Invalidate();
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);

            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                wWeek.hitTest(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                wWeek.clearSelection();
            }

            Invalidate();

            AllowDrop = true;
            DoDragDrop(new object(), DragDropEffects.Move);
        }

        Cell Selected { get; set; } = null;
        List<Cell> AnItems = new List<Cell>();

        private void AddItem(object o)
        {
            AnItems.Add(new Cell(o) { id = AnItems.Count + 1 });
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void renderItems(Graphics graph, IEnumerable<Cell> items, int width, int hight)
        {
            const int cell_margin_x = 5;
            const int cell_margin_y = 0;

            // расчитывается по ширине контрола, деленное на 7 (7 дней в неделе)
            //const int item_width = 80;
            int cell_width = (width / col_count) - cell_margin_x;
            // рассчитывается по высоте контрола, пропорциональном отношении кол-ва времени этой ячейки

            const int x_margin = 3;
            const int y_margin = 3;
            const int x_pos_day_start = 3;
            const int y_pos_day_start = 3;
            const int dayHeadHeight = 30;

            const int cell_height = 60;
            const int x_pos_cells_start = x_margin;
            const int y_pos_cells_start = dayHeadHeight;

            //*********************************************
            // Прямоугольники на всю высоту.
            //*********************************************
            int one_width = cell_width;
            int one_height = hight - 1;
            /// прямоугольники на всю высоту контрола
            for (int i = 0; i < col_count; i++)
            {
                Rectangle rec = new Rectangle(x_pos_day_start + i * (one_width + cell_margin_x), y_pos_day_start, one_width, one_height - 6);
                Rectangle recHeader = new Rectangle(x_pos_day_start + i * (one_width + cell_margin_x), y_pos_day_start, one_width, dayHeadHeight);

                if (i % 2 == 0)
                    graph.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Gray, Color.Transparent), rec);
                else
                    graph.FillRectangle(new HatchBrush(HatchStyle.ForwardDiagonal, Color.Gray, Color.Transparent), rec);

                // голова колонки
                //graph.FillRectangle(new LinearGradientBrush(recHeader, Color.Yellow, Color.Green, 0.0F), recHeader);
                graph.FillRectangle(new SolidBrush(FlatColors.DayHeaderBack), recHeader);

                // весь столбец дня
                graph.DrawRectangle(new Pen(FlatColors.Gray), rec);
            }
            //*********************************************

            int x_pos = x_pos_cells_start;
            int y_pos = y_pos_cells_start;

            int row_number = 0;
            int col_number = 0;

            foreach (var cell in items)
            {
                cell.Rect = new Rectangle(x_pos, y_pos, cell_width, cell_height);

                graph.FillRectangle(new SolidBrush(FlatColors.CellBackground), cell.Rect);
                graph.DrawRectangle(new Pen(FlatColors.CellBorder, 1), cell.Rect);

                Font drawFont = new Font("Roboto Condensed", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                graph.DrawRectangle(new Pen(FlatColors.CellBorder, 1), new Rectangle(x_pos + 2, y_pos + 2, cell.Rect.Width - 4, 18));
                graph.DrawString((cell.data as MyObj).Name, drawFont, drawBrush, new RectangleF(x_pos + 2, y_pos + 2, cell.Rect.Width - 4, 18));

                //update x_pos, y_pos. Расчет на количество колонок (7)
                if (col_number < col_count - 1)
                {
                    x_pos = x_pos + cell_margin_x + cell_width;
                    col_number++;
                }
                else
                {
                    row_number++;
                    col_number = 0;
                    x_pos = x_pos_cells_start;
                    y_pos = y_pos + cell_height + cell_margin_y;
                }

                if (Selected != null)
                    graph.DrawRectangle(new Pen(FlatColors.SelectedCellBorder, 3), Selected.Rect);
            }
        }
    }
}
