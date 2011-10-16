using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio.Conexiones
{
    sealed class SqlServerDB : AbstractDB
    {
        SqlConnection conn;
        SqlCommand comm;
        public SqlServerDB(string Nombre, string StrCon, string Provider)
        {
            this.proveedor = Provider;
            this.nombre = Nombre;
            this.cadenacnn = StrCon;
        }

        public override IDbConnection crearConexion()
        {
            if(conn == null)
                conn = new SqlConnection();
            conn.ConnectionString = this.cadenacnn;
            return conn;
        }
        public override IDbCommand crearComando(string sql, IDbConnection con)
        {
            if (comm != null)
                comm = new SqlCommand(sql, (SqlConnection)con);
            return comm;
        }
        public override void Conectar()
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                throw new RepositorioExeption("No se puede conectar el servidor de Base de Datos");
            }
        }

        public override void Desconectar()
        {
            conn.Close();
        }

        public override IDbDataAdapter CrearLector(IDbCommand comando)
        {
            return new SqlDataAdapter((SqlCommand)comando);
        }

        public override IDbDataParameter crearImagenParametro(string ParameterName, object ParameterValue)
        {
            if (comm == null)
                comm = conn.CreateCommand();
            SqlParameter Parametro = comm.CreateParameter();
            Parametro.SqlDbType = SqlDbType.Image;
            Parametro.ParameterName = ParameterName;
            Parametro.Value = ParameterValue;
            return Parametro;
        }
    }
}
