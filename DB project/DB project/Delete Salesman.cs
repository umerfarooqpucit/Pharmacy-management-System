using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_project
{
    public partial class Delete_Salesman : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer Farooq\Documents\Visual Studio 2012\Projects\DB project\DB project\database.mdf;Integrated Security=True;Connect Timeout=30");
        public Delete_Salesman()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int count, count2;
            if (comboBox1.Text == "ID")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(id) from accounts where id='" + textBox1.Text + "'", con);
                count = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();
                if (count == 1)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("delete from accounts where  id='" + textBox1.Text + "'", con);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    display_data();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("There is no such record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else if (comboBox1.Text == "Name")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(fname) from accounts where fname='" + textBox1.Text + "'", con);
                count2 = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();
                if (count2 == 1)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("delete from accounts where  fname='" + textBox1.Text + "' ", con);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    display_data();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("There is no such record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Choose a Valid Value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Close();
        }
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from accounts where status='salesman'", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();


        }

        private void Delete_Salesman_Load(object sender, EventArgs e)
        {
            //display_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from accounts where status='salesman' and id like '%" + textBox1.Text + "%'", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            else if (comboBox1.Text == "Name")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from accounts where status='salesman' and fname like '%" + textBox1.Text + "%'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();




            }
        }
    }
}
