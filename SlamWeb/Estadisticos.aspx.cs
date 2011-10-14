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
    public partial class Estadisticos : System.Web.UI.Page, IListadoEstadisticasCategoria, IListadoClubes, IListadoCategorias
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
            IListadoEstadisticasServicio servicioEstadisticas = new EstadisticasServicio();
            IListadoClubServicio servicioClubes = new ClubServicio();
            servicioClubes.ListarActivos(this);
            IListadoCategoriaServicio servicioCategorias = new CategoriaServicio();
            servicioCategorias.ListarActivas(this);
           

        }

        #region IListadoEstadisticasCategoria Members

        public List<object> ListarEstadisticas
        {
            set { throw new NotImplementedException(); }
        }

        public int IdClub
        {
            get { throw new NotImplementedException(); }
        }

        public int IdCategoria
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IListadoClubes Members

        public List<object> ListarClubes
        {
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region IListadoCategorias Members

        public List<object> ListaUI
        {
            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}
