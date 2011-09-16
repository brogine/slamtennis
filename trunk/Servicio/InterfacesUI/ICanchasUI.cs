using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface ICanchasUI
    {
        int IdCancha { get; }
        int IdSede { get; }
        int TipoCancha { get; set; }
        int Superficie { get; set; }
        bool Luz { get; set; }
        int Cantidad { get; set; }
    }
}
