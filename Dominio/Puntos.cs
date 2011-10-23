using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
  public class Puntos
    {
      public Puntos(int IdTorneo, string Ronda, int Puntos)
      {
          this.cantidadpuntos = Puntos;
          this.ronda = Ronda;
          this.idtorneo = IdTorneo;
      
      }
      public Puntos()
      {}
        string ronda;
        int cantidadpuntos;
        int idtorneo;


       public int IdTorneo
        {
            get { return idtorneo; }
            set { idtorneo = value; }
        }
       public string Ronda
        {
            get { return ronda; }
            set { ronda = value; }
        }

       public int CantidadPuntos 
        {
            get { return cantidadpuntos; }
            set { cantidadpuntos = value; } 
        }
    }
}
