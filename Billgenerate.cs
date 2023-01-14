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
    public partial class Billgenerate : Form
    {
        public Billgenerate()
        {
            InitializeComponent();
        }

        private void Billgenerate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet18.Bill' table. You can move, or remove it, as needed.
            this.billTableAdapter.Fill(this.database1DataSet18.Bill);
            // TODO: This line of code loads data into the 'database1DataSet17.Bill' table. You can move, or remove it, as needed.
           // this.billTableAdapter.Fill(this.database1DataSet17.Bill);
            // TODO: This line of code loads data into the 'database1DataSet131.Bill' table. You can move, or remove it, as needed.
            //this.billTableAdapter1.Fill(this.database1DataSet131.Bill);
            // TODO: This line of code loads data into the 'database1DataSet13.Bill' table. You can move, or remove it, as needed.
          //  this.billTableAdapter.Fill(this.database1DataSet13.Bill);
            comdisplay();
            storedisplay();
            groupBox1.Visible = false;
        }
        public void comdisplay()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "Customer");
            comboBox1.DisplayMember = "Cust_Name";
            comboBox1.ValueMember = "Cust_Name";
            comboBox1.DataSource = ds.Tables["Customer"];
        }
        public void storedisplay()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from STORE", con);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "STORE");
            comboBox2.DisplayMember = "MED_Name";
            comboBox2.ValueMember = "MED_NAME";
            comboBox2.DataSource = ds.Tables["STORE"];
            SqlDataAdapter adapt1 = new SqlDataAdapter("select * from STORE where MED_Name='"+comboBox2.SelectedValue+"'", con);
            DataSet ds1 = new DataSet();
            adapt1.Fill(ds1, "STORE"); 
            comboBox3.DisplayMember = "COM_Name";
            comboBox3.ValueMember = "MED_ID";
            comboBox3.DataSource = ds.Tables["STORE"];
        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            string query = "select * from STORE where MED_Name = '"+comboBox2.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string j = (string)sdr["Stock_Quantity"].ToString();
                string k = (string)sdr["MED_Price"].ToString();
                string l = (string)sdr["COM_Name"].ToString();
                textBox2.Text = j;
                textBox3.Text = k;
                comboBox3.Text = l;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
                if(Convert.ToInt32(textBox2.Text)>=(Convert.ToInt32(textBox1.Text)))
                {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                DialogResult dialogResult = MessageBox.Show("Are you sure to generate bills?", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("Insert into Bill(Cust_Name,MED_Name,Required_Quantity,Stock_Quantity,MED_TPrice,Stock_Remaining,COM_Name) values ('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + textBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text +"','" + textBox5.Text + "','" + comboBox3.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                  //  textBox1.Text = textBox2.Text = textBox3.Text = "";
                    Display();
                    ustore();
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
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Bill", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void ustore()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("update Store set Stock_Quantity='"+textBox5.Text+"' where MED_Name='"+comboBox2.Text+"'", con);
            adapt.Fill(dt);
        }
     /*   private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox5.Text = (float.Parse(textBox2.Text) - (float.Parse(textBox1.Text))).ToString();       
            textBox4.Text = (float.Parse(textBox3.Text) * (float.Parse(textBox1.Text))).ToString();
        }*/

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewStock vs = new ViewStock();
            vs.Show();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Text = "BILL TO:'" + comboBox1.Text + "'";
            label10.Text="MEDICINE:'"+comboBox2.Text+"'";
            label11.Text="QUANTITY:'"+textBox1.Text+"'";
            groupBox1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = (float.Parse(textBox2.Text) - (float.Parse(textBox1.Text))).ToString();
            textBox4.Text = (float.Parse(textBox3.Text) * (float.Parse(textBox1.Text))).ToString();
        }
    }
}
