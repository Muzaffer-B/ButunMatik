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
    public partial class kuponlarım : Form
    {

        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();

        String _customerid;
        String _password;
        public kuponlarım(string customerid, string password)
        {
            InitializeComponent();
            _customerid = customerid;
            _password = password;
        }

        public string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";


        private void kuponlarım_Load(object sender, EventArgs e)
        {


            int id = find_id();

            String SQL = " select name,ürün,marka,fiyat,açıklama from kupon where CustomerID = '"+id+"' ";


            dataAdapter = new SqlDataAdapter(SQL, conString);


            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();

            dataAdapter.Fill(table);
            bindingSource1.DataSource = table;

            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);


            dataGridView1.DataSource = bindingSource1;
        }

        private int find_id()
        {
            int id = 0;

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select id from  UserInfo where CustomerID ='" + _customerid + "' and Password = '" + _password + "'";

            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetInt32(0);

                return id;
            }

            return id;


        }

        private string find_mail()
        {
            string id = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select mail from  UserInfo where CustomerID ='" + _customerid + "' and Password = '" + _password + "'";

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


        public  string getHtml(DataGridView grid)
        {
            try
            {
                string messageBody = "<font>Satın Alınan Kuponlar Aşağıda listelenmiştir: </font><br><br>";
                if (grid.RowCount == 0) return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style=\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";
                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart + " Name" + htmlTdEnd;
                messageBody += htmlTdStart + "ürün" + htmlTdEnd;
                messageBody += htmlTdStart + "marka" + htmlTdEnd;
                messageBody += htmlTdStart + "fiyat" + htmlTdEnd;
                messageBody += htmlTdStart + "açıklama" + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;
                //Loop all the rows from grid vew and added to html td  
                for (int i = 0; i <= grid.RowCount - 1; i++)
                {
                    messageBody = messageBody + htmlTrStart;
                    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[0].Value + htmlTdEnd; //adding student name  
                    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[1].Value + htmlTdEnd; //adding DOB  
                    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[2].Value + htmlTdEnd; //adding Email   
                    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[3].Value + htmlTdEnd; //adding Mobile  
                    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[4].Value + htmlTdEnd; //adding Mobile  
                    messageBody = messageBody + htmlTrEnd;
                }
                messageBody = messageBody + htmlTableEnd;
                return messageBody; // return HTML Table as string from this function  
                

            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public  void Email(string htmlString)
        {
            string mail = find_mail();

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("butunmatik@gmail.com");
                message.To.Add(new MailAddress(mail));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("butunmatik@gmail.com", "test-12345");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("mail iletildi");

            }
            catch (Exception)
            {
                MessageBox.Show("mail iletilemedi");
            }
        }

        private void mail_gönder_Click(object sender, EventArgs e)
        {
            string htmlString = getHtml(dataGridView1); //here you will be getting an html string  
            Email(htmlString); //Pass html string to Email function.  
        }
    }
}
