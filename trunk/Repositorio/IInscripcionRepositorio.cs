using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IInscripcionRepositorio
    {
        int Agregar(Inscripcion Inscripcion);

        int UltimaInscripcion();

        void Modificar(Inscripcion Inscripcion);

        void Eliminar(int IdInscripcion);

        void Eliminar(int dni, int idtorneo);

        bool Existe(int IdTorneo, int DniJugador);

        void BajaInscripcion(Inscripcion Inscripcion);

        Inscripcion Buscar(int IdInscripcion);

        Inscripcion Buscar(int Dni, int IdTorneo);

        List<Inscripcion> Listar(int IdTorneo);

        List<Inscripcion> ListarActivas(int IdTorneo);

        List<Inscripcion> ListarPorPartido(int IdPartido);

       
    }
}
