using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Servicio.InterfacesUI
{
    public interface IListadoJugadoresCategoria
    {
        DataTable Listar { set; }

        int IdCategoria { get; }
    }
}
