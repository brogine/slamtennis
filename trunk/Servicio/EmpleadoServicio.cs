using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;
using System.Drawing;
using System.Drawing.Drawing2D;

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
            Login Login = new Login(UI.Usuario, UI.Password, UI.Dni, true);
            Bitmap newImage = null;
            if (UI.Foto != null)
            {
                newImage = new Bitmap(100, 100);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(UI.Foto, new Rectangle(0, 0, 100, 100));
                }
            }
            Empleado Emp = new Empleado(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac, Nacionalidad, UI.Sexo, UI.Estado, Ubicacion, Contacto, UI.Puesto, newImage);
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
            Bitmap newImage = null;
            if (UI.Foto != null)
            {
                newImage = new Bitmap(320, 240);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(UI.Foto, new Rectangle(0, 0, 320, 240));
                }
                ModEmp.Foto = ModEmp.ImagenABytes(newImage);
            }

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

        public bool Existe(int Dni)
        {
            return EmpleadoRepo.Existe(Dni);
        }

        public void Buscar(IEmpleadoUI UI)
        {
            if (this.Existe(UI.Dni))
            {
                Empleado BuscaEmpleado = EmpleadoRepo.Buscar(UI.Dni);
                UI.Dni = BuscaEmpleado.Dni;
                UI.Apellido = BuscaEmpleado.Apellido;
                UI.Nombre = BuscaEmpleado.Nombre;
                UI.FechaNac = BuscaEmpleado.FechaNac;
                UI.Nacionalidad = BuscaEmpleado.Nacionalidad.IdPais;
                UI.Puesto = BuscaEmpleado.Puesto;
                UI.Sexo = BuscaEmpleado.Sexo;
                if (BuscaEmpleado.Foto != null)
                    UI.Foto = BuscaEmpleado.BytesAImagen(BuscaEmpleado.Foto);

                // Value Object Login
                UI.Usuario = BuscaEmpleado.Login.Usuario;
                UI.Password = BuscaEmpleado.Login.Password;

                //Value Object Ubicacion
                UI.Pais = BuscaEmpleado.Ubicacion.Localidad.Provincia.Pais.IdPais;
                UI.Provincia = BuscaEmpleado.Ubicacion.Localidad.Provincia.IdProvincia;
                UI.Localidad = BuscaEmpleado.Ubicacion.Localidad.IdLocalidad;
                UI.Domicilio = BuscaEmpleado.Ubicacion.Domicilio;


                //Value Object Contacto
                UI.Telefono = BuscaEmpleado.Contacto.Telefono;
                UI.Email = BuscaEmpleado.Contacto.Email;
                UI.Celular = BuscaEmpleado.Contacto.Celular;
            }
            else
                throw new ServicioExeption("El Empleado con Dni " + UI.Dni + " No Existe");
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
                Objeto += Empleado.Puesto + ",";
                ListaUI.Add(Objeto);
            }
            UI.ListaEmpleados = ListaUI;
        }

        #endregion
        
    }
}
