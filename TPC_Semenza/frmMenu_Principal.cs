using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPC_Semenza
{
    public partial class frmMenu_Principal : Form
    {
        public frmMenu_Principal()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo_Test frmNuevo = new Nuevo_Test();
            frmNuevo.MdiParent = this;
            frmNuevo.Show();
        }

        private void buscarTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Testing frmBuscarTest = new Buscar_Testing();
            frmBuscarTest.MdiParent = this;
            frmBuscarTest.Show();
        }

        private void buscarTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Ticket frmBuscarTicket = new Buscar_Ticket();
            frmBuscarTicket.MdiParent = this;
            frmBuscarTicket.Show();
        }
    }
}
