namespace Slam
{
    partial class FrmListaArbitros
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblClubes = new System.Windows.Forms.Label();
            this.CmbClubes = new System.Windows.Forms.ComboBox();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.DgvArbitrosClub = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArbitrosClub)).BeginInit();
            this.SuspendLayout();
            // 
            // LblClubes
            // 
            this.LblClubes.AutoSize = true;
            this.LblClubes.Location = new System.Drawing.Point(14, 15);
            this.LblClubes.Name = "LblClubes";
            this.LblClubes.Size = new System.Drawing.Size(186, 13);
            this.LblClubes.TabIndex = 9;
            this.LblClubes.Text = "Seleccione un Club para filtrar Arbitros";
            // 
            // CmbClubes
            // 
            this.CmbClubes.FormattingEnabled = true;
            this.CmbClubes.Location = new System.Drawing.Point(217, 12);
            this.CmbClubes.Name = "CmbClubes";
            this.CmbClubes.Size = new System.Drawing.Size(164, 21);
            this.CmbClubes.TabIndex = 8;
            this.CmbClubes.SelectionChangeCommitted += new System.EventHandler(this.CmbClubes_SelectionChangeCommitted);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(342, 307);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 7;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(199, 307);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 6;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // DgvArbitrosClub
            // 
            this.DgvArbitrosClub.AllowUserToAddRows = false;
            this.DgvArbitrosClub.AllowUserToDeleteRows = false;
            this.DgvArbitrosClub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArbitrosClub.Location = new System.Drawing.Point(14, 39);
            this.DgvArbitrosClub.Name = "DgvArbitrosClub";
            this.DgvArbitrosClub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvArbitrosClub.Size = new System.Drawing.Size(582, 262);
            this.DgvArbitrosClub.TabIndex = 5;
            // 
            // FrmListaArbitros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 343);
            this.Controls.Add(this.LblClubes);
            this.Controls.Add(this.CmbClubes);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.DgvArbitrosClub);
            this.Name = "FrmListaArbitros";
            this.Text = "Arbitros";
            this.Load += new System.EventHandler(this.FrmListaArbitros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvArbitrosClub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblClubes;
        private System.Windows.Forms.ComboBox CmbClubes;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.DataGridView DgvArbitrosClub;
    }
}