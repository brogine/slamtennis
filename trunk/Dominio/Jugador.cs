using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dominio
{
    public class Jugador : Persona
    {
        #region Constructores
        public Jugador() { }

        /// <summary>
        /// Constructor para un Jugador mayor de edad sin historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        /// <param name="contacto"></param>
        /// <param name="ubicacion"></param>
        /// <param name="foto"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac, 
            Pais nacionalidad, string sexo, Contacto contacto, Ubicacion ubicacion, bool estado, Login login, Image foto)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido;
            this.FechaNac = fechaNac; this.Nacionalidad = nacionalidad; this.Login = login;
            this.Sexo = sexo; this.Contacto = contacto; this.Ubicacion = ubicacion; this.estado = estado;
            if (foto != null)
                this.Foto = ImagenABytes(foto);
        }

        /// <summary>
        /// Constructor para un Jugador mayor con historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        /// <param name="Estadisticas"></param>
        /// <param name="contacto"></param>
        /// <param name="ubicacion"></param>
        /// <param name="foto"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac,
            Pais nacionalidad, string sexo, List<Estadisticas> Estadisticas, 
            Contacto contacto, Ubicacion ubicacion, bool estado, Login login, Image foto)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido;
            this.FechaNac = fechaNac; this.Nacionalidad = nacionalidad; this.Login = login;
            this.Sexo = sexo; this.Contacto = contacto; this.Ubicacion = ubicacion;
            this.estadisticas = Estadisticas; this.estado = estado;
            if (foto != null)
                this.Foto = ImagenABytes(foto);
        }

        /// <summary>
        /// Constructor para un Jugador menor de edad sin historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        /// <param name="dniTutor"></param>
        /// <param name="relacionTutor"></param>
        /// <param name="contacto"></param>
        /// <param name="ubicacion"></param>
        /// <param name="foto"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac,
            Pais nacionalidad, string sexo, string Tutor, string relacionTutor,
            Contacto contacto, Ubicacion ubicacion, bool estado, Login login, Image foto)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido;
            this.FechaNac = fechaNac; this.Nacionalidad = nacionalidad; this.Login = login;
            this.Sexo = sexo; this.Contacto = contacto; this.Ubicacion = ubicacion;
            this.tutor = Tutor; this.relacionTutor = relacionTutor; this.estado = estado;
            if (foto != null)
                this.Foto = ImagenABytes(foto);
        }

        /// <summary>
        /// Constructor para un Jugador menor de edad con historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        /// <param name="dniTutor"></param>
        /// <param name="relacionTutor"></param>
        /// <param name="Estadisticas"></param>
        /// <param name="contacto"></param>
        /// <param name="ubicacion"></param>
        /// <param name="foto"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac,
            Pais nacionalidad, string sexo, string Tutor, string relacionTutor,
            List<Estadisticas> Estadisticas, Contacto contacto, Ubicacion ubicacion, bool estado, Login login, Image foto)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido;
            this.FechaNac = fechaNac; this.Nacionalidad = nacionalidad;
            this.Sexo = sexo; this.Contacto = contacto; this.Ubicacion = ubicacion;
            this.tutor = Tutor; this.relacionTutor = relacionTutor;
            this.estadisticas = Estadisticas; this.estado = estado; this.Login = login;
            if (foto != null)
                this.Foto = ImagenABytes(foto);
        }
        #endregion

        string tutor;
        string relacionTutor;
        List<Estadisticas> estadisticas;
        bool estado;

        public string Tutor
        {
            get { return tutor; }
            set { tutor = value; }
        }

        public string RelacionTutor
        {
            get { return relacionTutor; }
            set { relacionTutor = value; }
        }

        public List<Estadisticas> Estadisticas
        {
            get { return estadisticas; }
            set { estadisticas = value; }
        }
        
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        
    }
}
