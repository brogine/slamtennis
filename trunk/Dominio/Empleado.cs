using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Empleado : Persona
    {
        public Empleado(int dni, string nombre, string apellido, DateTime fechanac, Pais nacionalidad, string sexo,
            bool estado, string telefono, string celular, string email, Provincia provincia, Localidad localidad,
            string domicilio, string puesto, Sede sede)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido; this.FechaNac = fechanac; this.Nacionalidad = nacionalidad.Nombre;
            this.Sexo = sexo; this.estado = estado; this.Contacto.Telefono = telefono; this.Contacto.Celular = celular;
            this.Contacto.Email = email; this.Ubicacion.Provincia = provincia.Nombre; this.Ubicacion.Localidad = localidad.Nombre;
            this.Ubicacion.Domicilio = domicilio; this.puesto = puesto; this.sede = sede;
        }

        bool estado;
        string puesto;
        Sede sede;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Puesto
        {
            get { return puesto; }
            set { puesto = value; }
        }

        public Sede Sede
        {
            get { return sede; }
            set { sede = value; }
        }
    }
}
