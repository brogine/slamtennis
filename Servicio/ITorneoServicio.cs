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

        int GetTipoTorneo(int IdTorneo);

        bool Existe(int IdTorneo);

        void ArmarTorneoAutomatico(int IdTorneo);
    }
}
