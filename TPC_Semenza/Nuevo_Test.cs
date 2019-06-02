using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TPC_Semenza
{
    public partial class Nuevo_Test : Form
    {
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

        private void Nuevo_Test_Load(object sender, EventArgs e)
        {
            

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

                //RELLENAR LOS CAMPOS QUE VIENEN DE LA BUSQUEDA
                if (testLocal != null)
                {
                    txtTicket.Text = testLocal.NTicket.ToString();
                    txtIDTest.Text = testLocal.ID.ToString();
                    txtVersion.Text = testLocal.Version.ToString();
                    txtAsunto.Text = testLocal.Asunto;
                    txtDescripcion.Text = testLocal.Descripcion;
                    cmbSistema.SelectedIndex = cmbSistema.FindString(testLocal.Sistema.Nombre);
                    cmbPrioridad.SelectedIndex = cmbPrioridad.FindString(testLocal.Prioridad.TipoPrioridad);
                    cmbUsuarioTester.SelectedIndex = cmbUsuarioTester.FindString(testLocal.UsuarioT.Nombre + " " + testLocal.UsuarioT.Apellido);
                    cmbSolicitante.SelectedIndex = cmbSolicitante.FindString(testLocal.CiaSolicitante.Nombre);
                    cmbAplica.SelectedIndex = cmbAplica.FindString(testLocal.GrupoCia.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TestNegocio testNegocio = new TestNegocio();
            try
            {
                testLocal = new Test();
                testLocal.ID = Convert.ToInt16(txtIDTest.Text);//provisoriamente luego se generarà automaticamente
                testLocal.NTicket = Convert.ToInt16(txtTicket.Text);
                testLocal.Version = Convert.ToInt16(txtVersion.Text);
                testLocal.Sistema = (Sistema)cmbSistema.SelectedItem;
                testLocal.UsuarioT = (UsuarioTester)cmbUsuarioTester.SelectedItem;
                testLocal.Prioridad = (Prioridad)cmbPrioridad.SelectedItem;
                testLocal.CiaSolicitante = (Compañia)cmbSolicitante.SelectedItem;
                testLocal.GrupoCia = (GrupoCompañias)cmbAplica.SelectedItem;
                testLocal.Asunto = txtAsunto.Text;
                testLocal.Descripcion = txtDescripcion.Text;

                //testNegocio.agregarTest(test);
                testNegocio.verificarTest(testLocal);

                MessageBox.Show("Se Guardo Correctamente.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregarDatos_Click(object sender, EventArgs e)
        {
            testLocal = new Test();
            testLocal.ID = Convert.ToInt16(txtIDTest.Text);//provisoriamente luego se generarà automaticamente
            testLocal.NTicket = Convert.ToInt16(txtTicket.Text);
            testLocal.Version = Convert.ToInt16(txtVersion.Text);
            testLocal.Sistema = (Sistema)cmbSistema.SelectedItem;
            testLocal.UsuarioT = (UsuarioTester)cmbUsuarioTester.SelectedItem;
            testLocal.Prioridad = (Prioridad)cmbPrioridad.SelectedItem;
            testLocal.CiaSolicitante = (Compañia)cmbSolicitante.SelectedItem;
            testLocal.GrupoCia = (GrupoCompañias)cmbAplica.SelectedItem;
            testLocal.Asunto = txtAsunto.Text;
            testLocal.Descripcion = txtDescripcion.Text;
            frmAgregarDatos frmAD = new frmAgregarDatos(testLocal);
            frmAD.Show();
        }

        private void btnAgregarCasosPrueba_Click(object sender, EventArgs e)
        {
            frmAgregarCasoPrueba frmACP = new frmAgregarCasoPrueba();
            frmACP.Show();
        }

    }
}
