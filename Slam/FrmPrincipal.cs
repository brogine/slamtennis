using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio.InterfacesUI;
using Servicio;
using ApplicationContext;

namespace Slam
{
    public partial class FrmPrincipal : Form, IListadoTorneos
    {
        Form Padre;
        bool CerrarPadre = true;
        FrmListaJugadores Jugadores;
        FrmListaArbitros Arbitros;
        FrmListaClubes Clubes;
        FrmListaSedes Sedes;
        FrmListaEmpleados Empleados;
        FrmListaCategorias Categorias;
        FrmListaEstadisticas EstadisticasJugadores;
        FrmListaTorneos Torneos;
        FrmListaInscripciones Inscripciones;
        FrmListaPartidos Partidos;
        FrmReportes Reportes;
        FrmConfiguracion Configuracion;
        string ImplementaTorneos = "TorneoServicio";
        IListadoTorneoServicio servicioTorneos;
        public FrmPrincipal(Form _Padre)
        {
            InitializeComponent();
            this.Padre = _Padre;
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.Actualizar();
            servicioTorneos.ListarCerrados(this);
            timer1.Enabled = true;
        }

        private void TlsmiCerrarSesion_Click(object sender, EventArgs e)
        {
        	CerrarPadre = false;
            this.Close();
            Padre.Show();
        }

        private void TlsmiSalir_Click(object sender, EventArgs e)
        {
        	CerrarPadre = true;
            this.Close();
            Padre.Close();
        }

        private void TlsmiArbitros_Click(object sender, EventArgs e)
        {
        	if(Arbitros == null || Arbitros.IsDisposed)
        	{
	            Arbitros = new FrmListaArbitros();
	            Arbitros.MdiParent = this;
	            Arbitros.Show();
        	}
        	else
        		Arbitros.BringToFront();
        }

        private void TlsmiAdministrarClubes_Click(object sender, EventArgs e)
        {
        	if (Clubes == null || Clubes.IsDisposed) {
        		Clubes = new FrmListaClubes();
	            Clubes.MdiParent = this;
	            Clubes.Show();
        	}
        	else
        		Clubes.BringToFront();
        }

        private void TlsmiSedes_Click(object sender, EventArgs e)
        {
        	if (Sedes == null || Sedes.IsDisposed) {
        		Sedes = new FrmListaSedes();
	            Sedes.MdiParent = this;
	            Sedes.Show();
        	}
            else
            	Sedes.BringToFront();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CerrarPadre) {
        		Padre.Close();
        	}
        }
        
        void TlsmiEmpleadosClick(object sender, EventArgs e)
        {
        	if (Empleados == null || Empleados.IsDisposed) {
        		Empleados = new FrmListaEmpleados();
	            Empleados.MdiParent = this;
	            Empleados.Show();
        	}
            else
            	Empleados.BringToFront();
        }

        private void TlsmiCategorias_Click(object sender, EventArgs e)
        {
            if (Categorias == null || Categorias.IsDisposed)
            {
                Categorias = new FrmListaCategorias();
                Categorias.MdiParent = this;
                Categorias.Show();
            }
            else
                Categorias.BringToFront();
        }

        private void TlsmiAdministrarJugadores_Click(object sender, EventArgs e)
        {
            if (Jugadores == null || Jugadores.IsDisposed)
            {
                Jugadores = new FrmListaJugadores();
                Jugadores.MdiParent = this;
                Jugadores.Show();
            }
            else
                Jugadores.BringToFront();
        }

        private void TlsmiEstadisticasJugador_Click(object sender, EventArgs e)
        {
            if (EstadisticasJugadores == null || EstadisticasJugadores.IsDisposed)
            {
                EstadisticasJugadores = new FrmListaEstadisticas();
                EstadisticasJugadores.MdiParent = this;
                EstadisticasJugadores.Show();
            }
            else
                EstadisticasJugadores.BringToFront();
        }

        private void TSMITorneos_Click(object sender, EventArgs e)
        {
            

        }

        private void TSMIInscripciones_Click(object sender, EventArgs e)
        {
            if (Inscripciones == null || Inscripciones.IsDisposed)
            {
                Inscripciones = new FrmListaInscripciones();
                Inscripciones.MdiParent = this;
                Inscripciones.Show();
            }
            else
                Inscripciones.BringToFront();
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Torneos == null || Torneos.IsDisposed)
            {
                Torneos = new FrmListaTorneos();
                Torneos.MdiParent = this;
                Torneos.Show();
            }
            else
                Torneos.BringToFront();
        }

        private void partidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Partidos == null || Partidos.IsDisposed)
            {
                Partidos = new FrmListaPartidos();
                Partidos.MdiParent = this;
                Partidos.Show();
            }
            else
                Partidos.BringToFront();
        }

        private void TsmiReportes_Click(object sender, EventArgs e)
        {
            if (Reportes == null || Reportes.IsDisposed)
            {
                Reportes = new FrmReportes();
                Reportes.MdiParent = this;
                Reportes.Show();
            }
            else
                Reportes.BringToFront();
        }

        #region Miembros de IListadoTorneos

        public List<object> ListaUI
        {
            set 
            {
                if (value.Count > 0)
                {
                    foreach (object Torneo in value)
                    {
                        object[] DatosTorneo = Torneo.ToString().Split(',');
                        FrmPopUp popup = new FrmPopUp(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[1].ToString(), DatosTorneo[2].ToString());
                        popup.MdiParent = this;
                        
                        popup.Show();
                    }
                }
            }
        }

        #endregion


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            FrmMensajes frm = new FrmMensajes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //notifyIcon1.BalloonTipTitle = "Mensajes de la Web";
            //notifyIcon1.BalloonTipText = "Se encontraron mensajes recibidos de la web, Por favor haga clic aqui para ver los mensajes.";
            //notifyIcon1.ShowBalloonTip(3000);


        }

        private void tlsmiConfiguracion_Click(object sender, EventArgs e)
        {
            if (Configuracion == null || Configuracion.IsDisposed)
            {
                Configuracion = new FrmConfiguracion();
                Configuracion.MdiParent = this;
                Configuracion.Show();
            }
            else
                Configuracion.BringToFront();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcerca Acercade = new FrmAcerca();
            Acercade.MdiParent = this;
            Acercade.Show();
        }

        private void manualHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ubicacion = System.AppDomain.CurrentDomain.BaseDirectory;
            System.Diagnostics.Process.Start("IExplore.exe", ubicacion + "Manual del Usuario SLAM.htm"); 
        }

    }
}
