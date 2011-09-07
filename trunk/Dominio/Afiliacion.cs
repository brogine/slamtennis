using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Afiliacion
    {
        public Afiliacion()
        { }
        public Afiliacion(Club club, Jugador jugador, DateTime FechaAlta, bool Estado)
        {
            this.Club = club;
            this.Jugador = jugador;
            this.FechaAlta = FechaAlta;
            this.Estado = Estado;
        }
     public   Club Club { get; set; }
     public   Jugador Jugador { get; set; }
     public   DateTime FechaAlta { get; set; }
     public   DateTime FechaBaja { get; set; }
     public   bool Estado { get; set; }

    }
}
