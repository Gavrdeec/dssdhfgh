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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=userNikita;Initial Catalog=example;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void Fetchemp()
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите Id сотрудника");
                }

                //  int idFromDatabase = 0;
                //  SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maksim\Documents\Personal.mdf;Integrated Security=True;Connect Timeout=30");

                // connection.Open();

                // string quer = "SELECT Id FROM Person"; // Замените на ваш запрос SQL
                // SqlCommand command = new SqlCommand(quer, connection);

                // SqlDataReader reader = command.ExecuteReader();
                // if (reader.Read())
                // {
                // idFromDatabase = reader.GetInt32(0); // Получаем число из столбца Id
                //    }
                //  //  if (  int.Parse(textBox1.Text) != idFromDatabase)
                // {
                //      MessageBox.Show("Такого сотрудника нет");
                //  }

                //Con.Open();
                string query = "select * from Table1 Where Id= '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["Name"].ToString();
                    textBox3.Text = dr["Post"].ToString();
                    textBox5.Text = dr["Surname"].ToString();
                }
                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Fetchemp();
        }
        double Dailybase;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {

                MessageBox.Show("Выберите сотрудника ", "Сайт", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      
            else

            {
                


                double total =  Convert.ToInt32(comboBox5.Text) * Convert.ToInt32(textBox4.Text);

                richTextBox1.Text = "Id сотрудника: " + textBox1.Text + "\n" + "Имя сотрудника: " + textBox2.Text + "\n" + "Фамилия сотрудника: " + textBox5.Text + "\n" + "Должность сотрудника: " + textBox3.Text + "\n" + "Робочих дней: " + comboBox5.Text + "\n" + "Рублей за день: " + textBox4.Text + "\n" + "К выдаче: " + total ;



                Con.Close();

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F2 = new Form2();
            F2.Show();
        }
    }
} 

