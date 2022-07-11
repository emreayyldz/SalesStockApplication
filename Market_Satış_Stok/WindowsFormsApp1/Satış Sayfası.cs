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
    public partial class SatışSayfası : Form
    {
        public SatışSayfası()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-R4B5RFL;Initial Catalog=Market_satış_stok;Integrated Security=True");
        DataSet daset = new DataSet();

        private void hesapla()
        {
            try
            {
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("select sum(ToplamFiyat) from Kasa ", bağlantı);
                lblgeneltoplam.Text = komut.ExecuteScalar() + " TL";
                bağlantı.Close();
            }
            catch (Exception)
            {

                ;
            }
        }
        private void kasalistele()
        {
            bağlantı.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select*from Kasa",bağlantı);
            adtr.Fill(daset,"Kasa");
            dataGridView1.DataSource = daset.Tables["Kasa"];
            bağlantı.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label7.Text = dt.ToShortDateString();
            label8.Text = dt.ToShortTimeString();
        }

        private void SatışSayfası_Load(object sender, EventArgs e)
        {
            kasalistele();
        }
        private void Yenile()
        {
            if (txtbno.Text == "")
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtadet)
                        {
                            item.Text = "";
                        }
                    }

                }
            }
        }
        private void txtbno_TextChanged(object sender, EventArgs e)
        {
         Yenile();
            bağlantı.Close();
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("select *from Ürün where Barkodno like '" + txtbno.Text + "'", bağlantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                
                txtüa.Text = read["ÜrünAdı"].ToString();
                txtsatışf.Text = read["SatışFiyatı"].ToString();
               
            }
            bağlantı.Close();


        }
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("insert into Kasa(Barkodno, ÜrünAdı,Adet, SatışFiyatı,ToplamFiyat,Tarih ) values(@Barkodno, @ÜrünAdı,@Adet, @SatışFiyatı,@ToplamFiyat,@Tarih)", bağlantı);
            komut.Parameters.AddWithValue("@Barkodno" ,txtbno.Text);
            komut.Parameters.AddWithValue("@ÜrünAdı", txtüa.Text);
            komut.Parameters.AddWithValue("@Adet", int.Parse(txtadet.Text)); 
            komut.Parameters.AddWithValue("@SatışFiyatı",double.Parse( txtsatışf.Text));
            komut.Parameters.AddWithValue("@ToplamFiyat",double.Parse( txttoplamf.Text));
            komut.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            bağlantı.Close();
            txtadet.Text = "1"; 
            daset.Tables["Kasa"].Clear();
            kasalistele();
            hesapla();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtadet)
                    {
                        item.Text = "";
                    }
                }

            }
            
        }

        private void txtadet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamf.Text = (double.Parse(txtadet.Text) * double.Parse(txtsatışf.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void txtsatışf_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string v = (double.Parse(txtadet.Text) * double.Parse(txtsatışf.Text)).ToString();
                txttoplamf.Text = v;
            }
            catch (Exception)
            {

                ;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("delete from Kasa where Barkodno= '"+dataGridView1.CurrentRow.Cells["Barkodno"].Value.ToString() + "'", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("ürün kaldırıldı");
            daset.Tables["Kasa"].Clear();
            kasalistele();
            hesapla();

        }

        private void btnsatışiptal_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("delete from Kasa  ", bağlantı);
            komut.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("ürünler kaldırıldı");
            daset.Tables["Kasa"].Clear();
            kasalistele();
            hesapla();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
             for (int i = 0; i < dataGridView1.Rows.Count-1 ; i++)


            {
                bağlantı.Open();
                SqlCommand komut = new SqlCommand("insert into Satış (Barkodno, ÜrünAdı,Adet, SatışFiyatı,ToplamFiyat,Tarih ) values(@Barkodno, @ÜrünAdı,@Adet, @SatışFiyatı,@ToplamFiyat,@Tarih)", bağlantı);
                komut.Parameters.AddWithValue("@Barkodno", dataGridView1.Rows[i].Cells["Barkodno"].Value.ToString());
                komut.Parameters.AddWithValue("@ÜrünAdı", dataGridView1.Rows[i].Cells["ÜrünAdı"].Value.ToString());
                komut.Parameters.AddWithValue("@Adet", int.Parse(dataGridView1.Rows[i].Cells["Adet"].Value.ToString()));
                komut.Parameters.AddWithValue("@SatışFiyatı", double.Parse(dataGridView1.Rows[i].Cells["SatışFiyatı"].Value.ToString()));
                komut.Parameters.AddWithValue("@ToplamFiyat", double.Parse(dataGridView1.Rows[i].Cells["ToplamFiyat"].Value.ToString()));
                komut.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                SqlCommand komt = new SqlCommand("update Ürün set Adet=Adet- '" + int.Parse(dataGridView1.Rows[i].Cells["Adet"].Value.ToString()) + "'where Barkodno='" + dataGridView1.Rows[i].Cells["Barkodno"].Value.ToString() + "'", bağlantı);
                komt.ExecuteNonQuery();
                bağlantı.Close();
                                
            }

            bağlantı.Open();
            SqlCommand komut2 = new SqlCommand("delete from Kasa  ", bağlantı);
            komut2.ExecuteNonQuery();
            bağlantı.Close();
            daset.Tables["Kasa"].Clear();
            kasalistele();
            hesapla();
        }
    }
}
