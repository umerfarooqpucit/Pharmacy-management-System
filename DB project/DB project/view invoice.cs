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
    public partial class view_invoice : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer Farooq\Documents\Visual Studio 2012\Projects\DB project\DB project\database.mdf;Integrated Security=True;Connect Timeout=30");
        public view_invoice()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select p.p_id,p.pname,p.potency,s.quantity,s.price,s.discount,o.gross_amount as 'Net Bill',o.customer,o.dated as date from products p, sub_order s ,order_details o  where o.id='"+textBox6.Text+"' and s.p_id=p.p_id and s.o_id=o.id", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dt.Columns.Add("Sr #");
            dt.Columns["Sr #"].AutoIncrement = true;
            dt.Columns["Sr #"].AutoIncrementSeed = 1;
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
