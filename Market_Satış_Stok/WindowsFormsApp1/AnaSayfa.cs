using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToShortDateString();
            label2.Text = dt.ToShortTimeString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SatışSayfası gec = new SatışSayfası();
            gec.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stok_Sayfası gec = new Stok_Sayfası();
            gec.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Marka_Ekleme gec = new Marka_Ekleme();
            gec.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ürüneklegüncelle gec = new Ürüneklegüncelle();
            gec.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kategori_Ekleme gec = new Kategori_Ekleme();
            gec.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SatışGeçmişi gec = new SatışGeçmişi();
            gec.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            kategorimarkasilme gec = new kategorimarkasilme();
            gec.Show();
        }
    }
}
