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
    public partial class Delete_Supplier : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer Farooq\Documents\Visual Studio 2012\Projects\DB project\DB project\database.mdf;Integrated Security=True;Connect Timeout=30");
        public Delete_Supplier()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count, count2;
            if (comboBox1.Text == "ID")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(id) from suppliers where id='" + textBox3.Text + "'", con);
                count = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();
                if (count == 1)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("delete from suppliers where  id='" + textBox3.Text + "'", con);
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
                SqlCommand cmd = new SqlCommand("select count(sname) from suppliers where sname='" + textBox3.Text + "'", con);
                count2 = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();
                if (count2 == 1)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("delete from suppliers where  sname='" + textBox3.Text + "' ", con);
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
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from suppliers", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();


        }

        private void Delete_Supplier_Load(object sender, EventArgs e)
        {
            //display_data();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from suppliers where id like '%" + textBox3.Text + "%'", con);
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
                SqlCommand cmd = new SqlCommand("select * from suppliers where sname like '%" + textBox3.Text + "%'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();




            }
        }
    }
}
