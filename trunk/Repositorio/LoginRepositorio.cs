using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;

namespace Repositorio
{
    public class LoginRepositorio : ILoginRepositorio, IMapeador<Login>
    {
        Conexion Conn;
        public LoginRepositorio()
        {
            try
            {
                Conn = new Conexion();
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption(ex.Message);
            }
        }

        #region Miembros de ILoginRepositorio

        public void Agregar(Dominio.Login Objeto)
        {
            try
            {
                Conn.AgregarSinId("Login", "Dni,Usuario,Password,Estado", Objeto.Dni + ",'" + Objeto.Usuario +
                    "','" + Objeto.Password + "'," + (Objeto.Estado ? 1 : 0));
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudieron agregar los datos de login.", ex);
            }
        }

        public void Modificar(Dominio.Login Objeto)
        {
            string sql = " Update Login Set Usuario = '" + Objeto.Usuario + "', Password = '" + Objeto.Password + 
                "', Estado = " + (Objeto.Estado ? 1 : 0) + " Where Dni = " + Objeto.Dni;
            try
            {
                Conn.ActualizarOEliminar(sql);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudieron modificar los datos de login.", ex);
            }
        }

        public Dominio.Login Obtener(string Usuario)
        {
            string sql = " Select * From Login Where Usuario = '" + Usuario + "'";
            return this.Mapear(Conn.Buscar(sql));
        }

        public Login Obtener(int Dni)
        {
            string sql = " Select * From Login Where Dni = " + Dni;
            return this.Mapear(Conn.Buscar(sql));
        }

        public bool Existe(int Dni)
        {
            string sql = " Select * From Login Where Dni = " + Dni;
            if (Conn.Buscar(sql) == null)
                return false;
            else
                return true;
        }

        public bool Existe(string Usuario)
        {
            string sql = " Select * From Login Where Usuario = '" + Usuario + "'";
            if (Conn.Buscar(sql) == null)
                return false;
            else
                return true;
        }

        #endregion

        #region Miembros de IMapeador<Login>

        public Login Mapear(System.Data.DataRow Fila)
        {
            Login mLogin = null;
            if (Fila != null)
            {
                int dni = Fila.IsNull("Dni") ? 0 : Convert.ToInt32(Fila["Dni"]);
                string usuario = Fila.IsNull("Usuario") == true ? string.Empty : Fila["Usuario"].ToString();
                string password = Fila.IsNull("Password") == true ? string.Empty : Fila["Password"].ToString();
                bool estado = Fila.IsNull("Estado") == true ? false : true;
                mLogin = new Login(usuario, password, dni, estado);
            }
            return mLogin;
        }

        #endregion
    }
}
