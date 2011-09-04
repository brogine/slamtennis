using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    public class PersonaRepositorio
    {
        Conexion Conn;
        /// <summary>
        /// Constructor de PersonaRepositorio
        /// Crea una instancia de Conexión con Base de Datos
        /// </summary>
        protected PersonaRepositorio()
        {
            Conn = new Conexion();
        }

        /// <summary>
        /// Agrega una Persona a la Base de Datos
        /// </summary>
        /// <param name="Persona">Objeto a guardar</param>
        protected void Agregar(Persona Persona)
        {
            string Campos = "Dni, Nombre, Apellido, FechaNacimiento, Nacionalidad, Sexo, ";
            Campos += "Telefono, Celular, Email, Localidad, Domicilio, Estado ";
            string Valores = Persona.Dni + ",'" + Persona.Nombre + "','" + Persona.Apellido + "','";
            Valores += Persona.FechaNac + "'," + Persona.Nacionalidad.IdPais + ",'" + Persona.Sexo;
            Valores += "','" + Persona.Contacto.Telefono + "','" + Persona.Contacto.Celular;
            Valores += "','" + Persona.Contacto.Email  + "'," + Persona.Ubicacion.Localidad.IdLocalidad;
            Valores += ",'" + Persona.Ubicacion.Domicilio + "'," + (Persona.Estado ? 1 : 0);
            Conn.AgregarSinId("Personas", Campos, Valores);
        }

        /// <summary>
        /// Modifica datos de una Persona a partir de su Dni
        /// </summary>
        /// <param name="Persona">Objeto a modificar</param>
        protected void Modificar(Persona Persona)
        {
            string Consulta = " Update Personas Set ";
            Consulta += " Nombre = '" + Persona.Nombre + "',";
            Consulta += " Apellido = '" + Persona.Apellido + "',";
            Consulta += " FechaNacimiento = '" + Persona.FechaNac + "',";
            Consulta += " Nacionalidad = " + Persona.Nacionalidad.IdPais + ",";
            Consulta += " Sexo = '" + Persona.Sexo + "',";
            Consulta += " Telefono = '" + Persona.Contacto.Telefono + "',";
            Consulta += " Celular = '" + Persona.Contacto.Celular + "',";
            Consulta += " Email = '" + Persona.Contacto.Email + "',";
            Consulta += " Localidad = " + Persona.Ubicacion.Localidad.IdLocalidad + ",";
            Consulta += " Domicilio = '" + Persona.Ubicacion.Domicilio + "',";
            Consulta += " Estado = " + (Persona.Estado ? 1 : 0);
            Consulta += " Where Dni = " + Persona.Dni;
            Conn.ActualizarOEliminar(Consulta);
        }

        protected Persona MapearDatosPersonales(DataRow Fila, Persona Objeto)
        {
            IUbicacionRepositorio UbicacionRepo = new UbicacionRepositorio();

            //Agregate Root
            Objeto.Dni = (Fila.IsNull("Dni") == true ? 0 : Convert.ToInt32(Fila["Dni"]));
            Objeto.Nombre = (Fila.IsNull("Nombre") == true ? string.Empty : Convert.ToString(Fila["Nombre"]));
            Objeto.Apellido = (Fila.IsNull("Apellido") == true ? string.Empty : Convert.ToString(Fila["Apellido"]));
            Objeto.FechaNac = (Fila.IsNull("FechaNacimiento") == true ? DateTime.Now : Convert.ToDateTime(Fila["FechaNacimiento"]));
            Objeto.Nacionalidad = UbicacionRepo.ObtenerPais(Fila.IsNull("Nacionalidad") == true ? 0 : (int)Fila["Nacionalidad"]);
            Objeto.Sexo = (Fila.IsNull("Sexo") == true ? string.Empty : Convert.ToString(Fila["Sexo"]));
            Objeto.Estado = (Fila.IsNull("Sexo") == true ? false : Convert.ToBoolean(Fila["Estado"]));

            //Value Object Contacto
            string Telefono = (Fila.IsNull("Telefono") == true ? string.Empty : Convert.ToString(Fila["Telefono"]));
            string Celular = (Fila.IsNull("Celular") == true ? string.Empty : Convert.ToString(Fila["Celular"]));
            string Email = (Fila.IsNull("Email") == true ? string.Empty : Convert.ToString(Fila["Email"]));
            Contacto Contacto = new Contacto(Telefono, Celular, Email);
            Objeto.Contacto = Contacto;

            // Value Object Domicilio
            Provincia Provincia = UbicacionRepo.ObetenerProvincia(Fila.IsNull("Provincia") == true ? 0 : (int)Fila["Provincia"]);
            Localidad Localidad = UbicacionRepo.ObtenerLocalidad(Fila.IsNull("Localidad") == true ? 0 : (int)Fila["Localidad"]);
            string Domicilio = (Fila.IsNull("Domicilio") == true ? string.Empty : Convert.ToString(Fila["Domicilio"]));
            Ubicacion Ubicacion = new Ubicacion(Provincia, Localidad, Domicilio);
            Objeto.Ubicacion = Ubicacion;
            
            return Objeto;
        }

    }
}
