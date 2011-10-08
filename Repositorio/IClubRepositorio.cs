using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IClubRepositorio
    {
        int Agregar(Club Club);

        void Modificar(Club Club);

        Club Buscar(int IdClub);

        bool Existe(int IdClub);

        List<Club> Listar();
        List<Club> ListarActivos();
    }
}
