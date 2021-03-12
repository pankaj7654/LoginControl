using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace login_control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-BA8E536\SQLEXPRESS;Initial Catalog=database2;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from login where username='"+textBox1.Text+"'and password='"+textBox2.Text+"'",cnn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                this.Hide();
                Form2 a = new Form2();
                a.Show();
            }
            else
            {
                MessageBox.Show("please check username and password");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }
    }
}
