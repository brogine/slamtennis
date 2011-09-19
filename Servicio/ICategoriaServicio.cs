using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ICategoriaService
    {
        void Buscar(ICategoriaUI UI);

        int Agregar(ICategoriaUI UI);

        void Modificar(ICategoriaUI UI);

        void Listar(IListadoCategorias UI);
    }
}
