using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Localidad
    {
        public Localidad(Provincia provincia, string nombreLocalidad)
        {
            this.Provincia = provincia; this.Nombre = nombreLocalidad;
        }
        public Localidad(int idLocalidad, string nombre, bool estado, Provincia provincia)
        {
            this.IdLocalidad = idLocalidad; this.Nombre = nombre;
            this.Estado = estado; this.Provincia = provincia;
        }
        public int IdLocalidad { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public Provincia Provincia { get; set; }
    }
}
