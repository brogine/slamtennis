using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    /// <summary>
    /// Partido de un Torneo
    /// </summary>
    public class Partido
    {
        public Partido() 
        { }
        /// <summary>
        /// Constructor para partidos existentes
        /// </summary>
        /// <param name="idPartido">número de identificacion del partido</param>
        /// <param name="torneo">torneo al que pertenece</param>
        /// <param name="inscripciones">jugadores inscriptos</param>
        /// <param name="fecha">fecha cuando se juega</param>
        /// <param name="resultado">resultado del partido</param>
        /// <param name="ronda">ronda del torneo</param>
        /// <param name="arbitros">arbitros que arbitran</param>
        /// <param name="estado">estado del partido</param>
        public Partido(int idPartido, Torneo torneo, Inscripcion Equipo1,Inscripcion Equipo2, DateTime fecha, string resultado,
            int ronda,bool estado)
        {
            this.idPartido = idPartido; this.torneo = torneo; this.equipo1 = Equipo1; this.equipo2 = Equipo2; ; this.fecha = fecha;
            this.resultado = resultado; this.ronda = ronda; this.estado = estado;
        }

        /// <summary>
        /// Constructor para un nuevo partido
        /// </summary>
        /// <param name="torneo">torneo al que pertenece</param>
        /// <param name="inscripciones">jugadores inscriptos</param>
        /// <param name="fecha">fecha cuando se juega</param>
        /// <param name="resultado">resultado del partido</param>
        /// <param name="ronda">ronda del torneo</param>
        /// <param name="arbitros">arbitros que arbitran</param>
        /// <param name="estado">estado del partido</param>
        public Partido(Torneo torneo, Inscripcion Equipo1, Inscripcion Equipo2, DateTime fecha, string resultado,
            int ronda, bool estado)
        {
            this.torneo = torneo; this.equipo1 = Equipo1; this.equipo2 = Equipo2; ; this.fecha = fecha;
            this.resultado = resultado; this.ronda = ronda; this.estado = estado;
        }

        int idPartido;
        Torneo torneo;
        Inscripcion equipo1;
        Inscripcion equipo2;
        DateTime fecha;
        string resultado;
        int ronda;
        bool estado;

        public int IdPartido
        {
            get { return idPartido; }
            set { idPartido = value; }
        }

        public Torneo Torneo
        {
            get { return torneo; }
            set { torneo = value; }
        }
       public  Inscripcion Equipo1
        {
            get { return equipo1; }
            set { equipo1 = value; }
        }

        public Inscripcion Equipo2
        {
            get { return equipo2; }
            set { equipo2 = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public int Ronda
        {
            get { return ronda; }
            set { ronda = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
