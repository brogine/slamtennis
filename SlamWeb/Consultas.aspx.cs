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
            try
            {
                if (!Convert.ToBoolean(Session["Logeado"]))
                {
                    Response.Redirect("Login.aspx");
                }
                LblEmail.Text = Session["Email"].ToString().Trim();
                LblDNI.Text = Session["DNI"].ToString();
                LblSexo.Text = Session["Sexo"].ToString().Trim();
                if (Session["Imagen"] != null)
                {
                    Image2.ImageUrl = "~/Profiles/" + Session["Imagen"].ToString().Trim();
                }
                else
                {
                    Image2.ImageUrl = "~/Content/Alert_32x32-32.png";
                }
                IPaisServicio servicioPaises = new UbicacionServicio();
                servicioPaises.ListarPaises(this);
                //IProvinciaServicio servicioProv = new UbicacionServicio();
                //servicioProv.ListarProvincias(this);
                IJugadorServicio jugador = new JugadorServicio();
                jugador.Buscar(this);
            }
            catch { }
           
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
                LblFechaNac.Text = value.ToString("dd/MM/yyyy");
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
                foreach (var item in (List<object>)Session["ListadoPais"])
                {
                    string[] pais = item.ToString().Split(',');
                    if (pais[0] == value.ToString())
                    {
                        LblNaciona.Text = pais[1];
                        break;
                    }
                }
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
                return LblEmail.Text;
            }
            set
            {
                LblEmail.Text = value;
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
            get
            {
                return Convert.ToInt32(Session["IdProvincia"]);
            }
            set
            {
                Session["IdProvincia"] = value;
            }
        }

        public int Localidad
        {
            get
            {
                return 0;
            }
            set
            {

                ILocalidadServicio servicioLocalidades = new UbicacionServicio();
                IProvinciaServicio servicioProvincias = new UbicacionServicio();
                string[] ids = servicioLocalidades.ObtenerUbicacion(value).Split(',');
                foreach (string elemento in (List<object>)Session["ListadoPais"])
                {
                    string[] item = elemento.Split(',');
                    if (item[0] == ids[0])
                    {
                        servicioProvincias.ListarProvincias(this);
                        break;
                    }
                }

                foreach (string elemento in (List<object>)Session["ListadoProvincia"])
                {
                    string[] item = elemento.Split(',');
                    if (item[0] == ids[1])
                    {
                        LblProvincia.Text = item[1];
                        break;
                    }
                }                
            }
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
