using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
namespace TPC_Semenza
{
    public partial class Menu_Principal : Form
    {
        //private Test test;

        public Menu_Principal()
        {
            InitializeComponent();
        }

        //FUNCION PARA AGREGAR VENTANA A UN PANEL SIN CERRAR LAS ANTERIORES
        private void abrirForm<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelVentanas.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelVentanas.Controls.Add(formulario);
                panelVentanas.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        //FUNCION PARA AGREGAR VENTANA A UN PANEL CERRANDO LA ANTERIOR
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
            abrirForm<Nuevo_Test>();
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
            {
                this.panelVentanas.Controls.Clear();
            }
            
            btnBuscarTest.Visible = true;
            btnBuscarTicket.Visible = true;
            btnAgregarDatos.Visible = false;
            btnAgregarCasoPrueba.Visible = false;
            btnVolver.Visible = false;
        }

        private void btnAgregarDatos_Click(object sender, EventArgs e)
        {
            abrirForm<frmAgregarDatos>();
        }

        private void btnAgregarCasoPrueba_Click(object sender, EventArgs e)
        {
            abrirForm<frmAgregarCasoPrueba>();
        }
        
    }
}
