using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Provincia
    {
        public Provincia(string NombreProvincia, int IdPais)
        {
            this.Nombre = NombreProvincia; this.Pais = new Pais(IdPais);
        }
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public Pais Pais { get; set; }
    }
}
