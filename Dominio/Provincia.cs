using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Provincia
    {
        int IdProvincia { get; set; }
        string Nombre { get; set; }
        bool Estado { get; set; }
        Pais Pais { get; set; }
    }
}
