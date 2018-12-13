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
    public partial class Pd_Expiry : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer Farooq\Documents\Visual Studio 2012\Projects\DB project\DB project\database.mdf;Integrated Security=True;Connect Timeout=30");
        public Pd_Expiry()
        {
            InitializeComponent();
        }

        private void Pd_Expiry_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select p_id as 'Product ID', pname as 'Product Name',quantity as 'Quatitity',potency as 'Potency'from products where exp>='" + dateTimePicker1.Value.Date + "' and  exp<='" + dateTimePicker2.Value.Date + "'", con);
            SqlDataAdapter sq = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Sr #");
            dt.Columns["Sr #"].AutoIncrement = true;
            dt.Columns["Sr #"].AutoIncrementSeed = 1;
            sq.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
