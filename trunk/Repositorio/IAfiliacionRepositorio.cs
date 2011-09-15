using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IAfiliacionRepositorio
    {
       void Agregar(Afiliacion Afiliacion);
       void Modificar(Afiliacion Afiliacion);
       List<Afiliacion> Listar(Club Club);
       Afiliacion Buscar(int Dni, int IdClub);
       bool Existe(int Dni, int IdClub);
    }
}
