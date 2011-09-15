using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
   public interface IAfiliacionServicio
    {
        void Agregar(IAfiliacionUI UI);

        void Modificar(IAfiliacionUI UI);

        void Buscar(IAfiliacionUI UI);

        bool Existe(IAfiliacionUI UI);
    }
}
