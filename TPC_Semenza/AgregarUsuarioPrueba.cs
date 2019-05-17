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
        public AgregarUsuarioPrueba()
        {
            InitializeComponent();
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
            //UsuarioPruebaNegocio UPNegocio = new UsuarioPruebaNegocio();
            //try
            //{
            //    UsuarioPrueba usuarioP = new UsuarioPrueba();
            //    usuarioP.Nombre = txbNombre.Text;
            //    usuarioP.Apellido = txbApellido.Text;
            //    usuarioP.Documento = txbDocumento.Text;
            //    usuarioP.Contraseña = txbContraseña.Text;
            //    usuarioP.Compañia = (Compañia)cmbCompañia.SelectedItem;
            //    usuarioP.Perfil = (Perfil)cmbPerfil.SelectedItem;
            //    UPNegocio.AgregarUsuarioP(usuarioP);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            

        }
    }
}
