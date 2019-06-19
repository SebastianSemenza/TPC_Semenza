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
    public partial class Modulo1_Tiempos : System.Web.UI.Page
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
                    dtpDesde.Value = DateTime.Today.AddMonths(-48).ToShortDateString();
                    dtpHasta.Value = DateTime.Today.ToShortDateString();
                   
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
            sFiltro += sFiltro.Equals("") ? " t.FechaCarga between '" + dtpDesde.Value.ToString() + "' and '" + dtpHasta.Value.ToString() + "'" : " and t.FechaCarga between '" + dtpDesde.Value.ToString() + "' and '" + dtpHasta.Value.ToString() + "'";

            TicketNegocio ticketNegocio = new TicketNegocio();
            List<Ticket> listado = ticketNegocio.filtrarTickets(sFiltro);
            dgvResultadoBusqueda.DataSource = listado;
            dgvResultadoBusqueda.DataBind();

            List<TotalTiemposTickets> listadoTotales = ticketNegocio.calcularTotales(listado);
            dgvTotales.DataSource = listadoTotales;
            dgvTotales.DataBind();
        }

    }
}