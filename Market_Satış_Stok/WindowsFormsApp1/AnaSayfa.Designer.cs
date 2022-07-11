
namespace WindowsFormsApp1
{
    partial class AnaSayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btkapat = new System.Windows.Forms.Button();
            this.btstok = new System.Windows.Forms.Button();
            this.btsatış = new System.Windows.Forms.Button();
            this.btürünekle = new System.Windows.Forms.Button();
            this.btkateekle = new System.Windows.Forms.Button();
            this.btmarkaek = new System.Windows.Forms.Button();
            this.btsatışgeç = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btkapat
            // 
            this.btkapat.BackColor = System.Drawing.Color.Transparent;
            this.btkapat.Location = new System.Drawing.Point(572, 428);
            this.btkapat.Name = "btkapat";
            this.btkapat.Size = new System.Drawing.Size(187, 86);
            this.btkapat.TabIndex = 0;
            this.btkapat.Text = "OTURUMU KAPAT";
            this.btkapat.UseVisualStyleBackColor = false;
            this.btkapat.Click += new System.EventHandler(this.button1_Click);
            // 
            // btstok
            // 
            this.btstok.Location = new System.Drawing.Point(12, 12);
            this.btstok.Name = "btstok";
            this.btstok.Size = new System.Drawing.Size(404, 182);
            this.btstok.TabIndex = 1;
            this.btstok.Text = "STOK";
            this.btstok.UseVisualStyleBackColor = true;
            this.btstok.Click += new System.EventHandler(this.button2_Click);
            // 
            // btsatış
            // 
            this.btsatış.Location = new System.Drawing.Point(456, 12);
            this.btsatış.Name = "btsatış";
            this.btsatış.Size = new System.Drawing.Size(404, 182);
            this.btsatış.TabIndex = 2;
            this.btsatış.Text = "SATIŞ";
            this.btsatış.UseVisualStyleBackColor = true;
            this.btsatış.Click += new System.EventHandler(this.button3_Click);
            // 
            // btürünekle
            // 
            this.btürünekle.Location = new System.Drawing.Point(12, 332);
            this.btürünekle.Name = "btürünekle";
            this.btürünekle.Size = new System.Drawing.Size(404, 86);
            this.btürünekle.TabIndex = 3;
            this.btürünekle.Text = "ÜRÜN EKLEME GÜNCELLEME";
            this.btürünekle.UseVisualStyleBackColor = true;
            this.btürünekle.Click += new System.EventHandler(this.button4_Click);
            // 
            // btkateekle
            // 
            this.btkateekle.Location = new System.Drawing.Point(12, 428);
            this.btkateekle.Name = "btkateekle";
            this.btkateekle.Size = new System.Drawing.Size(87, 86);
            this.btkateekle.TabIndex = 4;
            this.btkateekle.Text = "KATEGORİ EKLEME";
            this.btkateekle.UseVisualStyleBackColor = true;
            this.btkateekle.Click += new System.EventHandler(this.button5_Click);
            // 
            // btmarkaek
            // 
            this.btmarkaek.Location = new System.Drawing.Point(328, 424);
            this.btmarkaek.Name = "btmarkaek";
            this.btmarkaek.Size = new System.Drawing.Size(88, 86);
            this.btmarkaek.TabIndex = 5;
            this.btmarkaek.Text = "MARKA EKLEME";
            this.btmarkaek.UseVisualStyleBackColor = true;
            this.btmarkaek.Click += new System.EventHandler(this.button6_Click);
            // 
            // btsatışgeç
            // 
            this.btsatışgeç.Location = new System.Drawing.Point(456, 332);
            this.btsatışgeç.Name = "btsatışgeç";
            this.btsatışgeç.Size = new System.Drawing.Size(404, 86);
            this.btsatışgeç.TabIndex = 6;
            this.btsatışgeç.Text = "SATIŞ GEÇMİŞİ";
            this.btsatışgeç.UseVisualStyleBackColor = true;
            this.btsatışgeç.Click += new System.EventHandler(this.button7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "TARİH";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "SAAT";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 86);
            this.button1.TabIndex = 9;
            this.button1.Text = "KATEGORİ VE MARKA SİLME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(874, 539);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btsatışgeç);
            this.Controls.Add(this.btmarkaek);
            this.Controls.Add(this.btkateekle);
            this.Controls.Add(this.btürünekle);
            this.Controls.Add(this.btsatış);
            this.Controls.Add(this.btstok);
            this.Controls.Add(this.btkapat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btkapat;
        private System.Windows.Forms.Button btstok;
        private System.Windows.Forms.Button btsatış;
        private System.Windows.Forms.Button btürünekle;
        private System.Windows.Forms.Button btkateekle;
        private System.Windows.Forms.Button btmarkaek;
        private System.Windows.Forms.Button btsatışgeç;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

