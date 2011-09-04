namespace Slam
{
    partial class FrmListaSedes
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
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnNueva = new System.Windows.Forms.Button();
            this.DgvSedes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSedes)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(243, 231);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 5;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            // 
            // BtnNueva
            // 
            this.BtnNueva.Location = new System.Drawing.Point(143, 231);
            this.BtnNueva.Name = "BtnNueva";
            this.BtnNueva.Size = new System.Drawing.Size(75, 23);
            this.BtnNueva.TabIndex = 4;
            this.BtnNueva.Text = "Nueva";
            this.BtnNueva.UseVisualStyleBackColor = true;
            // 
            // DgvSedes
            // 
            this.DgvSedes.AllowUserToAddRows = false;
            this.DgvSedes.AllowUserToDeleteRows = false;
            this.DgvSedes.AllowUserToResizeColumns = false;
            this.DgvSedes.AllowUserToResizeRows = false;
            this.DgvSedes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvSedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSedes.Location = new System.Drawing.Point(12, 12);
            this.DgvSedes.Name = "DgvSedes";
            this.DgvSedes.ReadOnly = true;
            this.DgvSedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSedes.Size = new System.Drawing.Size(418, 213);
            this.DgvSedes.TabIndex = 3;
            // 
            // FrmListaSedes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 267);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnNueva);
            this.Controls.Add(this.DgvSedes);
            this.Name = "FrmListaSedes";
            this.Text = "FrmListaSedes";
            ((System.ComponentModel.ISupportInitialize)(this.DgvSedes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnNueva;
        private System.Windows.Forms.DataGridView DgvSedes;
    }
}