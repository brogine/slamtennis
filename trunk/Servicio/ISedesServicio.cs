using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ISedesServicio
    {
        void Agregar(ISedesUI UI);

        void Modificar(ISedesUI UI);

        void Buscar(ISedesUI UI);
    }
}
