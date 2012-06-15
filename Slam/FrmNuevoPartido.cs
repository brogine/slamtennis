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
    public partial class FrmNuevoPartido : Form, IPartidoUI, IListadoTorneos, IListadoInscripciones,IFechasTorneoUI
    {
        int idpartido = 0;
        ITorneoServicio torneo;
        IListadoTorneoServicio servicioTorneos;
        IPartidoServicio servicioPartido;
        string ImplemetaPartidos = "PartidoServicio";
        string ImplementaTorneos = "TorneoServicio";
        IListadoInscripcionServicio servicioInscripciones;
        string ImplementaInscripciones = "InscripcionServicio";

        public FrmNuevoPartido()
        {
            InitializeComponent();
            this.Text = "Nuevo Partido";
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarCerrados(this);
            servicioPartido = (IPartidoServicio)AppContext.Instance.GetObject(ImplemetaPartidos);
            TxtResultado.Enabled = false;
            ChkEstado.Checked = true;
            ChkEstado.Enabled = false;
        }

        public FrmNuevoPartido(int IdPartido)
        {
            InitializeComponent();
            this.Text = "Modificar Partido";
            this.idpartido = IdPartido;

            IInscripcionServicio servicioInscripciones = (IInscripcionServicio)AppContext.Instance.GetObject("InscripcionServicio");
            servicioInscripciones.DarDeAltaPorPartido(IdPartido);

            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarCerrados(this);
            
            servicioPartido = (IPartidoServicio)AppContext.Instance.GetObject(ImplemetaPartidos);
            servicioPartido.Buscar(this);
            
            CboEquipo1.Enabled = false;
            CboEquipo2.Enabled = false;
            CboListaTorneo.Enabled = false;
            
        }

        #region Miembros de IPartidoUI

        public int IdPartido
        {
            get
            {
                return idpartido;
            }
            set
            {
                idpartido = value;
            }
        }

        public int IdEquipo1
        {
            get
            {
                return (int)CboEquipo1.SelectedValue;
            }
            set
            {
                CboEquipo1.SelectedValue = value;
            }
        }

        public int IdEquipo2
        {
            get
            {
                if (CboEquipo2.SelectedItem.ToString() == "BYE")
                {
                    return 0;

                }
                else
                {
                    return (int)CboEquipo2.SelectedValue;
                }
            }
            set
            {
                CboEquipo2.SelectedValue = value;
            }
        }

        public string Ronda
        {
            get
            {
                return CboRonda.SelectedValue.ToString();
            }
            set
            {
                CboRonda.SelectedValue = int.Parse(value);            
            }
        }

        public int IdTorneo
        {
            get
            {
                return Convert.ToInt32(((KeyValuePair<int, string>)CboListaTorneo.SelectedItem).Key);
            }
            set
            {
                CboListaTorneo.SelectedValue = value;
            }
        }

        public string Resultado
        {
            get
            {
                return TxtResultado.Text;
            }
            set
            {
                TxtResultado.Text = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return DtpFechaPartido.Value;
            }
            set
            {
                DtpFechaPartido.Value = value;
            }
        }

        public bool Estado
        {
            get
            {
                return ChkEstado.Checked;
            }
            set
            {
                ChkEstado.Checked = value;
            }
        }

        #endregion

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
                CboListaTorneo.DataSource = new BindingSource(ListaTorneos, String.Empty);
                CboListaTorneo.DisplayMember = "Value";
                CboListaTorneo.ValueMember = "Key";
                CboListaTorneo.SelectedIndex = -1;
            }
        }

        #endregion

        #region Miembros de IListadoInscripciones

        public List<object> ListarPorTorneo
        {
            set
            {
                if (idpartido == 0)
                {
                    if (value.Count > 8 && value.Count < 32)
                    {
                        CboRonda.SelectedValue = (int)Rondas.Primera_Ronda;
                    }
                    if (value.Count > 8 && value.Count <= 16)
                    {
                        CboRonda.SelectedValue = (int)Rondas.Segunda_Ronda;
                    }
                    if (value.Count > 4 && value.Count <= 8)
                    {
                        CboRonda.SelectedValue = (int)Rondas.Cuartos_Final;
                    }
                    if (value.Count <= 4 && value.Count > 2)
                    {
                        CboRonda.SelectedValue = (int)Rondas.Semi_Final;
                    }
                    if (value.Count == 2)
                    {
                        CboRonda.SelectedValue = (int)Rondas.Final;
                    }
                }

                Dictionary<int, string> ListaInscripciones = new Dictionary<int, string>();
                foreach (Object Inscripcion in value)
                {
                    Object[] DatosTorneo = Inscripcion.ToString().Split(',');

                    if (((TipoTorneo)(Convert.ToInt32(DatosTorneo[1]))) == TipoTorneo.Doble)
                    {
                        ListaInscripciones.Add(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[2].ToString() + "-" + DatosTorneo[3].ToString());
                    }
                    else
                    {
                        ListaInscripciones.Add(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[2].ToString());
                    }
                }
                if (ListaInscripciones.Count > 0)
                {
                    CboEquipo2.DataSource = new BindingSource(ListaInscripciones, null);
                    CboEquipo2.DisplayMember = "Value";
                    CboEquipo2.ValueMember = "Key";
                    CboEquipo2.SelectedValue = ListaInscripciones.Keys.ElementAt(1);
                    CboEquipo1.DataSource = new BindingSource(ListaInscripciones, null);
                    CboEquipo1.DisplayMember = "Value";
                    CboEquipo1.ValueMember = "Key";
                    CboEquipo1.SelectedValue = ListaInscripciones.Keys.ElementAt(0);
                }
            }
        }

        public List<object> ListarPorPartido
        {
            set { throw new NotImplementedException(); }
        }

        #endregion

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboEquipo1.SelectedIndex == CboEquipo2.SelectedIndex)
                    MessageBox.Show("No Puede Seleccionar El Mismo Equipo En Ambas istas");
                else
                {
                    if (EPPartidos.GetError(CboListaTorneo) != "" && EPPartidos.GetError(CboEquipo1) != "" && EPPartidos.GetError(CboEquipo2) != "")
                        MessageBox.Show("Complete Todos Los Campos Antes De Continuar");
                    else
                    {
                        if (servicioPartido.Existe(this.IdPartido))
                            servicioPartido.Modificar(this);
                        else
                            servicioPartido.Agregar(this);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboListaTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CboListaTorneo.SelectedIndex > -1)
                {
                    List<DictionaryEntry> ListaRondas = new List<DictionaryEntry>();
                    foreach(Rondas rondas in Enum.GetValues(typeof(Rondas)))
                    {
                        ListaRondas.Add(new DictionaryEntry((int)rondas, rondas));
                    }
                    CboRonda.DataSource = ListaRondas;
                    CboRonda.DisplayMember = "Value";
                    CboRonda.ValueMember = "Key";
                    servicioInscripciones = (IListadoInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
                    servicioInscripciones.ListarActivas(this);
                    torneo = (ITorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
                    torneo.GetFechas(this);
                    DtpFechaPartido.MinDate = this.FechaInicio;
                    DtpFechaPartido.MaxDate = this.FechaFin;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CboListaTorneo_Validating(object sender, CancelEventArgs e)
        {
            if (CboListaTorneo.SelectedIndex < 0)
                EPPartidos.SetError(CboListaTorneo, "Debe Seleccionar Un Torneo De La Lista");
            else
                EPPartidos.SetError(CboListaTorneo, "");
        }

        private void CboEquipo1_Validating(object sender, CancelEventArgs e)
        {
            if (CboEquipo1.SelectedIndex < 0)
                EPPartidos.SetError(CboEquipo1, "Debe Seleccionar Un Equipo De La Lista");
            else
                EPPartidos.SetError(CboEquipo1, "");

        }

        private void CboEquipo2_Validating(object sender, CancelEventArgs e)
        {
            if (CboEquipo2.SelectedIndex < 0)
                EPPartidos.SetError(CboEquipo2, "Debe Seleccionar Un Equipo De La Lista");
            else
                EPPartidos.SetError(CboEquipo2, "");
            if (CboEquipo1.SelectedItem != null)
            {
                if (Convert.ToInt32(((KeyValuePair<int, string>)CboEquipo2.SelectedItem).Key) == Convert.ToInt32(((KeyValuePair<int, string>)CboEquipo1.SelectedItem).Key))
                    EPPartidos.SetError(CboEquipo2, "Los Equipos No Pueden Ser Iguales");
                else
                    EPPartidos.SetError(CboEquipo2, "");
            }
        }

        #region IFechasTorneoUI Members

        public string Nombre
        {
            get;
            set;
        }

        public DateTime FechaInicio
        {
            get;
            set;
        }

        public DateTime FechaFin
        {
            get;
            set;
        }

        public DateTime FechaFinInscripcion
        {
            get;
            set;
        }

        public DateTime FechaInicioInscripcion
        {
            get;
            set;
        }

        int IFechasTorneoUI.Estado
        {
            get;
            set;
        }

        #endregion

    }
}
