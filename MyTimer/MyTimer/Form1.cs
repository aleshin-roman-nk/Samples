namespace MyTimer
{
    public partial class Form1 : Form
    {
        TimeSpan _time = new TimeSpan();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _time += new TimeSpan(0, 0, 1);
            label1.Text = _time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pictureBox1.Enabled = true;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            pictureBox1.Enabled = false;
            _time = new TimeSpan();
            label1.Text = _time.ToString();
        }
    }
}