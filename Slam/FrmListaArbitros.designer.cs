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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaArbitros));
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.DgvArbitrosClub = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArbitrosClub)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(342, 307);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 2;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(199, 307);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 1;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // DgvArbitrosClub
            // 
            this.DgvArbitrosClub.AllowUserToAddRows = false;
            this.DgvArbitrosClub.AllowUserToDeleteRows = false;
            this.DgvArbitrosClub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvArbitrosClub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArbitrosClub.Location = new System.Drawing.Point(14, 12);
            this.DgvArbitrosClub.Name = "DgvArbitrosClub";
            this.DgvArbitrosClub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvArbitrosClub.Size = new System.Drawing.Size(582, 289);
            this.DgvArbitrosClub.TabIndex = 0;
            // 
            // FrmListaArbitros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 343);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.DgvArbitrosClub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListaArbitros";
            this.Text = "Arbitros";
            this.Load += new System.EventHandler(this.FrmListaArbitros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvArbitrosClub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.DataGridView DgvArbitrosClub;
    }
}