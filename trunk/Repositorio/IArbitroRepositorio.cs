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

        bool Existe(int Dni);

        List<Arbitro> Listar();

        List<Arbitro> Listar(int IdPartido);

    }
}
