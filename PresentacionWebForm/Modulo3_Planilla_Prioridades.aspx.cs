using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace PresentacionWebForm
{
    public partial class Modulo2_Planilla_Prioridades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TicketNegocio ticketNegocio = new TicketNegocio();
            List<Ticket> listado = ticketNegocio.listarPlanillaPrioridades();
            dgvResultadoBusqueda.DataSource = listado;
            dgvResultadoBusqueda.DataBind();
        }
    }
}