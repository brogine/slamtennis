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

        void Modificar(Inscripcion Inscripcion);

        void Eliminar(int IdInscripcion);

        bool Existe(int IdTorneo, int DniJugador);

        void BajaInscripcion(Inscripcion Inscripcion);

        Inscripcion Buscar(int IdInscripcion);

        List<Inscripcion> Listar(int IdTorneo);

        List<Inscripcion> ListarActivas(int IdTorneo);

        List<Inscripcion> ListarPorPartido(int IdPartido);

       
    }
}
