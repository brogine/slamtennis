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

        int UltimaInscripcion();

        void Modificar(IInscripcionUI UI);

        void Eliminar(int IdInscripcion);

        void Eliminar(int dni, int idtorneo);

        bool Existe(int IdTorneo, int DniJugador);

        bool ValidarInscripcion(int IdTorneo, int DniJugador);

        void Buscar(IInscripcionUI UI);
    }
}
