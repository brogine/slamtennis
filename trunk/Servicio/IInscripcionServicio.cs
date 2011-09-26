using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IInscripcionServicio
    {
        int Agregar(IInscripcionUI UI);

        void Modificar(IInscripcionUI UI);

        bool Existe(int IdTorneo, int DniJugador);

        bool ValidarInscripcion(int IdTorneo, int DniJugador);

        void Buscar(IInscripcionUI UI);
    }
}
