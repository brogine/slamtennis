using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface ICanchasRepositorio
    {
        int Agregar(Cancha Cancha);

        void Modificar(Cancha Cancha);

        Cancha Buscar(int IdCancha);

        List<Cancha> Listar(int IdSede);
    }
}
