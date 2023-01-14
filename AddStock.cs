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
    public partial class AddStock : Form
    {
        public AddStock()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateStock us = new UpdateStock();
            us.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DelStock ds = new DelStock();
            ds.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewStock vs = new ViewStock();
            vs.Show();
            this.Hide();
        }
        public void comdisplay()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Company", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "Company");
            comboBox1.DisplayMember = "COM_Name";
            comboBox1.ValueMember = "COM_ID";
            comboBox1.DataSource = ds.Tables["Company"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sc= new SqlCommand("SELECT COUNT(*) FROM [STORE] WHERE ([MED_ID] = @id)", con);
            sc.Parameters.AddWithValue("@id", textBox1.Text);
            int UserExist = (int)sc.ExecuteScalar();
            if (UserExist > 0)
            {
                MessageBox.Show("Enter Other ID!!!!This ID Currently Exist.........");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to add these Stocks?", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                        SqlCommand cmd = new SqlCommand("Insert into STORE(MED_ID,MED_Name,MED_Price,Stock_Quantity,COM_Name,Location,Expiry_Date) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" +comboBox1.SelectedValue+ "','" +textBox5.Text+ "','" +dateTimePicker1.Value.Date+ "')",con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text ="";        
                        comboBox1.Text="";
                        Display();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Error");
                }   
            }
        }

        private void AddStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet5.STORE' table. You can move, or remove it, as needed.
            this.sTORETableAdapter.Fill(this.database1DataSet5.STORE);
            comdisplay();
        }
        public void Display()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from STORE", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        }
    }

