using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Xml;

namespace Repositorio.Conexiones
{
    public abstract class AbstractDB
    {
        protected string nombre;
        protected string cadenacnn;
        protected string proveedor;
    
        public static AbstractDB GetInstance()
        {
            XmlDocument doc = new XmlDocument();
            string dir = System.AppDomain.CurrentDomain.BaseDirectory;
            doc.Load(dir + "\\Configuracion.xml");
            XmlNodeList ListaNodos = doc.GetElementsByTagName("config");
            XmlNode nodo = doc.GetElementsByTagName("config").Item(0);
            string nombre = nodo.Attributes["nombre"].Value;
            string cnnStr = nodo.Attributes["ConnectionString"].Value;
            string proveedor = nodo.Attributes["Proveedor"].Value;
            
            GC.Collect();
            switch (nombre)
            {
                case "SqlServer": return new SqlServerDB(nombre, cnnStr, proveedor);
                case "MySQL": return new MySqlDB(nombre, cnnStr, proveedor);
                default: return null;
            }
        }
        public abstract IDbConnection crearConexion();
        public abstract IDbCommand crearComando(string sql, IDbConnection conn);

        public abstract IDbDataAdapter CrearLector(IDbCommand comando);
        public abstract void Conectar();
        public abstract void Desconectar();
    }
}
