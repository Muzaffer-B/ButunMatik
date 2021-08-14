
namespace BütünMatik
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.kullanıcı_giris = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.girissiz = new System.Windows.Forms.Button();
            this.Uye_Ol = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(38, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "LED ON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(178, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "LED OFF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(320, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kullanıcı Girişi";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(304, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(304, 293);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(162, 20);
            this.textBox2.TabIndex = 5;
            // 
            // kullanıcı_giris
            // 
            this.kullanıcı_giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullanıcı_giris.Location = new System.Drawing.Point(324, 356);
            this.kullanıcı_giris.Name = "kullanıcı_giris";
            this.kullanıcı_giris.Size = new System.Drawing.Size(105, 34);
            this.kullanıcı_giris.TabIndex = 6;
            this.kullanıcı_giris.Text = "Giriş";
            this.kullanıcı_giris.UseVisualStyleBackColor = true;
            this.kullanıcı_giris.Click += new System.EventHandler(this.kullanıcı_giris_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(175, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kullanıcı Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(175, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Şifre";
            // 
            // girissiz
            // 
            this.girissiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girissiz.Location = new System.Drawing.Point(654, 372);
            this.girissiz.Name = "girissiz";
            this.girissiz.Size = new System.Drawing.Size(134, 48);
            this.girissiz.TabIndex = 9;
            this.girissiz.Text = "Giriş Yapmadan Devam Et";
            this.girissiz.UseVisualStyleBackColor = true;
            // 
            // Uye_Ol
            // 
            this.Uye_Ol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Uye_Ol.Location = new System.Drawing.Point(547, 372);
            this.Uye_Ol.Name = "Uye_Ol";
            this.Uye_Ol.Size = new System.Drawing.Size(91, 48);
            this.Uye_Ol.TabIndex = 10;
            this.Uye_Ol.Text = "Üye Ol";
            this.Uye_Ol.UseVisualStyleBackColor = true;
            this.Uye_Ol.Click += new System.EventHandler(this.Uye_Ol_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 452);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Location = new System.Drawing.Point(644, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(149, 370);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Location = new System.Drawing.Point(644, 420);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(149, 34);
            this.panel3.TabIndex = 13;
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(178, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 78);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.girissiz);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Uye_Ol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kullanıcı_giris);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button kullanıcı_giris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button girissiz;
        private System.Windows.Forms.Button Uye_Ol;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

