using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ITorneoServicio
    {
        void Agregar(ITorneoUI UI);

        void Modificar(ITorneoUI UI);

        void Buscar(ITorneoUI UI);

        bool Existe(int IdTorneo);
    }
}
