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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace BütünMatik
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        FilterInfoCollection filtercollection;
        VideoCaptureDevice captureDevice;

        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();

        public string conString = "Data Source=DESKTOP-5HDJ4IR;Initial Catalog=ButunMatik;Integrated Security=True";


        private void Form7_Load(object sender, EventArgs e)
        {
            filtercollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filtercollection)
                cboDevice.Items.Add(filterInfo.Name);
            cboDevice.SelectedIndex = 0;

        }

        private void Scan_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filtercollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                BarcodeReader barcodereader = new BarcodeReader();
                Result result = barcodereader.Decode((Bitmap)pictureBox1.Image);
                if(result != null)
                {
                    textBox1.Text = result.ToString();

                    string firstid = textBox1.Text;
                    string id = firstid.Substring(0, 1);
                    string ürünkodu = firstid.Substring(1, 3);

                    //string satınalan = find_satınalan(ürünkodu);
                    //string alanid = find_name(Int32.Parse(satınalan));

                    String SQL = " select name,ürün,ürünkodu,stok,fiyat,valid from kuponalınanlar where satınalan = '" + id + "' and ürünkodu= '"+ürünkodu+"' ";


                    dataAdapter = new SqlDataAdapter(SQL, conString);

                    DataTable table = new DataTable();

                    dataAdapter.Fill(table);
                    bindingSource1.DataSource = table;

                    dataGridView1.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);


                    dataGridView1.DataSource = bindingSource1;

                    timer1.Stop();

                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }

        //private string find_satınalan(string ürünkodu)
        //{
        //    string id = "";

        //    SqlConnection con = new SqlConnection(conString);
        //    con.Open();

        //    String SQL = "   select satınalan from  kuponalınanlar where ürünkodu ='" + ürünkodu + "'";

        //    SqlCommand cmd = new SqlCommand(SQL, con);
        //    cmd.ExecuteNonQuery();

        //    SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        id = reader.GetString(0);

        //        return id;
        //    }

        //    return id;


        //}

        //private string find_name(int id)
        //{
        //    string name = "";

        //    SqlConnection con = new SqlConnection(conString);
        //    con.Open();

        //    String SQL = "   select name from  UserInfo where id ='" + id + "'";

        //    SqlCommand cmd = new SqlCommand(SQL, con);
        //    cmd.ExecuteNonQuery();

        //    SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        name = reader.GetString(0);

        //        return name;
        //    }

        //    return name;


        //}
    }
}
