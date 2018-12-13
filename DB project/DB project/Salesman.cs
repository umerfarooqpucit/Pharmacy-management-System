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
    public partial class Salesman : Form
    {
        public Salesman()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search_Products s1 = new Search_Products();
            s1.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Make_Sale m1 = new Make_Sale();
            m1.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
