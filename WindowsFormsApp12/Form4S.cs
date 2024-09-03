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
    public partial class Form4S : Form
    {
        public Form4S()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=userNikita;Initial Catalog=example;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void populateGrid()
        {
            Con.Open();
            string query = "select * from Table1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(" insert into Table1 values (N'" + textBox1.Text + "',  N'" + textBox2.Text + "', N'" + textBox4.Text + "', N'" + comboBox1.Text + "', N'" + comboBox2.Text + "', N'" + textBox3.Text + "') ", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Новый сотрудник успешно добавлен", "Сайт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    populateGrid();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "UPDATE Table1 SET   Name = N'" + textBox2.Text + "', Surname=@Surname,   Pol=@Pol,  Tel=@Tel ,Post=@Post Where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Surname", textBox4.Text);

            cmd.Parameters.AddWithValue("@Pol", comboBox1.Text);

            cmd.Parameters.AddWithValue("@Tel", textBox3.Text);
            cmd.Parameters.AddWithValue("@Post", comboBox2.Text);
            cmd.ExecuteNonQuery();
            Con.Close();
            populateGrid();
        }

        private void Form4S_Load(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }
   
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите индефикатор сотрудника", "Сайт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Con.Open();
                    string query = "delete from Table1 WHERE Id= '" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Cотрудник успешно удалён", "Сайт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    populateGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F2 = new Form2();
            F2.Show();
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

      
            private void dataGridView1_DoubleClick(object sender, EventArgs e)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();


            }
        }
    }

