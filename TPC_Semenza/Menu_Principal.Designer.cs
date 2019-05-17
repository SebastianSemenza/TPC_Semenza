namespace TPC_Semenza
{
    partial class Menu_Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Principal));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnBuscarTicket = new System.Windows.Forms.Button();
            this.btnBuscarTest = new System.Windows.Forms.Button();
            this.btnNuevoTest = new System.Windows.Forms.Button();
            this.panelVentanas = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.btnBuscarTicket);
            this.panelMenu.Controls.Add(this.btnBuscarTest);
            this.panelMenu.Controls.Add(this.btnNuevoTest);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 561);
            this.panelMenu.TabIndex = 2;
            // 
            // btnBuscarTicket
            // 
            this.btnBuscarTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnBuscarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarTicket.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTicket.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarTicket.Location = new System.Drawing.Point(12, 203);
            this.btnBuscarTicket.Name = "btnBuscarTicket";
            this.btnBuscarTicket.Size = new System.Drawing.Size(232, 39);
            this.btnBuscarTicket.TabIndex = 2;
            this.btnBuscarTicket.Text = "Buscar Ticket";
            this.btnBuscarTicket.UseVisualStyleBackColor = false;
            this.btnBuscarTicket.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnBuscarTest
            // 
            this.btnBuscarTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnBuscarTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarTest.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTest.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarTest.Location = new System.Drawing.Point(12, 158);
            this.btnBuscarTest.Name = "btnBuscarTest";
            this.btnBuscarTest.Size = new System.Drawing.Size(232, 39);
            this.btnBuscarTest.TabIndex = 1;
            this.btnBuscarTest.Text = "Buscar Test ";
            this.btnBuscarTest.UseVisualStyleBackColor = false;
            this.btnBuscarTest.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNuevoTest
            // 
            this.btnNuevoTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnNuevoTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoTest.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoTest.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevoTest.Location = new System.Drawing.Point(12, 113);
            this.btnNuevoTest.Name = "btnNuevoTest";
            this.btnNuevoTest.Size = new System.Drawing.Size(232, 39);
            this.btnNuevoTest.TabIndex = 0;
            this.btnNuevoTest.Text = "Nuevo Test";
            this.btnNuevoTest.UseVisualStyleBackColor = false;
            this.btnNuevoTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelVentanas
            // 
            this.panelVentanas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelVentanas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVentanas.Location = new System.Drawing.Point(250, 0);
            this.panelVentanas.Name = "panelVentanas";
            this.panelVentanas.Size = new System.Drawing.Size(734, 561);
            this.panelVentanas.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelVentanas);
            this.Controls.Add(this.panelMenu);
            this.Name = "Menu_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tester CESVI";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnBuscarTicket;
        private System.Windows.Forms.Button btnBuscarTest;
        private System.Windows.Forms.Button btnNuevoTest;
        private System.Windows.Forms.Panel panelVentanas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

