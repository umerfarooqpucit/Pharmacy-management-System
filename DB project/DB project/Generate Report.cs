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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer Farooq\Documents\Visual Studio 2012\Projects\DB project\DB project\database.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select p.p_id,p.pname,sum(s.quantity) quantity,sum(s.price) as 'gross sale',o.dated as date from products p, sub_order s ,order_details o  where p.pname='" + textBox1.Text + "' and s.p_id=p.p_id and s.o_id=o.id and (o.dated >='" + dateTimePicker1.Value.Date + "' and o.dated <='" + dateTimePicker2.Value.Date + "') group by p.p_id,o.dated,p.pname,s.price,s.quantity order by o.dated,s.price desc", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dt.Columns.Add("Sr #");
            dt.Columns["Sr #"].AutoIncrement = true;
            dt.Columns["Sr #"].AutoIncrementSeed = 1;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select p.p_id,p.pname,sum(s.quantity) quantity,sum(s.price) as 'gross sale',o.dated as date from products p, sub_order s ,order_details o  where s.p_id=p.p_id and o.id=s.o_id and (o.dated >='" + dateTimePicker1.Value.Date + "' and o.dated <='" + dateTimePicker2.Value.Date + "') group by p.p_id, p.pname,p.potency,s.price,o.dated order by o.dated,s.price desc", con);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dt.Columns.Add("Sr #");
            dt.Columns["Sr #"].AutoIncrement = true;
            dt.Columns["Sr #"].AutoIncrementSeed = 1;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
