﻿using System;
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

        List<Jugador> Listar();
    }
}