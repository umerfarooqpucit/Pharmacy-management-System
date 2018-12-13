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
    public partial class Make_Sale : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Umer Farooq\Documents\Visual Studio 2012\Projects\DB project\DB project\database.mdf;Integrated Security=True;Connect Timeout=30");
        int count;
        public Make_Sale()
        {
            InitializeComponent();
        }
        public void display_srno()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(id) from order_details", con);
            count = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            textBox5.Text = "" + count;
        }

        private void Make_Sale_Load(object sender, EventArgs e)
        {
            display_srno();
            

            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd1.Connection = con;
            cmd1.CommandText = "select p_id,pname,potency,quantity,retailunitprice as 'unit price',mfg,exp from products";
            sda.SelectCommand = cmd1;
            dt.Clear();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Salesman s1 = new Salesman();
            s1.Show();
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select p_id, pname,potency,quantity,retailunitprice as 'unit price',mfg,exp from products where pname like '%" + textBox1.Text + "%'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter a Valid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            else
            {
                SqlCommand cm = new SqlCommand("select quantity from products where p_id='" + textBox6.Text + "'", con);
                int quan = Convert.ToInt16(cm.ExecuteScalar());
                if (quan >= Convert.ToInt16( textBox2.Text) && quan!=0)
                {
                    SqlCommand cm1 = new SqlCommand("select retailunitprice from products where p_id='" + textBox6.Text + "'", con);
                    double price = Convert.ToDouble(cm1.ExecuteScalar());
                    price *= Convert.ToDouble(textBox2.Text);
                    double discount = price / 100 * (Convert.ToDouble(textBox3.Text));
                    textBox7.Text = Convert.ToString(Convert.ToDouble(textBox7.Text) + (price - discount));
                    SqlCommand cmd = new SqlCommand("insert into sub_order (p_id,o_id,quantity,discount,price) values ( '" + textBox6.Text + "','" + (count) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + (price - discount) + "')", con);
                    cmd.ExecuteNonQuery();
                    cm1 = new SqlCommand("select p.pname as 'product name',s.quantity,s.discount,s.price from products p,sub_order s where s.p_id=p.p_id and o_id='" + (count) + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cm1);

                    DataTable dt = new DataTable();


                    dt.Columns.Add("Sr #");
                    dt.Columns["Sr #"].AutoIncrement = true;
                    dt.Columns["Sr #"].AutoIncrementSeed = 1;
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                    textBox1.Clear();
                    textBox2.Text = "" + 0; 
                    textBox3.Text = "" + 0;

                    textBox6.Clear();
                }
                else if(quan==0)
                {
                    con.Close();
                    MessageBox.Show("Product is out of Stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Text = "" + 0;
                    textBox3.Text = "" + 0;

                    textBox6.Clear();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("Enter Valid Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Text = "" + 0;
                    textBox3.Text = "" + 0;

                    textBox6.Clear();
                }
            }
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd1.Connection = con;
            cmd1.CommandText = "select p_id,pname,potency,quantity,retailunitprice as 'unit price',mfg,exp from products";
            sda.SelectCommand = cmd1;
            dt.Clear();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            if (dataGridView2.DataSource != null)
            {
                SqlCommand cmd = new SqlCommand("delete from sub_order where o_id='" + count + "'", con);
                cmd.ExecuteNonQuery();
            }
            dataGridView2.DataSource = null;
            textBox7.Text = "" + 0;
            
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource != null)
            {
                con.Open();
                dataGridView2.DataSource = null;
                MessageBox.Show("Sale Successful.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //SqlCommand cmd = new SqlCommand("update order_details values('" + count + "','" + dateTimePicker1.Value.Date + "', (select sum(quantity) from sub_order where o_id='" + (count) + "'),'" + textBox4.Text + "',(select sum(price) from sub_order where o_id='" + (count) + "')) where id='"+count+"'", con);
                SqlCommand cmd = new SqlCommand("update order_details set id='" + count + "', dated='" + dateTimePicker1.Value.Date + "', quantity= (select sum(quantity) from sub_order where o_id='" + (count) + "'), customer='" + textBox4.Text + "', gross_amount=(select sum(price) from sub_order where o_id='" + (count) + "'),sal_id='" + textBox8.Text + "'  where order_details.id='" + count + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update products set products.quantity=(products.quantity-sub_order.quantity) from products,sub_order where products.p_id=sub_order.p_id and sub_order.o_id='" + (count) + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("insert into order_details (id) values('" + (count + 1) + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                display_srno();
                textBox7.Text = "" + 0;
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Invoice is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            //cmd = new SqlCommand("select count(sub_id) from sub_order", con);
            //int rows = Convert.ToInt16(cmd.ExecuteScalar());
            //while (rows > 0)
            //{
            //    cmd=new SqlCommand("select o_id from sub_order where o_id='"+(count-1)+"'",con);
            //}



        
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
