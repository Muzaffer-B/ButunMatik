using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;

namespace BütünMatik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //serialPort1.PortName = "COM5";
            //serialPort1.BaudRate = 9600;
            //serialPort1.Open();
            //button2.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            label1.Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //serialPort1.Write("1");
            //label1.Text = "LED ON";
            //button1.Enabled = false;
            //button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //serialPort1.Write("0");
            //label1.Text = "LED OFF";
            //button1.Enabled = true;
            //button2.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (serialPort1.IsOpen == true)
            //{
            //    serialPort1.Close();
            //}
        }
       public  string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";

        private void kullanıcı_giris_Click(object sender, EventArgs e)
        {
            string kullanici_adi = textBox1.Text;
            string şifre = textBox2.Text;


            if(kullanici_adi != null && şifre != null)
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                

                if(con.State == System.Data.ConnectionState.Open && is_valid(kullanici_adi, şifre))
                {
                    MessageBox.Show("Giriş Başarılı");

                    var Form3 = new KullanıcıArayüz(kullanici_adi,şifre);
                    Form3.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Bulunamadı");
                }
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girmeyiniz");
            }
        }


        bool is_valid( string kullanici_adi, string sifre)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "  select CustomerID,Password from UserInfo where CustomerID ='"+kullanici_adi+"' and Password= '"+sifre+"' ";
            SqlCommand cmd = new SqlCommand(SQL, con);

             SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                return true;
            }
            

            return false;
        }
        private void Uye_Ol_Click(object sender, EventArgs e)
        {

            var üyeol = new Form2();
            üyeol.Show();

        }

        
    }
}
