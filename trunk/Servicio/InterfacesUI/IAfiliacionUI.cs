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
        bool Estado { get; set; }
    }
}
