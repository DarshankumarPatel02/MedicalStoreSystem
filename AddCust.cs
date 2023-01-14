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
    public partial class AddCust : Form
    {
        public AddCust()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DelCust dc = new DelCust();
            dc.Show();
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
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sc = new SqlCommand("SELECT COUNT(*) FROM [Customer] WHERE ([CUST_ID] = @id)", con);
            sc.Parameters.AddWithValue("@id", textBox6.Text);
            int UserExist = (int)sc.ExecuteScalar();
            if (UserExist > 0)
            {
                MessageBox.Show("Enter Other ID!!!!This ID Currently Exist.........");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to add these Customer?", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("Insert into Customer(CUST_ID,Cust_Name,Cust_Surname,Cust_Contact,Cust_Address,Cust_City) values ('" + textBox6.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                    textBox6.Text = "";
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
        public void Display()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void AddCust_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet7.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.database1DataSet7.Customer);

        }
    }
}
