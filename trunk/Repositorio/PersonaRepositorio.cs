using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;
using System.IO;
using System.Drawing;

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
            string FechaFormateada = Persona.FechaNac.Year+"/"+Persona.FechaNac.Month+"/"+Persona.FechaNac.Day;
            string Campos = " Dni, Nombre, Apellido, FechaNacimiento, Nacionalidad, Sexo, ";
            Campos += "Telefono, Celular, Email, Localidad, Domicilio, Foto ";
            string Valores = Persona.Dni + ",'" + Persona.Nombre + "','" + Persona.Apellido + "','";
            Valores += FechaFormateada + "'," + Persona.Nacionalidad.IdPais + ",'" + Persona.Sexo;
            Valores += "','" + Persona.Contacto.Telefono + "','" + Persona.Contacto.Celular;
            Valores += "','" + Persona.Contacto.Email  + "'," + Persona.Ubicacion.Localidad.IdLocalidad;
            Valores += ",'" + Persona.Ubicacion.Domicilio + "',";
            Valores += "'" + GetBytes(Persona.Foto) + "'";
            try
            {
                Conn.AgregarSinId("Personas", Campos, Valores);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudieron agregar los datos personales.", ex);
            }

            ILoginRepositorio repoLogin = new LoginRepositorio();
            if (!repoLogin.Existe(Persona.Dni))
            {
                Login nLogin = new Login(Persona.Login.Usuario, Persona.Login.Password, Persona.Dni, Persona.Login.Estado);
                
                repoLogin.Agregar(nLogin);
            }
        }

        public virtual bool Existe(int Dni)
        {
            string Consulta = " Select Count(Dni) from Personas Where Dni = " + Dni;
            DataRow Fila = Conn.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
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
            string FechaFormateada = Persona.FechaNac.Year + "/" + Persona.FechaNac.Month + "/" + Persona.FechaNac.Day;
            string Consulta = " Update Personas Set ";
            Consulta += " Nombre = '" + Persona.Nombre + "',";
            Consulta += " Apellido = '" + Persona.Apellido + "',";
            Consulta += " FechaNacimiento = '" + FechaFormateada + "',";
            Consulta += " Nacionalidad = " + Persona.Nacionalidad.IdPais + ",";
            Consulta += " Sexo = '" + Persona.Sexo + "',";
            Consulta += " Telefono = '" + Persona.Contacto.Telefono + "',";
            Consulta += " Celular = '" + Persona.Contacto.Celular + "',";
            Consulta += " Email = '" + Persona.Contacto.Email + "',";
            Consulta += " Localidad = " + Persona.Ubicacion.Localidad.IdLocalidad + ",";
            Consulta += " Domicilio = '" + Persona.Ubicacion.Domicilio + "',";
            Consulta += " Foto = '" + GetBytes(Persona.Foto) + "'";
            Consulta += " Where Dni = " + Persona.Dni;
            try
            {
                Conn.ActualizarOEliminar(Consulta);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudieron modificar los datos personales.", ex);
            }

            ILoginRepositorio repoLogin = new LoginRepositorio();
            if (repoLogin.Existe(Persona.Dni))
            {
                Login bLogin = repoLogin.Obtener(Persona.Dni);
                bLogin.Password = Persona.Login.Password;
                bLogin.Estado = Persona.Login.Estado;
                repoLogin.Modificar(bLogin);
            }
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
            Objeto.Foto = (Fila.IsNull("Foto") == true ? null : BytesImage((Byte[])Fila["Foto"]));
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
            Login Login = new Login(Usuario, Password, Objeto.Dni, Estado);
            Objeto.Login = Login;
            
            return Objeto;
        }

        System.Drawing.Image BytesImage(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudo obtener la imagen de la persona...", ex);
            }
            return bm;
        }

        byte[] GetBytes(Image imagen)
        {
            byte[] imageData;
            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);
            imageData = ms.ToArray();
            return imageData;
        }

    }
}
