using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Arbitro : Persona
    {
        public Arbitro()
        { }
        public Arbitro(int dni, string nombre, string apellido, DateTime fechaNac,
            Pais nacionalidad, string sexo, Contacto contacto, Ubicacion ubicacion, string badge, int nivel, int inscripcion, bool estado)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido;
            this.FechaNac = FechaNac; this.Nacionalidad = nacionalidad;
            this.Sexo = sexo; this.Contacto = contacto; this.Ubicacion = ubicacion;
            this.Badge = badge;
            this.Nivel = nivel;
            this.NumeroInscripcion = inscripcion;
            this.Estado = estado;
            

        }

       public string Badge { get; set; }
       public int Nivel { get; set; }
       public int NumeroInscripcion { get; set; }
       public bool Estado { get; set; }
    }
}
