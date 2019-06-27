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
        Test testLocal = null;
        SiniestroPrueba SPLocal = null;

        public frmAgregarDatoPrueba()
        {
            InitializeComponent();
        }

        public frmAgregarDatoPrueba(Test test)
        {
            InitializeComponent();
            testLocal = test;
        }

        public frmAgregarDatoPrueba(Test test,SiniestroPrueba sp)
        {
            InitializeComponent();
            testLocal = test;
            SPLocal = sp;
        }

        private void frmAgregarDatoPrueba_Load(object sender, EventArgs e)
        {
            SistemaNegocio sistema = new SistemaNegocio();
            CompañiaNegocio compañia = new CompañiaNegocio();
            try
            {
                cmbSistema.DataSource = sistema.listarSistemas();
                cmbCompañia.DataSource = compañia.listarCompañias();
                cmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                if (SPLocal!=null)
                {
                    txbNroSiniestro.Text = SPLocal.NroSiniestro;
                    txbPatente.Text = SPLocal.Patente;
                    cmbCompañia.SelectedIndex = cmbCompañia.FindString(SPLocal.Compañia.Nombre);
                    cmbSistema.SelectedIndex = cmbSistema.FindString(SPLocal.Sistema.Nombre);
                    cmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    cmbCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                }
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
                if (txbNroSiniestro.Text == ""||txbPatente.Text == ""||cmbCompañia.SelectedIndex == 0 || cmbSistema.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe completar todos los datos");
                }
                else
                {
                    if (SPLocal == null)
                    {
                        SPLocal = new SiniestroPrueba();
                        SPLocal.NroSiniestro = txbNroSiniestro.Text;
                        SPLocal.Patente = txbPatente.Text;
                        SPLocal.Compañia = (Compañia)cmbCompañia.SelectedItem;
                        SPLocal.Sistema = (Sistema)cmbSistema.SelectedItem;
                        SPNegocio.agregarSiniestroPrueba(testLocal, SPLocal);
                    }
                    else
                    {
                        SPLocal.NroSiniestro = txbNroSiniestro.Text;
                        SPLocal.Patente = txbPatente.Text;
                        SPLocal.Compañia = (Compañia)cmbCompañia.SelectedItem;
                        SPLocal.Sistema = (Sistema)cmbSistema.SelectedItem;
                        SPNegocio.modificarSiniestroPrueba(testLocal, SPLocal);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
