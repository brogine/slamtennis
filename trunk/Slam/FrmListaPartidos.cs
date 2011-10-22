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
using Reportes;


namespace Slam
{
    public partial class FrmListaPartidos : Form,IListadoTorneos,IListadoPartidos, IListadoInscripciones
    {
        string ImplementaReportes = "ReportesServicio";
        string ImplementaTorneos = "TorneoServicio";
        string ImplementaInscripciones = "InscripcionServicio";
        string ImplementaPartidos = "PartidoServicio";
        IListadoTorneoServicio servicioTorneos;
        IListadoPartidoServicio servicioPartidos;
        IListadoInscripcionServicio servicioInscripciones;
        int IdTorneoActual = 0;

        public FrmListaPartidos()
        {
            InitializeComponent();
        }

        public FrmListaPartidos(int IdTorneo)
        {
            InitializeComponent();
            this.IdTorneoActual = IdTorneo;
        }

        #region Miembros de IListadoTorneos

        public List<object> ListaUI
        {
            set 
            {
                if (value.Count > 0)
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
        }

        #endregion

        #region Miembros de IListadoPartidos

        public List<object> ListarPartidos
        {
            set 
            {
                if (DgvListaPartidos.ColumnCount > 0)
                    DgvListaPartidos.Columns.Clear();
                DgvListaPartidos.Columns.Add("IdPartido", "IdPartido");
                DgvListaPartidos.Columns["IdPartido"].Visible = false;
                DgvListaPartidos.Columns.Add("Equipo1", "Equipo 1");
                DgvListaPartidos.Columns.Add("Equipo2", "Equipo 2");
                DgvListaPartidos.Columns.Add("Fecha", "Fecha");
                DgvListaPartidos.Columns.Add("Ronda", "Ronda");
                DgvListaPartidos.Columns.Add("Resultado", "Resultado");
                DgvListaPartidos.Columns.Add("Estado", "Estado");
                DgvListaPartidos.Columns["Estado"].Visible = false;
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
            servicioTorneos.ListarTorneosCerrados(this);
            if (IdTorneoActual > 0)
            {
                CboListaTorneos.SelectedValue = IdTorneoActual;
                servicioPartidos = (IListadoPartidoServicio)AppContext.Instance.GetObject(ImplementaPartidos);
                servicioPartidos.ListarPartidos(this);
            }
        }

        private void CboListaTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(servicioPartidos == null)
                servicioPartidos = (IListadoPartidoServicio)AppContext.Instance.GetObject(ImplementaPartidos);
            servicioPartidos.ListarPartidos(this);
        }

        private void BtnAgregarPartido_Click(object sender, EventArgs e)
        {
            int ronda = 0;
            if (DgvListaPartidos.RowCount > 0)
            {
                ronda = Convert.ToInt32(DgvListaPartidos["Ronda", DgvListaPartidos.RowCount - 1].Value);
            }
            FrmNuevoPartido NuevoPartido = new FrmNuevoPartido(DgvListaPartidos.RowCount, ronda);
            if (NuevoPartido.ShowDialog() == DialogResult.OK)
            {
                servicioPartidos.ListarPartidos(this);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            int ronda = 0;
            if (DgvListaPartidos.RowCount > 0)
            {
                ronda =Convert.ToInt32(DgvListaPartidos["Ronda", DgvListaPartidos.RowCount - 1].Value);

                FrmNuevoPartido ModificaPartido = new FrmNuevoPartido(Convert.ToInt32(DgvListaPartidos.SelectedRows[0].Cells[0].Value), DgvListaPartidos.RowCount,ronda);
                if (ModificaPartido.ShowDialog() == DialogResult.OK)
                {
                    servicioPartidos.ListarPartidos(this);
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        private void DgvListaPartidos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvListaPartidos.Rows.Count > 0)
            {
                //if (Convert.ToBoolean(DgvListaPartidos.SelectedRows[0].Cells["Estado"].Value) == false)
                //{
                //    BtnModificar.Enabled = false;

                //}
                //else
                //{
                //    BtnModificar.Enabled = true;
                //}
            }
        }

        private void BtnGenerarLlave_Click(object sender, EventArgs e)
        {
            servicioInscripciones = (IListadoInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
            servicioInscripciones.ListarPorTorneo(this);
        }

        #region Miembros de IListadoInscripciones

        public List<object> ListarPorTorneo
        {
            set 
            {
                if ((value.Count / 2) <= DgvListaPartidos.RowCount)
                {
                    IReportesServicio servicioReportes = (IReportesServicio)AppContext.Instance.GetObject(ImplementaReportes);
                    Object ReporteLlave = servicioReportes.CrearInstancia("Llave", IdTorneo);
                    FrmReportes Reportes = new FrmReportes(ReporteLlave);
                    Reportes.Show();
                }
                else
                    MessageBox.Show("Faltan crear partidos. ");
            }
        }

        public List<object> ListarPorPartido
        {
            set { throw new NotImplementedException(); }
        }

        public int IdPartido
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
