
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mail_gönder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(129, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(713, 252);
            this.dataGridView1.TabIndex = 0;
            // 
            // mail_gönder
            // 
            this.mail_gönder.Location = new System.Drawing.Point(766, 406);
            this.mail_gönder.Name = "mail_gönder";
            this.mail_gönder.Size = new System.Drawing.Size(114, 40);
            this.mail_gönder.TabIndex = 1;
            this.mail_gönder.Text = "Mail ile Gönder";
            this.mail_gönder.UseVisualStyleBackColor = true;
            this.mail_gönder.Click += new System.EventHandler(this.mail_gönder_Click);
            // 
            // kuponlarım
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 545);
            this.Controls.Add(this.mail_gönder);
            this.Controls.Add(this.dataGridView1);
            this.Name = "kuponlarım";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.kuponlarım_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button mail_gönder;
    }
}