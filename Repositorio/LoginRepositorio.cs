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
            Conn = new Conexion();
        }

        #region Miembros de ILoginRepositorio

        public void Agregar(Dominio.Login Objeto, int Dni)
        {
            Conn.AgregarSinId("Login", "Dni,Usuario,Password,Estado", Dni + ",'" + Objeto.Usuario +
                "','" + Objeto.Password + "'," + (Objeto.Estado ? 1 : 0));
        }

        public void Modificar(Dominio.Login Objeto)
        {
            string sql = " Update Login Set Password = '" + Objeto.Password + "', Estado = " + (Objeto.Estado ? 1 : 0);
            Conn.ActualizarOEliminar(sql);
        }

        public Dominio.Login Obtener(string Usuario)
        {
            string sql = " Select * From Login Where Usuario = '" + Usuario + "'";
            return this.Mapear(Conn.Buscar(sql));
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
                string usuario = Fila.IsNull("Usuario") == true ? string.Empty : Fila["Usuario"].ToString();
                string password = Fila.IsNull("Password") == true ? string.Empty : Fila["Password"].ToString();
                bool estado = Fila.IsNull("Estado") == true ? false : true;
                mLogin = new Login(usuario, password, estado);
            }
            return mLogin;
        }

        #endregion
    }
}
