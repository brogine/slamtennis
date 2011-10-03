using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
   public interface IListadoPartidos
    {
        List<Object> ListarPartidos { set; }
        int IdTorneo { get; }
    }
}
