using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IFechasTorneoUI
    {
        int IdTorneo { get; set; }
        string Nombre { get; set; }
        DateTime FechaInicio { get; set; }
        DateTime FechaFin { get; set; }
        DateTime FechaFinInscripcion { get; set; }
        DateTime FechaInicioInscripcion { get; set; }
        int Estado { get; set; }
    }
}
