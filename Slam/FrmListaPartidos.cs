using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio;
using Servicio.InterfacesUI;
using ApplicationContext;
using System.Collections;


namespace Slam
{
    public partial class FrmListaPartidos : Form,IListadoTorneos,IListadoPartidos
    {
        public FrmListaPartidos()
        {
            InitializeComponent();
        }

        string ImplementaTorneos = "TorneoServicio";
        IListadoTorneoServicio servicioTorneos;
        string ImplementaPartidos = "PartidoServicio";
        IListadoPartidoServicio servicioPartidos;
        #region Miembros de IListadoTorneos

        public List<object> ListaUI
        {
            set 
            {
                Dictionary<int, string> ListaTorneos = new Dictionary<int, string>();
                foreach (Object Torneo in value)
                {
                    Object[] DatosTorneo = Torneo.ToString().Split(',');
                    ListaTorneos.Add(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[2].ToString());
                }
                CboListaTorneos.DataSource = new BindingSource(ListaTorneos, null);
                CboListaTorneos.DisplayMember = "Value";
                CboListaTorneos.ValueMember = "Key";
                CboListaTorneos.SelectedIndex = -1;
            }
        }

        #endregion

        #region Miembros de IListadoPartidos

        public List<object> ListarPartidos
        {
            set 
            {
                if (DgvListaPartidos.ColumnCount > 0)
                    DgvListaPartidos.Columns.Clear();
                DgvListaPartidos.Columns.Add("Equipo1", "Equipo 1");
                DgvListaPartidos.Columns.Add("Equipo2", "Equipo 2");
                DgvListaPartidos.Columns.Add("Fecha", "Fecha");
                DgvListaPartidos.Columns.Add("Ronda", "Ronda");
                DgvListaPartidos.Columns.Add("Resultado", "Resultado");
                if (DgvListaPartidos.RowCount > 0)
                    DgvListaPartidos.Rows.Clear();
                foreach (Object Jugador in value)
                {
                    object[] Datos = Jugador.ToString().Split(',');
                    DgvListaPartidos.Rows.Add(Datos);
                }
            }
        }

        public int IdTorneo
        {
            get { return Convert.ToInt32(((KeyValuePair<int,string>)CboListaTorneos.SelectedItem).Key); }
        }

        #endregion

        private void FrmListaPartidos_Load(object sender, EventArgs e)
        {
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarTorneos(this);
        }

        private void CboListaTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servicioPartidos = (IListadoPartidoServicio)AppContext.Instance.GetObject(ImplementaPartidos);
            servicioPartidos.ListarPartidos(this);
        }
    }
}
