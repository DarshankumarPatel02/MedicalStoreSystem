﻿using System;
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
    public partial class DelCust : Form
    {
        public DelCust()
        {
            InitializeComponent();
           // display();
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
            ViewCust vc = new ViewCust();
            vc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                DialogResult dialogResult = MessageBox.Show("Delete Data", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlDataAdapter da = new SqlDataAdapter("delete from Customer where Cust_Name='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data Deleted!!");
                        display();
                        textBox1.Text = "";
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Customername/customer doesnot exist" + ex);
            }
        }
        public void display()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void DelCust_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet10.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.database1DataSet10.Customer);
            display();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
            }
        }
    }
}
