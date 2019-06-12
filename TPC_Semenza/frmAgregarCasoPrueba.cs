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
    public partial class frmAgregarCasoPrueba : Form
    {
        private Test testLocal = null;
        List<CasoPrueba> listadoCP = new List<CasoPrueba>();

        public frmAgregarCasoPrueba()
        {
            InitializeComponent();
        }

        public frmAgregarCasoPrueba(Test test)
        {
            InitializeComponent();
            testLocal = test;
        }

        private void frmAgregarCasoPrueba_Load(object sender, EventArgs e)
        {
            UsuarioPruebaNegocio UPNegocio = new UsuarioPruebaNegocio();
            SiniestroPruebaNegocio SPNegocio = new SiniestroPruebaNegocio();
            try
            {
                cmbUsuario.DataSource = UPNegocio.listarUsuariosP(testLocal);
                cmbDatoPrueba.DataSource = SPNegocio.listarSiniestroP(testLocal);
                cargarGrillaCasosP();
                //VERIFICA SI ESTA FINALIZADO PARA ESCONDER BOTONES Y FRIZAR CAMPOS
                if (testLocal.Finalizado == true)
                {
                    btnAgregarCaso.Visible = false;
                    btnEliminarCaso.Visible = false;
                    btnModificarCaso.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregarCaso_Click(object sender, EventArgs e)
        {
            CasoPruebaNegocio CPNegocio = new CasoPruebaNegocio();
            try
            {
                if (txbDetalle.Text == "" || txbDescripcion.Text == "" || cmbDatoPrueba.SelectedIndex == 0 || cmbUsuario.SelectedIndex == 0 || (ckbResultado.Checked == false && txbDetalleFalla.Text == ""))
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    CasoPrueba casoPrueba = new CasoPrueba();
                    casoPrueba.Descripcion = txbDescripcion.Text;
                    casoPrueba.Resultado = ckbResultado.Checked;
                    casoPrueba.Observaciones = txbDetalle.Text;
                    casoPrueba.TextoFalla = txbDetalleFalla.Text;
                    casoPrueba.Usuario = (UsuarioPrueba)cmbUsuario.SelectedItem;
                    casoPrueba.Siniestro = (SiniestroPrueba)cmbDatoPrueba.SelectedItem;
                    casoPrueba.Automatico = false;
                    CPNegocio.agregarDatoPrueba(testLocal, casoPrueba);
                    cargarGrillaCasosP();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        private void cargarGrillaCasosP()
        {
            CasoPruebaNegocio CPNegocio = new CasoPruebaNegocio();
            try
            {
                //DATAGRIDVIEW USUARIO PRUEBA
                listadoCP = CPNegocio.ListarCasosPrueba(testLocal);
                dgvCasosPrueba.DataSource = listadoCP;
                dgvCasosPrueba.Columns["ID"].Visible = false;
                dgvCasosPrueba.Columns["Descripcion"].Width = 180;
                dgvCasosPrueba.Columns["Adjunto"].Width = 50;
                dgvCasosPrueba.Columns["Automatico"].Width = 50;
                dgvCasosPrueba.Columns["Resultado"].Width = 50;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
