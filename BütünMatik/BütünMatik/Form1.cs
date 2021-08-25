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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace BütünMatik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        FilterInfoCollection filtercollection;
        VideoCaptureDevice captureDevice;

        private void Form1_Load(object sender, EventArgs e)
        {

            //serialPort1.PortName = "COM5";
            //serialPort1.BaudRate = 9600;
            //serialPort1.Open();
            //button2.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            label1.Visible = false;
            this.ControlBox = false;
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

            if (captureDevice!= null &&  captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
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

                    this.Visible = false;
                    
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

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox2.Image = null;
            filtercollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            captureDevice = new VideoCaptureDevice(filtercollection[1].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox2.Image = (Bitmap)eventArgs.Frame.Clone();
        }

       

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                BarcodeReader barcodereader = new BarcodeReader();
                Result result = barcodereader.Decode((Bitmap)pictureBox2.Image);
                if (result != null)
                {
                    string hash = result.ToString();
                    string customerId = getcustomer(hash).Trim();
                    string password = getpassword(hash).Trim();

                    
                    bool customerexist = customerExist(customerId, password);

                    if(customerexist == true)
                    {
                        KullanıcıArayüz arayüz = new KullanıcıArayüz(customerId, password);
                        pictureBox2.Visible = false;

                        arayüz.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Bulunamadı");
                    }



                    timer1.Stop();

                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }

        private string getcustomer(string hash)
        {
            string customerID = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select CustomerID from  UserInfo where hashcode ='" + hash +"'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customerID = reader.GetString(0);

                return customerID;
            }

            return customerID;
        }

        private string getpassword(string hash)
        {
            string Password = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select Password from  UserInfo where hashcode ='" + hash + "'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Password = reader.GetString(0);

                return Password;
            }

            return Password;
        }

        private bool customerExist(string customerid,string pasword)
        {


            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select CustomerID,Password from  UserInfo where CustomerID = '"+customerid+"' and Password = '"+pasword+"' ";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string customerID = reader.GetString(0).Trim();
                string Password = reader.GetString(1).Trim();

                if (customerid == customerID && pasword == Password)
                {
                    return true;
                }


            }

            return false;
        }
    }
}
