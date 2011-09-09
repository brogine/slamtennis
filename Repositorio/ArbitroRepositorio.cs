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
            base.Agregar(Arbitro);
            Conex.Agregar("Arbitros", "Dni,Badge,Nivel,NumeroInscripcion,Estado", Arbitro.Dni + "," + Arbitro.Badge + "," + Arbitro.Nivel+ "," +Arbitro.Estado);
        }

        public void Modificar(Arbitro Arbitro)
        {
            base.Modificar(Arbitro);
            string Consulta = " Update Arbitros set ";
            Consulta += " Nivel =" + Arbitro.Nivel + ",";
            Consulta += " Badge =" + Arbitro.Badge + ",";
            Consulta += " Estado =" + Arbitro.Estado;
            Consulta += " where Dni = " + Arbitro.Dni;
        }

        public Dominio.Arbitro Buscar(int Dni)
        {
            string Consulta = " Select * from Arbitros a ";
            Consulta += " inner join Login l ";
            Consulta += " on a.Dni = l.Dni where Dni " + Dni;
            return this.Mapear(Conex.Buscar(Consulta));

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
            if (Fila!=null)
            {
                Arbitro = new Arbitro();
                Arbitro = base.MapearDatosPersonales(Fila, Arbitro) as Arbitro;

                Arbitro.Badge = Fila.IsNull("Badge") ? string.Empty : Fila["Badge"].ToString();
                Arbitro.Nivel=Fila.IsNull("Nivel")?0:Convert.ToInt32( Fila["Nivel"]);
                Arbitro.Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                

            }
            return Arbitro;
        }

        #endregion
    }
}
