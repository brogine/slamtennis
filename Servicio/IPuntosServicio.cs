using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IPuntosServicio
    {
        void Agregar(IPuntosUI UI);

        void Modificar(IPuntosUI UI);

        void Buscar(IPuntosUI UI);

        bool Existe(IPuntosUI UI);
    }
}
