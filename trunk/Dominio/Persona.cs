using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Dominio
{
    public enum Tipo
    {
        Afiliado, Empleado, Arbitro
    }

    public abstract class Persona
    {
        #region Variables Privadas
        int dni;
        string nombre;
        string apellido;
        DateTime fechaNac;
        Pais nacionalidad;
        string sexo;
        string foto;
        #endregion

        #region Variables Públicas
        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public Pais Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public int Edad
        {
            get
            {
                int Edad = DateTime.Today.Year - this.FechaNac.Year;
                if (new DateTime(DateTime.Today.Year, this.FechaNac.Month, this.FechaNac.Day) > DateTime.Today)
                    Edad--;
                return Edad;
            }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        #endregion

        #region Value Objects
        Ubicacion ubicacion;
        Contacto contacto;
        Login login;

        public Ubicacion Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public Contacto Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public Login Login
        {
            get { return login; }
            set { login = value; }
        }
        #endregion

        public string CopiarFoto(string RutaOrigen,int Dni)
        { 
            if(!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory+@"Imagenes\"))
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory+@"Imagenes\");
            string extension = RutaOrigen.Substring(RutaOrigen.LastIndexOf('.'), RutaOrigen.Length - RutaOrigen.LastIndexOf('.'));
            string Destino = System.AppDomain.CurrentDomain.BaseDirectory+@"Imagenes\"+Dni.ToString()+extension;
            
            System.IO.File.Copy(RutaOrigen, Destino,true);
            return @"Imagenes\" + Dni.ToString() + extension;
        }
    }
}
