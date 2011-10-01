using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    interface IListadoPartidoServicio
    {
        void ListarPartidos(IListadoPartidos UI);
    }
}
