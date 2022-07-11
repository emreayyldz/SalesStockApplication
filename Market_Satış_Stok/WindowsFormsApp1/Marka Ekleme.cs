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
    public partial class Marka_Ekleme : Form
    {
        public Marka_Ekleme()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-R4B5RFL;Initial Catalog=Market_satış_stok;Integrated Security=True");
        bool durum;
        private void markakontrol()
        {
            durum = true;
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select*from markalar", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox1.Text==read["kategori"].ToString() &&  textBox1.Text == read["marka"].ToString() || comboBox1.Text=="" || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            bağlantı.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            markakontrol();
            if(durum==true)
            {
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("insert into markalar( kategori ,marka) values ('" + comboBox1.Text + "','" + textBox1.Text + "')", bağlantı);
                komut.ExecuteNonQuery();
                bağlantı.Close();
                MessageBox.Show("Marka Eklendi");
            }
            else
            {
                MessageBox.Show("Hata tekrar deneyiniz");
            }
            textBox1.Text = "";
            comboBox1.Text = "";
            
        }
        private void kategorigetir()
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select *from kategoriler", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["kategori"].ToString());
            }
            bağlantı.Close();
        }
        private void Marka_Ekleme_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }
    }
}
