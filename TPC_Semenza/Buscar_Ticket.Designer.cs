namespace TPC_Semenza
{
    partial class Buscar_Ticket
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
            this.dgvResultadoBusqueda = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbEstadoTicket = new System.Windows.Forms.ComboBox();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.cmbSistema = new System.Windows.Forms.ComboBox();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.txtNTicket = new System.Windows.Forms.TextBox();
            this.dtpFechaGrabadoHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaGrabadoHasta = new System.Windows.Forms.Label();
            this.lblFechaGrabadoDesde = new System.Windows.Forms.Label();
            this.dtpFechaGrabadoDesde = new System.Windows.Forms.DateTimePicker();
            this.lblEstadoTicket = new System.Windows.Forms.Label();
            this.lblFechaGrabado = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResultadoBusqueda
            // 
            this.dgvResultadoBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultadoBusqueda.Location = new System.Drawing.Point(31, 218);
            this.dgvResultadoBusqueda.Name = "dgvResultadoBusqueda";
            this.dgvResultadoBusqueda.Size = new System.Drawing.Size(619, 239);
            this.dgvResultadoBusqueda.TabIndex = 41;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(468, 177);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(182, 23);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbEstadoTicket
            // 
            this.cmbEstadoTicket.FormattingEnabled = true;
            this.cmbEstadoTicket.Location = new System.Drawing.Point(116, 50);
            this.cmbEstadoTicket.Name = "cmbEstadoTicket";
            this.cmbEstadoTicket.Size = new System.Drawing.Size(200, 21);
            this.cmbEstadoTicket.TabIndex = 39;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(450, 84);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(200, 21);
            this.cmbPrioridad.TabIndex = 38;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(450, 18);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(200, 21);
            this.cmbUsuario.TabIndex = 37;
            // 
            // cmbSistema
            // 
            this.cmbSistema.FormattingEnabled = true;
            this.cmbSistema.Location = new System.Drawing.Point(116, 79);
            this.cmbSistema.Name = "cmbSistema";
            this.cmbSistema.Size = new System.Drawing.Size(200, 21);
            this.cmbSistema.TabIndex = 36;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(450, 51);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(200, 20);
            this.txtAsunto.TabIndex = 35;
            // 
            // txtNTicket
            // 
            this.txtNTicket.Location = new System.Drawing.Point(116, 18);
            this.txtNTicket.Name = "txtNTicket";
            this.txtNTicket.Size = new System.Drawing.Size(200, 20);
            this.txtNTicket.TabIndex = 33;
            // 
            // dtpFechaGrabadoHasta
            // 
            this.dtpFechaGrabadoHasta.Location = new System.Drawing.Point(116, 176);
            this.dtpFechaGrabadoHasta.Name = "dtpFechaGrabadoHasta";
            this.dtpFechaGrabadoHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaGrabadoHasta.TabIndex = 32;
            // 
            // lblFechaGrabadoHasta
            // 
            this.lblFechaGrabadoHasta.AutoSize = true;
            this.lblFechaGrabadoHasta.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFechaGrabadoHasta.Location = new System.Drawing.Point(28, 178);
            this.lblFechaGrabadoHasta.Name = "lblFechaGrabadoHasta";
            this.lblFechaGrabadoHasta.Size = new System.Drawing.Size(38, 13);
            this.lblFechaGrabadoHasta.TabIndex = 31;
            this.lblFechaGrabadoHasta.Text = "Hasta:";
            // 
            // lblFechaGrabadoDesde
            // 
            this.lblFechaGrabadoDesde.AutoSize = true;
            this.lblFechaGrabadoDesde.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFechaGrabadoDesde.Location = new System.Drawing.Point(28, 154);
            this.lblFechaGrabadoDesde.Name = "lblFechaGrabadoDesde";
            this.lblFechaGrabadoDesde.Size = new System.Drawing.Size(41, 13);
            this.lblFechaGrabadoDesde.TabIndex = 30;
            this.lblFechaGrabadoDesde.Text = "Desde:";
            // 
            // dtpFechaGrabadoDesde
            // 
            this.dtpFechaGrabadoDesde.Location = new System.Drawing.Point(116, 152);
            this.dtpFechaGrabadoDesde.Name = "dtpFechaGrabadoDesde";
            this.dtpFechaGrabadoDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaGrabadoDesde.TabIndex = 29;
            // 
            // lblEstadoTicket
            // 
            this.lblEstadoTicket.AutoSize = true;
            this.lblEstadoTicket.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEstadoTicket.Location = new System.Drawing.Point(28, 54);
            this.lblEstadoTicket.Name = "lblEstadoTicket";
            this.lblEstadoTicket.Size = new System.Drawing.Size(76, 13);
            this.lblEstadoTicket.TabIndex = 28;
            this.lblEstadoTicket.Text = "Estado Ticket:";
            // 
            // lblFechaGrabado
            // 
            this.lblFechaGrabado.AutoSize = true;
            this.lblFechaGrabado.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFechaGrabado.Location = new System.Drawing.Point(28, 127);
            this.lblFechaGrabado.Name = "lblFechaGrabado";
            this.lblFechaGrabado.Size = new System.Drawing.Size(99, 13);
            this.lblFechaGrabado.TabIndex = 27;
            this.lblFechaGrabado.Text = "Fecha de Grabado:";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPrioridad.Location = new System.Drawing.Point(376, 87);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(51, 13);
            this.lblPrioridad.TabIndex = 26;
            this.lblPrioridad.Text = "Prioridad:";
            // 
            // lblAsunto
            // 
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAsunto.Location = new System.Drawing.Point(376, 54);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(43, 13);
            this.lblAsunto.TabIndex = 25;
            this.lblAsunto.Text = "Asunto:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsuario.Location = new System.Drawing.Point(376, 21);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 24;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSistema.Location = new System.Drawing.Point(28, 87);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(47, 13);
            this.lblSistema.TabIndex = 23;
            this.lblSistema.Text = "Sistema:";
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTicket.Location = new System.Drawing.Point(28, 21);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(55, 13);
            this.lblTicket.TabIndex = 21;
            this.lblTicket.Text = "Nº Ticket:";
            // 
            // Buscar_Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(662, 469);
            this.Controls.Add(this.dgvResultadoBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbEstadoTicket);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.cmbSistema);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.txtNTicket);
            this.Controls.Add(this.dtpFechaGrabadoHasta);
            this.Controls.Add(this.lblFechaGrabadoHasta);
            this.Controls.Add(this.lblFechaGrabadoDesde);
            this.Controls.Add(this.dtpFechaGrabadoDesde);
            this.Controls.Add(this.lblEstadoTicket);
            this.Controls.Add(this.lblFechaGrabado);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.lblAsunto);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblTicket);
            this.Name = "Buscar_Ticket";
            this.Text = "Buscar_Ticket";
            this.Load += new System.EventHandler(this.Buscar_Ticket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultadoBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbEstadoTicket;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.ComboBox cmbSistema;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.TextBox txtNTicket;
        private System.Windows.Forms.DateTimePicker dtpFechaGrabadoHasta;
        private System.Windows.Forms.Label lblFechaGrabadoHasta;
        private System.Windows.Forms.Label lblFechaGrabadoDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaGrabadoDesde;
        private System.Windows.Forms.Label lblEstadoTicket;
        private System.Windows.Forms.Label lblFechaGrabado;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblTicket;
    }
}