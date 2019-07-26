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
        private string usuarioLog;

        public Nuevo_Test()
        {
            InitializeComponent();
        }

        public Nuevo_Test(string usuario)
        {
            InitializeComponent();
            usuarioLog = usuario;
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
            List<UsuarioTester> listadoUsuarios = new List<UsuarioTester>();
            try
            {
                //Cargo los combos
                cmbSistema.DataSource = sistemaNegocio.listarSistemas();
                cmbPrioridad.DataSource = prioridadNegocio.listarPrioridades();
                cmbUsuarioTester.DataSource = testerNegocio.listarUsuariosT();
                cmbSolicitante.DataSource = compañiaNegocio.listarCompañias();
                cmbAplica.DataSource = grupoCompañiasNegocio.listarGrupoCompañias();
                cmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbUsuarioTester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cmbAplica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

                listadoUsuarios = testerNegocio.listarUsuariosT();
                foreach (var usuario in listadoUsuarios)
                {
                    if (usuario.Documento == usuarioLog)
                    {
                        cmbUsuarioTester.SelectedIndex = cmbUsuarioTester.FindString(usuario.Nombre + " " + usuario.Apellido);
                    }
                }
                txtIDTest.ReadOnly = true;
                txtVersion.ReadOnly = true;
                cmbUsuarioTester.Enabled = false;
                //RELLENAR LOS CAMPOS QUE VIENEN DE LA BUSQUEDA
                if (testLocal != null)
                {
                    if (testLocal.ID == 0)
                    {
                        txtTicket.Text = testLocal.NTicket.ToString();
                        txtAsunto.Text = testLocal.Asunto;
                        txtDescripcion.Text = testLocal.Descripcion;
                        cmbSistema.SelectedIndex = cmbSistema.FindString(testLocal.Sistema.Nombre);
                        cmbPrioridad.SelectedIndex = cmbPrioridad.FindString(testLocal.Prioridad.TipoPrioridad);
                        cmbUsuarioTester.SelectedIndex = cmbUsuarioTester.FindString(testLocal.UsuarioT.Nombre + " " + testLocal.UsuarioT.Apellido);
                        cmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        cmbUsuarioTester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    }
                    else
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
                        cmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        cmbUsuarioTester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        cmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                        cmbAplica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    }
                }
                //VERIFICA SI ESTA FINALIZADO PARA ESCONDER BOTONES Y FRIZAR CAMPOS
                if (testLocal == null || testLocal.Finalizado != true)
                {
                    btnGenerarVersion.Visible = false;
                }
                else
                {
                    if (testLocal.Ultimo != true || testLocal.VersionFinal == true)
                    {
                        btnGenerarVersion.Visible = false;
                    }
                    bloquearCampos();
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
                if (txtTicket.Text == "" || txtAsunto.Text == "" || txtDescripcion.Text == "" || cmbPrioridad.SelectedIndex == 0 || cmbSistema.SelectedIndex == 0 || cmbSolicitante.SelectedIndex == 0 || cmbUsuarioTester.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    if (testLocal != null)
                    {
                        if (testLocal.ID == 0)// Si viene desde Buscar tickets
                        {
                            testLocal.NTicket = Convert.ToInt32(txtTicket.Text);
                            testLocal.Sistema = (Sistema)cmbSistema.SelectedItem;
                            testLocal.UsuarioT = (UsuarioTester)cmbUsuarioTester.SelectedItem;
                            testLocal.Prioridad = (Prioridad)cmbPrioridad.SelectedItem;
                            testLocal.CiaSolicitante = (Compañia)cmbSolicitante.SelectedItem;
                            testLocal.GrupoCia = (GrupoCompañias)cmbAplica.SelectedItem;
                            testLocal.Asunto = txtAsunto.Text;
                            testLocal.Descripcion = txtDescripcion.Text;
                            testLocal.ID = testNegocio.agregarTest(testLocal);
                            testLocal.Version = 1;
                            txtIDTest.Text = testLocal.ID.ToString();
                            txtVersion.Text = testLocal.Version.ToString();
                            MessageBox.Show("Se Guardo Correctamente.");
                        }
                        else//Si viene desde Buscar Test
                        {
                            cargarTest(testLocal);
                            testNegocio.modificarTest(testLocal);
                            MessageBox.Show("Se Guardo Correctamente.");
                        }
                    }
                    else //Si viene desde Nuevo Test
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
                        testLocal.ID = testNegocio.agregarTest(testLocal);
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
            if (txtIDTest.Text == "")
            {
                MessageBox.Show("Debe grabar para continuar");
            }
            else
            {
                //verifica si entro por nueva o por busqueda
                if (testLocal == null)
                {
                    testLocal = new Test();
                    cargarTest(testLocal);
                    frmAgregarDatos frmAD = new frmAgregarDatos(testLocal);
                    frmAD.ShowDialog();
                }
                else
                {
                    frmAgregarDatos frmAD = new frmAgregarDatos(testLocal);
                    frmAD.ShowDialog();
                }

            }
        }

        private void btnAgregarCasosPrueba_Click(object sender, EventArgs e)
        {
            UsuarioPruebaNegocio UPNegocio = new UsuarioPruebaNegocio();
            SiniestroPruebaNegocio SPNegocio = new SiniestroPruebaNegocio();
            if (txtIDTest.Text == "")
            {
                MessageBox.Show("Debe grabar para continuar");
            }
            else
            {
                if (UPNegocio.verificarUsuarioCargado(testLocal) && SPNegocio.verificarDatoCargado(testLocal))
                {
                    //verifica si entro por nueva o por busqueda
                    if (testLocal == null)
                    {
                        testLocal = new Test();
                        cargarTest(testLocal);
                        frmAgregarCasoPrueba frmACP = new frmAgregarCasoPrueba(testLocal);
                        frmACP.ShowDialog();
                    }
                    else
                    {
                        frmAgregarCasoPrueba frmACP = new frmAgregarCasoPrueba(testLocal);
                        frmACP.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Debe haber al menos 1 usuario y 1 dato para poder agregar Casos de Prueba!");
                }
            }
        }

        private void btnGenerarVersion_Click(object sender, EventArgs e)
        {
            TestNegocio testNegocio = new TestNegocio();
            testNegocio.agregarVersion(testLocal);

            List<UsuarioPrueba> listadoUP = new List<UsuarioPrueba>();
            UsuarioPruebaNegocio upNegocio = new UsuarioPruebaNegocio();
            listadoUP = upNegocio.obtenerUsuarioVersion(testLocal);
            upNegocio.pasarUsuariosVersion(listadoUP);

            List<SiniestroPrueba> listadoSP = new List<SiniestroPrueba>();
            SiniestroPruebaNegocio spNegocio = new SiniestroPruebaNegocio();
            listadoSP = spNegocio.obtenerSiniestroVersion(testLocal);
            spNegocio.pasarSiniestrosVersion(listadoSP);

            List<CasoPrueba> listadoCP = new List<CasoPrueba>();
            CasoPruebaNegocio cpNegocio = new CasoPruebaNegocio();
            listadoCP = cpNegocio.obtenerCasoVersion(testLocal);
            cpNegocio.pasarCasosVersion(listadoCP);

            this.Close();
            testLocal.Version++;
            testLocal.Finalizado = false;
            Nuevo_Test frmNT = new Nuevo_Test(testLocal);
            frmNT.Show();
        }

        private void btnFinalizarVersion_Click(object sender, EventArgs e)
        {
            CasoPruebaNegocio CPNegocio = new CasoPruebaNegocio();
            if (txtTicket.Text == "" || txtAsunto.Text == "" || txtDescripcion.Text == "" || cmbPrioridad.SelectedIndex == 0 || cmbSistema.SelectedIndex == 0 || cmbSolicitante.SelectedIndex == 0 || cmbUsuarioTester.SelectedIndex == 0)
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                if (CPNegocio.verificarCasosCargados(testLocal))
                {
                    TestNegocio testNegocio = new TestNegocio();
                    cargarTest(testLocal);
                    testNegocio.modificarTest(testLocal);
                    testNegocio.finalizarVersion(testLocal);
                    MessageBox.Show("La version se finalizo");
                    bloquearCampos();
                    testLocal.Finalizado = true;
                    btnGenerarVersion.Visible = true;
                }
                else
                {
                    MessageBox.Show("Debe cargar al menos 1 caso de prueba para finalizar el Testeo");
                }
            }
        }

        private void btnTestingOK_Click(object sender, EventArgs e)
        {
            CasoPruebaNegocio CPNegocio = new CasoPruebaNegocio();
            if (txtTicket.Text == "" || txtAsunto.Text == "" || txtDescripcion.Text == "" || cmbPrioridad.SelectedIndex == 0 || cmbSistema.SelectedIndex == 0 || cmbSolicitante.SelectedIndex == 0 || cmbUsuarioTester.SelectedIndex == 0)
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                if(CPNegocio.verificarCasosCargados(testLocal))
                {
                    if (CPNegocio.verificarCasosConFallas(testLocal))
                    {
                        MessageBox.Show("No puede finalizar el Test mientras existan casos con fallas");
                    }
                    else
                    {
                        TestNegocio testNegocio = new TestNegocio();
                        cargarTest(testLocal);
                        testNegocio.modificarTest(testLocal);
                        testNegocio.generarVersionFinal(testLocal);
                        MessageBox.Show("Se finalizo el test, TESTING OK!!!");
                        bloquearCampos();
                        testLocal.Finalizado = true;
                    }
                }
                else
                {
                    MessageBox.Show("Debe cargar al menos 1 caso de prueba para finalizar el Testeo");
                }
                
            }
        }

        private void bloquearCampos()
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
}
