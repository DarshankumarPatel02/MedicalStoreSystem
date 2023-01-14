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
    public partial class PurStock : Form
    {
        public PurStock()
        {
            InitializeComponent();
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            Display();
            comdisplay();
            storedisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlCommand sc = new SqlCommand("SELECT COUNT(*) FROM [Pstock] WHERE ([Stock_ID] = @id)", con);
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
                        SqlCommand cmd = new SqlCommand("Insert into Pstock(Stock_ID,COM_Name,MED_Name,Quantity,Stock_Received,Total_Available_Quantity) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + comboBox3.Text + "','"+textBox6.Text+"')", con);
                        cmd.ExecuteNonQuery();
                      //  textBox1.Text = textBox4.Text = textBox5.Text = "";
                        SqlCommand cmd1 = new SqlCommand("update Pstock set Stock_Received='" + true + "',Total_Available_Quantity='" + textBox6.Text + "' where Stock_ID='" + textBox1.Text + "'", con);
                        cmd1.ExecuteNonQuery();
                        Display();
                        ustore();
                        con.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                    else { }
                }
            }
           /* else
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                DialogResult dialogResult = MessageBox.Show("Are you sure to add these Stocks?", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("update Pstock set Stock_Received='"+true+"',Total_Available_Quantity='"+textBox6.Text+"' where Stock_ID='"+textBox1.Text+"'", con);
                    cmd.ExecuteNonQuery();
                    Display();
                    ustore();
                    con.Close();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }*/
        public void ustore()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("update STORE set Stock_Quantity='" + textBox6.Text + "' where MED_Name='" + comboBox2.Text + "'", con);
            adapt.Fill(dt);
        }
         public void Display()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Pstock", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView3.DataSource = dt;
            dataGridView1.DataSource = dt;
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
         public void storedisplay()
         {
             SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
             con.Open();
             DataTable dt = new DataTable();
             SqlDataAdapter adapt = new SqlDataAdapter("select * from STORE", con);
             DataSet ds = new DataSet();
             adapt.Fill(ds, "STORE");
             comboBox2.DisplayMember = "MED_Name";
             comboBox2.ValueMember = "MED_ID";
             comboBox2.DataSource = ds.Tables["STORE"];
         }
         private void PurStock_Load(object sender, EventArgs e)
         {
             // TODO: This line of code loads data into the 'database1DataSet20.Pstock' table. You can move, or remove it, as needed.
             this.pstockTableAdapter.Fill(this.database1DataSet20.Pstock);
             // TODO: This line of code loads data into the 'database1DataSet19.Pstock' table. You can move, or remove it, as needed.
           //  this.pstockTableAdapter2.Fill(this.database1DataSet19.Pstock);
             // TODO: This line of code loads data into the 'database1DataSet16.Pstock' table. You can move, or remove it, as needed.
         //    this.pstockTableAdapter1.Fill(this.database1DataSet16.Pstock);
             // TODO: This line of code loads data into the 'database1DataSet15.Pstock' table. You can move, or remove it, as needed.
        //     this.pstockTableAdapter.Fill(this.database1DataSet15.Pstock);
             comdisplay();
             storedisplay();
             Display();
         }

        
         private void button2_Click(object sender, EventArgs e)
         {
             if (textBox2.Text == "True")
             {
                 SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
                 con.Open();
                 DialogResult dialogResult = MessageBox.Show("Delete Data", "Edit changes", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     SqlDataAdapter da = new SqlDataAdapter("delete from Pstock where Stock_ID='" + textBox5.Text + "'", con);
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     if (dt.Rows.Count == 0)
                     {
                         MessageBox.Show("Data Deleted!!");
                         Display();
                         comdisplay();
                         storedisplay();
                         textBox1.Text = "";
                     }
                 }
                 else if (dialogResult == DialogResult.No)
                 {
                 }
             }
             else
             {
                 MessageBox.Show("Stock are not received yet so it can't be deleted!!!!!!");
             }
         }

         private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
             this.Hide();
         }

         private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
         {
             textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
             textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
         }
         private void dataGridView2_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
         {
             textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            // textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
             comboBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
             comboBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
             comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
         }

         private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
             ustore();
             ViewStock vs = new ViewStock();
             vs.Show();
             this.Hide();
         }

         private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
         {
             SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Darshan\\Documents\\Visual Studio 2010\\Projects\\MSP\\MSP\\Database1.mdf;Integrated Security=True;User Instance=True");
             con.Open();
             string query = "select * from STORE where MED_Name = '" + comboBox2.Text + "' ";
             SqlCommand cmd = new SqlCommand(query, con);
             SqlDataReader sdr = cmd.ExecuteReader();
             while (sdr.Read())
             {
                 string j = (string)sdr["Stock_Quantity"].ToString();
                 textBox3.Text = j;
                 
             }
         }

         private void textBox4_KeyUp(object sender, KeyEventArgs e)
         {
             textBox6.Text = (int.Parse(textBox3.Text) + int.Parse(textBox4.Text)).ToString();       
         }

         private void textBox3_TextChanged(object sender, EventArgs e)
         {

         }

         private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
         {
             ViewStock vs = new ViewStock();
             vs.Show();
         }

         private void textBox2_TextChanged(object sender, EventArgs e)
         {

         }
    }
}
