using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PresentacionWebForm
{
    public partial class Modulo2_CantidadErroresXTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SistemaNegocio sistemaNegocio = new SistemaNegocio();
            UsuarioTesterNegocio usuarioNegocio = new UsuarioTesterNegocio();
            try
            {
                if (!IsPostBack)
                {
                    cmbSistemas.DataSource = sistemaNegocio.listarSistemas();
                    cmbSistemas.DataBind();
                    cmbUsuarios.DataSource = usuarioNegocio.listarUsuariosT();
                    cmbUsuarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sFiltro = "";
            if (!(txbTicket.Text.Equals("")))
            {
                sFiltro += " t.NTicket = " + txbTicket.Text.ToString();
            }
            if (cmbSistemas.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " s.Nombre = " + "'" + cmbSistemas.Text + "'" : " and s.Nombre = " + "'" + cmbSistemas.Text + "'";
            }
            if (cmbUsuarios.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " u.Nombre+' '+u.Apellido= " + "'" + cmbUsuarios.Text + "'" : " and u.Nombre+' '+u.Apellido= " + "'" + cmbUsuarios.Text + "'";
            }
            sFiltro += sFiltro.Equals("") ? " t.Ultimo = 1 " : " and t.Ultimo = 1 ";
            TestNegocio testNegocio = new TestNegocio();
            List<Test> listado = testNegocio.listarTests(sFiltro);
            dgvResultadoBusqueda.DataSource = listado;
            dgvResultadoBusqueda.DataBind();
        }
    }


}