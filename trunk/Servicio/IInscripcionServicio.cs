using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IInscripcionServicio
    {
        void Agregar(IInscripcionUI UI);

        void Modificar(IInscripcionUI UI);

        bool Existe(int IdTorneo, int DniJugador);

        void Buscar(IInscripcionUI UI);
    }
}
