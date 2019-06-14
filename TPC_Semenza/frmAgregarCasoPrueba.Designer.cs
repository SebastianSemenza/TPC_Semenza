namespace TPC_Semenza
{
    partial class frmAgregarCasoPrueba
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ckbResultado = new System.Windows.Forms.CheckBox();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDetalle = new System.Windows.Forms.RichTextBox();
            this.txbDetalleFalla = new System.Windows.Forms.RichTextBox();
            this.btnEliminarCaso = new System.Windows.Forms.Button();
            this.btnModificarCaso = new System.Windows.Forms.Button();
            this.btnAgregarCaso = new System.Windows.Forms.Button();
            this.lblCasosPrueba = new System.Windows.Forms.Label();
            this.dgvCasosPrueba = new System.Windows.Forms.DataGridView();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblDatoPrueba = new System.Windows.Forms.Label();
            this.cmbDatoPrueba = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCasosPrueba)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbResultado
            // 
            this.ckbResultado.AutoSize = true;
            this.ckbResultado.ForeColor = System.Drawing.SystemColors.Control;
            this.ckbResultado.Location = new System.Drawing.Point(448, 37);
            this.ckbResultado.Name = "ckbResultado";
            this.ckbResultado.Size = new System.Drawing.Size(141, 17);
            this.ckbResultado.TabIndex = 0;
            this.ckbResultado.Text = "Funcionó correctamente";
            this.ckbResultado.UseVisualStyleBackColor = true;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(94, 34);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(330, 20);
            this.txbDescripcion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descripcion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(22, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detalle:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(445, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Detalle de la falla:";
            // 
            // txbDetalle
            // 
            this.txbDetalle.Location = new System.Drawing.Point(25, 93);
            this.txbDetalle.Name = "txbDetalle";
            this.txbDetalle.Size = new System.Drawing.Size(399, 148);
            this.txbDetalle.TabIndex = 12;
            this.txbDetalle.Text = "";
            // 
            // txbDetalleFalla
            // 
            this.txbDetalleFalla.Location = new System.Drawing.Point(448, 93);
            this.txbDetalleFalla.Name = "txbDetalleFalla";
            this.txbDetalleFalla.Size = new System.Drawing.Size(380, 148);
            this.txbDetalleFalla.TabIndex = 13;
            this.txbDetalleFalla.Text = "";
            // 
            // btnEliminarCaso
            // 
            this.btnEliminarCaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnEliminarCaso.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminarCaso.Location = new System.Drawing.Point(386, 356);
            this.btnEliminarCaso.Name = "btnEliminarCaso";
            this.btnEliminarCaso.Size = new System.Drawing.Size(107, 28);
            this.btnEliminarCaso.TabIndex = 45;
            this.btnEliminarCaso.Text = "Eliminar";
            this.btnEliminarCaso.UseVisualStyleBackColor = false;
            this.btnEliminarCaso.Click += new System.EventHandler(this.btnEliminarCaso_Click);
            // 
            // btnModificarCaso
            // 
            this.btnModificarCaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnModificarCaso.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificarCaso.Location = new System.Drawing.Point(273, 356);
            this.btnModificarCaso.Name = "btnModificarCaso";
            this.btnModificarCaso.Size = new System.Drawing.Size(107, 28);
            this.btnModificarCaso.TabIndex = 44;
            this.btnModificarCaso.Text = "Modificar";
            this.btnModificarCaso.UseVisualStyleBackColor = false;
            this.btnModificarCaso.Click += new System.EventHandler(this.btnModificarCaso_Click);
            // 
            // btnAgregarCaso
            // 
            this.btnAgregarCaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnAgregarCaso.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregarCaso.Location = new System.Drawing.Point(160, 356);
            this.btnAgregarCaso.Name = "btnAgregarCaso";
            this.btnAgregarCaso.Size = new System.Drawing.Size(107, 28);
            this.btnAgregarCaso.TabIndex = 43;
            this.btnAgregarCaso.Text = "Agregar";
            this.btnAgregarCaso.UseVisualStyleBackColor = false;
            this.btnAgregarCaso.Click += new System.EventHandler(this.btnAgregarCaso_Click);
            // 
            // lblCasosPrueba
            // 
            this.lblCasosPrueba.AutoSize = true;
            this.lblCasosPrueba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCasosPrueba.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCasosPrueba.Location = new System.Drawing.Point(12, 356);
            this.lblCasosPrueba.Name = "lblCasosPrueba";
            this.lblCasosPrueba.Size = new System.Drawing.Size(106, 13);
            this.lblCasosPrueba.TabIndex = 42;
            this.lblCasosPrueba.Text = "Casos de prueba:";
            // 
            // dgvCasosPrueba
            // 
            this.dgvCasosPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCasosPrueba.Location = new System.Drawing.Point(12, 390);
            this.dgvCasosPrueba.Name = "dgvCasosPrueba";
            this.dgvCasosPrueba.Size = new System.Drawing.Size(803, 311);
            this.dgvCasosPrueba.TabIndex = 41;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(113, 259);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(183, 21);
            this.cmbUsuario.TabIndex = 46;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsuario.Location = new System.Drawing.Point(22, 262);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 47;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblDatoPrueba
            // 
            this.lblDatoPrueba.AutoSize = true;
            this.lblDatoPrueba.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDatoPrueba.Location = new System.Drawing.Point(22, 289);
            this.lblDatoPrueba.Name = "lblDatoPrueba";
            this.lblDatoPrueba.Size = new System.Drawing.Size(85, 13);
            this.lblDatoPrueba.TabIndex = 49;
            this.lblDatoPrueba.Text = "Dato de Prueba:";
            // 
            // cmbDatoPrueba
            // 
            this.cmbDatoPrueba.FormattingEnabled = true;
            this.cmbDatoPrueba.Location = new System.Drawing.Point(113, 286);
            this.cmbDatoPrueba.Name = "cmbDatoPrueba";
            this.cmbDatoPrueba.Size = new System.Drawing.Size(183, 21);
            this.cmbDatoPrueba.TabIndex = 48;
            // 
            // frmAgregarCasoPrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(840, 749);
            this.Controls.Add(this.lblDatoPrueba);
            this.Controls.Add(this.cmbDatoPrueba);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.btnEliminarCaso);
            this.Controls.Add(this.btnModificarCaso);
            this.Controls.Add(this.btnAgregarCaso);
            this.Controls.Add(this.lblCasosPrueba);
            this.Controls.Add(this.dgvCasosPrueba);
            this.Controls.Add(this.txbDetalleFalla);
            this.Controls.Add(this.txbDetalle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.ckbResultado);
            this.Name = "frmAgregarCasoPrueba";
            this.Text = "frmAgregarCasoPrueba";
            this.Load += new System.EventHandler(this.frmAgregarCasoPrueba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCasosPrueba)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbResultado;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txbDetalle;
        private System.Windows.Forms.RichTextBox txbDetalleFalla;
        private System.Windows.Forms.Button btnEliminarCaso;
        private System.Windows.Forms.Button btnModificarCaso;
        private System.Windows.Forms.Button btnAgregarCaso;
        private System.Windows.Forms.Label lblCasosPrueba;
        public System.Windows.Forms.DataGridView dgvCasosPrueba;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblDatoPrueba;
        private System.Windows.Forms.ComboBox cmbDatoPrueba;
    }
}