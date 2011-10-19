using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    /// <summary>
    /// Objeto Afiliacion de Jugador a un Club
    /// </summary>
    public class Afiliacion
    {
        /// <summary>
        /// Constructor de Afiliacion vacío
        /// </summary>
        public Afiliacion()
        { }

        /// <summary>
        /// Constructor de Afiliación con parámetros
        /// </summary>
        /// <param name="club">Club al que pertenece</param>
        /// <param name="jugador">Jugador que se afilia</param>
        /// <param name="FechaAlta">Fecha en que se afilia</param>
        /// <param name="Estado">Estado de la afiliación</param>
        public Afiliacion(Club club, Jugador jugador, DateTime FechaAlta, bool Estado)
        {
            this.club = club;
            this.jugador = jugador;
            this.fechaAlta = FechaAlta;
            this.estado = Estado;
        }

        Club club;
        Jugador jugador;
        DateTime fechaAlta;
        DateTime fechaBaja;
        bool estado;

        public Club Club
        {
            get { return club; }
            set { club = value; }
        }

        public Jugador Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }

        public DateTime FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        public DateTime FechaBaja
        {
            get { return fechaBaja; }
            set { fechaBaja = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

    }
}
