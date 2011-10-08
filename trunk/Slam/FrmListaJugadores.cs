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
    public partial class FrmListaJugadores : Form, IListadoClubes, IListadoJugadores
    {
    	string ImplementaClubes = "ClubServicio";
        string ImplementaJugadores = "JugadorServicio";
    	IListadoClubServicio servicioClubes;
        IListadoJugadoresServicio servicioJugadores;

        public FrmListaJugadores()
        {
            InitializeComponent();
        }

        private void FrmListaJugadores_Load(object sender, EventArgs e)
        {
            servicioJugadores = (IListadoJugadoresServicio)AppContext.Instance.GetObject(ImplementaJugadores);
        	servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioClubes.ListarActivos(this);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaAfiliacion nuevoJugador = new FrmNuevaAfiliacion();
            if(nuevoJugador.ShowDialog() == DialogResult.OK)
            {
                if(CboClubes.SelectedIndex > -1)
                    servicioJugadores.ListarJugadores(this);
            }
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
                servicioJugadores.ListarJugadores(this);
            }
        }

        #region Miembros de IListadoClubes

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

        #endregion

        #region Miembros de IListadoJugadores

        public List<object> Listar
        {
            set
            {
                if (DgvJugadoresClub.ColumnCount > 0)
                    DgvJugadoresClub.Columns.Clear();
                DgvJugadoresClub.Columns.Add("Dni", "Dni");
                DgvJugadoresClub.Columns.Add("NombreApellido", "Nombre y Apellido");
                DgvJugadoresClub.Columns.Add("FechaNac", "Fecha de Nac.");
                DgvJugadoresClub.Columns["FechaNac"].DefaultCellStyle.Format = "dd/MM/yyyy";
                DgvJugadoresClub.Columns.Add("Nacionalidad", "Nacionalidad");
                DgvJugadoresClub.Columns.Add("Sexo", "Sexo");
                if (DgvJugadoresClub.RowCount > 0)
                    DgvJugadoresClub.Rows.Clear();
                foreach (Object Jugador in value)
                {
                    object[] Datos = Jugador.ToString().Split(',');
                    DgvJugadoresClub.Rows.Add(Datos);
                }
            }
        }

        public int IdClub
        {
            get { return Convert.ToInt32(((DictionaryEntry)CboClubes.SelectedItem).Value); }
        }

        #endregion

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCambiaEstado_Click(object sender, EventArgs e)
        {
            if (DgvJugadoresClub.SelectedRows.Count == 1)
            {
                FrmNuevaAfiliacion ModificaAfiliacion = new FrmNuevaAfiliacion(Convert.ToInt32(((DictionaryEntry)CboClubes.SelectedItem).Value), Convert.ToInt32(this.DgvJugadoresClub.SelectedRows[0].Cells["Dni"].Value));
                if (ModificaAfiliacion.ShowDialog() == DialogResult.OK)
                    servicioJugadores.ListarJugadores(this);
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Un Club De La Lista Para Poder Modificar su estado");
            }
        }

        private void CboClubes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
