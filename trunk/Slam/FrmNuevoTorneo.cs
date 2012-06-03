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
            try
            {
                CboSuperficie.DataSource = Enum.GetValues(typeof(TipoSuperficie));
                ClubServicio = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
                ClubServicio.ListarActivos(this);
                servicioCategorias = (IListadoCategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
                
                servicioCategorias.ListarActivas(this);

                TorneoServicio = (ITorneoServicio)AppContext.Instance.GetObject(ImplementaTorneo);
                if (idtorneo > -1)
                {
                    TorneoServicio.Buscar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
               return Convert.ToInt32(CboCupo.SelectedItem);
            }
            set
            {
                CboCupo.Text = value.ToString();
            }
        }

        public string Sexo
        {
            get
            {
                if (RBMasculino.Checked)
                    return "Masculino";
                else if (RBFemenino.Checked)
                    return "Femenino";
                else
                    return "Mixto";
            }
            set
            {
                if (value == "Masculino")
                    RBMasculino.Checked = true;
                else if (value == "Femenino")
                    RBFemenino.Checked = true;
                else
                    RBMixto.Checked = true;
            }
        }

        public int Tipo
        {
            get
            {
                if (RBSingle.Checked)
                    return 0;
                else
                    return 1;
            }
            set
            {
                if (value == 0)
                    RBSingle.Checked = true;
                else
                    RBDouble.Checked = true;
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
                return (int)EstadoTorneo.NoIniciado;
            }
            set
            {
                LblEstado.Text=((EstadoTorneo)value).ToString();
            }
        }

        #endregion

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {
            set 
            {
                if (value.Count > 0)
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
                else
                {
                    MessageBox.Show("No existen Clubes en el Sistema. Para crear un Torneo debe haber al menos una Club. Agregue una Club para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FrmNuevoClub NuevoClub = new FrmNuevoClub();
                    if (NuevoClub.ShowDialog() != DialogResult.Retry)
                        this.ClubServicio.ListarActivos(this);
                }
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
                if (value.Count > 0)
                {
                    CboCategoria.DataSource = new BindingSource(ListaCategorias, null);
                    CboCategoria.DisplayMember = "Value";
                    CboCategoria.ValueMember = "Key";
                    CboCategoria.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No existen Categorías en el Sistema. Para crear un Torneo debe haber al menos una Categoría. Agregue una Categoría para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FrmNuevaCategoria NuevaCategoria = new FrmNuevaCategoria();
                    if(NuevaCategoria.ShowDialog() != DialogResult.Retry)
                        this.servicioCategorias.ListarActivas(this);
                }
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (EPTorneos.GetError(TxtNombre) != "" && EPTorneos.GetError(CboClub) != "" && EPTorneos.GetError(CboCategoria) != "" &&
                    EPTorneos.GetError(DTPFinInscripciones) != "" && EPTorneos.GetError(DTPInicioInscripciones) != "" && EPTorneos.GetError(DTPFinTorneo) != "" &&
                    EPTorneos.GetError(DTPInicioTorneo) != "" && EPTorneos.GetError(groupBox1) != "" && EPTorneos.GetError(groupBox2) != "" &&
                    EPTorneos.GetError(CboSuperficie) != "")
                    MessageBox.Show("Complete Todos Los Campos Antes de Continuar");
                else
                {
                    if (TorneoServicio.Existe(IdTorneo))
                        TorneoServicio.Modificar(this);
                    else
                        TorneoServicio.Agregar(this);

                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Operacion Realizada Con Exito");
                    this.Dispose();
                }
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

        private void TxtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNombre.Text == string.Empty)
                EPTorneos.SetError(TxtNombre, "El Nombre No Puede Estar en Blanco");
            else
                EPTorneos.SetError(TxtNombre, "");
        }

        private void CboClub_Validating(object sender, CancelEventArgs e)
        {
            if (CboClub.SelectedIndex < 0)
                EPTorneos.SetError(CboClub, "Debe Seleccionar Un Club De La Lista");
            else
                EPTorneos.SetError(CboClub, "");

        }
        private void CboCategoria_Validating(object sender, CancelEventArgs e)
        {
            if (CboCategoria.SelectedIndex < 0)
                EPTorneos.SetError(CboCategoria, "Debe Seleccionar Una Categoria De La Lista");
            else
                EPTorneos.SetError(CboCategoria, "");
        }

        private void DTPFinTorneo_Validating(object sender, CancelEventArgs e)
        {
            if (DTPFinTorneo.Value < DTPInicioTorneo.Value)
                EPTorneos.SetError(DTPFinTorneo, "La Fecha De Fin De Torneo No Puede Ser Menor Que La De Inicio");
            else
                EPTorneos.SetError(DTPFinTorneo, "");
        }

        private void DTPFinInscripciones_Validating(object sender, CancelEventArgs e)
        {
            if (DTPFinInscripciones.Value < DTPInicioInscripciones.Value)
                EPTorneos.SetError(DTPFinInscripciones, "La Fecha De Fin De Inscripciones No Puede Ser Menor Que La De Inicio");
            else
                EPTorneos.SetError(DTPFinInscripciones, "");
        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!RBMasculino.Checked && !RBFemenino.Checked && !RBMixto.Checked)
                EPTorneos.SetError(groupBox1, "Debe Seleccionar El Sexo");
            else
                EPTorneos.SetError(groupBox1, "");
        }

        private void groupBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!RBDouble.Checked && !RBSingle.Checked)
                EPTorneos.SetError(groupBox2, "Debe Seleccionar Un Tipo De Torneo");
            else
                EPTorneos.SetError(groupBox2, "");
        }


        private void CboSuperficie_Validating(object sender, CancelEventArgs e)
        {
            if (CboSuperficie.SelectedIndex < 0)
                EPTorneos.SetError(CboSuperficie, "Seleccione Un Tipo De Superficie");
            else
                EPTorneos.SetError(CboSuperficie, "");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmPuntosTorneo Puntos = new FrmPuntosTorneo();
            Puntos.Show();
        }
    }
}
