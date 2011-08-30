using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IClubServicio
    {
        void Agregar(IClubUI UI);

        void Modificar(IClubUI UI);

        void Buscar(IClubUI UI);
    }
}
