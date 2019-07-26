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
                cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbDatoPrueba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
                if (txbDetalle.Text == "" || txbDescripcion.Text == "" )
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    if(ckbResultado.Checked == false && txbDetalleFalla.Text == "")
                    {
                        MessageBox.Show("Si el caso no esta aprobado debe indicar la falla");
                    }
                    else
                    {
                        if(cmbDatoPrueba.SelectedValue==null||cmbUsuario.SelectedValue==null)
                        {
                            MessageBox.Show("Debe seleccionar alguna opcion");
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
                dgvCasosPrueba.Columns["Adjunto"].Visible = false;
                dgvCasosPrueba.Columns["Automatico"].Visible = false;
                dgvCasosPrueba.Columns["Test"].Visible = false;
                dgvCasosPrueba.Columns["Descripcion"].Width = 180;
                dgvCasosPrueba.Columns["Resultado"].Width = 50;
                dgvCasosPrueba.ReadOnly = true;
                dgvCasosPrueba.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCasosPrueba.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificarCaso_Click(object sender, EventArgs e)
        {
            if (dgvCasosPrueba.SelectedRows.Count == 1)
            {
                frm_ModificarCasoPrueba frmModCaso = new frm_ModificarCasoPrueba(testLocal, (CasoPrueba)dgvCasosPrueba.CurrentRow.DataBoundItem);
                frmModCaso.ShowDialog();
                cargarGrillaCasosP();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila!");
            }
        }

        private void btnEliminarCaso_Click(object sender, EventArgs e)
        {
            if (dgvCasosPrueba.SelectedRows.Count == 1)
            {
                CasoPruebaNegocio cpNegocio = new CasoPruebaNegocio();
                cpNegocio.eliminarDatoPrueba((CasoPrueba)dgvCasosPrueba.CurrentRow.DataBoundItem);
                cargarGrillaCasosP();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila!");
            }
        }

        private void btnImagenes_Click(object sender, EventArgs e)
        {
            if (dgvCasosPrueba.SelectedRows.Count == 1)
            {
                frmImagenesCasos frmImg = new frmImagenesCasos((CasoPrueba)dgvCasosPrueba.CurrentRow.DataBoundItem,testLocal);
                frmImg.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila!");
            }
        }

        private void ckbResultado_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbResultado.Checked==true)
            {
                txbDetalleFalla.Visible = false;
                lblDetalleFalla.Visible = false;
            }
            else
            {
                txbDetalleFalla.Visible = true;
                lblDetalleFalla.Visible = true;
            }
        }
    }
}
