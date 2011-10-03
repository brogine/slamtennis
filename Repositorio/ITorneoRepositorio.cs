using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
   public interface ITorneoRepositorio
    {
       void Agregar(Torneo Torneo);

       void Modificar(Torneo Torneo);

       Torneo Buscar(int IdTorneo);

       TipoTorneo GetTipoTorneo(int IdTorneo);

       bool Existe(int IdTorneo);

       List<Torneo> Listar();
       List<Torneo> ListarCerrados();
    }
}
