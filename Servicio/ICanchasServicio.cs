using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ICanchasServicio
    {
        void Agregar(ICanchasUI UI);

        void Modificar(ICanchasUI UI);

        void Buscar(ICanchasUI UI);
    }
}
