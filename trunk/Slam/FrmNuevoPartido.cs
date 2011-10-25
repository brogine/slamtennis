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
        int idpartido;
        public FrmNuevoPartido()
        {
            InitializeComponent();
            //CountSecuen = count;
            //UltimaRonda = ultimaRonda;
            this.Text = "Nuevo Partido";
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarTorneosCerrados(this);
            servicioPartido = (IPartidoServicio)AppContext.Instance.GetObject(ImplemetaPartidos);
        }

        public FrmNuevoPartido(int IdPartido)
        {
            InitializeComponent();
            //CountSecuen = count;
            //UltimaRonda = ultimaRonda;
            this.Text = "Modificar Partido";
            this.IdPartido = IdPartido;
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarTorneosCerrados(this);
            servicioPartido = (IPartidoServicio)AppContext.Instance.GetObject(ImplemetaPartidos);
            servicioPartido.Buscar(this);
        }
        ITorneoServicio torneo;
        IListadoTorneoServicio servicioTorneos;
        IPartidoServicio servicioPartido;
        string ImplemetaPartidos = "PartidoServicio";
        string ImplementaTorneos = "TorneoServicio";
        IListadoInscripcionServicio servicioInscripciones;
        string ImplementaInscripciones = "InscripcionServicio";

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
                if (CboEquipo2.SelectedItem == "BYE")
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
                CboRonda.SelectedItem = value;
               
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
                CboListaTorneo.DataSource = new BindingSource(ListaTorneos, null);
                CboListaTorneo.DisplayMember = "Value";
                CboListaTorneo.ValueMember = "Key";
                CboListaTorneo.SelectedIndex = -1;


            }
        }

        #endregion

        private void FrmNuevoPartido_Load(object sender, EventArgs e)
        {

        }

        #region Miembros de IListadoInscripciones

        public List<object> ListarPorTorneo
        {
            set
            {
                if(value.Count>4 && value.Count <=8)
                {
                    CboRonda.SelectedItem = Rondas.Cuartos_Final;
                }
                if (value.Count <= 4 && value.Count > 2)
                {
                    CboRonda.SelectedItem = Rondas.Semi_Final;
                }
                if (value.Count == 2)
                {
                    CboRonda.SelectedItem = Rondas.Final;
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
                CboEquipo2.DataSource = new BindingSource(ListaInscripciones, null);
                CboEquipo2.DisplayMember = "Value";
                CboEquipo2.ValueMember = "Key";
                CboEquipo2.SelectedIndex = -1;
                CboEquipo1.DataSource = new BindingSource(ListaInscripciones, null);
                CboEquipo1.DisplayMember = "Value";
                CboEquipo1.ValueMember = "Key";
                CboEquipo1.SelectedIndex = -1;
                //if ((Convert.ToInt32(ListaInscripciones.Count / 2)) == CountSecuen || CountSecuen == 0)
                //{
                //    TxtRonda.Text = Convert.ToString(UltimaRonda + 1);
                //}

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
                if (EPPartidos.GetError(CboListaTorneo) != "" && EPPartidos.GetError(CboEquipo1) != "" && EPPartidos.GetError(CboEquipo2) != "")
                {
                    MessageBox.Show("Complete Todos Los Campos Antes De Continuar");
                }
                else
                {
                    if (servicioPartido.Existe(this.IdPartido))
                    {
                        servicioPartido.Modificar(this);
                    }
                    else
                    {
                        servicioPartido.Agregar(this);
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CboListaTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboListaTorneo.SelectedIndex > -1)
            {
                CboRonda.DataSource = Enum.GetValues(typeof(Rondas));
                servicioInscripciones = (IListadoInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
                servicioInscripciones.ListarActivas(this);
                torneo = (ITorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
                torneo.GetFechas(this);
                DtpFechaPartido.MinDate = this.FechaInicio;
                DtpFechaPartido.MaxDate = this.FechaFin;

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
            {
                EPPartidos.SetError(CboListaTorneo, "Debe Seleccionar Un Torneo De La Lista");
            }
            else
            {
                EPPartidos.SetError(CboListaTorneo, "");
            }
        }
        private void CboEquipo1_Validating(object sender, CancelEventArgs e)
        {
            if (CboEquipo1.SelectedIndex < 0)
            {
                EPPartidos.SetError(CboEquipo1, "Debe Seleccionar Un Equipo De La Lista");
            }
            else
            {
                EPPartidos.SetError(CboEquipo1, "");
            }

        }
        private void CboEquipo2_Validating(object sender, CancelEventArgs e)
        {
            if (CboEquipo2.SelectedIndex < 0)
            {
                EPPartidos.SetError(CboEquipo2, "Debe Seleccionar Un Equipo De La Lista");
            }
            else
            {
                EPPartidos.SetError(CboEquipo2, "");
            }
            if (CboEquipo1.SelectedItem != null)
            {
                if (Convert.ToInt32(((KeyValuePair<int, string>)CboEquipo2.SelectedItem).Key) == Convert.ToInt32(((KeyValuePair<int, string>)CboEquipo1.SelectedItem).Key))
                {
                    EPPartidos.SetError(CboEquipo2, "Los Equipos No Pueden Ser Iguales");
                }
                else
                {
                    EPPartidos.SetError(CboEquipo2, "");
                }
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
