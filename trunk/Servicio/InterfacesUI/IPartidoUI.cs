using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    interface IPartidoUI
    {
        int IdPartido { get; set; }
        int IdEquipo1 { get; set; }
        int IdEquipo2 { get; set; }
        int Ronda { get; set; }
        int IdTorneo { get; set;}
        string Resultado { get; set; }
        DateTime Fecha { get; set; }
        bool Estado { get; set; }
    }
}
