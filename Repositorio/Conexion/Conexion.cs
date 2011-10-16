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
        /// <summary>
        /// Constructor de clase Conexion. 
        /// Instancia y establece conexion con la base de datos.
        /// </summary>
        public Conexion()
        {
            Db = AbstractDB.GetInstance();
            Cnn = Db.crearConexion();
            Db.Conectar();
            
        }

        /// <summary>
        /// Método que devuelve la primera fila de la respuesta de la BDD
        /// </summary>
        /// <param name="StrSql">Consulta Sql</param>
        /// <returns>Fila</returns>
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

        /// <summary>
        /// Método usado para traer muchas filas de una consulta
        /// desde la BDD.
        /// </summary>
        /// <param name="StrSql">Consulta SQL</param>
        /// <returns>Tabla con datos</returns>
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

        /// <summary>
        /// Agrega a la base de datos devolviendo valor autoincrementable.
        /// </summary>
        /// <param name="Tabla">Tabla a la que se quiere agregar</param>
        /// <param name="Campos">Campos de la Tabla</param>
        /// <param name="Valores">Valores para los Campos</param>
        /// <returns>Valor autoincrementable</returns>
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

        /// <summary>
        /// Agrega a la base de datos.
        /// </summary>
        /// <param name="Tabla">Tabla a la que se quiere agregar</param>
        /// <param name="Campos">Campos de la Tabla</param>
        /// <param name="Valores">Valores para los Campos</param>
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

        /// <summary>
        /// Actualiza o elimina uno o varios registros de la base de datos
        /// </summary>
        /// <param name="StrSql">Consulta SQL</param>
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

        /// <summary>
        /// Agrega una Foto a una Persona en la Base de Datos
        /// </summary>
        /// <param name="Tabla">Tabla a la que se agrega</param>
        /// <param name="Campo">Campo en el que se agrega</param>
        /// <param name="Imagen">bytes de la imagen</param>
        public void AgregarFoto(string Tabla, string Campo, string CampoCondicion, object ValorCondicion, byte[] Imagen)
        {
            if (Cnn.State == ConnectionState.Closed)
                Cnn.Open();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Com = Cnn.CreateCommand();
            Com.CommandText = " Update " + Tabla + " Set " + Campo + " = @" + Campo + " Where " + CampoCondicion + " = " + ValorCondicion;
            IDbDataParameter imageParam = Db.crearImagenParametro("@" + Campo, Imagen);
            Com.Parameters.Add(imageParam);
            Com.ExecuteNonQuery();
        }
    }
}

