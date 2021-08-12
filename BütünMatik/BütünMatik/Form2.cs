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

        private void Uye_Ol_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string number = textBox3.Text;
            string kullanıcıadı = textBox4.Text;
            string password = textBox5.Text;
            string mail = textBox6.Text;

            string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";

            if (name != null && surname != null && number != null && password != null && kullanıcıadı != null && mail != null)
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string connection = "insert into UserInfo(name,surname,number,CustomerID,Password,mail) values('"+name+"','"+surname+"','"+number+"','"+kullanıcıadı+"','"+password+"','"+mail+"')";
                    string useractivity = "insert into UserActivity(name,surname,bakiye,kupon) values('" + name + "','" + surname + "','" + 0 + "','" + 0 + "')";
                    SqlCommand cmd = new SqlCommand(connection, con);
                    SqlCommand usercmd = new SqlCommand(useractivity, con);
                    cmd.ExecuteNonQuery();
                    usercmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Olundu");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Doldurunuz");
            }
        }
    }
}
