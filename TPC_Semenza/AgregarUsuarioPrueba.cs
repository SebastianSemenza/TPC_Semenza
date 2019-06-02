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

        public AgregarUsuarioPrueba()
        {
            InitializeComponent();
        }

        public AgregarUsuarioPrueba(Test test)
        {
            InitializeComponent();
            testLocal = test;
        }

        private void AgregarUsuarioPrueba_Load(object sender, EventArgs e)
        {
            PerfilNegocio perfilNegocio = new PerfilNegocio();
            CompañiaNegocio compañia = new CompañiaNegocio();
            try
            {
                cmbPerfil.DataSource = perfilNegocio.listarPerfiles();
                cmbCompañia.DataSource = compañia.listarCompañias();
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
                UsuarioPrueba UPLocal = new UsuarioPrueba();
                UPLocal.Nombre = txbNombre.Text;
                UPLocal.Apellido = txbApellido.Text;
                UPLocal.Documento = txbDocumento.Text;
                UPLocal.Contraseña = txbContraseña.Text;
                UPLocal.Perfil = (Perfil)cmbPerfil.SelectedItem;
                UPLocal.Compañia = (Compañia)cmbCompañia.SelectedItem;
                UPNegocio.agregarUsuarioP(testLocal,UPLocal);

                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
