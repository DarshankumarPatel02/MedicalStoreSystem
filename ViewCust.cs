using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MSP
{
    public partial class ViewCust : Form
    {
        public ViewCust()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCust ac = new AddCust();
            ac.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DelCust dc = new DelCust();
            dc.Show();
            this.Hide();
        }

        private void ViewCust_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet12.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.database1DataSet12.Customer);
            Display();
        }
        public void Display()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

        }

    }
}
