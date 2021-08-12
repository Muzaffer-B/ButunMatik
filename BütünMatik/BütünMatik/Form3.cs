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
    public partial class KullanıcıArayüz : Form
    {

        public string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";


        string Customerıd;
        string _Password;
        public KullanıcıArayüz(String CustomerID,String Password)
        {
            InitializeComponent();
            Customerıd = CustomerID;
            _Password = Password;
            
        }

        private void KullanıcıArayüz_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "    select UserInfo.name, UserInfo.surname, bakiye,kupon from UserActivity left outer join  UserInfo on  UserInfo.id = UserActivity.id where  CustomerID ='"+Customerıd+"' and Password = '"+_Password+"'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();



            label1.Text = getBalance();
            kupon.Text = getKupon();

            

            if(Int32.Parse(kupon.Text) == 0)
            {
                kupon.Text = "Kuponunuz Bulunmamaktadır";
            }
            else
            {
                kupon.Text = getKupon();

            }
        }

        private String getBalance()
        {
            String balance = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select bakiye from UserActivity left outer join UserInfo  on  UserInfo.id = UserActivity.id where CustomerID ='" + Customerıd + "' and Password = '" + _Password + "'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                balance = reader.GetString(0);

                return balance;
            }


            return balance;
        }

        private String getKupon()
        {
            String balance = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select kupon from UserActivity left outer join UserInfo  on  UserInfo.id = UserActivity.id where  CustomerID ='" + Customerıd + "' and Password = '" + _Password + "'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                balance = reader.GetString(0);

                return balance;
            }


            return balance;
        }

        private void kupon_al(object sender,EventArgs e)
        {

            var kupon_al = new Form4(Customerıd,_Password);
            kupon_al.Show();

            this.Close();

        }

        private void kuponlarım(object sender, EventArgs e)
        {
            kuponlarım kupon = new kuponlarım(Customerıd, _Password);
            kupon.Show();
            this.Close();
        }
    }
}
