﻿using System;
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
            TicketNegocio ticketNegocio = new TicketNegocio();
            List<Ticket> listado = ticketNegocio.listarTickets();
            dgvResultadoBusqueda.DataSource = listado;
            dgvResultadoBusqueda.DataBind();
        }

        protected void dgvResultadoBusqueda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //TicketNegocio ticketNegocio = new TicketNegocio();
            //e.Row.Cells(7).text = Convert.ToString(ticketNegocio.calcularTiempoAnalisis((Ticket)dgvResultadoBusqueda.CurrentRow.DataBoundItem));
        }

    }
}