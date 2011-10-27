using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio.InterfacesUI;
using Servicio;

namespace SlamWeb
{
    public partial class Torneos : System.Web.UI.Page, IListadoTorneos
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
                IListadoTorneoServicio TorneoServicio = new TorneoServicio();
                TorneoServicio.ActualizarTorneos();
                TorneoServicio.ListarTorneos(this);
            }
        }

        #region IListadoTorneos Members

        public List<object> ListaUI
        {
            set 
            { 
                Session["Torneos"] = value; 
            }
        }

        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((LinkButton)sender).ID);
            object item = (Session["Torneos"] as List<object>)[index];
            string[] array = item.ToString().Split(',');
            TxtDNI1.Text = Session["DNI"].ToString();
            TxtTorneo.Text = array[2].ToString();
            LblFecha.Text = DateTime.Now.ToShortDateString();
            Response.Write("<script>alert('Puto'); </script>");
        }
    }
}
