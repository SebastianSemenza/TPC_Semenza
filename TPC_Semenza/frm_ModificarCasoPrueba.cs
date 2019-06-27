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
    public partial class frm_ModificarCasoPrueba : Form
    {
        private Test testLocal = null;
        private CasoPrueba cpLocal = null;

        public frm_ModificarCasoPrueba()
        {
            InitializeComponent();
        }

        public frm_ModificarCasoPrueba(Test test,CasoPrueba cp)
        {
            InitializeComponent();
            testLocal = test;
            cpLocal = cp;
        }

        private void frm_ModificarCasoPrueba_Load(object sender, EventArgs e)
        {
            UsuarioPruebaNegocio UPNegocio = new UsuarioPruebaNegocio();
            SiniestroPruebaNegocio SPNegocio = new SiniestroPruebaNegocio();
            try
            {
                cmbUsuario.DataSource = UPNegocio.listarUsuariosP(testLocal);
                cmbDatoPrueba.DataSource = SPNegocio.listarSiniestroP(testLocal);
                cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbDatoPrueba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                if (cpLocal!=null)
                {
                    txbDescripcion.Text = cpLocal.Descripcion;
                    txbDetalle.Text = cpLocal.Observaciones;
                    txbDetalleFalla.Text = cpLocal.TextoFalla;
                    ckbResultado.Checked = cpLocal.Resultado;
                    cmbDatoPrueba.SelectedIndex = cmbDatoPrueba.FindString(cpLocal.Siniestro.NroSiniestro);
                    cmbUsuario.SelectedIndex = cmbUsuario.FindString(cpLocal.Usuario.Nombre);
                    cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    cmbDatoPrueba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CasoPruebaNegocio cpNegocio = new CasoPruebaNegocio();
            try
            {
                if (txbDetalle.Text == "" || txbDescripcion.Text == "")
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    if (ckbResultado.Checked == false && txbDetalleFalla.Text == "")
                    {
                        MessageBox.Show("Si el caso no esta aprobado debe indicar la falla");
                    }
                    else
                    {
                        if (cmbDatoPrueba.SelectedValue == null || cmbUsuario.SelectedValue == null)
                        {
                            MessageBox.Show("Debe seleccionar alguna opcion");
                        }
                        else
                        {
                            if (cpLocal == null)
                            {
                                CasoPrueba cpLocal = new CasoPrueba();
                                cpLocal.Descripcion = txbDescripcion.Text;
                                cpLocal.Observaciones = txbDetalle.Text;
                                cpLocal.TextoFalla = txbDetalleFalla.Text;
                                cpLocal.Resultado = ckbResultado.Checked;
                                cpLocal.Siniestro = (SiniestroPrueba)cmbDatoPrueba.SelectedItem;
                                cpLocal.Usuario = (UsuarioPrueba)cmbUsuario.SelectedItem;
                                cpNegocio.modificarDatoPrueba(testLocal, cpLocal);
                            }
                            else
                            {
                                cpLocal.Descripcion = txbDescripcion.Text;
                                cpLocal.Observaciones = txbDetalle.Text;
                                cpLocal.TextoFalla = txbDetalleFalla.Text;
                                cpLocal.Resultado = ckbResultado.Checked;
                                cpLocal.Siniestro = (SiniestroPrueba)cmbDatoPrueba.SelectedItem;
                                cpLocal.Usuario = (UsuarioPrueba)cmbUsuario.SelectedItem;
                                cpNegocio.modificarDatoPrueba(testLocal, cpLocal);
                            }
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ckbResultado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbResultado.Checked == true)
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
