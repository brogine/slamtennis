namespace Slam
{
    partial class FrmListaEstadisticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaEstadisticas));
            this.CboCategorias = new System.Windows.Forms.ComboBox();
            this.LblPorCategoria = new System.Windows.Forms.Label();
            this.LblPorClub = new System.Windows.Forms.Label();
            this.DgvEstadisticas = new System.Windows.Forms.DataGridView();
            this.BtnReporte = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CboClubes = new System.Windows.Forms.ComboBox();
            this.BtnNuevaEstadistica = new System.Windows.Forms.Button();
            this.BtnVerEstadisticas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // CboCategorias
            // 
            this.CboCategorias.FormattingEnabled = true;
            this.CboCategorias.Location = new System.Drawing.Point(144, 48);
            this.CboCategorias.Name = "CboCategorias";
            this.CboCategorias.Size = new System.Drawing.Size(163, 21);
            this.CboCategorias.TabIndex = 0;
            this.CboCategorias.SelectionChangeCommitted += new System.EventHandler(this.CboCategorias_SelectionChangeCommitted);
            this.CboCategorias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboCategorias_KeyPress);
            // 
            // LblPorCategoria
            // 
            this.LblPorCategoria.AutoSize = true;
            this.LblPorCategoria.Location = new System.Drawing.Point(12, 51);
            this.LblPorCategoria.Name = "LblPorCategoria";
            this.LblPorCategoria.Size = new System.Drawing.Size(131, 13);
            this.LblPorCategoria.TabIndex = 1;
            this.LblPorCategoria.Text = "Seleccione una Categoría";
            // 
            // LblPorClub
            // 
            this.LblPorClub.AutoSize = true;
            this.LblPorClub.Location = new System.Drawing.Point(12, 20);
            this.LblPorClub.Name = "LblPorClub";
            this.LblPorClub.Size = new System.Drawing.Size(99, 13);
            this.LblPorClub.TabIndex = 3;
            this.LblPorClub.Text = "Seleccione un Club";
            // 
            // DgvEstadisticas
            // 
            this.DgvEstadisticas.AllowUserToAddRows = false;
            this.DgvEstadisticas.AllowUserToDeleteRows = false;
            this.DgvEstadisticas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvEstadisticas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEstadisticas.Location = new System.Drawing.Point(12, 86);
            this.DgvEstadisticas.Name = "DgvEstadisticas";
            this.DgvEstadisticas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEstadisticas.Size = new System.Drawing.Size(474, 263);
            this.DgvEstadisticas.TabIndex = 4;
            // 
            // BtnReporte
            // 
            this.BtnReporte.Location = new System.Drawing.Point(367, 15);
            this.BtnReporte.Name = "BtnReporte";
            this.BtnReporte.Size = new System.Drawing.Size(107, 23);
            this.BtnReporte.TabIndex = 5;
            this.BtnReporte.Text = "Generar Reporte";
            this.BtnReporte.UseVisualStyleBackColor = true;
            this.BtnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Location = new System.Drawing.Point(367, 46);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(107, 23);
            this.BtnSalir.TabIndex = 6;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // CboClubes
            // 
            this.CboClubes.FormattingEnabled = true;
            this.CboClubes.Location = new System.Drawing.Point(144, 17);
            this.CboClubes.Name = "CboClubes";
            this.CboClubes.Size = new System.Drawing.Size(163, 21);
            this.CboClubes.TabIndex = 0;
            this.CboClubes.SelectionChangeCommitted += new System.EventHandler(this.CboClubes_SelectionChangeCommitted);
            this.CboClubes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboClubes_KeyPress);
            // 
            // BtnNuevaEstadistica
            // 
            this.BtnNuevaEstadistica.Location = new System.Drawing.Point(86, 355);
            this.BtnNuevaEstadistica.Name = "BtnNuevaEstadistica";
            this.BtnNuevaEstadistica.Size = new System.Drawing.Size(160, 23);
            this.BtnNuevaEstadistica.TabIndex = 7;
            this.BtnNuevaEstadistica.Text = "Nueva Estadística";
            this.BtnNuevaEstadistica.UseVisualStyleBackColor = true;
            this.BtnNuevaEstadistica.Click += new System.EventHandler(this.BtnNuevaEstadistica_Click);
            // 
            // BtnVerEstadisticas
            // 
            this.BtnVerEstadisticas.Location = new System.Drawing.Point(252, 355);
            this.BtnVerEstadisticas.Name = "BtnVerEstadisticas";
            this.BtnVerEstadisticas.Size = new System.Drawing.Size(160, 23);
            this.BtnVerEstadisticas.TabIndex = 7;
            this.BtnVerEstadisticas.Text = "Ver Estadísticas Personales";
            this.BtnVerEstadisticas.UseVisualStyleBackColor = true;
            this.BtnVerEstadisticas.Click += new System.EventHandler(this.BtnVerEstadisticas_Click);
            // 
            // FrmListaEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(498, 390);
            this.Controls.Add(this.BtnVerEstadisticas);
            this.Controls.Add(this.BtnNuevaEstadistica);
            this.Controls.Add(this.DgvEstadisticas);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnReporte);
            this.Controls.Add(this.CboClubes);
            this.Controls.Add(this.LblPorClub);
            this.Controls.Add(this.CboCategorias);
            this.Controls.Add(this.LblPorCategoria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListaEstadisticas";
            this.Text = "Estadísticas de Jugadores";
            this.Load += new System.EventHandler(this.FrmListaEstadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEstadisticas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboCategorias;
        private System.Windows.Forms.Label LblPorCategoria;
        private System.Windows.Forms.Label LblPorClub;
        private System.Windows.Forms.DataGridView DgvEstadisticas;
        private System.Windows.Forms.Button BtnReporte;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ComboBox CboClubes;
        private System.Windows.Forms.Button BtnNuevaEstadistica;
        private System.Windows.Forms.Button BtnVerEstadisticas;
    }
}