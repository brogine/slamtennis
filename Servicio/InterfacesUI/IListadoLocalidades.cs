using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
    public interface IListadoLocalidades
    {
        List<Object> ListarLocalidades { set; }

        int Pais { get; }

        int Provincia { get; }
    }
}
