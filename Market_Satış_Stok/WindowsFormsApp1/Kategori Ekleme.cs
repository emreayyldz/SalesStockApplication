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
    public partial class Kategori_Ekleme : Form
    {
        public Kategori_Ekleme()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-R4B5RFL;Initial Catalog=Market_satış_stok;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        bool durum;
        private void kategorikontrol()
        {
            durum = true;
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select*from kategoriler",bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
               if(textBox1.Text==read["kategori"].ToString() || textBox1.Text=="")
                {
                    durum = false; 
                }
            }
            bağlantı.Close();

        }
        private void Kategori_Ekleme_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kategorikontrol();
            if(durum==true)
            {
                bağlantı.Open();
                SqlCommand kmut = new SqlCommand("insert into kategoriler (kategori) values ('" + textBox1.Text + "')", bağlantı);
                kmut.ExecuteNonQuery();
                bağlantı.Close();
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Hata tekrar deneyiniz");
            }
            textBox1.Text = "";
        }
    }
}
