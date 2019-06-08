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

        private void cargarTest(Test cTest)
        {
            cTest.ID = Convert.ToInt32(txtIDTest.Text);
            cTest.NTicket = Convert.ToInt32(txtTicket.Text);
            cTest.Version = Convert.ToInt32(txtVersion.Text);
            cTest.Sistema = (Sistema)cmbSistema.SelectedItem;
            cTest.UsuarioT = (UsuarioTester)cmbUsuarioTester.SelectedItem;
            cTest.Prioridad = (Prioridad)cmbPrioridad.SelectedItem;
            cTest.CiaSolicitante = (Compañia)cmbSolicitante.SelectedItem;
            cTest.GrupoCia = (GrupoCompañias)cmbAplica.SelectedItem;
            cTest.Asunto = txtAsunto.Text;
            cTest.Descripcion = txtDescripcion.Text;
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
                txtIDTest.ReadOnly = true;
                txtVersion.ReadOnly = true;
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
                //VERIFICA SI ESTA FINALIZADO PARA ESCONDER BOTONES Y FRIZAR CAMPOS
                if(testLocal==null || testLocal.Finalizado != true)
                {
                    btnGenerarVersion.Visible = false;
                }
                else
                {
                    btnGuardar.Visible = false;
                    btnFinalizarVersion.Visible = false;
                    btnTestingOK.Visible = false;
                    txtTicket.ReadOnly = true;
                    txtIDTest.ReadOnly = true;
                    txtVersion.ReadOnly = true;
                    txtAsunto.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    cmbSistema.Enabled = false;
                    cmbPrioridad.Enabled = false;
                    cmbUsuarioTester.Enabled = false;
                    cmbSolicitante.Enabled = false;
                    cmbAplica.Enabled = false;
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
                if (txtTicket.Text == "" || txtAsunto.Text == "" || txtDescripcion.Text == "" || cmbPrioridad.SelectedIndex == 0 || cmbSistema.SelectedIndex == 0 || cmbSolicitante.SelectedIndex == 0 ||cmbUsuarioTester.SelectedIndex==0 || cmbAplica.SelectedIndex==0)
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    if (testLocal != null)
                    {
                        cargarTest(testLocal);
                        testNegocio.modificarTest(testLocal);
                        MessageBox.Show("Se Guardo Correctamente.");
                    }
                    else
                    {
                        testLocal = new Test();
                        testLocal.NTicket = Convert.ToInt32(txtTicket.Text);
                        testLocal.Sistema = (Sistema)cmbSistema.SelectedItem;
                        testLocal.UsuarioT = (UsuarioTester)cmbUsuarioTester.SelectedItem;
                        testLocal.Prioridad = (Prioridad)cmbPrioridad.SelectedItem;
                        testLocal.CiaSolicitante = (Compañia)cmbSolicitante.SelectedItem;
                        testLocal.GrupoCia = (GrupoCompañias)cmbAplica.SelectedItem;
                        testLocal.Asunto = txtAsunto.Text;
                        testLocal.Descripcion = txtDescripcion.Text;

                        testLocal.ID=testNegocio.agregarTest(testLocal);
                        testLocal.Version = 1;
                        txtIDTest.Text = testLocal.ID.ToString();
                        txtVersion.Text = testLocal.Version.ToString();

                        MessageBox.Show("Se Guardo Correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregarDatos_Click(object sender, EventArgs e)
        {
            if(txtIDTest.Text=="")
            {
                MessageBox.Show("Debe grabar para continuar");
            }
            else
            {
                testLocal = new Test();
                cargarTest(testLocal);
                frmAgregarDatos frmAD = new frmAgregarDatos(testLocal);
                frmAD.Show();
            }
        }

        private void btnAgregarCasosPrueba_Click(object sender, EventArgs e)
        {
            if (txtIDTest.Text == "")
            {
                MessageBox.Show("Debe grabar para continuar");
            }
            else
            {
                testLocal = new Test();
                cargarTest(testLocal);
                frmAgregarCasoPrueba frmACP = new frmAgregarCasoPrueba(testLocal);
                frmACP.Show();
            }
        }

        private void btnGenerarVersion_Click(object sender, EventArgs e)
        {
            TestNegocio testNegocio = new TestNegocio();
            testNegocio.agregarVersion(testLocal);
            //ver como agregarle los casos de prueba usuarios y datos a la nueva version

        }

        private void btnFinalizarVersion_Click(object sender, EventArgs e)
        {
            TestNegocio testNegocio = new TestNegocio();
            testNegocio.finalizarVersion(testLocal);
            MessageBox.Show("La version se finalizo");
            //ver la forma de actualizar y para frizar los campos
            this.Close();
            Nuevo_Test frmTest = new Nuevo_Test(testLocal);
            frmTest.Show();
        }

        private void btnTestingOK_Click(object sender, EventArgs e)
        {
            TestNegocio testNegocio = new TestNegocio();
            testNegocio.generarVersionFinal(testLocal);
            MessageBox.Show("Se finalizo el test, TESTING OK!!!");
            //ver la forma de actualizar y para frizar los campos
        }
    }
}
