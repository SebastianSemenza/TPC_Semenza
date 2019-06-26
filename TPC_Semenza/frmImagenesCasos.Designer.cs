namespace TPC_Semenza
{
    partial class frmImagenesCasos
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pcbImagenes = new System.Windows.Forms.PictureBox();
            this.cmbImagenes = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscarImg = new System.Windows.Forms.Button();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSeleccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenes)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pcbImagenes
            // 
            this.pcbImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbImagenes.Location = new System.Drawing.Point(12, 47);
            this.pcbImagenes.Name = "pcbImagenes";
            this.pcbImagenes.Size = new System.Drawing.Size(756, 377);
            this.pcbImagenes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbImagenes.TabIndex = 0;
            this.pcbImagenes.TabStop = false;
            // 
            // cmbImagenes
            // 
            this.cmbImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImagenes.FormattingEnabled = true;
            this.cmbImagenes.Location = new System.Drawing.Point(541, 430);
            this.cmbImagenes.Name = "cmbImagenes";
            this.cmbImagenes.Size = new System.Drawing.Size(227, 21);
            this.cmbImagenes.TabIndex = 1;
            this.cmbImagenes.SelectedIndexChanged += new System.EventHandler(this.cmbImagenes_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(661, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 28);
            this.btnAgregar.TabIndex = 51;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscarImg
            // 
            this.btnBuscarImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnBuscarImg.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarImg.Location = new System.Drawing.Point(470, 14);
            this.btnBuscarImg.Name = "btnBuscarImg";
            this.btnBuscarImg.Size = new System.Drawing.Size(35, 24);
            this.btnBuscarImg.TabIndex = 52;
            this.btnBuscarImg.Text = "...";
            this.btnBuscarImg.UseVisualStyleBackColor = false;
            this.btnBuscarImg.Click += new System.EventHandler(this.btnBuscarImg_Click);
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(151, 16);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(313, 20);
            this.txbDescripcion.TabIndex = 53;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 21);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(132, 13);
            this.lblDescripcion.TabIndex = 54;
            this.lblDescripcion.Text = "Descripcion de la imagen: ";
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeleccion.AutoSize = true;
            this.lblSeleccion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSeleccion.Location = new System.Drawing.Point(423, 433);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(112, 13);
            this.lblSeleccion.TabIndex = 55;
            this.lblSeleccion.Text = "Seleccion de imagen: ";
            // 
            // frmImagenesCasos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(784, 469);
            this.Controls.Add(this.lblSeleccion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.btnBuscarImg);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbImagenes);
            this.Controls.Add(this.pcbImagenes);
            this.Name = "frmImagenesCasos";
            this.Text = "frmImagenesCasos";
            this.Load += new System.EventHandler(this.frmImagenesCasos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pcbImagenes;
        private System.Windows.Forms.ComboBox cmbImagenes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscarImg;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblSeleccion;
    }
}