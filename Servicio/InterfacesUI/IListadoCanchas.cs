using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IListadoCanchas
    {
        int IdSede { get; }
        List<Object> ListaCanchas { set; }
    }
}
