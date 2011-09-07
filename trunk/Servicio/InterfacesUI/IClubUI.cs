using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IClubUI
    {
        int IdClub { get; set; }

        string NombrePresidente { get; set; }

        string NombreClub { get; set; }

        bool Estado { get; set; }
    }
}
