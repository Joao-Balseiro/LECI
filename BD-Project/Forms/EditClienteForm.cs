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
    public partial class EditClienteForm : Form
    {
        private string conStr = Globals.strConn;
        private Form1 mainForm;
        public EditClienteForm(Form1 form1)
        {
            InitializeComponent();
            displayClientes();
            mainForm = form1;
        }

        private void EditClienteForm_Load(object sender, EventArgs e)
        {

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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.displayClientes();
            this.Hide();
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string NIFText = " ";
            string Nome = " ";
            string NumTelefText = " ";
            string Endereco = " ";
            string ReservaIDText = " ";
            string Email = " ";
            
            using (SqlConnection con = new SqlConnection(conStr))
                {
                    try
                    {
                        con.Open();
                        string query = "EXEC EditarCliente @NIF, @Nome, @NumTelef, @Endereco, @ReservaID, @Email";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {

                        NIFText = textBox1.Text;
                        int NIFInt = int.Parse(NIFText);
                        cmd.Parameters.AddWithValue("@NIF", NIFInt);

                        if (!string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            Nome = textBox2.Text;
                            cmd.Parameters.AddWithValue("@Nome", Nome);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Nome", DBNull.Value);
                        }
                        if (!string.IsNullOrWhiteSpace(textBox3.Text)) { 
                            NumTelefText = textBox3.Text;
                            int NumTelefInt = int.Parse(NumTelefText);
                            cmd.Parameters.AddWithValue("@NumTelef", NumTelefInt);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@NumTelef", DBNull.Value);
                        }
                        if (!string.IsNullOrWhiteSpace(textBox4.Text)) { 
                            Endereco = textBox4.Text;
                            cmd.Parameters.AddWithValue("@Endereco", Endereco);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Endereco", DBNull.Value);
                        }
                        if (!string.IsNullOrWhiteSpace(textBox5.Text))
                        {
                            ReservaIDText = textBox3.Text;
                            int ReservaIDInt = int.Parse(ReservaIDText);
                            cmd.Parameters.AddWithValue("@ReservaID", ReservaIDInt);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ReservaID", DBNull.Value);
                        }
                        if (!string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            Email = textBox6.Text;
                            cmd.Parameters.AddWithValue("@Email", Email);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                        }
                        

                        cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cliente editado com sucesso!");
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
    }
}
