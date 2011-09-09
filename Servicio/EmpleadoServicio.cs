﻿using System;
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
            Login Login = new Login(UI.Usuario, UI.Password, true);
            
            Empleado Emp = new Empleado(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac, Nacionalidad, UI.Sexo, UI.Estado, Ubicacion, Contacto, UI.Puesto);
            Emp.Login = Login;
            EmpleadoRepo.Agregar(Emp);
        }

        public void Modificar(IEmpleadoUI UI)
        {
            Empleado ModEmp = EmpleadoRepo.Buscar(UI.Dni);
            IUbicacionRepositorio UbicaRepo = new UbicacionRepositorio();
            
            ModEmp.Apellido = UI.Apellido;
            ModEmp.FechaNac = UI.FechaNac;
            Pais Nacionalidad = UbicaRepo.ObtenerPais(UI.Nacionalidad);
            ModEmp.Nacionalidad = Nacionalidad;
            ModEmp.Nombre = UI.Nombre;
            ModEmp.Sexo = UI.Sexo;
            ModEmp.Puesto = UI.Puesto;
            ModEmp.Login.Usuario = UI.Usuario;
            ModEmp.Login.Password = UI.Password;
            
            //Atributos de Value Object "Contacto"
            ModEmp.Contacto.Celular = UI.Celular;
            ModEmp.Contacto.Email = UI.Email;
            ModEmp.Contacto.Telefono = UI.Telefono;
            
            //Atributos de Value Object "Ubicacion"
            ModEmp.Ubicacion.Domicilio = UI.Domicilio;
            Localidad Localidad=UbicaRepo.ObtenerLocalidad(UI.Localidad);
            ModEmp.Ubicacion.Localidad = Localidad;

            EmpleadoRepo.Modificar(ModEmp);
        }

        public void Buscar(IEmpleadoUI UI)
        {
           Empleado BuscaEmpleado = EmpleadoRepo.Buscar(UI.Dni);
           UI.Apellido = BuscaEmpleado.Apellido;
           UI.Nombre = BuscaEmpleado.Nombre;
           UI.FechaNac = BuscaEmpleado.FechaNac;
           UI.Nacionalidad = BuscaEmpleado.Nacionalidad.IdPais;
           UI.Puesto = BuscaEmpleado.Puesto;
           UI.Sexo = BuscaEmpleado.Sexo;
           

            // Value Object Login
           UI.Usuario = BuscaEmpleado.Login.Usuario;
           UI.Password = BuscaEmpleado.Login.Password;
           
            //Value Object Ubicacion
           UI.Provincia = BuscaEmpleado.Ubicacion.Localidad.Provincia.IdProvincia;
           UI.Localidad = BuscaEmpleado.Ubicacion.Localidad.IdLocalidad;
           UI.Domicilio = BuscaEmpleado.Ubicacion.Domicilio;

            
           //Value Object Contacto
           UI.Telefono = BuscaEmpleado.Contacto.Telefono;
           UI.Email = BuscaEmpleado.Contacto.Email;
           UI.Celular = BuscaEmpleado.Contacto.Celular;
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