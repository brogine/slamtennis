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
    public partial class FrmListaPartidos : Form, IListadoTorneos, IListadoPartidos, IListadoInscripciones, IPuntosUI
    {
        string ImplementaReportes = "ReportesServicio";
        string ImplementaTorneos = "TorneoServicio";
        string ImplementaInscripciones = "InscripcionServicio";
        string ImplementaPartidos = "PartidoServicio";
        string ImplementaPuntos = "PuntosServicio";
        IListadoTorneoServicio servicioTorneos;
        IListadoPartidoServicio servicioPartidos;
        IListadoInscripcionServicio servicioInscripciones;
        IPuntosServicio servicioPuntos;
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
                    Datos[4] = Enum.GetName(typeof(Rondas), Convert.ToInt32(Datos[4]));
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
            try
            {
                servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
                servicioPuntos = (IPuntosServicio)AppContext.Instance.GetObject(ImplementaPuntos);
                servicioTorneos.ListarCerrados(this);
                if (IdTorneoActual > 0)
                {
                    CboListaTorneos.SelectedValue = IdTorneoActual;
                    servicioPartidos = (IListadoPartidoServicio)AppContext.Instance.GetObject(ImplementaPartidos);
                    servicioPartidos.Listar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboListaTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (servicioPuntos.Existe(this))
                {
                    if (servicioPartidos == null)
                        servicioPartidos = (IListadoPartidoServicio)AppContext.Instance.GetObject(ImplementaPartidos);
                    servicioPartidos.Listar(this);
                }
                else
                {
                    MessageBox.Show("El Torneo elegido no tiene puntos asignados.");
                    FrmPuntosTorneo frmPuntos =
                        new FrmPuntosTorneo(
                            Convert.ToInt32(((KeyValuePair<int, string>)CboListaTorneos.SelectedItem).Key));
                    if (frmPuntos.ShowDialog() == DialogResult.OK)
                    {
                        if (servicioPartidos == null)
                            servicioPartidos = (IListadoPartidoServicio)AppContext.Instance.GetObject(ImplementaPartidos);
                        servicioPartidos.Listar(this);
                    }
                }
                this.IdTorneoActual = (int)CboListaTorneos.SelectedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregarPartido_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboListaTorneos.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe Seleccionar Un Torneo De La Lista");
                    return;
                }
                FrmNuevoPartido NuevoPartido = new FrmNuevoPartido();
                if (NuevoPartido.ShowDialog() == DialogResult.OK)
                {
                    servicioPartidos.Listar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvListaPartidos.RowCount > 0)
                {


                    FrmNuevoPartido ModificaPartido = new FrmNuevoPartido(Convert.ToInt32(DgvListaPartidos.SelectedRows[0].Cells[0].Value), (int)CboListaTorneos.SelectedValue);
                    if (ModificaPartido.ShowDialog() == DialogResult.OK)
                    {
                        servicioPartidos.Listar(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }
        private void BtnGenerarLlave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboListaTorneos.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe Seleccionar Un Torneo De La Lista");
                    return;
                }
                servicioInscripciones = (IListadoInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
                servicioInscripciones.ListarPorTorneo(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Miembros de IListadoInscripciones

        public List<object> ListarPorTorneo
        {
            set 
            {
                if ((value.Count / 2) <= DgvListaPartidos.RowCount)
                {
                    IReportesServicio servicioReportes = (IReportesServicio)AppContext.Instance.GetObject(ImplementaReportes);
                    Object ReporteLlave = servicioReportes.CrearInstancia(ListadoReportes.Llave, IdTorneo);
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

        #region Miembros de IPuntosUI


        public int PrimeraRonda
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int SegundaRonda
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int CuartosFinal
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int SemiFinal
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Final
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Cupo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Campeon
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion



        private void DgvListaPartidos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaPartidos.SelectedRows.Count > 0)
            {
                if (DgvListaPartidos.SelectedRows[0].Cells["Equipo2"].Value.ToString() == "BYE")
                {
                    BtnModificar.Enabled = false;
                }
                else
                {
                    BtnModificar.Enabled = true;
                }
            }
        }




    }
}
