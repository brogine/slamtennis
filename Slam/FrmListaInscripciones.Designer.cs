namespace Slam
{
    partial class FrmListaInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaInscripciones));
            this.DgvListaInscripciones = new System.Windows.Forms.DataGridView();
            this.CboTorneos = new System.Windows.Forms.ComboBox();
            this.LblListaTorneos = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaInscripciones)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvListaInscripciones
            // 
            this.DgvListaInscripciones.AllowUserToAddRows = false;
            this.DgvListaInscripciones.AllowUserToDeleteRows = false;
            this.DgvListaInscripciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvListaInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaInscripciones.Location = new System.Drawing.Point(12, 45);
            this.DgvListaInscripciones.Name = "DgvListaInscripciones";
            this.DgvListaInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaInscripciones.Size = new System.Drawing.Size(525, 281);
            this.DgvListaInscripciones.TabIndex = 0;
            // 
            // CboTorneos
            // 
            this.CboTorneos.FormattingEnabled = true;
            this.CboTorneos.Location = new System.Drawing.Point(110, 12);
            this.CboTorneos.Name = "CboTorneos";
            this.CboTorneos.Size = new System.Drawing.Size(220, 21);
            this.CboTorneos.TabIndex = 1;
            this.CboTorneos.SelectionChangeCommitted += new System.EventHandler(this.CboTorneos_SelectionChangeCommitted);
            this.CboTorneos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboTorneos_KeyPress);
            // 
            // LblListaTorneos
            // 
            this.LblListaTorneos.AutoSize = true;
            this.LblListaTorneos.Location = new System.Drawing.Point(26, 15);
            this.LblListaTorneos.Name = "LblListaTorneos";
            this.LblListaTorneos.Size = new System.Drawing.Size(78, 13);
            this.LblListaTorneos.TabIndex = 3;
            this.LblListaTorneos.Text = "Elija un Torneo";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(12, 332);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(75, 23);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "Nueva";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(93, 332);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(75, 23);
            this.BtnModificar.TabIndex = 4;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Location = new System.Drawing.Point(462, 332);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmListaInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(549, 363);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.LblListaTorneos);
            this.Controls.Add(this.CboTorneos);
            this.Controls.Add(this.DgvListaInscripciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmListaInscripciones";
            this.Text = "Lista de Inscripciones";
            this.Load += new System.EventHandler(this.FrmListaInscripciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaInscripciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvListaInscripciones;
        private System.Windows.Forms.ComboBox CboTorneos;
        private System.Windows.Forms.Label LblListaTorneos;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnSalir;
    }
}