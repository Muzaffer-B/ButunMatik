using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        private void Para_Yatır(object sender, EventArgs e)
        {
            Para_Yatır parayatır = new Para_Yatır(Customerıd,_Password);
            parayatır.Show();
        }

        

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            Form7 scan = new Form7();
            scan.Show();
        }


        private string find_mail()
        {
            string id = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select mail from  UserInfo where CustomerID ='" + Customerıd + "' and Password = '" + _Password + "'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetString(0);

                return id;
            }

            return id;


        }

        public void Email( string savepoint)
        {
            string mail = find_mail();

            try
            {


                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                AlternateView aw = AlternateView.CreateAlternateViewFromString(message.Body + "<br/><img src=cid:imgpath height=300 width=300/>", null, "text/html");
                LinkedResource link = new LinkedResource(savepoint);
                link.ContentId = "imgpath";
                aw.LinkedResources.Add(link);


                message.From = new MailAddress("butunmatik@gmail.com");
                message.To.Add(new MailAddress(mail));
                message.Subject = "QR kodunuz";
                message.IsBodyHtml = true; //to make message body as html  
                message.AlternateViews.Add(aw);
                message.Body =  link.ContentId;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("butunmatik@gmail.com", "test-12345");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("QR kod Mailinize iletildi");
            }
            catch (Exception)
            {
                MessageBox.Show("mail iletilemedi");
            }
        }

        private void qrcodebutton_Click(object sender, EventArgs e)
        {

            string hash = gethashcode().Trim();


            if (hash == "eklenmemis")
            {
                PictureBox picture = new PictureBox();
                Random r = new Random();

                string savepoint = "";
                int hashcode = 0;

                     int randomnumber = r.Next(1, 999999999);

                    QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                    var mydata = QG.CreateQrCode(randomnumber.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
                    var code = new QRCoder.QRCode(mydata);
                    picture.Image = code.GetGraphic(50);

                



                Image image;
                image = picture.Image;

                SqlConnection con = new SqlConnection(conString);
                con.Open();

                bool duplicatecheck = hash_duplicate(randomnumber.ToString());
                if (con.State == System.Data.ConnectionState.Open && duplicatecheck == true)
                {
                    string connection = "Update UserInfo set  hashcode = '"+randomnumber+"' where CustomerID = '"+Customerıd+"' and Password ='"+_Password+"'";

                    SqlCommand cmd = new SqlCommand(connection, con);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    qrcodebutton_Click(sender, e);
                }
                

                
                if (image != null)
                {
                    image.Save("C:/Users/muzo6/OneDrive/Masaüstü/QRCODES/" + hashcode +".jpeg");
                    savepoint = "C:/Users/muzo6/OneDrive/Masaüstü/QRCODES/" + hashcode + ".jpeg";

                }
                 Email(savepoint);
            }
            else
            {
                MessageBox.Show("Zaten QR kodunuz Bulunmaktadır\n\n \t Mailinize bakınız");
            }
        }
            
            

        private string gethashcode()
        {
            string hash = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select hashcode from  UserInfo where CustomerID ='" + Customerıd + "' and Password = '" + _Password + "'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                hash = reader.GetString(0);

                return hash;
            }

            return hash;
        }

        private bool hash_duplicate(string hashcode)
        {
           

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select hashcode from  UserInfo ";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string x = reader.GetString(0).Trim();

                if(hashcode == x)
                {
                    return false;
                }

                
            }

            return true;
        }
    }
}
