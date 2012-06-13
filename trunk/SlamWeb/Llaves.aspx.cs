﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio.InterfacesUI;
using Servicio;
using Reportes;

namespace SlamWeb
{
    public partial class Llaves : System.Web.UI.Page, IListadoTorneos
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsPostBack != true)
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
                    IListadoTorneoServicio servicioTorneos = new TorneoServicio();
                    servicioTorneos.ListarCerrados(this);
                }
                else
                {
                    if (Session["ReporteLlave"] != null)
                    {
                        ReportViewerLlave.ReportSource = Session["ReporteLlave"];
                        ReportViewerLlave.RefreshReport();
                    }
                }
            }
            catch { }
        }

        #region IListadoTorneos Members

        public List<object> ListaUI
        {
            set 
            {
                if (value.Count > 0)
                {
                    Dictionary<int, string> ListaTorneos = new Dictionary<int, string>();
                    ListaTorneos.Add(0, "Seleccione");
                    foreach (Object Torneo in value)
                    {
                        Object[] DatosTorneo = Torneo.ToString().Split(',');
                        ListaTorneos.Add(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[2].ToString());
                    }
                    CboTorneos.DataSource = ListaTorneos;
                    CboTorneos.DataTextField = "Value";
                    CboTorneos.DataValueField = "Key";
                    CboTorneos.DataBind();
                    CboTorneos.SelectedIndex = -1;

                }
                else 
                {
                    Response.Redirect("Redirect.aspx");
                }
            }
        }

        #endregion

        protected void CboTorneos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CboTorneos.SelectedIndex != 0)
                {
                    IReportesServicio servicioReportes = new ReportesServicio();
                    Object ReporteLlave = servicioReportes.CrearInstancia(ListadoReportes.Llave, Convert.ToInt32(CboTorneos.SelectedValue));
                    if (ReporteLlave != null)
                    {
                        Session["ReporteLlave"] = ReporteLlave;
                        ReportViewerLlave.Visible = true;
                        ReportViewerLlave.ReportSource = ReporteLlave;
                        ReportViewerLlave.RefreshReport();
                    }
                }
                else
                {
                    ReportViewerLlave.Visible = false;
                }
            }
            catch { }
        }
    }
}
