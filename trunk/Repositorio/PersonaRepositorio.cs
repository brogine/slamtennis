using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;

namespace Repositorio
{
    internal abstract class PersonaRepositorio
    {
        Persona Persona;
        Conexion Conn;
        internal PersonaRepositorio(Persona persona)
        {
            this.Persona = persona;
            Conn = new Conexion();
        }

        public void Agregar()
        {
            string Campos = "Dni, Nombre, Apellido, FechaNacimiento, Nacionalidad, Sexo, ";
            Campos += "Telefono, Celular, Email, Localidad, Domicilio, Estado ";
            string Valores = Persona.Dni + ",'" + Persona.Nombre + "','" + Persona.Apellido + "','";
            Valores += Persona.FechaNac + "'," + Persona.Nacionalidad.IdPais + ",'" + Persona.Sexo;
            Valores += "','" + Persona.Contacto.Telefono + "','" + Persona.Contacto.Celular;
            Valores += "','" + Persona.Contacto.Email  + "'," + Persona.Ubicacion.Localidad.IdLocalidad;
            Valores += ",'" + Persona.Ubicacion.Domicilio + "'," + (Persona.Estado ? 1 : 0);
            Conn.AgregarSinId("Persona", Campos, Valores);
        }

        public void Modificar()
        {

        }
    }
}
