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
    public partial class Login : System.Web.UI.Page, ILoginUI, IJugadorUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region ILoginUI Members

        public string Usuario
        {
            get { return Login1.UserName; }
        }

        public string Password
        {
            get { return Login1.Password; }
        }

        public bool Estado
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            ILoginServicio LoginServicio = new LoginServicio();
            this.Dni = LoginServicio.Validar(this);
            if (this.Dni == 0)
            {
                Login1.FailureText = "Su Nombre de usuario o clave no es valido, Verifique...";
            }
            else
            {
                IJugadorServicio jugador = new JugadorServicio();
                jugador.Buscar(this);
                Response.Redirect("Default.aspx");
            }
        }

        #region IJugadorUI Members

        public int Dni
        {
            get { return 0; }
            set
            {
                Session["Dni"] = value;
            }
        }

        public string Nombre
        {
            get { return null; }
            set
            {
                Session["Nombre"] = value;
            }
        }

        public string Apellido
        {
            get { return null; }
            set
            {
                Session["Apellido"] = value;
            }
        }

        public DateTime FechaNac
        {
            get { return DateTime.Now; }
            set
            {
                Session["FechaNac"] = value;
            }
        }

        public int Nacionalidad
        {
            get { return 0; }
            set
            {
                Session["Nacionalidad"] = value;
            }
        }

        public string Sexo
        {
            get { return null; }
            set
            {
                Session["Sexo"] = value;
            }
        }

        public string Tutor
        {
            get;
            set;
        }

        public int Edad
        {
            get;
            set;
        }

        public string RelacionTutor
        {
            get;
            set;
        }

        public string Telefono
        {
            get { return null; }
            set
            {
                Session["Sexo"] = value;
            }
        }

        public string Celular
        {
            get { return null; }
            set
            {
                Session["Sexo"] = value;
            }
        }

        public string Email
        {
            get { return null; }
            set
            {
                Session["Sexo"] = value;
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
            get { return null; }
            set
            {
                Session["Sexo"] = value;
            }
        }

        string IJugadorUI.Usuario
        {
            get;
            set;
        }

        string IJugadorUI.Password
        {
            get;
            set;
        }

        System.Drawing.Image IJugadorUI.Foto
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

       
    }
}
