using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Repositorio
{
   public interface IPuntosRepositorio
    {
       
       void Agregar(List<Puntos> Puntos);

       void Modificar(List<Puntos> Puntos);

        List<Puntos> ListarPuntos(int IdTorneo);
    }
}
