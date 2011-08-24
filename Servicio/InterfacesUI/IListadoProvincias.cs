using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
    public interface IListadoProvincias
    {
        Dictionary<int, string> ListarProvincias { set; }
        int Pais { get; }
    }
}
