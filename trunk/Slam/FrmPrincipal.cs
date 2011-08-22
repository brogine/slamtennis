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
        public FrmPrincipal(Form _Padre)
        {
            InitializeComponent();
            this.Padre = _Padre;
        }

        private void TlsmiCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Show();
        }

        private void TlsmiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Close();
        }

        private void TlsmiJugadores_Click(object sender, EventArgs e)
        {
            FrmListaJugadores Jugadores = new FrmListaJugadores();
            Jugadores.MdiParent = this;
            Jugadores.Show();
        }

        private void TlsmiArbitros_Click(object sender, EventArgs e)
        {
            FrmListaArbitros Arbitros = new FrmListaArbitros();
            Arbitros.MdiParent = this;
            Arbitros.Show();
        }

        private void TlsmiAdministrarClubes_Click(object sender, EventArgs e)
        {
            FrmListaClubes Clubes = new FrmListaClubes();
            Clubes.MdiParent = this;
            Clubes.Show();
        }
    }
}
