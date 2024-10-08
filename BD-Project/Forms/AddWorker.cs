using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaGestaoEventos
{
    public partial class AddWorker : Form
    {
        private string conStr = Globals.strConn;
        private ManagerMenu managerMenu;
        public AddWorker(ManagerMenu managerMenu)
        {
            InitializeComponent();
            displayClientes();
            this.managerMenu = managerMenu;
        }

        public void displayClientes()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM SGE.Empregado";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.Message);
                }
            }
        }

        private void AddWorker_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int CC) &&
                int.TryParse(textBox2.Text, out int ManagerCC) &&
                int.TryParse(textBox3.Text, out int NIF) &&
                int.TryParse(textBox4.Text, out int Salario)
                )
            {
                string Trabalho = textBox5.Text;

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    try
                    {
                        con.Open();
                        string query = "INSERT INTO SGE.Empregado VALUES(@CC, @ManagerCC, @NIF, @Trabalho, @Salario)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@NIF", NIF);
                            cmd.Parameters.AddWithValue("@ManagerCC", ManagerCC);
                            cmd.Parameters.AddWithValue("@CC", CC);
                            cmd.Parameters.AddWithValue("@Trabalho", Trabalho);
                            cmd.Parameters.AddWithValue("@Salario", Salario);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Empregado adicionado com sucesso!");
                        managerMenu.displayClientes();

                        this.Hide();
                        managerMenu.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error! " + ex.Message);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            managerMenu.displayClientes();
            this.Hide();
            managerMenu.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
