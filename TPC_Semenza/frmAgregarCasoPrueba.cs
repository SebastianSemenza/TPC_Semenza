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

namespace TPC_Semenza
{
    public partial class frmAgregarCasoPrueba : Form
    {
        private Test testLocal = null;

        public frmAgregarCasoPrueba()
        {
            InitializeComponent();
        }

        public frmAgregarCasoPrueba(Test test)
        {
            InitializeComponent();
            testLocal = test;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
