using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Servicio
{
    public interface IInscripcionReporteServicio
    {
        DataTable BuscarPorId(int IdInscripcion);
    }
}
