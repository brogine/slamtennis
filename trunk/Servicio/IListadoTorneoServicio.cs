using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
   public interface IListadoTorneoServicio
    {
       void Listar(IListadoTorneos UI);

       void ListarCerrados(IListadoTorneos UI);

       void ListarAbiertos(IListadoTorneos UI);

       void Actualizar();

    }
}
