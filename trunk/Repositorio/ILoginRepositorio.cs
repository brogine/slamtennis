using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface ILoginRepositorio
    {
        void Agregar(Login Objeto, int Dni);

        void Modificar(Login Objeto);

        Login Obtener(string Usuario);

        bool Existe(string Usuario);
    }
}
