using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BütünMatik
{
    public partial class Form4 : Form
    {

        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();

        String _customerid;
        String _password;

        public Form4(String customerid,String password)
        {
            InitializeComponent();
            _customerid = customerid;
            _password = password;
        }

        public string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";

        private void Form4_Load(object sender, EventArgs e)
        {

            String SQL = " select name,ürün,marka,fiyat,açıklama,stok from kupon";


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

        private void kupon_sec(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if(e.ColumnIndex == 0)
            {
                MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) +
              "  Column check box clicked ");
            }*/
        }

        private void Kupon_al_Click(object sender, EventArgs e)
        {
            string bakiye = find_bakiye();
            int customerbakiye = Int32.Parse(bakiye);



            for (int i =0;i < dataGridView1.Rows.Count -1; i++)
            {
                bool isSelected = Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value);


                int bakiyee = Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string ürün = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string marka = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string açıklama = dataGridView1.Rows[i].Cells[5].Value.ToString();

                int stok = Int32.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());

                if (isSelected && customerbakiye > bakiyee && stok >0 )
                {
                    int id = find_id();

                    Random r = new Random();

                    SqlConnection con = new SqlConnection(conString);
                    con.Open();

                    String SQL = " insert into kuponalınanlar(name,ürün,ürünkodu,stok,fiyat,satınalan) values ('"+name+"','"+ürün+"','"+r.Next(100,1000)+"', '"+stok+"','"+bakiyee+"','"+id+"')";
                    String updatekupon = "Update UserActivity set kupon = kupon + 1 where id = '"+id+"'";
                    String updatebakiye = "Update UserActivity set bakiye = bakiye - "+ bakiyee+" where id = '"+id+"'";
                    String Updatestok = "Update kupon set stok = stok -1 where id = '"+(i+1)+"'";

                    SqlCommand cmd = new SqlCommand(SQL, con);
                    SqlCommand cmd2 = new SqlCommand(updatekupon, con);
                    SqlCommand cmd3 = new SqlCommand(updatebakiye, con);
                    SqlCommand cmd4 = new SqlCommand(Updatestok, con);

                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();

                    MessageBox.Show("ürün Alınmıştır");
                }if(isSelected && stok <= 0)
                {
                    MessageBox.Show("Üründe Stok kalmamıştır.");
                }
                

            }
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
        private string find_bakiye()
        {
            string id = "";
            int idd = find_id();

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            String SQL = "   select bakiye from  UserActivity where id = '"+idd+"'";

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
    }


    }

