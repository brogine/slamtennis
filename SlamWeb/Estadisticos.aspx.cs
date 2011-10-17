using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio.InterfacesUI;
using Servicio;
using System.Data;

namespace SlamWeb
{
    public partial class Estadisticos : System.Web.UI.Page, IListadoEstadisticasCategoria, IListadoClubes, IListadoCategorias, IEstadisticasUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!Convert.ToBoolean(Session["Logeado"]))
                {
                    Response.Redirect("Login.aspx");
                }
                LblEmail.Text = Session["Email"].ToString().Trim();
                LblNombre.Text = Session["Nombre"].ToString().Trim() + " " + Session["Apellido"].ToString().Trim();
                LblUsuario.Text = Session["Usuario"].ToString().Trim();
                LblSexo.Text = Session["Sexo"].ToString().Trim();
                Image2.ImageUrl = "~/Profiles/" + Session["Imagen"].ToString().Trim();
                IListadoEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
                IListadoClubServicio servicioClubes = new ClubServicio();
                servicioClubes.ListarActivos(this);
                IListadoCategoriaServicio servicioCategorias = new CategoriaServicio();
                servicioCategorias.ListarActivas(this);
            }

        }

        #region IListadoEstadisticasCategoria Members

        public List<object> ListarEstadisticas
        {
            set
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Dni");
                dt.Columns.Add("Nombre y Apellido");
                dt.Columns.Add("PJ");
                dt.Columns.Add("PG");
                dt.Columns.Add("PP");
                dt.Columns.Add("TJ");
                dt.Columns.Add("TC");
                dt.Columns.Add("Puntos");
                if (dt.Rows.Count > 0)
                    dt.Rows.Clear();
                foreach (object estadistica in value)
                {
                    object[] estadisticas = estadistica.ToString().Split(',');
                    dt.Rows.Add(estadisticas);
                }
                DgvEstadisticas.DataSource = dt;
                DgvEstadisticas.DataBind();
                PnlDatos.Visible = true;
                IEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
                if (IdCategoria > 0 && Dni > 0)
                {
                    servicioEstadisticas.Buscar(this);
                }
            }
        }

        public int IdClub
        {
            get { return Convert.ToInt32(CboClub.SelectedValue); }
        }

        public int IdCategoria
        {
            get { return Convert.ToInt32(CboCategorias.SelectedValue); }
        }

        #endregion

        #region IListadoClubes Members

        public List<object> ListarClubes
        {
            set
            {
                Dictionary<int, string> ListaClubes = new Dictionary<int, string>();
                ListaClubes.Add(0, "Seleccione");
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    ListaClubes.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboClub.DataSource = ListaClubes;
                CboClub.DataTextField = "Value";
                CboClub.DataValueField = "Key";
                CboClub.DataBind();
                CboClub.SelectedIndex = -1;
            }
        }

        #endregion

        #region IListadoCategorias Members

        public List<object> ListaUI
        {
            set
            {
                Dictionary<int, string> ListaCategorias = new Dictionary<int, string>();
                ListaCategorias.Add(0, "Seleccione");
                foreach (Object Categoria in value)
                {
                    Object[] DatosClub = Categoria.ToString().Split(',');
                    ListaCategorias.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboCategorias.DataSource = ListaCategorias;
                CboCategorias.DataTextField = "Value";
                CboCategorias.DataValueField = "Key";
                CboCategorias.SelectedIndex = -1;
                CboCategorias.DataBind(); 
            }
        }

        #endregion

        protected void CboClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboClub.SelectedIndex > -1 && CboCategorias.SelectedIndex > -1)
            {
                IListadoEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
                servicioEstadisticas.ListarPorCategoriaClub(this);
            }
        }

        protected void CboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboClub.SelectedIndex > -1 && CboCategorias.SelectedIndex > -1)
            {
                IListadoEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
                servicioEstadisticas.ListarPorCategoriaClub(this);
            }
        }

        #region IEstadisticasUI Members

        public int Dni
        {
            get
            {
                return Convert.ToInt32(Session["DNI"]);
            }
            set
            {
                Session["DNI"] = value;
            }
        }

        public int PartidosJugados
        {
            set { LblPJ.Text = value.ToString(); }
        }

        public int PartidosGanados
        {
            get
            {
                throw new NotImplementedException();
            }
            set { LblPG.Text = value.ToString(); }
        }

        public int PartidosPerdidos
        {
            get
            {
                throw new NotImplementedException();
            }
            set { LblPJ.Text = value.ToString(); }
        }

        int IEstadisticasUI.IdCategoria
        {
            get
            {
                return this.IdCategoria;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Puntos
        {
            get
            {
                throw new NotImplementedException();
            }
            set { this.LblPUNTOS.Text = value.ToString(); }
        }

        public int TorneosCompletados
        {
            get
            {
                throw new NotImplementedException();
            }
            set { LblTC.Text = value.ToString(); }
        }

        public int TorneosJugados
        {
            get
            {
                throw new NotImplementedException();
            }
            set { LblTJ.Text = value.ToString(); }
        }

        public bool Estado
        {
            get;
            set;
        }

        #endregion
    }
}
