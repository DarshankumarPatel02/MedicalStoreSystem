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
    public partial class UpdateStock : Form
    {
        public UpdateStock()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddStock ads = new AddStock();
            ads.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

        private void UpdateStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet4.STORE' table. You can move, or remove it, as needed.
            this.sTORETableAdapter.Fill(this.database1DataSet4.STORE);
            display();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == string.Empty) && (textBox2.Text == string.Empty) && (textBox2.Text == string.Empty))
            {
                MessageBox.Show("Enter Details to perform Edit operation!!!!!!");
            }
            else 
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to update these Stocks?", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from STORE where MED_Name='" + textBox3.Text+ "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Name!!!!!!!");
                    }
                    else
                    {
                        da = new SqlDataAdapter("update STORE set Stock_Quantity='" + textBox2.Text + "'where MED_Name='" + textBox3.Text + "'", con);
                        da.Fill(dt);
                        textBox1.Text = textBox2.Text= "";
                        display();                    
                    }
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox1.Text=row.Cells[3].Value.ToString();
            }
        }
        public void display()
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
