
namespace BütünMatik
{
    partial class kuponlarım
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mail_gönder = new System.Windows.Forms.Button();
            this.send_SMS = new System.Windows.Forms.Button();
            this.Seç = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seç});
            this.dataGridView1.Location = new System.Drawing.Point(129, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(713, 252);
            this.dataGridView1.TabIndex = 0;
            // 
            // mail_gönder
            // 
            this.mail_gönder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mail_gönder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mail_gönder.Location = new System.Drawing.Point(712, 406);
            this.mail_gönder.Name = "mail_gönder";
            this.mail_gönder.Size = new System.Drawing.Size(130, 40);
            this.mail_gönder.TabIndex = 1;
            this.mail_gönder.Text = "Mail ile Gönder";
            this.mail_gönder.UseVisualStyleBackColor = true;
            this.mail_gönder.Click += new System.EventHandler(this.mail_gönder_Click);
            // 
            // send_SMS
            // 
            this.send_SMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.send_SMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.send_SMS.Location = new System.Drawing.Point(713, 470);
            this.send_SMS.Name = "send_SMS";
            this.send_SMS.Size = new System.Drawing.Size(129, 36);
            this.send_SMS.TabIndex = 2;
            this.send_SMS.Text = "SMS gönder";
            this.send_SMS.UseVisualStyleBackColor = true;
            this.send_SMS.Click += new System.EventHandler(this.send_SMS_Click);
            // 
            // Seç
            // 
            this.Seç.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Seç.HeaderText = "Seç";
            this.Seç.MinimumWidth = 50;
            this.Seç.Name = "Seç";
            this.Seç.Width = 50;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(848, 420);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(148, 26);
            this.progressBar1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // kuponlarım
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1009, 545);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.send_SMS);
            this.Controls.Add(this.mail_gönder);
            this.Controls.Add(this.dataGridView1);
            this.Name = "kuponlarım";
            this.Text = "Kuponlarım";
            this.Load += new System.EventHandler(this.kuponlarım_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button mail_gönder;
        private System.Windows.Forms.Button send_SMS;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seç;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}