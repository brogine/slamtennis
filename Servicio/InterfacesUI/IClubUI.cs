using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IClubUI
    {
        int IdClub { get; set; }

        int DniPresidente { get; set; }

        string NombrePresidente { set; }

        string NombreClub { get; set; }

        bool Estado { get; set; }
    }
}
