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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.MsPrincipal = new System.Windows.Forms.MenuStrip();
            this.TsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiJugadores = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiAdministrarJugadores = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiEstadisticasJugador = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiArbitros = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiClubes = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiAdministrarClubes = new System.Windows.Forms.ToolStripMenuItem();
            this.TlsmiSedes = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiEventos = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMITorneos = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIInscripciones = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmiConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.TsmiReportes,
            this.tlsmiConfiguracion,
            this.ayudaToolStripMenuItem});
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
            this.TlsmiEmpleados,
            this.TlsmiCategorias});
            this.TsmiGestion.Name = "TsmiGestion";
            this.TsmiGestion.Size = new System.Drawing.Size(59, 20);
            this.TsmiGestion.Text = "Gestión";
            // 
            // TlsmiJugadores
            // 
            this.TlsmiJugadores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlsmiAdministrarJugadores,
            this.TlsmiEstadisticasJugador});
            this.TlsmiJugadores.Name = "TlsmiJugadores";
            this.TlsmiJugadores.Size = new System.Drawing.Size(132, 22);
            this.TlsmiJugadores.Text = "Jugadores";
            // 
            // TlsmiAdministrarJugadores
            // 
            this.TlsmiAdministrarJugadores.Name = "TlsmiAdministrarJugadores";
            this.TlsmiAdministrarJugadores.Size = new System.Drawing.Size(136, 22);
            this.TlsmiAdministrarJugadores.Text = "Administrar";
            this.TlsmiAdministrarJugadores.Click += new System.EventHandler(this.TlsmiAdministrarJugadores_Click);
            // 
            // TlsmiEstadisticasJugador
            // 
            this.TlsmiEstadisticasJugador.Name = "TlsmiEstadisticasJugador";
            this.TlsmiEstadisticasJugador.Size = new System.Drawing.Size(136, 22);
            this.TlsmiEstadisticasJugador.Text = "Estadisticas";
            this.TlsmiEstadisticasJugador.Click += new System.EventHandler(this.TlsmiEstadisticasJugador_Click);
            // 
            // TlsmiArbitros
            // 
            this.TlsmiArbitros.Name = "TlsmiArbitros";
            this.TlsmiArbitros.Size = new System.Drawing.Size(132, 22);
            this.TlsmiArbitros.Text = "Arbitros";
            this.TlsmiArbitros.Click += new System.EventHandler(this.TlsmiArbitros_Click);
            // 
            // TlsmiEmpleados
            // 
            this.TlsmiEmpleados.Name = "TlsmiEmpleados";
            this.TlsmiEmpleados.Size = new System.Drawing.Size(132, 22);
            this.TlsmiEmpleados.Text = "Empleados";
            this.TlsmiEmpleados.Click += new System.EventHandler(this.TlsmiEmpleadosClick);
            // 
            // TlsmiCategorias
            // 
            this.TlsmiCategorias.Name = "TlsmiCategorias";
            this.TlsmiCategorias.Size = new System.Drawing.Size(132, 22);
            this.TlsmiCategorias.Text = "Categorias";
            this.TlsmiCategorias.Click += new System.EventHandler(this.TlsmiCategorias_Click);
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
            this.TsmiEventos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMITorneos,
            this.TSMIInscripciones});
            this.TsmiEventos.Name = "TsmiEventos";
            this.TsmiEventos.Size = new System.Drawing.Size(60, 20);
            this.TsmiEventos.Text = "Eventos";
            // 
            // TSMITorneos
            // 
            this.TSMITorneos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem,
            this.partidosToolStripMenuItem});
            this.TSMITorneos.Name = "TSMITorneos";
            this.TSMITorneos.Size = new System.Drawing.Size(143, 22);
            this.TSMITorneos.Text = "Torneos";
            this.TSMITorneos.Click += new System.EventHandler(this.TSMITorneos_Click);
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.administrarToolStripMenuItem.Text = "Administrar";
            this.administrarToolStripMenuItem.Click += new System.EventHandler(this.administrarToolStripMenuItem_Click);
            // 
            // partidosToolStripMenuItem
            // 
            this.partidosToolStripMenuItem.Name = "partidosToolStripMenuItem";
            this.partidosToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.partidosToolStripMenuItem.Text = "Partidos";
            this.partidosToolStripMenuItem.Click += new System.EventHandler(this.partidosToolStripMenuItem_Click);
            // 
            // TSMIInscripciones
            // 
            this.TSMIInscripciones.Name = "TSMIInscripciones";
            this.TSMIInscripciones.Size = new System.Drawing.Size(143, 22);
            this.TSMIInscripciones.Text = "Inscripciones";
            this.TSMIInscripciones.Click += new System.EventHandler(this.TSMIInscripciones_Click);
            // 
            // TsmiReportes
            // 
            this.TsmiReportes.Name = "TsmiReportes";
            this.TsmiReportes.Size = new System.Drawing.Size(65, 20);
            this.TsmiReportes.Text = "Reportes";
            this.TsmiReportes.Click += new System.EventHandler(this.TsmiReportes_Click);
            // 
            // tlsmiConfiguracion
            // 
            this.tlsmiConfiguracion.Name = "tlsmiConfiguracion";
            this.tlsmiConfiguracion.Size = new System.Drawing.Size(95, 20);
            this.tlsmiConfiguracion.Text = "Configuración";
            this.tlsmiConfiguracion.Click += new System.EventHandler(this.tlsmiConfiguracion_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualHTMLToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualHTMLToolStripMenuItem
            // 
            this.manualHTMLToolStripMenuItem.Name = "manualHTMLToolStripMenuItem";
            this.manualHTMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.manualHTMLToolStripMenuItem.Text = "Manual HTML";
            this.manualHTMLToolStripMenuItem.Click += new System.EventHandler(this.manualHTMLToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
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
        private System.Windows.Forms.ToolStripMenuItem TlsmiCategorias;
        private System.Windows.Forms.ToolStripMenuItem TlsmiAdministrarJugadores;
        private System.Windows.Forms.ToolStripMenuItem TlsmiEstadisticasJugador;
        private System.Windows.Forms.ToolStripMenuItem TSMITorneos;
        private System.Windows.Forms.ToolStripMenuItem TSMIInscripciones;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partidosToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem tlsmiConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}