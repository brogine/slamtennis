using System;
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
    public partial class Torneos : System.Web.UI.Page, IListadoTorneos,IInscripcionUI
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
                TorneoServicio.Actualizar();
                TorneoServicio.Listar(this);
                TxtDNI1.Text = Session["DNI"].ToString().Trim();
                LblFecha.Text = DateTime.Now.ToShortDateString();
                IInscripcionServicio incripservice = new InscripcionServicio();
                LblInscripcion.Text = Convert.ToString(incripservice.UltimaInscripcion() + 1);
            }
            else
            {
                string parametro1 = Request.Params[0].ToString();
                if (parametro1 == string.Empty)
                {
                    return;
                }
                int index = parametro1.IndexOf("=");
                string parametro2 = parametro1.Substring(0, index);
                switch (parametro2)
                {
                    case "Torneo":
                        int valor = Convert.ToInt32(parametro1.Substring((index + 1), parametro1.Length - (index + 1)));
                        TxtIDTorneo.Text = valor.ToString();
                        try
                        {
                            int IdInscripcionActual = Convert.ToInt32(LblInscripcion.Text);
                            IInscripcionServicio servicioInscripciones = new InscripcionServicio();
                            IdInscripcionActual = servicioInscripciones.Agregar(this);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            ClientScriptManager manager = Page.ClientScript;
                            manager.RegisterStartupScript(this.GetType(), "Alerta", "<script language='javascript' type='text/javascript'>ImprimirReporte();</script>");

                        }
                        catch (Exception ex)
                        {
                            ClientScriptManager manager = Page.ClientScript;
                            manager.RegisterStartupScript(this.GetType(), "Alerta", "<script type='text/javascript'>window.alert('Error " + ex.Message + "');</script>");
                        }
                        break;
                    case "Imprimir":
                        bool imprime = Convert.ToBoolean(parametro1.Substring((index + 1), parametro1.Length - (index + 1)));
                        if (imprime)
                        {
                            Session["NroIncripcion"] = Convert.ToInt32(LblInscripcion.Text);
                            ClientScriptManager manager = Page.ClientScript;
                            manager.RegisterStartupScript(this.GetType(), "Alerta", "<script type='text/javascript'>openpopup();</script>");
                        }
                        break;
                    case "Borrar":
                        string[] borra = parametro1.Substring((index + 1), parametro1.Length - (index + 1)).Split(',');
                        if (Convert.ToBoolean(borra[0]))
                        {
                            int idtorneo = Convert.ToInt32(borra[1]);
                            Servicio.IInscripcionServicio servicioInscripciones = new Servicio.InscripcionServicio();
                            servicioInscripciones.Eliminar(Convert.ToInt32(Session["DNI"]), idtorneo);
                            System.Threading.Thread.Sleep(3000);
                            ClientScriptManager manager = Page.ClientScript;
                            manager.RegisterStartupScript(this.GetType(), "Alerta", "<script type='text/javascript'>Mensaje();</script>");
                         
                        }
                        break;
                }

            }
        }

        #region IListadoTorneos Members

        public List<object> ListaUI
        {
            set 
            {
                if (value.Count != 0)
                {
                    Session["Torneos"] = value;
                }
                else
                {
                    Response.Redirect("Redirect.aspx");
                }
            }
        }

        #endregion

        #region IInscripcionUI Members

        public int IdInscripcion
        {
            get;
            set;
        }

        public int IdTorneo
        {
            get
            {
                return Convert.ToInt32(TxtIDTorneo.Text);
            }
            set
            {
                TxtIDTorneo.Text = value.ToString();
            }
        }

        public DateTime Fecha
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                LblFecha.Text = value.ToShortDateString();
            }
        }

        public int DniJugador1
        {
            get
            {
                return Convert.ToInt32(TxtDNI1.Text);
            }
            set
            {
                TxtDNI1.Text = value.ToString();
            }
        }

        public int DniJugador2
        {
            get
            {
                int dni2 = 0;
                if (TxtDNI2.Text != string.Empty)
                {
                    dni2 = Convert.ToInt32(TxtDNI2.Text);
                }
                return dni2;
            }
            set
            {
                TxtDNI2.Text = value.ToString();
            }
        }

        public bool ModificarJugador
        {
            get { return false; }
        }

        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

     
    }
}
