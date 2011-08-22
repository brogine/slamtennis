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
    public partial class FrmListaJugadores : Form
    {
        public FrmListaJugadores()
        {
            InitializeComponent();
        }

        private void FrmListaJugadores_Load(object sender, EventArgs e)
        {
            //Cargo lista de Clubes
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaPersona nuevoJugador = new FrmNuevaPersona(TipoPersona.Jugador);
            nuevoJugador.Show();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvJugadoresClub.SelectedRows.Count == 1)
            {
                FrmNuevaPersona modificarJugador = new FrmNuevaPersona(TipoPersona.Jugador, 
                    Convert.ToInt32(DgvJugadoresClub.SelectedRows[0].Cells["Dni"].Value));
                modificarJugador.Show();
            }
            else
                MessageBox.Show("Elija un Jugador de la grilla para Modificar", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbClubes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbClubes.SelectedIndex > -1)
            {
                //Cargar lista de jugadores por club
            }
        }
    }
}
