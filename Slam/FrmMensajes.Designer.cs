namespace Slam
{
    partial class FrmMensajes
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
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnCambiaEstado = new System.Windows.Forms.Button();
            this.LblClubes = new System.Windows.Forms.Label();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.DgvJugadoresClub = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvJugadoresClub)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(519, 306);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 11;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnCambiaEstado
            // 
            this.BtnCambiaEstado.Location = new System.Drawing.Point(138, 309);
            this.BtnCambiaEstado.Name = "BtnCambiaEstado";
            this.BtnCambiaEstado.Size = new System.Drawing.Size(75, 23);
            this.BtnCambiaEstado.TabIndex = 10;
            this.BtnCambiaEstado.Text = "Eliminar";
            this.BtnCambiaEstado.UseVisualStyleBackColor = true;
            // 
            // LblClubes
            // 
            this.LblClubes.AutoSize = true;
            this.LblClubes.Location = new System.Drawing.Point(12, 22);
            this.LblClubes.Name = "LblClubes";
            this.LblClubes.Size = new System.Drawing.Size(116, 13);
            this.LblClubes.TabIndex = 9;
            this.LblClubes.Text = "Listado de Mensajes....";
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(15, 309);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(117, 23);
            this.BtnModificar.TabIndex = 8;
            this.BtnModificar.Text = "Ver Detalle";
            this.BtnModificar.UseVisualStyleBackColor = true;
            // 
            // DgvJugadoresClub
            // 
            this.DgvJugadoresClub.AllowUserToAddRows = false;
            this.DgvJugadoresClub.AllowUserToDeleteRows = false;
            this.DgvJugadoresClub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvJugadoresClub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvJugadoresClub.Location = new System.Drawing.Point(12, 38);
            this.DgvJugadoresClub.Name = "DgvJugadoresClub";
            this.DgvJugadoresClub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvJugadoresClub.Size = new System.Drawing.Size(582, 262);
            this.DgvJugadoresClub.TabIndex = 7;
            // 
            // FrmMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 344);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnCambiaEstado);
            this.Controls.Add(this.LblClubes);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.DgvJugadoresClub);
            this.Name = "FrmMensajes";
            this.Text = "FrmMensajes";
            this.Load += new System.EventHandler(this.FrmMensajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvJugadoresClub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnCambiaEstado;
        private System.Windows.Forms.Label LblClubes;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.DataGridView DgvJugadoresClub;
    }
}