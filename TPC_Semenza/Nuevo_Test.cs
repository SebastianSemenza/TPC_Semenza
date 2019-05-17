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
using AccesoDatos;

namespace TPC_Semenza
{
    public partial class Nuevo_Test : Form
    {
        private List<UsuarioPrueba> listadoUP= new List<UsuarioPrueba>();
        private List<SiniestroPrueba> listadoSP = new List<SiniestroPrueba>();

        private Test testLocal = null;

        public Nuevo_Test()
        {
            InitializeComponent();
        }

        public Nuevo_Test(Test test)
        {
            InitializeComponent();
            testLocal = test;
        }
        
        //no va
        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void Nuevo_Test_Load(object sender, EventArgs e)
        {
            short IDTest = 0;
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            SistemaNegocio sistemaNegocio = new SistemaNegocio();
            UsuarioTesterNegocio testerNegocio = new UsuarioTesterNegocio();
            CompañiaNegocio compañiaNegocio = new CompañiaNegocio();
            GrupoCompañiasNegocio grupoCompañiasNegocio = new GrupoCompañiasNegocio();
            
            try
            {
                //Cargo los combos
                cmbSistema.DataSource = sistemaNegocio.listarSistemas();
                cmbPrioridad.DataSource = prioridadNegocio.listarPrioridades();
                cmbUsuarioTester.DataSource = testerNegocio.listarUsuariosT();
                cmbSolicitante.DataSource = compañiaNegocio.listarCompañias();
                cmbAplica.DataSource = grupoCompañiasNegocio.listarGrupoCompañias();
                //DATAGRIDVIEW USUARIOS PRUEBA
                cargarGrillaUsuariosP();
                //DATAGRIDVIEW STRO PRUEBA
                cargarGrillaSiniestrosP();

                //VER PARA QUE SIRVE EL SELECTEDINDEX
                if (testLocal!=null)
                {
                    cmbSistema.SelectedIndex = cmbSistema.FindString(testLocal.Ticket.Sistema.Nombre);
                    cmbPrioridad.SelectedIndex = cmbPrioridad.FindString(testLocal.Ticket.Prioridad.TipoPrioridad);
                    cmbUsuarioTester.SelectedIndex = cmbUsuarioTester.FindString(testLocal.UsuarioT.Nombre+" "+testLocal.UsuarioT.Apellido);
                    cmbSolicitante.SelectedIndex = cmbSolicitante.FindString(testLocal.CiaSolicitante.Nombre);
                    cmbAplica.SelectedIndex = cmbAplica.FindString(testLocal.GrupoCia.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarUP_Click(object sender, EventArgs e)
        {
            AgregarUsuarioPrueba formUsuarioP = new AgregarUsuarioPrueba();
            formUsuarioP.ShowDialog();
        }

        private void btnAgregarDato_Click(object sender, EventArgs e)
        {
            frmAgregarDatoPrueba formDato = new frmAgregarDatoPrueba();
            formDato.ShowDialog();
        }

        private void cargarGrillaUsuariosP()
        {
            UsuarioPruebaNegocio UPnegocio = new UsuarioPruebaNegocio();
            try
            {
                //DATAGRIDVIEW USUARIO PRUEBA
                listadoUP = UPnegocio.listarUsuariosP();
                dgvUsuariosPrueba.DataSource = listadoUP;
                dgvUsuariosPrueba.Columns["ID"].Visible = false;
                dgvUsuariosPrueba.Columns["Test"].Visible = false;
                dgvUsuariosPrueba.Columns["Grabado"].Visible = false;
                dgvUsuariosPrueba.Columns["Nombre"].DisplayIndex = 0;
                dgvUsuariosPrueba.Columns["Apellido"].DisplayIndex = 1;
                dgvUsuariosPrueba.Columns["Documento"].DisplayIndex = 2;
                dgvUsuariosPrueba.Columns["Documento"].Width = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarGrillaSiniestrosP()
        {
            SiniestroPruebaNegocio SPnegocio = new SiniestroPruebaNegocio();
            try
            {
                //DATAGRIDVIEW SINIESTROS PRUEBA
                listadoSP = SPnegocio.listarSiniestroP();
                dgvDatosPrueba.DataSource = listadoSP;
                dgvDatosPrueba.Columns["ID"].Visible = false;
                dgvDatosPrueba.Columns["Test"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
