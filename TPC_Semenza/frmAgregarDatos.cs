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
            //VERIFICA SI ESTA FINALIZADO PARA ESCONDER BOTONES Y FRIZAR CAMPOS
            if (testLocal.Finalizado == true)
            {
                btnAgregarDato.Visible = false;
                btnEliminarDato.Visible = false;
                btnModificarDato.Visible = false;
                btnAgregarUP.Visible = false;
                btnEliminarUP.Visible = false;
                btnModificarUP.Visible = false;
            }
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
                dgvUsuariosPrueba.ReadOnly = true;
                dgvUsuariosPrueba.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsuariosPrueba.MultiSelect = false;
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
                dgvDatosPrueba.ReadOnly = true;
                dgvDatosPrueba.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDatosPrueba.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificarUP_Click(object sender, EventArgs e)
        {
            if (dgvUsuariosPrueba.SelectedRows.Count == 1)
            {
                AgregarUsuarioPrueba frmAgregarUP = new AgregarUsuarioPrueba(testLocal, (UsuarioPrueba)dgvUsuariosPrueba.CurrentRow.DataBoundItem);
                frmAgregarUP.ShowDialog();
                cargarGrillaUsuariosP();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila!");
            }
        }

        private void btnEliminarUP_Click(object sender, EventArgs e)
        {
            UsuarioPruebaNegocio UPNegocio = new UsuarioPruebaNegocio();
            try
            {
                if(dgvUsuariosPrueba.SelectedRows.Count==1)
                {
                    if(UPNegocio.verificarEnUso((UsuarioPrueba)dgvUsuariosPrueba.CurrentRow.DataBoundItem,testLocal)==true)
                    {
                        MessageBox.Show("El usuario esta en uso en un caso de prueba!");
                    }
                    else
                    {
                        UPNegocio.eliminarUsuarioP((UsuarioPrueba)dgvUsuariosPrueba.CurrentRow.DataBoundItem);
                        cargarGrillaUsuariosP();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnModificarDato_Click(object sender, EventArgs e)
        {
            if (dgvDatosPrueba.SelectedRows.Count == 1)
            {
                frmAgregarDatoPrueba frmAgregarSP = new frmAgregarDatoPrueba(testLocal, (SiniestroPrueba)dgvDatosPrueba.CurrentRow.DataBoundItem);
                frmAgregarSP.ShowDialog();
                cargarGrillaSiniestrosP();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila!");
            }
        }

        private void btnEliminarDato_Click(object sender, EventArgs e)
        {
            SiniestroPruebaNegocio SPNegocio = new SiniestroPruebaNegocio();
            try
            {
                if (dgvDatosPrueba.SelectedRows.Count == 1)
                {
                    if (SPNegocio.verificarEnUso((SiniestroPrueba)dgvDatosPrueba.CurrentRow.DataBoundItem, testLocal) == true)
                    {
                        MessageBox.Show("El dato esta en uso en un caso de prueba!");
                    }
                    else
                    {
                        SPNegocio.eliminarSiniestroPrueba((SiniestroPrueba)dgvDatosPrueba.CurrentRow.DataBoundItem);
                        cargarGrillaSiniestrosP();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
