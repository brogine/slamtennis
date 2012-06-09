﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlamWeb
{
    public partial class Mensajes : System.Web.UI.Page
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
            Image2.ImageUrl = "~/Profiles/" + Session["Imagen"].ToString().Trim();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                Servicio.IJugadorServicio jugadorSvr = new Servicio.JugadorServicio();
                jugadorSvr.EnviarMensaje(Session["Nombre"].ToString().Trim(), TextBox3.Text);
            //}
            //catch { }
            Response.Redirect("Correcto.aspx");
        }
    }
}
