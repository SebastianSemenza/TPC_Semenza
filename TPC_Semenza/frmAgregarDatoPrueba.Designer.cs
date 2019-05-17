namespace TPC_Semenza
{
    partial class frmAgregarDatoPrueba
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
            this.cmbSistema = new System.Windows.Forms.ComboBox();
            this.cmbCompañia = new System.Windows.Forms.ComboBox();
            this.txbPatente = new System.Windows.Forms.TextBox();
            this.txbNroSiniestro = new System.Windows.Forms.TextBox();
            this.lblSistema = new System.Windows.Forms.Label();
            this.lblCompañia = new System.Windows.Forms.Label();
            this.lblPatente = new System.Windows.Forms.Label();
            this.lblNroSiniestro = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbSistema
            // 
            this.cmbSistema.FormattingEnabled = true;
            this.cmbSistema.Location = new System.Drawing.Point(83, 165);
            this.cmbSistema.Name = "cmbSistema";
            this.cmbSistema.Size = new System.Drawing.Size(201, 21);
            this.cmbSistema.TabIndex = 21;
            // 
            // cmbCompañia
            // 
            this.cmbCompañia.FormattingEnabled = true;
            this.cmbCompañia.Location = new System.Drawing.Point(83, 134);
            this.cmbCompañia.Name = "cmbCompañia";
            this.cmbCompañia.Size = new System.Drawing.Size(201, 21);
            this.cmbCompañia.TabIndex = 20;
            // 
            // txbPatente
            // 
            this.txbPatente.Location = new System.Drawing.Point(83, 98);
            this.txbPatente.Name = "txbPatente";
            this.txbPatente.Size = new System.Drawing.Size(201, 20);
            this.txbPatente.TabIndex = 19;
            // 
            // txbNroSiniestro
            // 
            this.txbNroSiniestro.Location = new System.Drawing.Point(83, 62);
            this.txbNroSiniestro.Name = "txbNroSiniestro";
            this.txbNroSiniestro.Size = new System.Drawing.Size(201, 20);
            this.txbNroSiniestro.TabIndex = 18;
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSistema.Location = new System.Drawing.Point(12, 173);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(47, 13);
            this.lblSistema.TabIndex = 17;
            this.lblSistema.Text = "Sistema:";
            // 
            // lblCompañia
            // 
            this.lblCompañia.AutoSize = true;
            this.lblCompañia.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCompañia.Location = new System.Drawing.Point(12, 137);
            this.lblCompañia.Name = "lblCompañia";
            this.lblCompañia.Size = new System.Drawing.Size(54, 13);
            this.lblCompañia.TabIndex = 16;
            this.lblCompañia.Text = "Compañia";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPatente.Location = new System.Drawing.Point(12, 101);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(47, 13);
            this.lblPatente.TabIndex = 15;
            this.lblPatente.Text = "Patente:";
            // 
            // lblNroSiniestro
            // 
            this.lblNroSiniestro.AutoSize = true;
            this.lblNroSiniestro.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNroSiniestro.Location = new System.Drawing.Point(12, 65);
            this.lblNroSiniestro.Name = "lblNroSiniestro";
            this.lblNroSiniestro.Size = new System.Drawing.Size(70, 13);
            this.lblNroSiniestro.TabIndex = 14;
            this.lblNroSiniestro.Text = "Nro Siniestro:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(112, 211);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // frmAgregarDatoPrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(296, 296);
            this.Controls.Add(this.cmbSistema);
            this.Controls.Add(this.cmbCompañia);
            this.Controls.Add(this.txbPatente);
            this.Controls.Add(this.txbNroSiniestro);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblCompañia);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.lblNroSiniestro);
            this.Controls.Add(this.btnAgregar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarDatoPrueba";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarDatoPrueba";
            this.Load += new System.EventHandler(this.frmAgregarDatoPrueba_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSistema;
        private System.Windows.Forms.ComboBox cmbCompañia;
        private System.Windows.Forms.TextBox txbPatente;
        private System.Windows.Forms.TextBox txbNroSiniestro;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblCompañia;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Label lblNroSiniestro;
        private System.Windows.Forms.Button btnAgregar;
    }
}