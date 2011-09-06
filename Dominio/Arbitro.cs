using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Arbitro : Persona
    {
       public string Badge { get; set; }
       public int Nivel { get; set; }
       public int NumeroInscripcion { get; set; }
       public bool Estado { get; set; }
    }
}
