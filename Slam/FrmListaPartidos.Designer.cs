namespace Slam
{
    partial class FrmListaPartidos
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
            this.CboListaTorneos = new System.Windows.Forms.ComboBox();
            this.DgvListaPartidos = new System.Windows.Forms.DataGridView();
            this.BtnAgregarPartido = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaPartidos)).BeginInit();
            this.SuspendLayout();
            // 
            // CboListaTorneos
            // 
            this.CboListaTorneos.FormattingEnabled = true;
            this.CboListaTorneos.Location = new System.Drawing.Point(189, 12);
            this.CboListaTorneos.Name = "CboListaTorneos";
            this.CboListaTorneos.Size = new System.Drawing.Size(223, 21);
            this.CboListaTorneos.TabIndex = 0;
            this.CboListaTorneos.SelectionChangeCommitted += new System.EventHandler(this.CboListaTorneos_SelectionChangeCommitted);
            // 
            // DgvListaPartidos
            // 
            this.DgvListaPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaPartidos.Location = new System.Drawing.Point(12, 39);
            this.DgvListaPartidos.Name = "DgvListaPartidos";
            this.DgvListaPartidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaPartidos.Size = new System.Drawing.Size(551, 150);
            this.DgvListaPartidos.TabIndex = 1;
            // 
            // BtnAgregarPartido
            // 
            this.BtnAgregarPartido.Location = new System.Drawing.Point(12, 198);
            this.BtnAgregarPartido.Name = "BtnAgregarPartido";
            this.BtnAgregarPartido.Size = new System.Drawing.Size(75, 23);
            this.BtnAgregarPartido.TabIndex = 2;
            this.BtnAgregarPartido.Text = "Agregar";
            this.BtnAgregarPartido.UseVisualStyleBackColor = true;
            this.BtnAgregarPartido.Click += new System.EventHandler(this.BtnAgregarPartido_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(99, 198);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 3;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(488, 198);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione Un Torneo De La Lista";
            // 
            // FrmListaPartidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 233);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnAgregarPartido);
            this.Controls.Add(this.DgvListaPartidos);
            this.Controls.Add(this.CboListaTorneos);
            this.Name = "FrmListaPartidos";
            this.Text = "FrmListaPartidos";
            this.Load += new System.EventHandler(this.FrmListaPartidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaPartidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboListaTorneos;
        private System.Windows.Forms.DataGridView DgvListaPartidos;
        private System.Windows.Forms.Button BtnAgregarPartido;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label1;
    }
}