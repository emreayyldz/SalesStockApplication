using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Ürüneklegüncelle : Form
    {
        public Ürüneklegüncelle()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-R4B5RFL;Initial Catalog=Market_satış_stok;Integrated Security=True");
        bool durum;
        private void barkodkontrol()
        {
            durum = true;
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select*from Ürün", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtbn.Text==read["Barkodno"].ToString() || txtbn.Text=="")
                {
                    durum = false;
                }
            }
            bağlantı.Close();

        }

        private void label3_Click(object sender, EventArgs e)

        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
        private void Ürüneklegüncelle_Load(object sender, EventArgs e)
        {
            kategorigetir();

        }

        private void btekle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if(durum==true)
            {
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("insert into Ürün(Barkodno,ÜrünAdı,Marka,Adet,Kategori,AlışFiyatı,Satışfiyatı) values(@Barkodno,@ÜrünAdı,@Marka,@Adet,@Kategori,@AlışFiyatı,@Satışfiyatı)  ", bağlantı);
                komut.Parameters.AddWithValue("@Barkodno", txtbn.Text);
                komut.Parameters.AddWithValue("@ÜrünAdı", txtüa.Text);
                komut.Parameters.AddWithValue("@Marka", cbmarka.Text);
                komut.Parameters.AddWithValue("@Adet", int.Parse(txtadet.Text));
                komut.Parameters.AddWithValue("@Kategori", cbkategori.Text);
                komut.Parameters.AddWithValue("@AlışFiyatı", double.Parse(txtaf.Text));
                komut.Parameters.AddWithValue("@Satışfiyatı", double.Parse(txtsf.Text));
                komut.ExecuteNonQuery();
                bağlantı.Close();
                MessageBox.Show("Ürün Eklendi");
            }
            else
            {
                MessageBox.Show("Tekrar Deneyiniz Barkodno Hatalı");
            }
            cbmarka.Items.Clear();
            foreach(Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            

        }

        private void cbkategori_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbmarka.Items.Clear();
            cbmarka.Text = ""; 
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("select *from markalar where kategori='"+cbkategori.SelectedItem+"' ", bağlantı);
                SqlDataReader read = komut.ExecuteReader();
                while (read.Read())
                {
                    cbmarka.Items.Add(read["marka"].ToString());
                }
                bağlantı.Close();
            
        }

        private void txtbng_TextChanged(object sender, EventArgs e)
        {
            if (txtbng.Text=="")

            {
                foreach (Control  item in groupBox2.Controls)

                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
           
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select *from Ürün where Barkodno like '"+txtbng.Text+"'", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtkategorig.Text = read["Kategori"].ToString();
                txtmarkag.Text = read["Marka"].ToString();
                txtüag.Text = read["ÜrünAdı"].ToString();
                txtadetg.Text = read["Adet"].ToString();
                txtafg.Text = read["AlışFiyatı"].ToString();
                txtsfg.Text = read["SatışFiyatı"].ToString();
            
            }
            bağlantı.Close();
        }

        private void btgüncelle_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("update Ürün set Adet=Adet+'"+int.Parse(textBox1.Text)+"'where Barkodno='"+txtbng.Text+"'",bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            foreach (Control item in groupBox2.Controls)

            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            MessageBox.Show("Ürün adeti güncellendi");
        }

        private void cbmarka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtüa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
