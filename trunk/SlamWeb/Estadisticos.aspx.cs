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
    public partial class Estadisticos : System.Web.UI.Page, IListadoCategorias,IListadoEstadisticasCategoria, IListadoEstadisticasDni, IEstadisticasUI
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
                if (Session["Imagen"] != null)
                {
                    Image1.ImageUrl = "~/Profiles/" + Session["Imagen"].ToString().Trim();
                }
                else
                {
                    Image1.ImageUrl = "~/Content/Alert_32x32-32.png";
                }
                IListadoEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
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
                dt.Columns.Add("Posicion");
                if (dt.Rows.Count > 0)
                    dt.Rows.Clear();
                bool existe = false;
                foreach (object estadistica in value)
                {
                    object[] estadisticas = estadistica.ToString().Split(',');
                    if (Convert.ToInt32(estadisticas[0]) == Convert.ToInt32(Session["Dni"]))
                    {
                        existe = true;
                    }
                    dt.Rows.Add(estadisticas);
                }
                DgvEstadisticas.DataSource = dt;
                DgvEstadisticas.DataBind();

                if (existe != false)
                {
                    PnlDatos.Visible = true;
                    IEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
                    if (IdCategoria > 0 && Dni > 0)
                    {
                        servicioEstadisticas.Buscar(this);
                    }
                }
                else
                {
                    PnlDatos.Visible = false;
                }
            }
        }

        public int IdClub
        {
            get { return 0; }
        }

        public int IdCategoria
        {
            get { return Convert.ToInt32(CboCategorias.SelectedValue); }
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
      
        protected void CboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCategorias.SelectedIndex > 0 && CboTipo.SelectedIndex > 0)
            {
                if (CboTipo.Text == "Single")
                {
                    IListadoEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
                    servicioEstadisticas.ListarPorCategoria(this);
                }
                else
                {
                    IListadoEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
                    servicioEstadisticas.ListarPorCategoriaDobles(this);
                }
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

        #region IListadoEstadisticasDni Members


        public int DniJugador
        {
            get { return Convert.ToInt32(Session["DNI"]); }
        }

        #endregion

        #region Miembros de IEstadisticasUI


        public int PartidosJugadosDobles
        {
            set { LblPJ2.Text = value.ToString(); }
        }

        public int PartidosGanadosDobles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                LblPG2.Text = value.ToString();
            }
        }

        public int PartidosPerdidosDobles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                LblPP2.Text = value.ToString();
            }
        }

        public int TorneosCompletadosDobles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                LblTC2.Text = value.ToString();
            }
        }

        public int TorneosJugadosDobles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                LblTJ2.Text = value.ToString();
            }
        }

        public int PuntosDobles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.LblPD2.Text = value.ToString();
            }
        }

        #endregion
    }
}
