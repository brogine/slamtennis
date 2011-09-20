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
        Categoria Buscar(int Id);
        int Agregar(Categoria Categoria);
        void Modificar(Categoria Categoria);
        bool Existe(int Id);
        
    }
}
