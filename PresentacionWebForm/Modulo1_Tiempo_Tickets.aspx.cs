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
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sFiltro = "";
            if (!(txbTicket.Text.Equals("")))
            {
                sFiltro += " t.NTicket = " + txbTicket.Text.ToString();
            }
            //if (cmbSistema.SelectedIndex != 0)
            //{
            //    sFiltro += sFiltro.Equals("") ? " s.Nombre = " + "'" + cmbSistema.Text + "'" : " and s.Nombre = " + "'" + cmbSistema.Text + "'";
            //}
            //if (cmbUsuario.SelectedIndex != 0)
            //{
            //    sFiltro += sFiltro.Equals("") ? " u.Nombre+' '+u.Apellido= " + "'" + cmbUsuario.Text + "'" : " and u.Nombre+' '+u.Apellido= " + "'" + cmbUsuario.Text + "'";
            //}
            ////hacerlo no case sensitive
            //if (!(txtAsunto.Text.Equals("")))
            //{
            //    sFiltro += sFiltro.Equals("") ? " t.Asunto= " + txtAsunto.Text.ToString() : " and t.Asunto= " + txtAsunto.Text.ToString();
            //}
            ////filtro prioridad
            //if (cmbPrioridad.SelectedIndex != 0)
            //{
            //    sFiltro += sFiltro.Equals("") ? " p.Nombre = " + "'" + cmbPrioridad.Text + "'" : " and p.Nombre = " + "'" + cmbPrioridad.Text + "'";
            //}
            ////filtro estado
            //if (cmbEstadoTicket.SelectedIndex != 0)
            //{
            //    sFiltro += sFiltro.Equals("") ? " p.Nombre = " + "'" + cmbEstadoTicket.Text + "'" : " and p.Nombre = " + "'" + cmbEstadoTicket.Text + "'";
            //}
            TicketNegocio ticketNegocio = new TicketNegocio();
            List<Ticket> listado = ticketNegocio.filtrarTickets(sFiltro);
            dgvResultadoBusqueda.DataSource = listado;
            dgvResultadoBusqueda.DataBind();

            //List<TotalTiemposTickets> listadoTotales = ticketNegocio.calcularTotales(listado);
            //dgvTotales.DataSource = listadoTotales;
            //dgvTotales.DataBind();
        }

    }
}