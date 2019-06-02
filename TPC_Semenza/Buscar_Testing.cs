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

            //hacerlo no case sensitive
            if (!(txtAsunto.Text.Equals("")))
            {
                sFiltro += sFiltro.Equals("") ? " t.Asunto= " + txtAsunto.Text.ToString() : " and t.Asunto= " + txtAsunto.Text.ToString();
            }

            //if (!(txtIDTest.Text.Equals("")))
            //{
            //    sFiltro += sFiltro.Equals("") ? " t.ID= " + txtIDTest.Text.ToString() : " and t.ID= " + txtIDTest.Text.ToString();
            //}

            //if (!(txtIDTest.Text.Equals("")))
            //{
            //    sFiltro += sFiltro.Equals("") ? " t.ID= " + txtIDTest.Text.ToString() : " and t.ID= " + txtIDTest.Text.ToString();
            //}
            //unica llamada al metodo cargargrilla

            cargarGrillaTests(sFiltro);
        }

        private void cargarGrillaTests(string sFiltro)
        {
            TestNegocio testNegocio = new TestNegocio();
            try
            {
                //DATAGRIDVIEW USUARIO PRUEBA
                listadoTests = testNegocio.listarTests(sFiltro);
                dgvResultadoBusqueda.DataSource = listadoTests;
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
                dgvResultadoBusqueda.Columns["ID"].DisplayIndex = 0;
                dgvResultadoBusqueda.Columns["Version"].Width = 30;
                dgvResultadoBusqueda.Columns["Ticket"].Width = 70;
                dgvResultadoBusqueda.Columns["Asunto"].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvResultadoBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Nuevo_Test frmTest = new Nuevo_Test((Test)dgvResultadoBusqueda.CurrentRow.DataBoundItem);
            this.Close();
            frmTest.Show();
        }
    }
}
