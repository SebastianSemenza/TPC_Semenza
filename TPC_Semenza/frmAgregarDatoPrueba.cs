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
        Test testLocal;

        public frmAgregarDatoPrueba()
        {
            InitializeComponent();
        }

        public frmAgregarDatoPrueba(Test test)
        {
            InitializeComponent();
            testLocal = test;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SiniestroPruebaNegocio SPNegocio = new SiniestroPruebaNegocio();
            try
            {
                SiniestroPrueba siniestroPrueba = new SiniestroPrueba();
                siniestroPrueba.NroSiniestro = txbNroSiniestro.Text;
                siniestroPrueba.Patente = txbPatente.Text;
                siniestroPrueba.Compañia = (Compañia)cmbCompañia.SelectedItem;
                siniestroPrueba.Sistema = (Sistema)cmbSistema.SelectedItem;
                SPNegocio.agregarSiniestroPrueba(testLocal,siniestroPrueba);

                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
