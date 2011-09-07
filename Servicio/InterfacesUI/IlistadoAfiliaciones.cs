using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IlistadoAfiliaciones
    {
        List<Object> ListaAfiliaciones { set; }
        int IdClub { get; }
    }
}
