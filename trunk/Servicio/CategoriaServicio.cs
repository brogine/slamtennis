using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using Dominio;
using Servicio.InterfacesUI;

namespace Servicio
{
    public class CategoriaServicio : ICategoriaService
    {
        
        ICategoriaRepositorio repositorio;
        public CategoriaServicio()
        {
            repositorio = new CategoriaRepositorio();
        }
        #region Miembros de ICategoriaService

        public void Buscar(ICategoriaUI UI)
        {
            repositorio = new CategoriaRepositorio();
            Categoria Cat = repositorio.Buscar(UI.IdCategoria);
            UI.IdCategoria = Cat.Id;
            UI.Nombre = Cat.Nombre;
            UI.EdadMinima = Cat.EdadMin;
            UI.EdadMaxima = Cat.EdadMax;
            UI.Estado = Cat.Estado;
        }

        public int Agregar(ICategoriaUI UI)
        {
            repositorio = new CategoriaRepositorio();
            Categoria nCat = new Categoria(UI.Nombre, UI.EdadMinima, UI.EdadMaxima, UI.Estado);
            return repositorio.Agregar(nCat);
        }

        public void Modificar(ICategoriaUI UI)
        {
            repositorio = new CategoriaRepositorio();
            Categoria nCat = repositorio.Buscar(UI.IdCategoria);
            nCat.Nombre= UI.Nombre;
            nCat.EdadMin=UI.EdadMinima;
            nCat.EdadMax=UI.EdadMaxima;
            nCat.Estado =UI.Estado;
            repositorio.Modificar(nCat);
        }

        public void Listar(IListadoCategorias UI)
        {
            List<Object> ListaUI = new List<object>();
            List<Categoria> ListaCat = repositorio.Listar();
            foreach (Categoria Categoria in ListaCat)
            {
                Object Objeto = new object();
                Objeto = Categoria.Id + ",";
                Objeto += Categoria.Nombre +",";
                Objeto += Categoria.EdadMin + ",";
                Objeto += Categoria.EdadMax + ",";
                Objeto += Categoria.Estado.ToString();
                ListaUI.Add(Objeto);
            }
            UI.ListaUI = ListaUI;
        }

        #endregion
    }
}
