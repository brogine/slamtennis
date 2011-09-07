using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IAfiliacionUI
    {
        int IdClub { get; set; }
        int Dni { get; set; }
        string NombreJugador { get; set; }
        string NombreClub { get; set; }
        DateTime FechaAlta { get; set; }
        DateTime FechaBaja { get; set; }
        bool Estado { get; set; }
    }
}
