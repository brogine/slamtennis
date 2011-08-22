using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    interface IMapeador<T>
    {
        T Mapear(System.Data.DataRow Fila);
    }
}
