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
    public partial class ViewStock : Form
    {
        public ViewStock()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddStock ads=new AddStock();
            ads.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateStock us = new UpdateStock();
            us.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DelStock ds = new DelStock();
            ds.Show();
            this.Hide();
        }

        private void ViewStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.STORE' table. You can move, or remove it, as needed.
            this.sTORETableAdapter.Fill(this.database1DataSet3.STORE);
            display();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display();
        }
        public void display()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from STORE", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EndEdit();
            dataGridView1.Parent.Refresh();
            dataGridView1.Refresh();
        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display();
        }
    }
}
