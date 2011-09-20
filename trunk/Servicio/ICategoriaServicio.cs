using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ICategoriaServicio
    {
        void Buscar(ICategoriaUI UI);

        int Agregar(ICategoriaUI UI);

        void Modificar(ICategoriaUI UI);

        bool Existe(int Id);
    }
}
