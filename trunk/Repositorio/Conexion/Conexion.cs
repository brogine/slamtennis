using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.Common;
using System.Threading;
using System.Globalization;

namespace Repositorio.Conexiones
{
    public class Conexion
    {
        IDbConnection Cnn;
        IDbCommand Com;
        AbstractDB Db;
        CultureInfo info = CultureInfo.CurrentCulture;
        public Conexion()
        {
            Db = AbstractDB.GetInstance();
            Cnn = Db.crearConexion();
            Db.Conectar();
        }

        public DataRow Buscar(string StrSql)
        {
            if (Cnn.State == ConnectionState.Closed)
                Cnn.Open();
            Com = Cnn.CreateCommand();
            Com.CommandText = StrSql;
            IDbDataAdapter Lector = Db.CrearLector(Com);
            DataSet ds = new DataSet();
            Lector.Fill(ds);
            Cnn.Close();
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];
            else
                return null;
        }

        public DataTable Listar(string StrSql)
        {
            if (Cnn.State == ConnectionState.Closed)
                Cnn.Open();
            Com = Cnn.CreateCommand();
            Com.CommandText = StrSql;
            IDbDataAdapter Lector = Db.CrearLector(Com);
            DataSet ds = new DataSet();
            Lector.Fill(ds);
            Cnn.Close();
            return ds.Tables[0];
        }

        public int Agregar(string Tabla, string Campos, string Valores)
        {
            if (Cnn.State == ConnectionState.Closed)
                Cnn.Open();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Com = Cnn.CreateCommand();
            Com.CommandText = " Insert into " + Tabla + " (" + Campos + ") Values (" + Valores + ") select @@identity ";
            int retorno = Convert.ToInt32(Com.ExecuteScalar());
            Thread.CurrentThread.CurrentCulture = info;
            Cnn.Close();
            return retorno;
        }

        public void AgregarSinId(string Tabla, string Campos, string Valores)
        {
            if (Cnn.State == ConnectionState.Closed)
                Cnn.Open();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Com = Cnn.CreateCommand();
            Com.CommandText = " Insert into " + Tabla + " (" + Campos + ") Values (" + Valores + ")";
            Com.ExecuteNonQuery();
            Cnn.Close();
            Thread.CurrentThread.CurrentCulture = info;
        }

        public void ActualizarOEliminar(string StrSql)
        {
            if (Cnn.State == ConnectionState.Closed)
                Cnn.Open();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Com = Cnn.CreateCommand();
            Com.CommandText = StrSql;
            Com.ExecuteNonQuery();
            Thread.CurrentThread.CurrentCulture = info;
            Cnn.Close();
        }

    }
}

