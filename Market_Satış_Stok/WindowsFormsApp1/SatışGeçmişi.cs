using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SatışGeçmişi : Form
    {
        public SatışGeçmişi()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-R4B5RFL;Initial Catalog=Market_satış_stok;Integrated Security=True");
        DataSet daset = new DataSet();
        private void satışlistele()
        {
            bağlantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from Satış", bağlantı);
            adtr.Fill(daset, "Satış");
            dataGridView1.DataSource = daset.Tables["Satış"];
            bağlantı.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SatışGeçmişi_Load(object sender, EventArgs e)
        {
            satışlistele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label6.Text = dt.ToShortDateString();
            label5.Text = dt.ToShortTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void txtbarkodara_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            bağlantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from Satış where Barkodno like '%"+txtbarkodara.Text+"%'",bağlantı);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            bağlantı.Close(); 
        }
    }
}
