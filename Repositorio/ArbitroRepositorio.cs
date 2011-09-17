using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
  public  class ArbitroRepositorio:PersonaRepositorio, IArbitroRepositorio, IMapeador<Arbitro>
    {
        Conexion Conex;

        public ArbitroRepositorio()
            :base()
        {
            Conex = new Conexion();
        }
        #region Miembros de IArbitroRepositorio

        public void Agregar(Dominio.Arbitro Arbitro)
        {
            if (!base.Existe(Arbitro.Dni))
                base.Agregar(Arbitro);
            else
                base.Modificar(Arbitro);
            Conex.AgregarSinId("Arbitros", "Dni,Badge,Nivel,Estado",
                Arbitro.Dni + ",'" + Arbitro.Badge + "'," + Arbitro.Nivel + "," + (Arbitro.Estado ? 1 : 0));
        }

        public override bool Existe(int Dni)
        {
            string Consulta = " Select Count(*) From Arbitros Where Dni = " + Dni;
            DataRow Fila = Conex.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
            if (cantidad == 1)
                return true;
            else
                return false;
        }

        public void Modificar(Arbitro Arbitro)
        {
            base.Modificar(Arbitro);
            string Consulta = " Update Arbitros set ";
            Consulta += " Nivel =" + Arbitro.Nivel + ",";
            Consulta += " Badge ='" + Arbitro.Badge + "',";
            Consulta += " Estado ='" + Arbitro.Estado + "'";
            Consulta += " where Dni = " + Arbitro.Dni;
        }

        public Dominio.Arbitro Buscar(int Dni)
        {
            if (base.Existe(Dni))
            {
                if (Existe(Dni))
                {
                    string Consulta = " Select * from Arbitros a ";
                    Consulta += " inner join Login l ";
                    Consulta += " on a.Dni = l.Dni inner join Personas P ";
                    Consulta += " on a.Dni = P.Dni Where a.Dni = " + Dni;
                    return this.Mapear(Conex.Buscar(Consulta));
                }
                else
                {
                    string Consulta = " Select * From Personas P ";
                    Consulta += " inner join Login L ";
                    Consulta += " on P.Dni = L.Dni ";
                    Consulta += " Where P.Dni = " + Dni;
                    return this.Mapear(Conex.Buscar(Consulta));
                }
            }
            else
                throw new RepositorioExeption("No Existen Registros en la Base de Datos con Dni: " + Dni.ToString());
        }

        public List<Dominio.Arbitro> Listar()
        {
            string Sql = "select * from Arbitros A inner join Personas P on A.Dni = P.Dni ";
            Sql += " inner join Login L on A.Dni = L.Dni ";
            DataTable Tabla = Conex.Listar(Sql);
            List<Arbitro> Lista = new List<Arbitro>();

            foreach (DataRow Dr in Tabla.Rows)
            { 
                Lista.Add(this.Mapear(Dr));
            }
            return Lista;
        }

        #endregion

        #region Miembros de IMapeador<Arbitro>

        public Arbitro Mapear(System.Data.DataRow Fila)
        {
            Arbitro Arbitro = null;
            if (Fila != null)
            {
                Arbitro = new Arbitro();
                Arbitro = base.MapearDatosPersonales(Fila, Arbitro) as Arbitro;

                if (Fila.Table.Columns.Contains("Badge") && Fila.Table.Columns.Contains("Nivel")
                    && Fila.Table.Columns.Contains("Estado"))
                {
                    Arbitro.Badge = Fila.IsNull("Badge") ? string.Empty : Fila["Badge"].ToString();
                    Arbitro.Nivel = Fila.IsNull("Nivel") ? 0 : Convert.ToInt32(Fila["Nivel"]);
                    Arbitro.Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                }

            }
            return Arbitro;
        }

        #endregion
    }
}
