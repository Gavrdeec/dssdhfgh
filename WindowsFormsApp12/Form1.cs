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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=userNikita;Initial Catalog=example;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            int i = 0;
            SqlCommand command = new SqlCommand(" select Log, Pass from [dbo].[Table] where Log = @Log and Pass = @Pass", con);
            command.Parameters.Add("@Log", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBox2.Text;
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dac = new SqlDataAdapter(command);
            dac.Fill(dt);
            DataSend.text = textBox2.Text;
            con.Close();


            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Неверный логин или пароль", "Сайт", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
               Form2 F2 = new Form2();
                F2.Show();
                MessageBox.Show("Авторизация прошла успешно", "Сайт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
