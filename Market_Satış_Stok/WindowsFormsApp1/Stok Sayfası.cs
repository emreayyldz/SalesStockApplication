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
    public partial class Stok_Sayfası : Form
    {
        public Stok_Sayfası()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-R4B5RFL;Initial Catalog=Market_satış_stok;Integrated Security=True");
        DataSet dset = new DataSet();


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Stok_Sayfası_Load(object sender, EventArgs e)
        {
            stok();
           

        }

        private void stok()
        {
            bağlantı.Open();
            SqlDataAdapter adr = new SqlDataAdapter("select*from Ürün ", bağlantı);
            adr.Fill(dset, "Ürün ");
            dataGridView1.DataSource = dset.Tables["Ürün "];
            bağlantı.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtbn.Text = dataGridView1.CurrentRow.Cells["Barkodno"].Value.ToString();
            txtüa.Text = dataGridView1.CurrentRow.Cells["ÜrünAdı"].Value.ToString();
            txtkategori.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            txtmarka.Text = dataGridView1.CurrentRow.Cells["Marka"].Value.ToString();
            txtadet.Text = dataGridView1.CurrentRow.Cells["Adet"].Value.ToString();
            txtaf.Text = dataGridView1.CurrentRow.Cells["AlışFiyatı"].Value.ToString();
            txtsf.Text = dataGridView1.CurrentRow.Cells["SatışFiyatı"].Value.ToString();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand kmut = new SqlCommand("update Ürün set ÜrünAdı=@ÜrünAdı ,kategori=@kategori, Marka=@Marka , Adet=@Adet, AlışFiyatı=@AlışFiyatı, SatışFiyatı=@SatışFiyatı where Barkodno=@Barkodno ", bağlantı);
            kmut.Parameters.AddWithValue("Barkodno", txtbn.Text);
            kmut.Parameters.AddWithValue("ÜrünAdı", txtüa.Text);
            kmut.Parameters.AddWithValue("kategori", txtkategori.Text);
            kmut.Parameters.AddWithValue("Marka", txtmarka.Text);
            kmut.Parameters.AddWithValue("Adet", int.Parse(txtadet.Text));
            kmut.Parameters.AddWithValue("AlışFiyatı",double.Parse( txtaf.Text));
            kmut.Parameters.AddWithValue("SatışFiyatı", double.Parse(txtsf.Text));
            kmut.ExecuteNonQuery();
            bağlantı.Close();
           

        
           

            MessageBox.Show("Güncelleme tamamlandı");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox) 
                {
                    item.Text = "";
                }
            }
        }

        private void cbkategori_SelectedIndexChanged(object sender, EventArgs e)
        {

            bağlantı.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("delete from ürün where Barkodno='"+dataGridView1.CurrentRow.Cells["Barkodno"].Value.ToString()+"' ",bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();

            MessageBox.Show("Ürün kaydı sildi");


        }

        private void txtbn_TextChanged(object sender, EventArgs e)
        {
            if (txtbn.Text == "")

            {
                foreach (Control item in groupBox1.Controls)

                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }

            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select *from Ürün where Barkodno like '" + txtbn.Text + "'", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtkategori.Text = read["Kategori"].ToString();
                txtmarka.Text = read["Marka"].ToString();
                txtüa.Text = read["ÜrünAdı"].ToString();
                txtadet.Text = read["Adet"].ToString();
                txtaf.Text = read["AlışFiyatı"].ToString();
                txtsf.Text = read["SatışFiyatı"].ToString();

            }
            bağlantı.Close();
        }
    }
}
