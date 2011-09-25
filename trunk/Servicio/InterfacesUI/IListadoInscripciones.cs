using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IListadoInscripciones
    {
        List<Object> ListarPorTorneo { set; }
        List<Object> ListarPorPartido { set; }
        int IdTorneo { get; }
        int IdPartido { get; }
    }
}
