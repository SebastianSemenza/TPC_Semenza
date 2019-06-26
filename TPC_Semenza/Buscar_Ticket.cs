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
        DataGridViewButtonColumn botonAbrir = null;

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
                //cmbEstadoTicket.DataSource = estadoNegocio.listarEstadosT();
                dtpFechaGrabadoDesde.Value = DateTime.Now.AddMonths(-24);
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
            if (!(txtAsunto.Text.Equals("")))
            {
                sFiltro += sFiltro.Equals("") ? " t.Asunto like '%" + txtAsunto.Text.ToString() + "%'" : " and t.Asunto like '%" + txtAsunto.Text.ToString() + "%'";
            }
            //filtro prioridad
            if (cmbPrioridad.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " p.Nombre = " + "'" + cmbPrioridad.Text + "'" : " and p.Nombre = " + "'" + cmbPrioridad.Text + "'";
            }
            sFiltro += sFiltro.Equals("") ? " t.FechaCarga between '" + dtpFechaGrabadoDesde.Value + "' and '" + dtpFechaGrabadoHasta.Value + "'" : " and t.FechaCarga between '" + dtpFechaGrabadoDesde.Value + "' and '" + dtpFechaGrabadoHasta.Value + "'";

            cargarGrillaTickets(sFiltro);
        }

        private void cargarGrillaTickets(string sFiltro)
        {
            TicketNegocio ticketNegocio = new TicketNegocio();
            try
            {
                if (botonAbrir == null)
                {
                    botonAbrir = new DataGridViewButtonColumn();
                    dgvResultadoBusqueda.Columns.Add(botonAbrir);
                    botonAbrir.Name = "Abrir";
                    botonAbrir.HeaderText = "Abrir";
                }
                //DATAGRIDVIEW RESULTADO BUSQUEDA
                listadoTickets = ticketNegocio.filtrarTickets(sFiltro);
                dgvResultadoBusqueda.DataSource = listadoTickets;
                dgvResultadoBusqueda.Columns["Abrir"].DisplayIndex = 0;
                dgvResultadoBusqueda.Columns["Abrir"].Width = 35;
                dgvResultadoBusqueda.Columns["estadoPlanilla"].Visible = false;
                dgvResultadoBusqueda.Columns["ER"].Visible = false;
                dgvResultadoBusqueda.Columns["PosicionPlanilla"].Visible = false;
                dgvResultadoBusqueda.Columns["TiempoAnalisis"].Visible = false;
                dgvResultadoBusqueda.Columns["TiempoDesarrollo"].Visible = false;
                dgvResultadoBusqueda.Columns["TiempoTesteo"].Visible = false;
                dgvResultadoBusqueda.Columns["TiempoPuestaProduccion"].Visible = false;
                dgvResultadoBusqueda.ReadOnly = true;
                dgvResultadoBusqueda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvResultadoBusqueda_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvResultadoBusqueda.Columns[e.ColumnIndex].Name == "Abrir")
            {
                Ticket ticketLocal = (Ticket)dgvResultadoBusqueda.CurrentRow.DataBoundItem;
                Test testLocal = new Test();
                testLocal.NTicket = ticketLocal.NTicket;
                testLocal.Sistema = ticketLocal.Sistema;
                testLocal.UsuarioT = ticketLocal.UsuarioTicket;
                testLocal.Prioridad = ticketLocal.Prioridad;
                testLocal.Asunto = ticketLocal.Asunto;
                testLocal.Descripcion = ticketLocal.Descripcion;
                Nuevo_Test frmTest = new Nuevo_Test(testLocal);
                this.Close();
                frmTest.Show();
            }
        }
    }
}
