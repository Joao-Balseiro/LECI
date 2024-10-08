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
    public partial class OpeningMenu : Form
    {
        private Form1 areaCliente;
        private ReservaMenu areaReserva;
        private ManagerMenu areaManager;
        public OpeningMenu()
        {
            InitializeComponent();
            areaCliente = new Form1(this);
            areaReserva = new ReservaMenu(this);
            areaManager = new ManagerMenu(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            areaCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            areaReserva.displayReservas();
            areaReserva.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            areaManager.Show();
        }
    }
}
