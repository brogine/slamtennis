using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface ISedesRepositorio
    {
        int Agregar(Sede Sede);

        void Modificar(Sede Sede);

        Sede Buscar(int Id);

        List<Sede> Listar(int IdClub);
    }
}
