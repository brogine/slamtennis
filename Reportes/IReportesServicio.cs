using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reportes
{
    public interface IReportesServicio
    {
        object CrearInstancia(string NombreReporte, object Sender);

        void Parametros(string[] NombresParametros, object[] ValorParametros);
    }
}
