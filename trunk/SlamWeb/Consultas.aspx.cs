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
    public partial class Consultas : System.Web.UI.Page, IJugadorUI,IListadoPaises,IListadoProvincias
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["Logeado"]))
            {
                Response.Redirect("Login.aspx");
            }
            LblEmail.Text = Session["Email"].ToString().Trim();
            LblDNI.Text = Session["DNI"].ToString();
            LblSexo.Text = Session["Sexo"].ToString().Trim();
            Image2.ImageUrl = "~/Profiles/" + Session["Imagen"].ToString().Trim();
            IPaisServicio servicioPaises = new UbicacionServicio();
            servicioPaises.ListarPaises(this);
            IJugadorServicio jugador = new JugadorServicio();
            jugador.Buscar(this);
        }

        #region IJugadorUI Members

        public int Dni
        {
            get
            {
                return Convert.ToInt32(LblDNI.Text);
            }
            set
            {
                LblDNI.Text = value.ToString();
            }
        }

        public string Nombre
        {
            get
            {
                return LblNombre2.Text;
            }
            set
            {
                LblNombre2.Text = value;
            }
        }

        public string Apellido
        {
            get
            {
                return LblApellido.Text;
            }
            set
            {
                LblApellido.Text = value;
            }
        }

        public DateTime FechaNac
        {
            get
            {
                return Convert.ToDateTime(LblFechaNac.Text);
            }
            set
            {
                LblFechaNac.Text = value.ToString();
            }
        }

        public int Nacionalidad
        {
            get
            {
                return 0;
            }
            set
            {
                //int index = value;
                //LblNaciona.Text = ((List<object>)Session["ListadoPais"]).ToString().Split(',')[index].ToString();            
            }
        }

        public string Sexo
        {
            get
            {
                return LblSexo.Text;
            }
            set
            {
                LblSexo.Text = value;
            }
        }

        public string Tutor
        {
            get;
            set;
        }

        public int Edad
        {
            get
            {
                return Convert.ToInt32(LblEdad.Text);
            }
            set
            {
                LblEdad.Text = value.ToString();
            }
        }

        public string RelacionTutor
        {
            get;
            set;
        }

        public string Telefono
        {
            get
            {
                return LblTelefono.Text;
            }
            set
            {
                LblTelefono.Text = value;
            }
        }

        public string Celular
        {
            get
            {
                return LblCelular.Text;
            }
            set
            {
                LblCelular.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return LblCelular.Text;
            }
            set
            {
                LblCelular.Text = value;
            }
        }

        public int Pais
        {
            get
            {
                return Convert.ToInt32(Session["IdPais"]);
            }
            set
            {
                Session["IdPais"] = value;
            }
        }

        public int Provincia
        {
            get;
            set;
        }

        public int Localidad
        {
            get;
            set;
        }

        public string Domicilio
        {
            get
            {
                return LblDomicilio.Text;
            }
            set
            {
                LblDomicilio.Text = value;
            }
        }

        public string Usuario
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool Estado
        {
            get;
            set;
        }

        public System.Drawing.Image Foto
        {
            get;
            set;
        }

        #endregion

        #region IListadoPaises Members

        public List<object> ListarPaises
        {
            set { Session["ListadoPais"] = value; }
        }

        #endregion

        #region IListadoProvincias Members

        public List<object> ListarProvincias
        {
            set { Session["ListadoProvincia"] = value; }
        }

        #endregion
    }
}
