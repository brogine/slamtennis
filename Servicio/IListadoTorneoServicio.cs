using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
   public interface IListadoTorneoServicio
    {
       void ListarTorneos(IListadoTorneos UI);

       void ListarTorneosCerrados(IListadoTorneos UI);

       void ListarTorneosAbiertos(IListadoTorneos UI);
    }
}
