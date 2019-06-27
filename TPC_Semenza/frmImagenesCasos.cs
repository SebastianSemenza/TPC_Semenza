using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace TPC_Semenza
{
    public partial class frmImagenesCasos : Form
    {
        ImagenCasoNegocio ImagenNegocio = new ImagenCasoNegocio();
        CasoPrueba CasoLocal;

        public frmImagenesCasos()
        {
            InitializeComponent();
        }

        public frmImagenesCasos(CasoPrueba caso)
        {
            InitializeComponent();
            CasoLocal = caso;
        }

        private void btnBuscarImg_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.Equals("") == false)
                {
                    pcbImagenes.Load(this.openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puedo cargar la imagen" + ex.ToString());
            }
        }

        private void frmImagenesCasos_Load(object sender, EventArgs e)
        {
            ImagenNegocio.abrirConexion();
            ImagenNegocio.cargarImagenes(cmbImagenes,CasoLocal.ID);
            cmbImagenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //cmbImagenes.SelectedIndex = 0; 
        }

        private void cmbImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImagenNegocio.verImagen(pcbImagenes, CasoLocal.ID,cmbImagenes.SelectedItem.ToString());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txbDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar una descripcion para la imagen!");
            }
            else
            {
                MessageBox.Show(ImagenNegocio.insertarImagen(CasoLocal.ID, txbDescripcion.Text, pcbImagenes));
                cmbImagenes.Items.Clear();
                ImagenNegocio.cargarImagenes(cmbImagenes, CasoLocal.ID);
            }
        }
    }
}
