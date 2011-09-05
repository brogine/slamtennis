using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Slam
{
    public partial class FrmPrincipal : Form
    {
        Form Padre;
        bool Closing = true;
        FrmListaJugadores Jugadores;
        FrmListaArbitros Arbitros;
        FrmListaClubes Clubes;
        FrmListaSedes Sedes;
        public FrmPrincipal(Form _Padre)
        {
            InitializeComponent();
            this.Padre = _Padre;
        }

        private void TlsmiCerrarSesion_Click(object sender, EventArgs e)
        {
        	Closing = false;
            this.Close();
            Padre.Show();
        }

        private void TlsmiSalir_Click(object sender, EventArgs e)
        {
        	Closing = true;
            this.Close();
            Padre.Close();
        }

        private void TlsmiJugadores_Click(object sender, EventArgs e)
        {
        	if(Jugadores == null || Jugadores.IsDisposed)
        	{
            	Jugadores = new FrmListaJugadores();
            	Jugadores.MdiParent = this;
            	Jugadores.Show();
        	}
        	else
        		Jugadores.BringToFront();
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
        	if (!Closing) {
        		Padre.Close();
        	}
        }
    }
}
