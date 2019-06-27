using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using AccesoDatos;

namespace TPC_Semenza
{
    public partial class AgregarUsuarioPrueba : Form
    {
        private Test testLocal =null;
        private UsuarioPrueba UPLocal = null;

        public AgregarUsuarioPrueba()
        {
            InitializeComponent();
        }

        public AgregarUsuarioPrueba(Test test)
        {
            InitializeComponent();
            testLocal = test;
        }

        public AgregarUsuarioPrueba(Test test,UsuarioPrueba up)
        {
            InitializeComponent();
            testLocal = test;
            UPLocal = up;
        }

        private void AgregarUsuarioPrueba_Load(object sender, EventArgs e)
        {
            PerfilNegocio perfilNegocio = new PerfilNegocio();
            CompañiaNegocio compañia = new CompañiaNegocio();
            try
            {
                cmbPerfil.DataSource = perfilNegocio.listarPerfiles();
                cmbCompañia.DataSource = compañia.listarCompañias();
                cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                if (UPLocal!=null)
                {
                    txbNombre.Text = UPLocal.Nombre;
                    txbApellido.Text = UPLocal.Apellido;
                    txbDocumento.Text = UPLocal.Documento;
                    txbContraseña.Text = UPLocal.Contraseña;
                    cmbPerfil.SelectedIndex = cmbPerfil.FindString(UPLocal.Perfil.Nombre);
                    cmbCompañia.SelectedIndex = cmbCompañia.FindString(UPLocal.Compañia.Nombre);
                    cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    cmbCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            UsuarioPruebaNegocio UPNegocio = new UsuarioPruebaNegocio();
            try
            {
                if(txbNombre.Text==""||txbDocumento.Text==""||txbContraseña.Text==""||txbApellido.Text==""||cmbCompañia.SelectedIndex==0||cmbPerfil.SelectedIndex==0)
                {
                    MessageBox.Show("Debe completar todos los datos");
                }
                else
                {
                    if (UPLocal == null)
                    {
                        UPLocal = new UsuarioPrueba();
                        UPLocal.Nombre = txbNombre.Text;
                        UPLocal.Apellido = txbApellido.Text;
                        UPLocal.Documento = txbDocumento.Text;
                        UPLocal.Contraseña = txbContraseña.Text;
                        UPLocal.Perfil = (Perfil)cmbPerfil.SelectedItem;
                        UPLocal.Compañia = (Compañia)cmbCompañia.SelectedItem;
                        UPNegocio.agregarUsuarioP(testLocal, UPLocal);
                    }
                    else
                    {
                        UPLocal.Nombre = txbNombre.Text;
                        UPLocal.Apellido = txbApellido.Text;
                        UPLocal.Documento = txbDocumento.Text;
                        UPLocal.Contraseña = txbContraseña.Text;
                        UPLocal.Perfil = (Perfil)cmbPerfil.SelectedItem;
                        UPLocal.Compañia = (Compañia)cmbCompañia.SelectedItem;
                        UPNegocio.modificarUsuarioP(testLocal, UPLocal);
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
