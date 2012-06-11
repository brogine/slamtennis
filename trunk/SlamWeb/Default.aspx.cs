using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlamWeb
{
    public partial class Default : System.Web.UI.Page
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
            if (Session["Imagen"] != null)
            {
                Image1.ImageUrl = "~/Profiles/" + Session["Imagen"].ToString().Trim();
            }
            else
            {
                Image1.ImageUrl = "~/Content/Alert_32x32-32.png";
                Session["Imagen"] = "~/Content/Alert_32x32-32.png";
            }
        }

        protected void Estadisticos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Estadisticos.aspx");
        }

        protected void Historicos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Historicos.aspx");
        }

        protected void Consultas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        protected void Torneos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Torneos.aspx");
        }

        protected void Llaves_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Llaves.aspx");
        }

        protected void Mensajes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Mensajes.aspx");
        }

        protected void Cerrar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Sesion.aspx");
        }

    }
}
