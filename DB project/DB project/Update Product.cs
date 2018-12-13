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
    public partial class Update_Product : Form

    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer Farooq\Documents\Visual Studio 2012\Projects\DB project\DB project\database.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
   
        public Update_Product()
        {
            InitializeComponent();
        }

        private void Update_Product_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            MessageBox.Show("Record Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            con.Open();
            sda = new SqlDataAdapter(@"select * from products", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            sda = new SqlDataAdapter(@"select * from products where pname like '%" + textBox6.Text + "%'", con);
            dt = new DataTable();
            
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
