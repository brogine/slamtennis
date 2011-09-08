namespace Slam
{
    partial class FrmPrincipal
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
        	this.MsPrincipal = new System.Windows.Forms.MenuStrip();
        	this.TsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
        	this.TlsmiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
        	this.TlsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
        	this.TsmiGestion = new System.Windows.Forms.ToolStripMenuItem();
        	this.TlsmiJugadores = new System.Windows.Forms.ToolStripMenuItem();
        	this.TlsmiArbitros = new System.Windows.Forms.ToolStripMenuItem();
        	this.TlsmiEmpleados = new System.Windows.Forms.ToolStripMenuItem();
        	this.TsmiClubes = new System.Windows.Forms.ToolStripMenuItem();
        	this.TlsmiAdministrarClubes = new System.Windows.Forms.ToolStripMenuItem();
        	this.TlsmiSedes = new System.Windows.Forms.ToolStripMenuItem();
        	this.TsmiEventos = new System.Windows.Forms.ToolStripMenuItem();
        	this.TsmiReportes = new System.Windows.Forms.ToolStripMenuItem();
        	this.MsPrincipal.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// MsPrincipal
        	// 
        	this.MsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.TsmiArchivo,
        	        	        	this.TsmiGestion,
        	        	        	this.TsmiClubes,
        	        	        	this.TsmiEventos,
        	        	        	this.TsmiReportes});
        	this.MsPrincipal.Location = new System.Drawing.Point(0, 0);
        	this.MsPrincipal.MdiWindowListItem = this.TsmiArchivo;
        	this.MsPrincipal.Name = "MsPrincipal";
        	this.MsPrincipal.Size = new System.Drawing.Size(793, 24);
        	this.MsPrincipal.TabIndex = 0;
        	this.MsPrincipal.Text = "menuStrip1";
        	// 
        	// TsmiArchivo
        	// 
        	this.TsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.TlsmiCerrarSesion,
        	        	        	this.TlsmiSalir});
        	this.TsmiArchivo.Name = "TsmiArchivo";
        	this.TsmiArchivo.Size = new System.Drawing.Size(60, 20);
        	this.TsmiArchivo.Text = "Archivo";
        	// 
        	// TlsmiCerrarSesion
        	// 
        	this.TlsmiCerrarSesion.Name = "TlsmiCerrarSesion";
        	this.TlsmiCerrarSesion.Size = new System.Drawing.Size(143, 22);
        	this.TlsmiCerrarSesion.Text = "Cerrar Sesión";
        	this.TlsmiCerrarSesion.Click += new System.EventHandler(this.TlsmiCerrarSesion_Click);
        	// 
        	// TlsmiSalir
        	// 
        	this.TlsmiSalir.Name = "TlsmiSalir";
        	this.TlsmiSalir.Size = new System.Drawing.Size(143, 22);
        	this.TlsmiSalir.Text = "Salir";
        	this.TlsmiSalir.Click += new System.EventHandler(this.TlsmiSalir_Click);
        	// 
        	// TsmiGestion
        	// 
        	this.TsmiGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.TlsmiJugadores,
        	        	        	this.TlsmiArbitros,
        	        	        	this.TlsmiEmpleados});
        	this.TsmiGestion.Name = "TsmiGestion";
        	this.TsmiGestion.Size = new System.Drawing.Size(59, 20);
        	this.TsmiGestion.Text = "Gestión";
        	// 
        	// TlsmiJugadores
        	// 
        	this.TlsmiJugadores.Name = "TlsmiJugadores";
        	this.TlsmiJugadores.Size = new System.Drawing.Size(152, 22);
        	this.TlsmiJugadores.Text = "Jugadores";
        	this.TlsmiJugadores.Click += new System.EventHandler(this.TlsmiJugadores_Click);
        	// 
        	// TlsmiArbitros
        	// 
        	this.TlsmiArbitros.Name = "TlsmiArbitros";
        	this.TlsmiArbitros.Size = new System.Drawing.Size(152, 22);
        	this.TlsmiArbitros.Text = "Arbitros";
        	this.TlsmiArbitros.Click += new System.EventHandler(this.TlsmiArbitros_Click);
        	// 
        	// TlsmiEmpleados
        	// 
        	this.TlsmiEmpleados.Name = "TlsmiEmpleados";
        	this.TlsmiEmpleados.Size = new System.Drawing.Size(152, 22);
        	this.TlsmiEmpleados.Text = "Empleados";
        	this.TlsmiEmpleados.Click += new System.EventHandler(this.TlsmiEmpleadosClick);
        	// 
        	// TsmiClubes
        	// 
        	this.TsmiClubes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.TlsmiAdministrarClubes,
        	        	        	this.TlsmiSedes});
        	this.TsmiClubes.Name = "TsmiClubes";
        	this.TsmiClubes.Size = new System.Drawing.Size(55, 20);
        	this.TsmiClubes.Text = "Clubes";
        	// 
        	// TlsmiAdministrarClubes
        	// 
        	this.TlsmiAdministrarClubes.Name = "TlsmiAdministrarClubes";
        	this.TlsmiAdministrarClubes.Size = new System.Drawing.Size(136, 22);
        	this.TlsmiAdministrarClubes.Text = "Administrar";
        	this.TlsmiAdministrarClubes.Click += new System.EventHandler(this.TlsmiAdministrarClubes_Click);
        	// 
        	// TlsmiSedes
        	// 
        	this.TlsmiSedes.Name = "TlsmiSedes";
        	this.TlsmiSedes.Size = new System.Drawing.Size(136, 22);
        	this.TlsmiSedes.Text = "Sedes";
        	this.TlsmiSedes.Click += new System.EventHandler(this.TlsmiSedes_Click);
        	// 
        	// TsmiEventos
        	// 
        	this.TsmiEventos.Name = "TsmiEventos";
        	this.TsmiEventos.Size = new System.Drawing.Size(60, 20);
        	this.TsmiEventos.Text = "Eventos";
        	// 
        	// TsmiReportes
        	// 
        	this.TsmiReportes.Name = "TsmiReportes";
        	this.TsmiReportes.Size = new System.Drawing.Size(65, 20);
        	this.TsmiReportes.Text = "Reportes";
        	// 
        	// FrmPrincipal
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(793, 499);
        	this.Controls.Add(this.MsPrincipal);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.IsMdiContainer = true;
        	this.MainMenuStrip = this.MsPrincipal;
        	this.Name = "FrmPrincipal";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Slam Sistema de Gestión";
        	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
        	this.MsPrincipal.ResumeLayout(false);
        	this.MsPrincipal.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip MsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem TsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem TlsmiCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem TlsmiSalir;
        private System.Windows.Forms.ToolStripMenuItem TsmiGestion;
        private System.Windows.Forms.ToolStripMenuItem TlsmiJugadores;
        private System.Windows.Forms.ToolStripMenuItem TlsmiArbitros;
        private System.Windows.Forms.ToolStripMenuItem TlsmiEmpleados;
        private System.Windows.Forms.ToolStripMenuItem TsmiClubes;
        private System.Windows.Forms.ToolStripMenuItem TsmiEventos;
        private System.Windows.Forms.ToolStripMenuItem TlsmiAdministrarClubes;
        private System.Windows.Forms.ToolStripMenuItem TlsmiSedes;
        private System.Windows.Forms.ToolStripMenuItem TsmiReportes;
    }
}