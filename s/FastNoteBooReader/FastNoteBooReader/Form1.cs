namespace FastNoteBooReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                using (var db = new AppData(ofd.FileName))
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = db.table1.OrderByDescending(x => x.date_sort).ToList();
                    
                    dataGridView1.DataSource = bs;
                    richTextBox1.DataBindings.Add("Text", bs, "content_note");
                }
            }
        }
    }
}