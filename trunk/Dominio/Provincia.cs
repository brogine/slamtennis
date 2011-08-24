using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Provincia
    {
        public Provincia(string NombreProvincia, Pais pais)
        {
            this.Nombre = NombreProvincia; this.Pais = pais;
        }
        public Provincia(int idProvincia, string nombre, bool estado, Pais pais)
        {
            this.IdProvincia = idProvincia; this.Nombre = nombre;
            this.Estado = estado; this.Pais = pais;
        }
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public Pais Pais { get; set; }
    }
}
