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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaSedes));
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnNueva = new System.Windows.Forms.Button();
            this.DgvSedes = new System.Windows.Forms.DataGridView();
            this.LblFiltrarClub = new System.Windows.Forms.Label();
            this.CboClubes = new System.Windows.Forms.ComboBox();
            this.DgvCanchas = new System.Windows.Forms.DataGridView();
            this.BtnNuevaCancha = new System.Windows.Forms.Button();
            this.BtnModificarCancha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSedes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCanchas)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(116, 267);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(94, 23);
            this.BtnModificar.TabIndex = 5;
            this.BtnModificar.Text = "Modificar Sede";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnNueva
            // 
            this.BtnNueva.Location = new System.Drawing.Point(16, 267);
            this.BtnNueva.Name = "BtnNueva";
            this.BtnNueva.Size = new System.Drawing.Size(94, 23);
            this.BtnNueva.TabIndex = 4;
            this.BtnNueva.Text = "Nueva Sede";
            this.BtnNueva.UseVisualStyleBackColor = true;
            this.BtnNueva.Click += new System.EventHandler(this.BtnNueva_Click);
            // 
            // DgvSedes
            // 
            this.DgvSedes.AllowUserToAddRows = false;
            this.DgvSedes.AllowUserToDeleteRows = false;
            this.DgvSedes.AllowUserToResizeColumns = false;
            this.DgvSedes.AllowUserToResizeRows = false;
            this.DgvSedes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvSedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSedes.Location = new System.Drawing.Point(16, 39);
            this.DgvSedes.MultiSelect = false;
            this.DgvSedes.Name = "DgvSedes";
            this.DgvSedes.ReadOnly = true;
            this.DgvSedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSedes.Size = new System.Drawing.Size(418, 213);
            this.DgvSedes.TabIndex = 3;
            this.DgvSedes.SelectionChanged += new System.EventHandler(this.DgvSedes_SelectionChanged);
            // 
            // LblFiltrarClub
            // 
            this.LblFiltrarClub.AutoSize = true;
            this.LblFiltrarClub.Location = new System.Drawing.Point(119, 15);
            this.LblFiltrarClub.Name = "LblFiltrarClub";
            this.LblFiltrarClub.Size = new System.Drawing.Size(74, 13);
            this.LblFiltrarClub.TabIndex = 6;
            this.LblFiltrarClub.Text = "Filtrar por Club";
            // 
            // CboClubes
            // 
            this.CboClubes.FormattingEnabled = true;
            this.CboClubes.Location = new System.Drawing.Point(199, 12);
            this.CboClubes.Name = "CboClubes";
            this.CboClubes.Size = new System.Drawing.Size(121, 21);
            this.CboClubes.TabIndex = 7;
            this.CboClubes.SelectionChangeCommitted += new System.EventHandler(this.CboClubes_SelectionChangeCommitted);
            this.CboClubes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboClubes_KeyPress);
            // 
            // DgvCanchas
            // 
            this.DgvCanchas.AllowUserToAddRows = false;
            this.DgvCanchas.AllowUserToDeleteRows = false;
            this.DgvCanchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCanchas.Location = new System.Drawing.Point(16, 296);
            this.DgvCanchas.MultiSelect = false;
            this.DgvCanchas.Name = "DgvCanchas";
            this.DgvCanchas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCanchas.Size = new System.Drawing.Size(418, 207);
            this.DgvCanchas.TabIndex = 8;
            // 
            // BtnNuevaCancha
            // 
            this.BtnNuevaCancha.Location = new System.Drawing.Point(230, 267);
            this.BtnNuevaCancha.Name = "BtnNuevaCancha";
            this.BtnNuevaCancha.Size = new System.Drawing.Size(94, 23);
            this.BtnNuevaCancha.TabIndex = 4;
            this.BtnNuevaCancha.Text = "Nueva Cancha";
            this.BtnNuevaCancha.UseVisualStyleBackColor = true;
            this.BtnNuevaCancha.Click += new System.EventHandler(this.BtnNuevaCancha_Click);
            // 
            // BtnModificarCancha
            // 
            this.BtnModificarCancha.Location = new System.Drawing.Point(330, 267);
            this.BtnModificarCancha.Name = "BtnModificarCancha";
            this.BtnModificarCancha.Size = new System.Drawing.Size(102, 23);
            this.BtnModificarCancha.TabIndex = 5;
            this.BtnModificarCancha.Text = "Modificar Cancha";
            this.BtnModificarCancha.UseVisualStyleBackColor = true;
            this.BtnModificarCancha.Click += new System.EventHandler(this.BtnModificarCancha_Click);
            // 
            // FrmListaSedes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 514);
            this.Controls.Add(this.DgvCanchas);
            this.Controls.Add(this.CboClubes);
            this.Controls.Add(this.LblFiltrarClub);
            this.Controls.Add(this.BtnModificarCancha);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnNuevaCancha);
            this.Controls.Add(this.BtnNueva);
            this.Controls.Add(this.DgvSedes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListaSedes";
            this.Text = "Sedes";
            this.Load += new System.EventHandler(this.FrmListaSedes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSedes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCanchas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnNueva;
        private System.Windows.Forms.DataGridView DgvSedes;
        private System.Windows.Forms.Label LblFiltrarClub;
        private System.Windows.Forms.ComboBox CboClubes;
        private System.Windows.Forms.DataGridView DgvCanchas;
        private System.Windows.Forms.Button BtnNuevaCancha;
        private System.Windows.Forms.Button BtnModificarCancha;
    }
}