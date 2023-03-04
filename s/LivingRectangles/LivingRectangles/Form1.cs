using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingRectangles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            customScrollBar1.PosChanged += CustomScrollBar1_PosChanged;
        }

        private void CustomScrollBar1_PosChanged(object sender, EventArgs e)
        {
            textBox1.Text = $"{customScrollBar1.Pos} / {customScrollBar1.AllWay}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CircleTestForm form2 = new CircleTestForm();
            form2.Show();
        }
    }
}
