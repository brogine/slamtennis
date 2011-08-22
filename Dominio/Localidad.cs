using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Localidad
    {
        int IdLocalidad { get; set; }
        string Nombre { get; set; }
        bool Estado { get; set; }
        Provincia Provincia { get; set; }

    }
}
