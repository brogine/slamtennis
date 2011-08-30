using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
    public interface IEmpleadoRepositorio
    {
        void Agregar(Empleado Empleado);

        void Modificar(Empleado Empleado);

        Empleado BuscarPresidente(int IdClub);

        Empleado Buscar(int Dni);

        List<Empleado> Listar();
    }
}
