using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IListadoSedesServicio
    {
        void ListarSedes(IListadoSedes UI);
    }
}
