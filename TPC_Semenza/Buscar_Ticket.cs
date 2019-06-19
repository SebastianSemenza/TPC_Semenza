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
    public partial class Buscar_Ticket : Form
    {
        private List<Ticket> listadoTickets;

        public Buscar_Ticket()
        {
            InitializeComponent();
        }

        private void Buscar_Ticket_Load(object sender, EventArgs e)
        {
            SistemaNegocio sistemaNegocio = new SistemaNegocio();
            UsuarioTesterNegocio usuarioNegocio = new UsuarioTesterNegocio();
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            EstadoTicketNegocio estadoNegocio = new EstadoTicketNegocio();
            try
            {
                cmbSistema.DataSource = sistemaNegocio.listarSistemas();
                cmbUsuario.DataSource = usuarioNegocio.listarUsuariosT();
                cmbPrioridad.DataSource = prioridadNegocio.listarPrioridades();
                cmbEstadoTicket.DataSource = estadoNegocio.listarEstadosT();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sFiltro = "";
            if (!(txtNTicket.Text.Equals("")))
            {
                sFiltro += " t.NTicket = " + txtNTicket.Text.ToString();
            }
            if (cmbSistema.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " s.Nombre = " + "'" + cmbSistema.Text + "'" : " and s.Nombre = " + "'" + cmbSistema.Text + "'";
            }
            if (cmbUsuario.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " u.Nombre+' '+u.Apellido= " + "'" + cmbUsuario.Text + "'" : " and u.Nombre+' '+u.Apellido= " + "'" + cmbUsuario.Text + "'";
            }
            //hacerlo no case sensitive
            if (!(txtAsunto.Text.Equals("")))
            {
                sFiltro += sFiltro.Equals("") ? " t.Asunto= '" + txtAsunto.Text.ToString() + "'" : " and t.Asunto= '" + txtAsunto.Text.ToString() +"'";
            }
            //filtro prioridad
            if (cmbPrioridad.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " p.Nombre = " + "'" + cmbPrioridad.Text + "'" : " and p.Nombre = " + "'" + cmbPrioridad.Text + "'";
            }
            //filtro estado
            if (cmbEstadoTicket.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " p.Nombre = " + "'" + cmbEstadoTicket.Text + "'" : " and p.Nombre = " + "'" + cmbEstadoTicket.Text + "'";
            }
            cargarGrillaTickets(sFiltro);
        }

        private void cargarGrillaTickets(string sFiltro)
        {
            TicketNegocio ticketNegocio = new TicketNegocio();
            try
            {
                //DATAGRIDVIEW RESULTADO BUSQUEDA
                listadoTickets = ticketNegocio.filtrarTickets(sFiltro);
                dgvResultadoBusqueda.DataSource = listadoTickets;
                //dgvResultadoBusqueda.Columns["Duracion"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
