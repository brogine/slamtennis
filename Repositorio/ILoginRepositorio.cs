using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface ILoginRepositorio
    {
        void Agregar(Login Objeto);

        void Modificar(Login Objeto);

        Login Obtener(string Usuario);

        Login Obtener(int Dni);

        bool Existe(int Dni);

        bool Existe(string Usuario);
    }
}
