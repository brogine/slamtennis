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
            this.label1 = new System.Windows.Forms.Label();
            this.RBSingle = new System.Windows.Forms.RadioButton();
            this.RBDoble = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // CboCategorias
            // 
            this.CboCategorias.FormattingEnabled = true;
            this.CboCategorias.Location = new System.Drawing.Point(147, 73);
            this.CboCategorias.Name = "CboCategorias";
            this.CboCategorias.Size = new System.Drawing.Size(163, 21);
            this.CboCategorias.TabIndex = 0;
            this.CboCategorias.SelectionChangeCommitted += new System.EventHandler(this.CboCategorias_SelectionChangeCommitted);
            this.CboCategorias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboCategorias_KeyPress);
            // 
            // LblPorCategoria
            // 
            this.LblPorCategoria.AutoSize = true;
            this.LblPorCategoria.Location = new System.Drawing.Point(12, 76);
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
            this.DgvEstadisticas.Location = new System.Drawing.Point(15, 100);
            this.DgvEstadisticas.Name = "DgvEstadisticas";
            this.DgvEstadisticas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEstadisticas.Size = new System.Drawing.Size(474, 231);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccione El Tipo";
            // 
            // RBSingle
            // 
            this.RBSingle.AutoSize = true;
            this.RBSingle.Location = new System.Drawing.Point(147, 47);
            this.RBSingle.Name = "RBSingle";
            this.RBSingle.Size = new System.Drawing.Size(54, 17);
            this.RBSingle.TabIndex = 9;
            this.RBSingle.TabStop = true;
            this.RBSingle.Text = "Single";
            this.RBSingle.UseVisualStyleBackColor = true;
            this.RBSingle.CheckedChanged += new System.EventHandler(this.RBSingle_CheckedChanged);
            // 
            // RBDoble
            // 
            this.RBDoble.AutoSize = true;
            this.RBDoble.Location = new System.Drawing.Point(238, 47);
            this.RBDoble.Name = "RBDoble";
            this.RBDoble.Size = new System.Drawing.Size(53, 17);
            this.RBDoble.TabIndex = 10;
            this.RBDoble.TabStop = true;
            this.RBDoble.Text = "Doble";
            this.RBDoble.UseVisualStyleBackColor = true;
            this.RBDoble.CheckedChanged += new System.EventHandler(this.RBDoble_CheckedChanged);
            // 
            // FrmListaEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(498, 390);
            this.Controls.Add(this.RBDoble);
            this.Controls.Add(this.RBSingle);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBSingle;
        private System.Windows.Forms.RadioButton RBDoble;
    }
}