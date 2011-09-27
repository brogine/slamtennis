using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;
using Servicio;
using System.Windows.Forms;
using ApplicationContext;

namespace Slam
{
    public partial class FrmNuevoTorneo : Form, ITorneoUI, IListadoClubes, IListadoCategorias
    {
        int idtorneo = -1;
        string ImplementaClubes = "ClubServicio";
        string ImplementaCategorias = "CategoriaServicio";
        IListadoClubServicio ClubServicio;
        IListadoCategoriaServicio servicioCategorias;
        ITorneoServicio TorneoServicio;
        string ImplementaTorneo = "TorneoServicio";

        public FrmNuevoTorneo(int IdTorneo)
        {
            InitializeComponent();
            this.idtorneo = IdTorneo;
            this.Text = "Modificar Torneo";
        }

        public FrmNuevoTorneo()
        {
            InitializeComponent();
            this.Text = "Nuevo Torneo";
        }

        private void FrmNuevoTorneo_Load(object sender, EventArgs e)
        {

            CboEstado.DataSource = Enum.GetValues(typeof(EstadoTorneo));
            CboSuperficie.DataSource = Enum.GetValues(typeof(TipoSuperficie));
            ClubServicio = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            ClubServicio.Listar(this);
            servicioCategorias = (IListadoCategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
            servicioCategorias.Listar(this);
            TorneoServicio = (ITorneoServicio)AppContext.Instance.GetObject(ImplementaTorneo);
            if (idtorneo > -1)
            {
                TorneoServicio.Buscar(this);
            }
           
        }

        #region Miembros de ITorneoUI

        public int IdTorneo
        {
            get
            {
                return idtorneo;
            }
            set
            {
                idtorneo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return TxtNombre.Text;
            }
            set
            {
                TxtNombre.Text = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return DTPInicioTorneo.Value;
            }
            set
            {
                DTPInicioTorneo.Value = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return DTPFinTorneo.Value;
            }
            set
            {
                DTPFinTorneo.Value = value;
            }
        }

        public DateTime FechaFinInscripcion
        {
            get
            {
                return DTPFinInscripciones.Value;
            }
            set
            {
                DTPFinInscripciones.Value = value;
            }
        }

        public DateTime FechaInicioInscripcion
        {
            get
            {
                return DTPInicioInscripciones.Value;
            }
            set
            {
                DTPInicioInscripciones.Value = value;
            }
        }

        public int Cupo
        {
            get
            {
               return int.Parse(TxtCupo.Text);
            }
            set
            {
                TxtCupo.Text = value.ToString();
            }
        }

        public string Sexo
        {
            get
            {
                if (RBMasculino.Checked)
                {
                    return "Masculino";
                }
                else if (RBFemenino.Checked)
                {
                    return "Femenino";
                }
                else
                {
                    return "Mixto";
                }
            }
            set
            {
                if (value == "Masculino")
                {
                    RBMasculino.Checked=true;
                }
                else if (value == "Femenino")
                {
                    RBFemenino.Checked = true;
                }
                else
                {
                    RBMixto.Checked = true;
                }
            }
        }

        public int Tipo
        {
            get
            {
                if (RBSingle.Checked)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                if (value == 0)
                {
                    RBSingle.Checked = true;
                }
                else
                {
                    RBDouble.Checked = true;
                }
            }
        }

        public int IdClub
        {
            get
            {
                return (int)CboClub.SelectedValue;
            }
            set
            {
                CboClub.SelectedValue = value;
            }
        }

        public int IdCategoria
        {
            get
            {
                return (int)CboCategoria.SelectedValue;
            }
            set
            {
                CboCategoria.SelectedValue = value;
            }
        }

        public bool TipoInscripcion
        {
            get
            {
                return ChkInscripcion.Checked;
            }
            set
            {
                ChkInscripcion.Checked = value;
            }
        }

        public int Superficie
        {
            get
            {
                return (int) CboSuperficie.SelectedValue; 
            }
            set
            {
                CboSuperficie.SelectedIndex = value;
            }
        }

        public int Estado
        {
            get
            {
                return (int)CboEstado.SelectedValue;
            }
            set
            {
                CboEstado.SelectedIndex = value;
            }
        }

        #endregion

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {
            set 
            {
                Dictionary<int, string> ListaClubes = new Dictionary<int, string>();
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    ListaClubes.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboClub.DataSource = new BindingSource(ListaClubes, null);
                CboClub.DisplayMember = "Value";
                CboClub.ValueMember = "Key";
                CboClub.SelectedIndex = -1;
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
                CboCategoria.DataSource = new BindingSource(ListaCategorias, null);
                CboCategoria.DisplayMember = "Value";
                CboCategoria.ValueMember = "Key";
                CboCategoria.SelectedIndex = -1;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TorneoServicio.Existe(IdTorneo))
                {
                    TorneoServicio.Modificar(this);
                }
                else
                {
                    TorneoServicio.Agregar(this);
                }
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Operacion Realizada Con Exito");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
