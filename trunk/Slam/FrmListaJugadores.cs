using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ApplicationContext;
using Servicio;
using Servicio.InterfacesUI;

namespace Slam
{
    public partial class FrmListaJugadores : Form, IListadoClubes
    {
    	string ImplementaClubes = "ClubServicio";
    	IListadoClubServicio servicioClubes;
        public FrmListaJugadores()
        {
            InitializeComponent();
        }

        private void FrmListaJugadores_Load(object sender, EventArgs e)
        {
        	servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
        	servicioClubes.Listar(this);
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
            if (CboClubes.SelectedIndex > -1)
            {
                //Cargar lista de jugadores por club
            }
        }
    	
    	
		public List<object> ListarClubes {
			set {
				foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    CboClubes.Items.Add(new DictionaryEntry(DatosClub[1], DatosClub[0]));
                }
                CboClubes.DisplayMember = "Key";
                CboClubes.ValueMember = "Value";
                CboClubes.SelectedIndex = -1;
			}
		}
    }
}
