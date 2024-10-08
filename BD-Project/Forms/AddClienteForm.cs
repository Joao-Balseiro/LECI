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

namespace SistemaGestaoEventos
{
    public partial class AddClienteForm : Form
    {
        private string conStr = Globals.strConn;
        private Form1 mainForm;
        public AddClienteForm(Form1 form1)
        {
            InitializeComponent();
            displayClientes();
            mainForm = form1;
        }

        private void AddClienteForm_Load(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox1.Text, out int NIF) &&
                int.TryParse(textBox3.Text, out int NumTelef) 
                )
            {
                string Nome = textBox2.Text;
                string Endereco = textBox4.Text;
                string Email = textBox6.Text;

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    try
                    {
                        con.Open();
                        string query = "EXEC AdicionarCliente @NIF, @Nome, @NumTelef, @Endereco, @Email, @ReservaID, @CC";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@NIF", NIF);
                            cmd.Parameters.AddWithValue("@Nome", Nome);
                            cmd.Parameters.AddWithValue("@NumTelef", NumTelef);
                            cmd.Parameters.AddWithValue("@Endereco", Endereco);
                            cmd.Parameters.AddWithValue("@Email", Email);
                            if (!string.IsNullOrWhiteSpace(textBox7.Text))
                            {
                               int.TryParse(textBox7.Text, out int CC);
                               cmd.Parameters.AddWithValue("@CC", CC);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@CC", DBNull.Value);
                            }

                            if (!string.IsNullOrWhiteSpace(textBox5.Text))
                            {
                                int.TryParse(textBox5.Text, out int ReservaID);
                                cmd.Parameters.AddWithValue("@ReservaID", ReservaID);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@ReservaID", DBNull.Value);
                            }


                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cliente adicionado com sucesso!");
                        mainForm.displayClientes();

                        this.Hide();
                        mainForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error! " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Dados inseridos inválidos");
            }


        }
        public void displayClientes()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM SGE.Cliente";
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


        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.displayClientes();
            this.Hide();
            mainForm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
