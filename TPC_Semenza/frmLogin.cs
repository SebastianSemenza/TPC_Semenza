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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioTesterNegocio UTNegocio = new UsuarioTesterNegocio();
            try
            {
                if (UTNegocio.Login(txbUsuario.Text, txbContraseña.Text) && txbUsuario.Text != "0")
                {
                    frmMenu_Principal frmMenu = new frmMenu_Principal(txbUsuario.Text);
                    frmMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El usuario y la contraseña no son correctos!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txbContraseña.PasswordChar = '*';
        }
    }
}
