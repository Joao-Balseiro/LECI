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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemaGestaoEventos
{
    public partial class Form1 : Form
    {


        private string conStr = Globals.strConn;
        private EditClienteForm editClienteForm;
        private RemoveClienteForm removeClienteForm;
        private AddClienteForm addClienteForm;
        private OpeningMenu openingMenu;

        public Form1(OpeningMenu openingMenu)
        {
            InitializeComponent();
            displayClientes();
            this.openingMenu = openingMenu;
            editClienteForm = new EditClienteForm(this);
            removeClienteForm = new RemoveClienteForm(this);
            addClienteForm = new AddClienteForm(this);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addClienteForm.displayClientes();
            addClienteForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            removeClienteForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            editClienteForm.displayClientes();
            editClienteForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {   

            using (SqlConnection con = new SqlConnection(conStr))
            {
                
                try
                {
                    con.Open();
                    string query = "SELECT* FROM filtrarClientesPorReservaENifENome(@ReservaID, @NIF, @Name)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if(int.TryParse(textBox1.Text, out int ReservaID)){
                            cmd.Parameters.AddWithValue("@NIF", DBNull.Value);
                            cmd.Parameters.AddWithValue("@ReservaID", ReservaID);
                            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                        }
                        else
                        {
                            String Name = textBox1.Text;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            cmd.Parameters.AddWithValue("@ReservaID", DBNull.Value);
                            cmd.Parameters.AddWithValue("@NIF", DBNull.Value);
                        }

                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.Message);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM SGE.ClienteParticular"; //MUDAR PARA A VIEW?
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

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM SGE.ClienteEmpresa"; //MUDAR PARA A VIEW?
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

        private void button8_Click(object sender, EventArgs e)
        {
            displayClientes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            openingMenu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
