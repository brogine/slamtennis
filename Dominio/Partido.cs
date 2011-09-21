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
        public Partido(int idPartido, Torneo torneo, List<Inscripcion> inscripciones, DateTime fecha, string resultado,
            int ronda, List<Arbitro> arbitros, bool estado)
        {
            this.idPartido = idPartido; this.torneo = torneo; this.inscripciones = inscripciones; this.fecha = fecha;
            this.resultado = resultado; this.ronda = ronda; this.arbitros = arbitros; this.estado = estado;
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
        public Partido(Torneo torneo, List<Inscripcion> inscripciones, DateTime fecha, string resultado,
            int ronda, List<Arbitro> arbitros, bool estado)
        {
            this.torneo = torneo; this.inscripciones = inscripciones; this.fecha = fecha;
            this.resultado = resultado; this.ronda = ronda; this.arbitros = arbitros; this.estado = estado;
        }

        int idPartido;
        Torneo torneo;
        List<Inscripcion> inscripciones;
        DateTime fecha;
        string resultado;
        int ronda;
        List<Arbitro> arbitros;
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

        public List<Inscripcion> Inscripciones
        {
            get { return inscripciones; }
            set { inscripciones = value; }
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

        public List<Arbitro> Arbitros
        {
            get { return arbitros; }
            set { arbitros = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
