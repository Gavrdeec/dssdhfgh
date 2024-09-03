using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=userNikita;Initial Catalog=example;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void TextboxFilter()
        {
            Con.Open();
            string query = "select * from Table1 where Name  = '" + textBox1.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Con.Close();
        }
        public void TextboxFilter1()
        {
            Con.Open();
            string query = "select * from Table1 where Surname = '" + textBox1.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextboxFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextboxFilter1();
        }
    }
}
