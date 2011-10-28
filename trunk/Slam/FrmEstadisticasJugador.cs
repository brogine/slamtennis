using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio;
using ApplicationContext;
using Servicio.InterfacesUI;

namespace Slam
{
    public partial class FrmEstadisticasJugador : Form, IEstadisticasUI, IListadoCategorias
    {
        string ImplementaEstadisticas = "EstadisticasServicio";
        string ImplementaCategorias = "CategoriaServicio";
        IEstadisticasServicio servicioEstadisticas;
        IListadoCategoriaServicio servicioCategorias;
        int DniJugador = 0;
        int IdCategoriaActual = 0;
        public FrmEstadisticasJugador(int DniJugador, string NombreApellido)
        {
            InitializeComponent();
            this.DniJugador = DniJugador;
            LblJugador.Text = NombreApellido;
        }

        public FrmEstadisticasJugador(int DniJugador, int IdCategoriaActual, string NombreApellido)
        {
            InitializeComponent();
            this.IdCategoriaActual = IdCategoriaActual;
            this.DniJugador = DniJugador;
            LblJugador.Text = NombreApellido;
        }

        private void FrmEstadisticasJugador_Load(object sender, EventArgs e)
        {
            try
            {
                servicioCategorias = (IListadoCategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
                servicioCategorias.ListarActivas(this);
                servicioEstadisticas = (IEstadisticasServicio)AppContext.Instance.GetObject(ImplementaEstadisticas);


                if (IdCategoriaActual > 0 && DniJugador > 0)
                {
                    CboCategorias.SelectedValue = IdCategoriaActual;

                    servicioEstadisticas.Buscar(this);

                    this.Text = "Modificar Estadisticas del Jugador";
                }
                else
                    this.Text = "Nueva Estadistica del Jugador";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Validaciones
        private void CboCategorias_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboCategorias_Validating(object sender, CancelEventArgs e)
        {
            if (CboCategorias.SelectedIndex < 0)
                EpEstadisticas.SetError(CboCategorias, "Debe elegir una Categoría");
            else
                EpEstadisticas.SetError(CboCategorias, "");
        }

        private void TxtPG_Validating(object sender, CancelEventArgs e)
        {
            int Result = 0;
            if (TxtPG.Text == "" && int.TryParse(TxtPG.Text, out Result))
                EpEstadisticas.SetError(TxtPG, "Debe poner un número de Partidos Ganados");
            else
                EpEstadisticas.SetError(TxtPG, "");
        }

        private void TxtPP_Validating(object sender, CancelEventArgs e)
        {
            int Result = 0;
            if (TxtPP.Text == "" && int.TryParse(TxtPP.Text, out Result))
                EpEstadisticas.SetError(TxtPP, "Debe poner un número de Partidos Perdidos");
            else
                EpEstadisticas.SetError(TxtPP, "");
        }

        private void TxtTJ_Validating(object sender, CancelEventArgs e)
        {
            int Result = 0;
            if (TxtTJ.Text == "" && int.TryParse(TxtTJ.Text, out Result))
                EpEstadisticas.SetError(TxtTJ, "Debe poner un número de Torneos Jugados");
            else
                EpEstadisticas.SetError(TxtTJ, "");
        }

        private void TxtTC_Validating(object sender, CancelEventArgs e)
        {
            int Result = 0;
            if (TxtTC.Text == "" && int.TryParse(TxtTC.Text, out Result))
                EpEstadisticas.SetError(TxtTC, "Debe poner un número de Torneos Completados");
            else
                EpEstadisticas.SetError(TxtTC, "");
        }

        private void TxtPuntos_Validating(object sender, CancelEventArgs e)
        {
            int Result = 0;
            if (TxtPuntos.Text == "" && int.TryParse(TxtPuntos.Text, out Result))
                EpEstadisticas.SetError(TxtPuntos, "Debe poner un número de Puntos");
            else
                EpEstadisticas.SetError(TxtPuntos, "");
        }
        #endregion

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (EpEstadisticas.GetError(CboCategorias) == "" && EpEstadisticas.GetError(TxtPG) == "" &&
                EpEstadisticas.GetError(TxtPP) == "" && EpEstadisticas.GetError(TxtTJ) == "" &&
                EpEstadisticas.GetError(TxtTC) == "" && EpEstadisticas.GetError(TxtPuntos) == "")
            {
                try
                {
                    if (DniJugador > 0)
                    {
                        if (!servicioEstadisticas.Existe(this))
                            servicioEstadisticas.Agregar(this);
                        else
                            servicioEstadisticas.Modificar(this);
                    }
                    
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Acción realizada con éxito");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Miembros de IEstadisticasUI

        public int Dni
        {
            get
            {
                return DniJugador;
            }
            set
            {
                DniJugador = value;
            }
        }

        public int PartidosJugados
        {
            set { TxtPJ.Text = value.ToString(); }
        }

        public int PartidosGanados
        {
            get
            {
                return int.Parse(TxtPG.Text);
            }
            set
            {
                TxtPG.Text = value.ToString();
            }
        }

        public int PartidosPerdidos
        {
            get
            {
                return int.Parse(TxtPP.Text);
            }
            set
            {
                TxtPP.Text = value.ToString();
            }
        }

        public int IdCategoria
        {
            get
            {
                return (int)CboCategorias.SelectedValue;
            }
            set
            {
                CboCategorias.SelectedValue = value;
            }
        }

        public int Puntos
        {
            get
            {
                return int.Parse(TxtPuntos.Text);
            }
            set
            {
                TxtPuntos.Text = value.ToString();
            }
        }

        public int TorneosCompletados
        {
            get
            {
                return int.Parse(TxtTC.Text);
            }
            set
            {
                TxtTC.Text = value.ToString();
            }
        }

        public int TorneosJugados
        {
            get
            {
                return int.Parse(TxtTJ.Text);
            }
            set
            {
                TxtTJ.Text = value.ToString();
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

        #region Miembros de IListadoCategorias

        public List<object> ListaUI
        {
            set 
            {
                Dictionary<int, string> ListaCategorias = new Dictionary<int, string>();
                foreach (Object Categoria in value)
                {
                    Object[] DatosClub = Categoria.ToString().Split(',');
                    ListaCategorias.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboCategorias.DataSource = new BindingSource(ListaCategorias, null);
                CboCategorias.DisplayMember = "Value";
                CboCategorias.ValueMember = "Key";
                CboCategorias.SelectedIndex = -1;
            }
        }

        #endregion


        #region Miembros de IEstadisticasUI


        public int PartidosJugadosDobles
        {
            set { TxtPartJugDob.Text = value.ToString(); }
        }

        public int PartidosGanadosDobles
        {
            get
            {
                return Convert.ToInt32(TxtPartGanDob.Text);
            }
            set
            {
                TxtPartGanDob.Text = value.ToString();
            }
        }

        public int PartidosPerdidosDobles
        {
            get
            {
                return Convert.ToInt32(TxtPartPerDob.Text);
            }
            set
            {
                TxtPartPerDob.Text = value.ToString();
            }
        }

        public int TorneosCompletadosDobles
        {
            get
            {
                return Convert.ToInt32(TxtTornCompDob.Text);
            }
            set
            {
                TxtTornCompDob.Text = value.ToString();
            }
        }

        public int TorneosJugadosDobles
        {
            get
            {
                return Convert.ToInt32(TxtTorJugDob.Text);
            }
            set
            {
                TxtTorJugDob.Text = value.ToString();
            }
        }

        public int PuntosDobles
        {
            get
            {
                return Convert.ToInt32(TxtPuntosDob.Text);
            }
            set
            {
                TxtPuntosDob.Text = value.ToString();
            }
        }

        #endregion
    }
}
