using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
    public interface IListadoLocalidades
    {
        List<String> ListarLocalidades { set; }

        string Pais { get; }

        string Provincia { get; }
    }
}
