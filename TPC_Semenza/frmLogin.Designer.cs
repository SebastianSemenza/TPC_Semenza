﻿namespace TPC_Semenza
{
    partial class frmLogin
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.txbContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsuario.Location = new System.Drawing.Point(25, 49);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txbUsuario
            // 
            this.txbUsuario.Location = new System.Drawing.Point(122, 48);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(192, 20);
            this.txbUsuario.TabIndex = 2;
            // 
            // txbContraseña
            // 
            this.txbContraseña.Location = new System.Drawing.Point(122, 86);
            this.txbContraseña.Name = "txbContraseña";
            this.txbContraseña.Size = new System.Drawing.Size(192, 20);
            this.txbContraseña.TabIndex = 4;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblContraseña.ForeColor = System.Drawing.SystemColors.Control;
            this.lblContraseña.Location = new System.Drawing.Point(25, 87);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(85, 17);
            this.lblContraseña.TabIndex = 3;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIngresar.Location = new System.Drawing.Point(132, 136);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(182, 23);
            this.btnIngresar.TabIndex = 41;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(338, 199);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txbContraseña);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.TextBox txbContraseña;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Button btnIngresar;
    }
}