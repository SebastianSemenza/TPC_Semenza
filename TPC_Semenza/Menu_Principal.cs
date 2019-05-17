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


        //NUEVOS BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            AddFormInPanel(new Nuevo_Test());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFormInPanel(new Buscar_Testing());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddFormInPanel(new Buscar_Ticket());
        }
    }
}
