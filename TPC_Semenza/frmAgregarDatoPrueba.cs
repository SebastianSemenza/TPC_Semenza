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
using Negocio;

namespace TPC_Semenza
{
    public partial class frmAgregarDatoPrueba : Form
    {
        public frmAgregarDatoPrueba()
        {
            InitializeComponent();
        }

        private void frmAgregarDatoPrueba_Load(object sender, EventArgs e)
        {
            SistemaNegocio sistema = new SistemaNegocio();
            CompañiaNegocio compañia = new CompañiaNegocio();
            try
            {
                cmbSistema.DataSource = sistema.listarSistemas();
                cmbCompañia.DataSource = compañia.listarCompañias();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
