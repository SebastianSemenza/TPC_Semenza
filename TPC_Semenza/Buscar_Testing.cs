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
    public partial class Buscar_Testing : Form
    {
        private List<Test> listadoTests;

        public Buscar_Testing()
        {
            InitializeComponent();
        }

        private void Buscar_Testing_Load(object sender, EventArgs e)
        {
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            SistemaNegocio sistemaNegocio = new SistemaNegocio();
            UsuarioTesterNegocio testerNegocio = new UsuarioTesterNegocio();
            try
            {
                cmbSistema.DataSource = sistemaNegocio.listarSistemas();
                cmbPrioridad.DataSource = prioridadNegocio.listarPrioridades();
                cmbUsuarioTester.DataSource = testerNegocio.listarUsuariosT();
                cmbTipoGrabado.Items.Add("Todos");
                cmbTipoGrabado.Items.Add("Parcial");
                cmbTipoGrabado.Items.Add("Final");
                cmbTipoGrabado.SelectedIndex = 0;
                dtpFechaGrabadoDesde.Value = DateTime.Now.AddMonths(-24);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sFiltro = "";

            if (!(txtTicket.Text.Equals("")))
            {
                sFiltro += " t.NTicket = " + txtTicket.Text.ToString();
            }
            if (!(txtIDTest.Text.Equals("")))
            {
                sFiltro += sFiltro.Equals("") ? " t.ID= " + txtIDTest.Text.ToString() : " and t.ID= " + txtIDTest.Text.ToString();
            }
            if (cmbSistema.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " s.Nombre = " + "'" + cmbSistema.Text + "'" : " and s.Nombre = " + "'" + cmbSistema.Text + "'";
            }
            if (cmbUsuarioTester.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " u.Nombre+' '+u.Apellido= " + "'" + cmbUsuarioTester.Text + "'" : " and u.Nombre+' '+u.Apellido= " + "'" + cmbUsuarioTester.Text + "'";
            }
            if (!(txtAsunto.Text.Equals("")))//hacerlo no case sensitive
            {
                sFiltro += sFiltro.Equals("") ? " t.Asunto= " + txtAsunto.Text.ToString() : " and t.Asunto= " + txtAsunto.Text.ToString();
            }
            if (cmbPrioridad.SelectedIndex != 0)
            {
                sFiltro += sFiltro.Equals("") ? " p.Nombre = " + "'" + cmbPrioridad.Text + "'" : " and p.Nombre = " + "'" + cmbPrioridad.Text + "'";
            }
            if (cmbTipoGrabado.SelectedIndex != 0)
            {
                if(cmbTipoGrabado.SelectedIndex==1)
                {
                    sFiltro += sFiltro.Equals("") ? " t.Finalizado = 0" : " and p.Finalizado = 0";
                }
                else
                {
                    sFiltro += sFiltro.Equals("") ? " t.Finalizado = 1" : " and p.Finalizado = 1";
                }
            }
            sFiltro += sFiltro.Equals("") ? " t.FechaCarga between '" + dtpFechaGrabadoDesde.Value + "' and '" + dtpFechaGrabadoHasta.Value+ "'" : " and t.FechaCarga between '" + dtpFechaGrabadoDesde.Value+ "' and '" + dtpFechaGrabadoHasta.Value + "'";
            cargarGrillaTests(sFiltro);
        }   

        private void cargarGrillaTests(string sFiltro)
        {
            TestNegocio testNegocio = new TestNegocio();
            try
            {
                DataGridViewButtonColumn botonAbrir = new DataGridViewButtonColumn();
                botonAbrir.Name = "Abrir";
                botonAbrir.HeaderText = "Abrir";
                //DATAGRIDVIEW RESULTADO BUSQUEDA
                listadoTests = testNegocio.listarTests(sFiltro);
                dgvResultadoBusqueda.DataSource = listadoTests;
                dgvResultadoBusqueda.Columns.Add(botonAbrir);
                dgvResultadoBusqueda.Columns["Abrir"].DisplayIndex = 0;
                dgvResultadoBusqueda.Columns["Abrir"].Width = 35;
                dgvResultadoBusqueda.Columns["Duracion"].Visible = false;
                dgvResultadoBusqueda.Columns["UsuarioP"].Visible = false;
                dgvResultadoBusqueda.Columns["SiniestroP"].Visible = false;
                dgvResultadoBusqueda.Columns["CasoP"].Visible = false;
                dgvResultadoBusqueda.Columns["Complejidad"].Visible = false;
                dgvResultadoBusqueda.Columns["Riesgo"].Visible = false;
                dgvResultadoBusqueda.Columns["Ticket"].Visible = false;
                dgvResultadoBusqueda.Columns["Estado"].Visible = false;
                dgvResultadoBusqueda.Columns["Informe"].Visible = false;
                dgvResultadoBusqueda.Columns["Descripcion"].Visible = false;
                dgvResultadoBusqueda.Columns["ID"].Width = 30;
                dgvResultadoBusqueda.Columns["ID"].DisplayIndex = 1;
                dgvResultadoBusqueda.Columns["Version"].Width = 40;
                dgvResultadoBusqueda.Columns["Ticket"].Width = 70;
                dgvResultadoBusqueda.Columns["Asunto"].Width = 150;
                dgvResultadoBusqueda.Columns["Finalizado"].Width = 50;
                dgvResultadoBusqueda.Columns["VersionFinal"].Width = 50;
                dgvResultadoBusqueda.Columns["Ultimo"].Width = 50;
                dgvResultadoBusqueda.Columns["Prioridad"].Width = 100;
                dgvResultadoBusqueda.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvResultadoBusqueda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvResultadoBusqueda.Columns[e.ColumnIndex].Name == "Abrir")
            {
                Nuevo_Test frmTest = new Nuevo_Test((Test)dgvResultadoBusqueda.CurrentRow.DataBoundItem);
                this.Close();
                frmTest.Show();
            }
            
        }
    }
}
