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
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        //FUNCION PARA AGREGAR VENTANA A UN PANEL
        private void AddFormInPanel(object formHijo)
        {
            if (this.panelVentanas.Controls.Count > 0)
                this.panelVentanas.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelVentanas.Controls.Add(fh);
            this.panelVentanas.Tag = fh;
            fh.Show();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            btnVolver.Visible = false;
            btnAgregarDatos.Visible = false;
            btnAgregarCasoPrueba.Visible = false;
        }

        //BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            AddFormInPanel(new Nuevo_Test());
            btnBuscarTest.Visible = false;
            btnBuscarTicket.Visible = false;
            btnAgregarDatos.Visible = true;
            btnAgregarCasoPrueba.Visible = true;
            btnVolver.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFormInPanel(new Buscar_Testing());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddFormInPanel(new Buscar_Ticket());
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (this.panelVentanas.Controls.Count > 0)
                this.panelVentanas.Controls.RemoveAt(0);
            btnBuscarTest.Visible = true;
            btnBuscarTicket.Visible = true;
            btnAgregarDatos.Visible = false;
            btnAgregarCasoPrueba.Visible = false;
            btnVolver.Visible = false;
        }

        
    }
}
