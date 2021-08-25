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
    public partial class Para_Yatır : Form
    {
        bool onayla = true;
        string password;
        string customerıd;
        private string data;
        public Para_Yatır(String _customerid,String _password)
        {

            InitializeComponent();
            customerıd = _customerid;
            password = _password;

            


        }

        int bakiye;

        public string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";

        private void button2_Click(object sender, EventArgs e)
        {

            //serialPort1.Write("1");

            try
            {
                serialPort1.PortName = "COM5";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();

            }
            catch
            {

            }
            /*
            for (int i = 0; i < 100; i++)
            {
                string para = serialPort1.ReadLine();
                int paraint = Int32.Parse(para);
                System.Diagnostics.Debug.WriteLine(paraint.ToString());
                if (paraint < 500)
                {
                    bakiye = bakiye + 10;

                    label3.Text = bakiye.ToString();

                    string newbakiye = getBalance();
                    int newbakiyeint = Int32.Parse(newbakiye);
                    label4.Text = (newbakiyeint + bakiye).ToString();
                }
                
            }*/


        }

        private void Para_Yatır_Load(object sender, EventArgs e)
        {
    
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataRecieved);
                     
        }

        private void SerialPort1_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displayData_event));
        }

        private void displayData_event(object sender, EventArgs e)
        {
            int paraint = Int32.Parse(data);

            if (paraint < 500)
            {
                bakiye = bakiye + 10;

                label3.Text = bakiye.ToString();

                string newbakiye = getBalance();
                int newbakiyeint = Int32.Parse(newbakiye);
                label4.Text = (newbakiyeint + bakiye).ToString();
            }
        }

        private void Para_Yatır_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

        private void kapa_Click(object sender, EventArgs e)
        {
            //serialPort1.Write("0");
            serialPort1.Close();
        }

        private int find_id()
        {
            int id = 0;

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select id from  UserInfo where CustomerID ='" + customerıd + "' and Password = '" + password + "'";

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
        private String getBalance()
        {
            String balance = "";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select bakiye from UserActivity left outer join UserInfo  on  UserInfo.id = UserActivity.id where CustomerID ='" + customerıd + "' and Password = '" + password + "'";

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

        private void button1_Click(object sender, EventArgs e)
        {
            onayla = false;
            int id = find_id();

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String updatebakiye = "Update UserActivity set bakiye = bakiye + " + bakiye + " where id = '" + id + "'";



            SqlCommand cmd3 = new SqlCommand(updatebakiye, con);


            cmd3.ExecuteNonQuery();


            MessageBox.Show("para Bakiyenize Eklenmiştir");
        }

        
    }
}
