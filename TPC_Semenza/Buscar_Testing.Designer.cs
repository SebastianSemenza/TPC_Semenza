namespace TPC_Semenza
{
    partial class Buscar_Testing
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
            this.lblIDTest = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.lblUsuarioTester = new System.Windows.Forms.Label();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblFechaGrabado = new System.Windows.Forms.Label();
            this.lblTipoGrabado = new System.Windows.Forms.Label();
            this.dtpFechaGrabadoDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaGrabadoDesde = new System.Windows.Forms.Label();
            this.lblFechaGrabadoHasta = new System.Windows.Forms.Label();
            this.dtpFechaGrabadoHasta = new System.Windows.Forms.DateTimePicker();
            this.txtIDTest = new System.Windows.Forms.TextBox();
            this.txtTicket = new System.Windows.Forms.TextBox();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.cmbSistema = new System.Windows.Forms.ComboBox();
            this.cmbUsuarioTester = new System.Windows.Forms.ComboBox();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.cmbTipoGrabado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvResultadoBusqueda = new System.Windows.Forms.DataGridView();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIDTest
            // 
            this.lblIDTest.AutoSize = true;
            this.lblIDTest.ForeColor = System.Drawing.SystemColors.Control;
            this.lblIDTest.Location = new System.Drawing.Point(28, 24);
            this.lblIDTest.Name = "lblIDTest";
            this.lblIDTest.Size = new System.Drawing.Size(45, 13);
            this.lblIDTest.TabIndex = 0;
            this.lblIDTest.Text = "ID Test:";
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTicket.Location = new System.Drawing.Point(28, 57);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(40, 13);
            this.lblTicket.TabIndex = 1;
            this.lblTicket.Text = "Ticket:";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSistema.Location = new System.Drawing.Point(28, 90);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(47, 13);
            this.lblSistema.TabIndex = 2;
            this.lblSistema.Text = "Sistema:";
            // 
            // lblUsuarioTester
            // 
            this.lblUsuarioTester.AutoSize = true;
            this.lblUsuarioTester.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsuarioTester.Location = new System.Drawing.Point(344, 24);
            this.lblUsuarioTester.Name = "lblUsuarioTester";
            this.lblUsuarioTester.Size = new System.Drawing.Size(79, 13);
            this.lblUsuarioTester.TabIndex = 3;
            this.lblUsuarioTester.Text = "Usuario Tester:";
            // 
            // lblAsunto
            // 
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAsunto.Location = new System.Drawing.Point(344, 57);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(43, 13);
            this.lblAsunto.TabIndex = 4;
            this.lblAsunto.Text = "Asunto:";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPrioridad.Location = new System.Drawing.Point(344, 90);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(51, 13);
            this.lblPrioridad.TabIndex = 5;
            this.lblPrioridad.Text = "Prioridad:";
            // 
            // lblFechaGrabado
            // 
            this.lblFechaGrabado.AutoSize = true;
            this.lblFechaGrabado.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFechaGrabado.Location = new System.Drawing.Point(28, 149);
            this.lblFechaGrabado.Name = "lblFechaGrabado";
            this.lblFechaGrabado.Size = new System.Drawing.Size(99, 13);
            this.lblFechaGrabado.TabIndex = 6;
            this.lblFechaGrabado.Text = "Fecha de Grabado:";
            // 
            // lblTipoGrabado
            // 
            this.lblTipoGrabado.AutoSize = true;
            this.lblTipoGrabado.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTipoGrabado.Location = new System.Drawing.Point(343, 125);
            this.lblTipoGrabado.Name = "lblTipoGrabado";
            this.lblTipoGrabado.Size = new System.Drawing.Size(75, 13);
            this.lblTipoGrabado.TabIndex = 7;
            this.lblTipoGrabado.Text = "Tipo Grabado:";
            // 
            // dtpFechaGrabadoDesde
            // 
            this.dtpFechaGrabadoDesde.Location = new System.Drawing.Point(81, 175);
            this.dtpFechaGrabadoDesde.Name = "dtpFechaGrabadoDesde";
            this.dtpFechaGrabadoDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaGrabadoDesde.TabIndex = 8;
            // 
            // lblFechaGrabadoDesde
            // 
            this.lblFechaGrabadoDesde.AutoSize = true;
            this.lblFechaGrabadoDesde.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFechaGrabadoDesde.Location = new System.Drawing.Point(28, 181);
            this.lblFechaGrabadoDesde.Name = "lblFechaGrabadoDesde";
            this.lblFechaGrabadoDesde.Size = new System.Drawing.Size(41, 13);
            this.lblFechaGrabadoDesde.TabIndex = 9;
            this.lblFechaGrabadoDesde.Text = "Desde:";
            // 
            // lblFechaGrabadoHasta
            // 
            this.lblFechaGrabadoHasta.AutoSize = true;
            this.lblFechaGrabadoHasta.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFechaGrabadoHasta.Location = new System.Drawing.Point(27, 206);
            this.lblFechaGrabadoHasta.Name = "lblFechaGrabadoHasta";
            this.lblFechaGrabadoHasta.Size = new System.Drawing.Size(38, 13);
            this.lblFechaGrabadoHasta.TabIndex = 10;
            this.lblFechaGrabadoHasta.Text = "Hasta:";
            // 
            // dtpFechaGrabadoHasta
            // 
            this.dtpFechaGrabadoHasta.Location = new System.Drawing.Point(81, 199);
            this.dtpFechaGrabadoHasta.Name = "dtpFechaGrabadoHasta";
            this.dtpFechaGrabadoHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaGrabadoHasta.TabIndex = 11;
            // 
            // txtIDTest
            // 
            this.txtIDTest.Location = new System.Drawing.Point(81, 21);
            this.txtIDTest.Name = "txtIDTest";
            this.txtIDTest.Size = new System.Drawing.Size(200, 20);
            this.txtIDTest.TabIndex = 12;
            // 
            // txtTicket
            // 
            this.txtTicket.Location = new System.Drawing.Point(81, 54);
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.Size = new System.Drawing.Size(200, 20);
            this.txtTicket.TabIndex = 13;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(429, 54);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(200, 20);
            this.txtAsunto.TabIndex = 14;
            // 
            // cmbSistema
            // 
            this.cmbSistema.FormattingEnabled = true;
            this.cmbSistema.Location = new System.Drawing.Point(81, 87);
            this.cmbSistema.Name = "cmbSistema";
            this.cmbSistema.Size = new System.Drawing.Size(200, 21);
            this.cmbSistema.TabIndex = 15;
            // 
            // cmbUsuarioTester
            // 
            this.cmbUsuarioTester.FormattingEnabled = true;
            this.cmbUsuarioTester.Location = new System.Drawing.Point(429, 21);
            this.cmbUsuarioTester.Name = "cmbUsuarioTester";
            this.cmbUsuarioTester.Size = new System.Drawing.Size(200, 21);
            this.cmbUsuarioTester.TabIndex = 16;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(429, 87);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(200, 21);
            this.cmbPrioridad.TabIndex = 17;
            // 
            // cmbTipoGrabado
            // 
            this.cmbTipoGrabado.FormattingEnabled = true;
            this.cmbTipoGrabado.Location = new System.Drawing.Point(429, 122);
            this.cmbTipoGrabado.Name = "cmbTipoGrabado";
            this.cmbTipoGrabado.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoGrabado.TabIndex = 18;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(447, 200);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(182, 23);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvResultadoBusqueda
            // 
            this.dgvResultadoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultadoBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultadoBusqueda.Location = new System.Drawing.Point(21, 248);
            this.dgvResultadoBusqueda.Name = "dgvResultadoBusqueda";
            this.dgvResultadoBusqueda.Size = new System.Drawing.Size(614, 223);
            this.dgvResultadoBusqueda.TabIndex = 20;
            this.dgvResultadoBusqueda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultadoBusqueda_CellContentDoubleClick);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVersion.Location = new System.Drawing.Point(344, 157);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 21;
            this.lblVersion.Text = "Version:";
            // 
            // cmbVersion
            // 
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(429, 154);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(200, 21);
            this.cmbVersion.TabIndex = 22;
            // 
            // Buscar_Testing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(655, 483);
            this.Controls.Add(this.cmbVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.dgvResultadoBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbTipoGrabado);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.cmbUsuarioTester);
            this.Controls.Add(this.cmbSistema);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.txtTicket);
            this.Controls.Add(this.txtIDTest);
            this.Controls.Add(this.dtpFechaGrabadoHasta);
            this.Controls.Add(this.lblFechaGrabadoHasta);
            this.Controls.Add(this.lblFechaGrabadoDesde);
            this.Controls.Add(this.dtpFechaGrabadoDesde);
            this.Controls.Add(this.lblTipoGrabado);
            this.Controls.Add(this.lblFechaGrabado);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.lblAsunto);
            this.Controls.Add(this.lblUsuarioTester);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.lblIDTest);
            this.Name = "Buscar_Testing";
            this.Text = "Buscar_Testing";
            this.Load += new System.EventHandler(this.Buscar_Testing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIDTest;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblUsuarioTester;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblFechaGrabado;
        private System.Windows.Forms.Label lblTipoGrabado;
        private System.Windows.Forms.DateTimePicker dtpFechaGrabadoDesde;
        private System.Windows.Forms.Label lblFechaGrabadoDesde;
        private System.Windows.Forms.Label lblFechaGrabadoHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaGrabadoHasta;
        private System.Windows.Forms.TextBox txtIDTest;
        private System.Windows.Forms.TextBox txtTicket;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.ComboBox cmbSistema;
        private System.Windows.Forms.ComboBox cmbUsuarioTester;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.ComboBox cmbTipoGrabado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvResultadoBusqueda;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ComboBox cmbVersion;
    }
}