using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;


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
        Image foto;
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

        public Image Foto
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

        public Image CopiarFoto(string RutaOrigen)
        {
            Bitmap mapabit;
            Image imagen;
            if (File.Exists(RutaOrigen))
            {
                FileInfo info = new FileInfo(RutaOrigen);
                string extenc = info.Name.Replace(info.Extension, "");
                mapabit = new Bitmap(RutaOrigen);
                Size size = mapabit.Size;
                double ratio = size.Height / size.Width;
                imagen = mapabit.GetThumbnailImage(254, 205, null, IntPtr.Zero);
                return imagen;
            }
            else
            {
                return null;
            }
        }
    }
}
