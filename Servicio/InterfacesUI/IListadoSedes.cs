using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IListadoSedes
    {
        int IdClub { get; }

        List<Object> ListarSedes { set; }
    }
}
