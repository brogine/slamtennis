using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
   public interface ITorneoUI
    {
       int IdTorneo { get; set; }
       string Nombre { get; set;}
       DateTime FechaInicio { get; set; }
       DateTime FechaFin { get; set; }
       DateTime FechaFinInscripcion { get; set; }
       DateTime FechaInicioInscripcion { get; set; }
       int Cupo { get; set; }
       string Sexo { get; set; }
       int Tipo { get; set; }
       int IdClub { get; set; }
       int IdCategoria { get; set; }
       bool TipoInscripcion { get; set; }
       int Superficie { get; set; }
       int Estado { get; set; }

    }
}
