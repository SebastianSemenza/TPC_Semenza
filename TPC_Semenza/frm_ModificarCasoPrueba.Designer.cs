namespace TPC_Semenza
{
    partial class frm_ModificarCasoPrueba
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
            this.lblDatoPrueba = new System.Windows.Forms.Label();
            this.cmbDatoPrueba = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.txbDetalleFalla = new System.Windows.Forms.RichTextBox();
            this.txbDetalle = new System.Windows.Forms.RichTextBox();
            this.lblDetalleFalla = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.ckbResultado = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDatoPrueba
            // 
            this.lblDatoPrueba.AutoSize = true;
            this.lblDatoPrueba.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDatoPrueba.Location = new System.Drawing.Point(23, 277);
            this.lblDatoPrueba.Name = "lblDatoPrueba";
            this.lblDatoPrueba.Size = new System.Drawing.Size(85, 13);
            this.lblDatoPrueba.TabIndex = 60;
            this.lblDatoPrueba.Text = "Dato de Prueba:";
            // 
            // cmbDatoPrueba
            // 
            this.cmbDatoPrueba.FormattingEnabled = true;
            this.cmbDatoPrueba.Location = new System.Drawing.Point(114, 274);
            this.cmbDatoPrueba.Name = "cmbDatoPrueba";
            this.cmbDatoPrueba.Size = new System.Drawing.Size(183, 21);
            this.cmbDatoPrueba.TabIndex = 59;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsuario.Location = new System.Drawing.Point(23, 250);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 58;
            this.lblUsuario.Text = "Usuario:";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(114, 247);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(183, 21);
            this.cmbUsuario.TabIndex = 57;
            // 
            // txbDetalleFalla
            // 
            this.txbDetalleFalla.Location = new System.Drawing.Point(449, 81);
            this.txbDetalleFalla.Name = "txbDetalleFalla";
            this.txbDetalleFalla.Size = new System.Drawing.Size(380, 148);
            this.txbDetalleFalla.TabIndex = 56;
            this.txbDetalleFalla.Text = "";
            // 
            // txbDetalle
            // 
            this.txbDetalle.Location = new System.Drawing.Point(26, 81);
            this.txbDetalle.Name = "txbDetalle";
            this.txbDetalle.Size = new System.Drawing.Size(399, 148);
            this.txbDetalle.TabIndex = 55;
            this.txbDetalle.Text = "";
            // 
            // lblDetalleFalla
            // 
            this.lblDetalleFalla.AutoSize = true;
            this.lblDetalleFalla.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDetalleFalla.Location = new System.Drawing.Point(446, 58);
            this.lblDetalleFalla.Name = "lblDetalleFalla";
            this.lblDetalleFalla.Size = new System.Drawing.Size(91, 13);
            this.lblDetalleFalla.TabIndex = 54;
            this.lblDetalleFalla.Text = "Detalle de la falla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Detalle:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Descripcion:";
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(95, 22);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(330, 20);
            this.txbDescripcion.TabIndex = 51;
            // 
            // ckbResultado
            // 
            this.ckbResultado.AutoSize = true;
            this.ckbResultado.ForeColor = System.Drawing.SystemColors.Control;
            this.ckbResultado.Location = new System.Drawing.Point(449, 25);
            this.ckbResultado.Name = "ckbResultado";
            this.ckbResultado.Size = new System.Drawing.Size(141, 17);
            this.ckbResultado.TabIndex = 50;
            this.ckbResultado.Text = "Funcionó correctamente";
            this.ckbResultado.UseVisualStyleBackColor = true;
            this.ckbResultado.CheckedChanged += new System.EventHandler(this.ckbResultado_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(524, 267);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(305, 28);
            this.btnAceptar.TabIndex = 61;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frm_ModificarCasoPrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(843, 316);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblDatoPrueba);
            this.Controls.Add(this.cmbDatoPrueba);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.txbDetalleFalla);
            this.Controls.Add(this.txbDetalle);
            this.Controls.Add(this.lblDetalleFalla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.ckbResultado);
            this.Name = "frm_ModificarCasoPrueba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ModificarCasoPrueba";
            this.Load += new System.EventHandler(this.frm_ModificarCasoPrueba_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatoPrueba;
        private System.Windows.Forms.ComboBox cmbDatoPrueba;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.RichTextBox txbDetalleFalla;
        private System.Windows.Forms.RichTextBox txbDetalle;
        private System.Windows.Forms.Label lblDetalleFalla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.CheckBox ckbResultado;
        private System.Windows.Forms.Button btnAceptar;
    }
}