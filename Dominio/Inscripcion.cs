using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    /// <summary>
    /// Inscripcion  de un jugador a un partido de un torneo
    /// </summary>
    public class Inscripcion
    {
        /// <summary>
        /// Constructor para Inscripciones existentes
        /// </summary>
        /// <param name="idInscripcion">número de identificacion de la inscripcion</param>
        /// <param name="torneo">torneo al que se inscribe</param>
        /// <param name="fecha">fecha de inscripcion</param>
        /// <param name="jugadores">jugadores vinculados</param>
        public Inscripcion(int idInscripcion, Torneo torneo, DateTime fecha, Equipo equipo)
        {
            this.idInscripcion = idInscripcion; this.torneo = torneo; this.fecha = fecha;
            this.equipo = equipo;
        }

        /// <summary>
        /// Constructor para una nueva Inscripcion
        /// </summary>
        /// <param name="torneo">torneo al que se inscribe</param>
        /// <param name="fecha">fecha de inscripcion</param>
        /// <param name="jugadores">jugadores vinculados</param>
        public Inscripcion(Torneo torneo, DateTime fecha, Equipo equipo)
        {
            this.torneo = torneo; this.fecha = fecha;
            this.equipo = equipo;
        }




        int idInscripcion;
        Torneo torneo;
        DateTime fecha;
        Equipo equipo;

        public int IdInscripcion
        {
            get { return idInscripcion; }
            set { idInscripcion = value; }
        }

        public Torneo Torneo
        {
            get { return torneo; }
            set { torneo = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Equipo Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

    }
}
