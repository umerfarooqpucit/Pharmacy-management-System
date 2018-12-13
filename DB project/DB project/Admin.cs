using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_project
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_product ad1 = new Add_product();
            ad1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete_Product d1 = new Delete_Product();
            d1.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update_Product u1 = new Update_Product();
            u1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Salesman s1 = new Add_Salesman();
            s1.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Delete_Salesman d1 = new Delete_Salesman();
            d1.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Update_Salesman u1 = new Update_Salesman();
            u1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Supplier s1 = new Add_Supplier();
            s1.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Delete_Supplier d1p = new Delete_Supplier();
            d1p.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Update_Supplier u1=new Update_Supplier();
            u1.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            view_invoice v1 = new view_invoice();
            v1.Show();
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Pd_Expiry p = new Pd_Expiry();
            p.Show();
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
