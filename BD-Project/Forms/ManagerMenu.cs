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
    public partial class ManagerMenu : Form
    {
        private string conStr = Globals.strConn;
        private AddWorker addWorker;
        private OpeningMenu openingMenu;
        public ManagerMenu(OpeningMenu openingMenu)
        {
            InitializeComponent();
            displayClientes();
            addWorker = new AddWorker(this);
            this.openingMenu = openingMenu;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void displayClientes()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM SGE.Manager";
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

        private void ManagerMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addWorker.displayClientes();
            this.Hide();
            addWorker.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openingMenu.Show();
            this.Hide();
        }
    }
}
