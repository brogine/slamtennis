using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface ITorneoInicioUI
    {
        int IdTorneo { set; }
        string Nombre { set; }
        string Categoria { set; }
    }
}
