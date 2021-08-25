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

namespace BütünMatik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";

        private void Uye_Ol_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string number = textBox3.Text;
            string kullanıcıadı = textBox4.Text;
            string password = textBox5.Text;
            string mail = textBox6.Text;


            if (name != null && surname != null && number != null && password != null && kullanıcıadı != null && mail != null)
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();


                bool mail_Duplicate = mail_duplicate(mail);
                bool kullanıcı_Duplicate = kullanıcıadı_duplicate(kullanıcıadı);
                if (con.State == System.Data.ConnectionState.Open && mail_Duplicate && kullanıcı_Duplicate)
                {
                    string connection = "insert into UserInfo(name,surname,number,CustomerID,Password,mail) values('"+name+"','"+surname+"','"+number+"','"+kullanıcıadı+"','"+password+"','"+mail+"')";
                    string useractivity = "insert into UserActivity(name,surname,bakiye,kupon) values('" + name + "','" + surname + "','" + 0 + "','" + 0 + "')";
                    SqlCommand cmd = new SqlCommand(connection, con);
                    SqlCommand usercmd = new SqlCommand(useractivity, con);
                    cmd.ExecuteNonQuery();
                    usercmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Olundu");
                    this.Close();
                }
                if(mail_Duplicate == false && kullanıcı_Duplicate == true)
                {
                    MessageBox.Show("Mail Zaten Sisteme Kayıtlı");
                }
                if (mail_Duplicate == true && kullanıcı_Duplicate == false)
                {
                    MessageBox.Show("Kullanıcı Adı Zaten Sisteme Kayıtlı");
                }
                if (mail_Duplicate == false && kullanıcı_Duplicate == false)
                {
                    MessageBox.Show("Kullanıcı Adı ve Mail Zaten Sisteme Kayıtlı");
                }

                
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Doldurunuz");
            }
        }


        private bool mail_duplicate(string mail)
        {


            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select mail from  UserInfo ";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string x = reader.GetString(0).Trim();

                if (mail == x)
                {
                    return false;
                }


            }

            return true;
        }

        private bool kullanıcıadı_duplicate(string kullanıcı)
        {


            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select CustomerID from  UserInfo ";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string x = reader.GetString(0).Trim();

                if (kullanıcı == x)
                {
                    return false;
                }


            }

            return true;
        }
    }
}
