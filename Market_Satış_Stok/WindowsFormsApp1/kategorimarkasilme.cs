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
    public partial class kategorimarkasilme : Form
    {
        public kategorimarkasilme()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-R4B5RFL;Initial Catalog=Market_satış_stok;Integrated Security=True");
        DataSet dset = new DataSet();
        private void kategorigetir()
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select *from kategoriler", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cbkategori.Items.Add(read["Kategori"].ToString());
            }
            bağlantı.Close();
        }

        private void markagetir()
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select *from markalar", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cbmarka.Items.Add(read["marka"].ToString());
            }
            bağlantı.Close();
        }


        private void btkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("delete from kategoriler where kategori='" + dataGridView1.CurrentRow.Cells["kategori"].Value.ToString() + "' ", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();

            MessageBox.Show("Kategori kaydı sildi");
        }

        private void kategorimarkasilme_Load(object sender, EventArgs e)
        {
            kategorigetir();
            markagetir();
            kategori();
            marka();
        }


        private void kategori()
        {
            bağlantı.Open();
            SqlDataAdapter adr = new SqlDataAdapter("select*from kategoriler ", bağlantı);
            adr.Fill(dset, "kategoriler ");
            dataGridView1.DataSource = dset.Tables["kategoriler "];
            bağlantı.Close();
        }

        private void marka()
        {
            bağlantı.Open();
            SqlDataAdapter adr = new SqlDataAdapter("select*from markalar ", bağlantı);
            adr.Fill(dset, "markalar ");
            dataGridView2.DataSource = dset.Tables["markalar "];
            bağlantı.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("delete from markalar where kategori='" + dataGridView2.CurrentRow.Cells["kategori"].Value.ToString() + "' ", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();

            MessageBox.Show("Marka kaydı sildi");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
