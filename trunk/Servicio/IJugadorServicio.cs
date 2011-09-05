using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IJugadorServicio
    {
        void Agregar(IJugadorUI UI);

        void Modificar(IJugadorUI UI);
        
        void Buscar(IJugadorUI UI);
    }
}
