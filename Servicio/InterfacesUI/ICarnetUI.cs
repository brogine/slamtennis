using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dominio;

namespace Servicio.InterfacesUI
{
    public interface ICarnetUI
    {
        DataTable TablaDatos { set; }
        int DniCarnet { get; }
        Tipo TipoPersona { get; }
    }
}
