using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;
namespace Servicio
{
    public interface IEmpleadoServicio
    {
        void Agregar(IEmpleadoUI UI);

        void Modificar(IEmpleadoUI UI);

        bool Existe(int Dni);

        void Buscar(IEmpleadoUI UI);

    }
}
