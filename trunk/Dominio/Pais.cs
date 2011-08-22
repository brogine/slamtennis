using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
   public class Pais
    {
       public Pais(int IdPais)
       {
           this.IdPais = IdPais;
       }
       public Pais(string NombrePais)
       {
           this.Nombre = NombrePais;
       }
       public Pais(int IdPais, string NombrePais, bool Estado)
       {
           this.IdPais = IdPais;
           this.Nombre = NombrePais;
           this.Estado = Estado;
       }
       public int IdPais { get; set; }
       public string Nombre { get; set; }
       public bool Estado { get; set; }
    }
}
