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
    public partial class AddCom : Form
    {
        public AddCom()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand sc = new SqlCommand("SELECT COUNT(*) FROM [Company] WHERE ([COM_ID] = @id)", con);
            sc.Parameters.AddWithValue("@id", textBox5.Text);
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
                    SqlCommand cmd = new SqlCommand("Insert into Company(COM_ID,COM_Name,COM_Address,COM_Contact,COM_O_Name) values ('" + textBox5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DelCom dc = new DelCom();
            dc.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewCom vc = new ViewCom();
            vc.Show();
            this.Hide();
        }

        private void AddCom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet8.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.database1DataSet8.Company);
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
