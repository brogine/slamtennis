using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IPartidoRepositorio
    {
        int Agregar(Partido Partido);

        void Modificar(Partido Partido);

        Partido Buscar(int IdPartido);

        List<Partido> Listar(int IdTorneo);
    }
}
