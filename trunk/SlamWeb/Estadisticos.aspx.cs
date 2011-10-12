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
    public partial class Estadisticos : System.Web.UI.Page,IListadoEstadisticasDni,IAfiliacionUI,IListadoEstadisticasCategoria
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["Logeado"]))
            {
                Response.Redirect("Login.aspx");
            }
            LblEmail.Text = Session["Email"].ToString().Trim();
            LblNombre.Text = Session["Nombre"].ToString().Trim() + " " + Session["Apellido"].ToString().Trim();
            LblUsuario.Text = Session["Usuario"].ToString().Trim();
            LblSexo.Text = Session["Sexo"].ToString().Trim();
            IListadoEstadisticasServicio estadistica = new EstadisticasServicio();
            estadistica.ListarPorDni(this);
            IAfiliacionServicio afiliado = new AfiliacionServicio();
            afiliado.Buscar(this);
            IListadoEstadisticasServicio categoria = new EstadisticasServicio();
            categoria.ListarPorCategoriaClub(this);        

        }

        #region IAfiliacionUI Members

        int IAfiliacionUI.IdClub
        {
            get
            {
                return 1;
            }
            set
            {
                Session["IdClub"] = value;
            }
        }

        public int Dni
        {
            get
            {
                return Convert.ToInt32(Session["DNI"]);
            }
            set
            {
                Session["DNI"] =  value;
            }
        }

        public bool Estado
        {
            get;set;
        }

        #endregion            
          
        #region IListadoEstadisticasDni Members

        public List<object> ListarEstadisticas
        {
            set
            {

                if (DgvEstadisticas.Columns.Count > 0)
                    DgvEstadisticas.DataSource = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("PJ");
                dt.Columns.Add("PG");
                dt.Columns.Add("PP");
                dt.Columns.Add("TJ");
                dt.Columns.Add("TC");
                dt.Columns.Add("Puntos");
                foreach (object estadistica in value)
                {
                    object[] estadisticas = estadistica.ToString().Split(',');
                    dt.Rows.Add(estadisticas);
                }
                //}
                DgvEstadisticas.DataSource = dt;
                DgvEstadisticas.DataBind();
            }
        }

        public int DniJugador
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

        #endregion

        #region IListadoEstadisticasCategoria Members


        int IListadoEstadisticasCategoria.IdClub
        {
            get
            {
                return Convert.ToInt32(Session["IdClub"]);
            }
            
        }

        int IListadoEstadisticasCategoria.IdCategoria
        {
            get { return 0; }
        }

        List<Object> IListadoEstadisticasCategoria.ListarEstadisticas
        {
            set
            {

                if (this.DgvEstadisticasCategoria.Columns.Count > 0)
                    DgvEstadisticasCategoria.DataSource = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("Dni");
                dt.Columns.Add("Nombre y Apellido");
                dt.Columns.Add("PJ");
                dt.Columns.Add("PG");
                dt.Columns.Add("PP");
                dt.Columns.Add("TJ");
                dt.Columns.Add("TC");
                dt.Columns.Add("Puntos");
                foreach (object estadistica in value)
                {
                    object[] estadisticas = estadistica.ToString().Split(',');
                    dt.Rows.Add(estadisticas);
                }
                //}
                DgvEstadisticasCategoria.DataSource = dt;
                DgvEstadisticasCategoria.DataBind();
            }
        }

        #endregion
    }
}
