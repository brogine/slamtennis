using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IPuntosUI
    {
        int IdTorneo { get; }
        int PrimeraRonda { get; set; }
        int SegundaRonda { get; set; }
        
        int CuartosFinal { get; set; }
        int SemiFinal { get; set; }
        int Final { get; set; }
        int Cupo { get; set; }

        int Campeon { get; set; }
    }
}
