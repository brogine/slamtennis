using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IArbitroRepositorio
    {
        void Agregar(Arbitro Arbitro);
        void Modificar(Arbitro Arbitro);
        Arbitro Buscar(int Dni);
        List<Arbitro> Listar();

    }
}
