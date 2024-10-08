using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemaGestaoEventos
{
    public partial class RemoveClienteForm : Form
    {
        private string conStr = Globals.strConn;
        private Form1 mainForm;
        public RemoveClienteForm(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
        }

        private void RemoveClienteForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int NIF))
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    try
                    {
                        con.Open();
                        string query = "EXEC RemoveCliente @NIF";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@NIF", NIF);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cliente removido com sucesso!");
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
                MessageBox.Show("NIF inválido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.displayClientes();
            this.Hide();
            mainForm.Show();
        }
    }
}
