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
    public partial class ViewCom : Form
    {
        public ViewCom()
        {
            InitializeComponent();
            Display();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCom ac = new AddCom();
            ac.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DelCom dc = new DelCom();
            dc.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ViewCom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet11.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.database1DataSet11.Company);
        }
        public void Display()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Company", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
