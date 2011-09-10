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
            string Campos = " Dni, Nombre, Apellido, FechaNacimiento, Nacionalidad, Sexo, ";
            Campos += "Telefono, Celular, Email, Localidad, Domicilio ";
            string Valores = Persona.Dni + ",'" + Persona.Nombre + "','" + Persona.Apellido + "','";
            Valores += Persona.FechaNac + "'," + Persona.Nacionalidad.IdPais + ",'" + Persona.Sexo;
            Valores += "','" + Persona.Contacto.Telefono + "','" + Persona.Contacto.Celular;
            Valores += "','" + Persona.Contacto.Email  + "'," + Persona.Ubicacion.Localidad.IdLocalidad;
            Valores += ",'" + Persona.Ubicacion.Domicilio + "'";
            Conn.AgregarSinId("Personas", Campos, Valores);

            Campos = " Dni, Usuario, Password, Estado ";
            Valores = Persona.Dni + ",'" + Persona.Login.Usuario + "','" + Persona.Login.Password + "'," + (Persona.Login.Estado ? 1 : 0);
            Conn.AgregarSinId("Login", Campos, Valores);
        }

        public bool Existe(int Dni)
        {
            string Consulta = " Select Count(Dni) from Personas Where Dni = " + Dni;
            DataRow Fila = Conn.Buscar(Consulta);
            int cantidad = Fila.IsNull(0) ? 0 : 1;
            if (cantidad == 1)
                return true;
            else
                return false;
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
            Consulta += " Domicilio = '" + Persona.Ubicacion.Domicilio + "'";
            Consulta += " Where Dni = " + Persona.Dni;
            Conn.ActualizarOEliminar(Consulta);

            Consulta = " Update Login Set ";
            Consulta += " Usuario = '" + Persona.Login.Usuario + "',";
            Consulta += " Password = '" + Persona.Login.Password + "',";
            Consulta += " Estado = " + (Persona.Login.Estado ? 1 : 0);
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

            //Value Object Contacto
            string Telefono = (Fila.IsNull("Telefono") == true ? string.Empty : Convert.ToString(Fila["Telefono"]));
            string Celular = (Fila.IsNull("Celular") == true ? string.Empty : Convert.ToString(Fila["Celular"]));
            string Email = (Fila.IsNull("Email") == true ? string.Empty : Convert.ToString(Fila["Email"]));
            Contacto Contacto = new Contacto(Telefono, Celular, Email);
            Objeto.Contacto = Contacto;

            // Value Object Domicilio
            Localidad Localidad = UbicacionRepo.ObtenerLocalidad(Fila.IsNull("Localidad") == true ? 0 : (int)Fila["Localidad"]);
            string Domicilio = (Fila.IsNull("Domicilio") == true ? string.Empty : Convert.ToString(Fila["Domicilio"]));
            Ubicacion Ubicacion = new Ubicacion(Localidad, Domicilio);
            Objeto.Ubicacion = Ubicacion;

            // Value Object Login
            string Usuario = Fila.IsNull("Usuario") ? string.Empty : Fila["Usuario"].ToString();
            string Password = Fila.IsNull("Password") ? string.Empty : Fila["Password"].ToString();
            bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
            Login Login = new Login(Usuario, Password, Estado);
            Objeto.Login = Login;
            
            return Objeto;
        }

    }
}
