using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
   public interface IPartidoServicio
    {
       void Agregar(IPartidoUI UI);

       void Modificar(IPartidoUI UI);

       void Buscar(IPartidoUI UI);

       bool Existe(int IdPartido);

       string GanadorPartido(int IdPartido);
    }
}
