using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ServidorSMTP
    {
        public string Nombre { get; set; }
        public string Host { get; set; }
        public int Puerto { get; set; }
        public bool RequiereAutenticacion { get; set; }

    }
}
