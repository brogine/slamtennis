using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;


namespace Repositorio.Conexiones
{
    sealed class MySqlDB : AbstractDB
    {
        MySqlConnection conn;
        MySqlCommand comm;
        public MySqlDB(string Nombre, string StrCon, string Provider)
        {
            this.proveedor = Provider;
            this.nombre = Nombre;
            this.cadenacnn = StrCon;
        }

        public override IDbConnection crearConexion()
        {
            if (conn == null)
                conn = new MySqlConnection();
            conn.ConnectionString = this.cadenacnn;
            return conn;
        }

        public override IDbCommand crearComando(string sql, IDbConnection con)
        {
            if (comm != null)
                comm = new MySqlCommand(sql, (MySqlConnection)con);
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
            return new MySqlDataAdapter((MySqlCommand)comando);
        }

        public override IDbDataParameter crearImagenParametro(string ParameterName, object ParameterValue)
        {
            if (comm == null)
                comm = conn.CreateCommand();
            MySqlParameter Parametro = comm.CreateParameter();
            Parametro.MySqlDbType = MySqlDbType.Blob;
            Parametro.ParameterName = ParameterName;
            Parametro.Value = ParameterValue;
            return Parametro;
        }
    }
}
