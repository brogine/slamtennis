using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    public class PuntosRepositorio:IPuntosRepositorio, IMapeador<Puntos>
    {
        Conexion Conex;
        public PuntosRepositorio()
        {
            Conex = new Conexion();
        }
        

        #region Miembros de IMapeador<Puntos>

        public Puntos Mapear(System.Data.DataRow Fila)
        {
            Puntos Puntos = null;
            
                if(Fila!=null)
                {
                    Puntos = new Puntos();
                }
                if (Fila.Table.Columns.Contains("IdTorneo") && Fila.Table.Columns.Contains("Ronda")
                        && Fila.Table.Columns.Contains("Puntos"))
                {
                   Puntos.IdTorneo = Fila.IsNull("IdTorneo") ? 0 : Convert.ToInt32(Fila["IdTorneo"]);
                   Puntos.Ronda = Fila.IsNull("Ronda") ? string.Empty : Fila["Ronda"].ToString();
                   Puntos.CantidadPuntos=Fila.IsNull("Puntos") ? 0 : Convert.ToInt32(Fila["Puntos"]);

                }
                return Puntos;
        }

        #endregion

        #region Miembros de IPuntosRepositorio

        public void Agregar(List<Puntos> Puntos)
        {
            foreach (Puntos P in Puntos)
            {
                Conex.AgregarSinId("PuntosTorneo", "IdTorneo,Ronda,Puntos", P.IdTorneo + ",'" + P.Ronda + "'," + P.CantidadPuntos);
            }
            }

        public void Modificar(List<Puntos> Puntos)
        {
            foreach (Puntos P in Puntos)
            {
                string Sql = "Update PuntosTorneo Set ";
                Sql += "Puntos = " + P.CantidadPuntos;
                Sql += " Where IdTorneo = " + P.IdTorneo + " and Ronda = '" + P.Ronda+"'";
                Conex.ActualizarOEliminar(Sql);
            }
        }

        public void Buscar(Puntos Puntos)
        {
            throw new NotImplementedException();
        }

        public List<Puntos> ListarPuntos(int IdTorneo)
        {
            string sql = "Select * from PuntosTorneo Where IdTorneo = " + IdTorneo;

            DataTable Tabla = Conex.Listar(sql);

            List<Puntos> Lista = new List<Puntos>();
            foreach (DataRow Dr in Tabla.Rows)
            {
                Puntos Puntos = new Puntos();
               Lista.Add(this.Mapear(Dr));
            }
            return Lista;
        }

        #endregion
    }
}
