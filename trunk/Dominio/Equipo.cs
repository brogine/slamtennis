using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Equipo
    {
        public Equipo() { }
        public Equipo(Jugador jugador1, Jugador jugador2)
        {
            this.jugador2 = jugador2; this.jugador1 = jugador1;
        }

        Jugador jugador1;

        Jugador jugador2;

        public Jugador Jugador1
        {
            get { return jugador1; }
            set { jugador1 = value; }
        }

        public Jugador Jugador2
        {
            get { return jugador2; }
            set { jugador2 = value; }
        }
    }
}
