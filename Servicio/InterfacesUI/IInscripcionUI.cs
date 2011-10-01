using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IInscripcionUI
    {
        int IdInscripcion { get; set; }
        int IdTorneo { get; set; }
        DateTime Fecha { get; set; }
        int DniJugador1 { get; set; }
        int DniJugador2 { get; set; }
        bool ModificarJugador { get; }
    }
}
