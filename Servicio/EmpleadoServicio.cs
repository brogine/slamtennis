using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;

namespace Servicio
{
    public class EmpleadoServicio : IEmpleadoServicio, IListadoEmpleadoServicio
    {
        IEmpleadoRepositorio EmpleadoRepo;
        public EmpleadoServicio()
        {
            EmpleadoRepo = new EmpleadoRepositorio();
        }
        
        #region Miembros de IEmpleadoServicio


        public void Agregar(IEmpleadoUI UI)
        {
            IUbicacionRepositorio Ubica = new UbicacionRepositorio();
            Pais Nacionalidad = Ubica.ObtenerPais(UI.Nacionalidad);
            Ubicacion Ubicacion = new Ubicacion(Ubica.ObtenerLocalidad(UI.Localidad),UI.Domicilio);
            Contacto Contacto = new Contacto(UI.Telefono,UI.Celular,UI.Email);
            Empleado Emp = new Empleado(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac, Nacionalidad, UI.Sexo, UI.Estado, Ubicacion, Contacto, UI.Puesto);
            EmpleadoRepo.Agregar(Emp);
        }

        public void Modificar(IEmpleadoUI UI)
        {
            throw new NotImplementedException();
        }

        public void Buscar(IEmpleadoUI UI)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Miembros de IListadoEmpleadoServicio

        public void ListarEmpleados(IListadoEmpleados UI)
        {
            List<Object> ListaUI = new List<object>();
            List<Empleado> ListaEmp = EmpleadoRepo.Listar();
            foreach (Empleado Empleado in ListaEmp)
            {
                Object Objeto = new object();
                Objeto = Empleado.Dni+",";
                Objeto += Empleado.Apellido + " " + Empleado.Nombre + ",";
                Objeto += Empleado.Puesto;
                ListaUI.Add(Objeto);
            }
            UI.ListaEmpleados = ListaUI;
        }

        #endregion
        
    }
}
