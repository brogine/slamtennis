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
    public partial class FrmListaArbitros : Form
    {
        public FrmListaArbitros()
        {
            InitializeComponent();
        }

        private void FrmListaArbitros_Load(object sender, EventArgs e)
        {
            //Cargar Clubes
        }

        private void CmbClubes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbClubes.SelectedIndex > -1)
            {
                //Cargar lista de jugadores por club
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaPersona nuevoJugador = new FrmNuevaPersona(TipoPersona.Arbitro);
            nuevoJugador.Show();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvArbitrosClub.SelectedRows.Count == 1)
            {
                FrmNuevaPersona modificarJugador = new FrmNuevaPersona(TipoPersona.Arbitro,
                    Convert.ToInt32(DgvArbitrosClub.SelectedRows[0].Cells["Dni"].Value));
                modificarJugador.Show();
            }
            else
                MessageBox.Show("Elija un Arbitro de la grilla para Modificar", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
