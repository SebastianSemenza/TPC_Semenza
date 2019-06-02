﻿using System;
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
    public partial class frmAgregarDatos : Form
    {
        private List<UsuarioPrueba> listadoUP = new List<UsuarioPrueba>();
        private List<SiniestroPrueba> listadoSP = new List<SiniestroPrueba>();
        private Test testLocal = null;

        public frmAgregarDatos()
        {
            InitializeComponent();
        }

        public frmAgregarDatos(Test test)
        {
            InitializeComponent();
            testLocal = test;
        }

        private void btnAgregarUP_Click(object sender, EventArgs e)
        {
            AgregarUsuarioPrueba newForm = new AgregarUsuarioPrueba(testLocal);
            newForm.ShowDialog();
            cargarGrillaUsuariosP();
        }

        private void btnAgregarDato_Click(object sender, EventArgs e)
        {
            frmAgregarDatoPrueba newForm = new frmAgregarDatoPrueba(testLocal);
            newForm.ShowDialog();
            cargarGrillaSiniestrosP();
        }

        private void frmAgregarDatos_Load(object sender, EventArgs e)
        {
            //DATAGRIDVIEW USUARIOS PRUEBA
            cargarGrillaUsuariosP();
            //DATAGRIDVIEW STRO PRUEBA
            cargarGrillaSiniestrosP();
        }

        private void cargarGrillaUsuariosP()
        {
            UsuarioPruebaNegocio UPnegocio = new UsuarioPruebaNegocio();
            try
            {
                //DATAGRIDVIEW USUARIO PRUEBA
                listadoUP = UPnegocio.listarUsuariosP(testLocal);
                dgvUsuariosPrueba.DataSource = listadoUP;
                dgvUsuariosPrueba.Columns["ID"].Visible = false;
                dgvUsuariosPrueba.Columns["Test"].Visible = false;
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
                listadoSP = SPnegocio.listarSiniestroP(testLocal);
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
