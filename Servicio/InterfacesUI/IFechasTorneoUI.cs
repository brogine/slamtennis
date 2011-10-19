using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public class IFechasTorneoUI
    {
        int IdTorneo { get; }
        string Nombre { set; }
        DateTime FechaInicio { set; }
        DateTime FechaFin { set; }
        DateTime FechaFinInscripcion { set; }
        DateTime FechaInicioInscripcion { set; }
        int Estado { set; }
    }
}
