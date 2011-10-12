using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IJugadorRepositorio
    {
        void Agregar(Jugador Jugador);

        void Modificar(Jugador Jugador);

        Jugador Buscar(int Dni);

        Categoria BuscarCategoria(int Dni);

        bool Existe(int Dni);

        List<Jugador> Listar(int IdClub);

        List<Jugador> ListarPorCategoria(int IdCategoria);
    }
}
