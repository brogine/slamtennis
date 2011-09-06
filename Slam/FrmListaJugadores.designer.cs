namespace Slam
{
    partial class FrmListaJugadores
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaJugadores));
        	this.DgvJugadoresClub = new System.Windows.Forms.DataGridView();
        	this.BtnNuevo = new System.Windows.Forms.Button();
        	this.BtnModificar = new System.Windows.Forms.Button();
        	this.CboClubes = new System.Windows.Forms.ComboBox();
        	this.LblClubes = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.DgvJugadoresClub)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// DgvJugadoresClub
        	// 
        	this.DgvJugadoresClub.AllowUserToAddRows = false;
        	this.DgvJugadoresClub.AllowUserToDeleteRows = false;
        	this.DgvJugadoresClub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.DgvJugadoresClub.Location = new System.Drawing.Point(12, 41);
        	this.DgvJugadoresClub.Name = "DgvJugadoresClub";
        	this.DgvJugadoresClub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.DgvJugadoresClub.Size = new System.Drawing.Size(582, 262);
        	this.DgvJugadoresClub.TabIndex = 0;
        	// 
        	// BtnNuevo
        	// 
        	this.BtnNuevo.Location = new System.Drawing.Point(197, 309);
        	this.BtnNuevo.Name = "BtnNuevo";
        	this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
        	this.BtnNuevo.TabIndex = 1;
        	this.BtnNuevo.Text = "Nuevo";
        	this.BtnNuevo.UseVisualStyleBackColor = true;
        	this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
        	// 
        	// BtnModificar
        	// 
        	this.BtnModificar.Location = new System.Drawing.Point(340, 309);
        	this.BtnModificar.Name = "BtnModificar";
        	this.BtnModificar.Size = new System.Drawing.Size(75, 23);
        	this.BtnModificar.TabIndex = 2;
        	this.BtnModificar.Text = "Modificar";
        	this.BtnModificar.UseVisualStyleBackColor = true;
        	this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
        	// 
        	// CboClubes
        	// 
        	this.CboClubes.FormattingEnabled = true;
        	this.CboClubes.Location = new System.Drawing.Point(215, 14);
        	this.CboClubes.Name = "CboClubes";
        	this.CboClubes.Size = new System.Drawing.Size(164, 21);
        	this.CboClubes.TabIndex = 3;
        	this.CboClubes.SelectionChangeCommitted += new System.EventHandler(this.CmbClubes_SelectionChangeCommitted);
        	// 
        	// LblClubes
        	// 
        	this.LblClubes.AutoSize = true;
        	this.LblClubes.Location = new System.Drawing.Point(12, 17);
        	this.LblClubes.Name = "LblClubes";
        	this.LblClubes.Size = new System.Drawing.Size(197, 13);
        	this.LblClubes.TabIndex = 4;
        	this.LblClubes.Text = "Seleccione un Club para filtrar jugadores";
        	// 
        	// FrmListaJugadores
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(610, 343);
        	this.Controls.Add(this.LblClubes);
        	this.Controls.Add(this.CboClubes);
        	this.Controls.Add(this.BtnModificar);
        	this.Controls.Add(this.BtnNuevo);
        	this.Controls.Add(this.DgvJugadoresClub);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "FrmListaJugadores";
        	this.Text = "Jugadores";
        	this.Load += new System.EventHandler(this.FrmListaJugadores_Load);
        	((System.ComponentModel.ISupportInitialize)(this.DgvJugadoresClub)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox CboClubes;

        #endregion

        private System.Windows.Forms.DataGridView DgvJugadoresClub;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Label LblClubes;
    }
}