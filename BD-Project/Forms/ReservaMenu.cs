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
    public partial class ReservaMenu : Form
    {
        private string conStr = Globals.strConn;
        private OpeningMenu openingMenu;
        public ReservaMenu(OpeningMenu openingMenu)
        {
            InitializeComponent();
            displayReservas();
            this.openingMenu = openingMenu;
        }

        public void displayReservas()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM SGE.ReservaPagamento";
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

        private void ReservaMenu_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openingMenu.Show();
            this.Hide();
        }
    }
}
