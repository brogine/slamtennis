using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface ICategoriaRepositorio
    {
        List<Categoria> Listar();
        List<Categoria> ListarActivas();

        Categoria Buscar(int Id);

        int Agregar(Categoria Categoria);

        void Modificar(Categoria Categoria);

        Categoria ObtenerPorEdad(int Edad);

        bool Existe(int Id);
        
    }
}
