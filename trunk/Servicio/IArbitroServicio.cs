using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IArbitroServicio
    {
        void Agregar(IArbitroUI UI);

        void Modificar(IArbitroUI UI);

        void Buscar(IArbitroUI UI);
    }
}
