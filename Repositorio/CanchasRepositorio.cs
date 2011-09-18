using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;
using System.Data;

namespace Repositorio
{
    public class CanchasRepositorio : ICanchasRepositorio, IMapeador<Cancha>
    {
        Conexion Conn;
        public CanchasRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de ICanchasRepositorio

        public int Agregar(Cancha Cancha)
        {
            return Conn.Agregar("Canchas", "IdSede, Tipo, Superficie, Luz, Cantidad",
                Cancha.Sede.Id + "," + (int)Cancha.TipoCancha + "," + (int)Cancha.Superficie + "," + (Cancha.Luz ? 1 : 0) + "," + Cancha.Cantidad);
        }

        public void Modificar(Cancha Cancha)
        {
            string Consulta = " Update Canchas Set ";
            Consulta += " Tipo = " + (int)Cancha.TipoCancha + ",";
            Consulta += " Superficie = " + (int)Cancha.Superficie + ",";
            Consulta += " Luz = " + (Cancha.Luz ? 1 : 0) + ",";
            Consulta += " Cantidad = " + Cancha.Cantidad;
            Consulta += " Where IdCanchas = " + Cancha.Id;
            Conn.ActualizarOEliminar(Consulta);
        }

        public Cancha Buscar(int IdCancha)
        {
            string Consulta = " Select * From Canchas Where IdCanchas = " + IdCancha;
            return this.Mapear(Conn.Buscar(Consulta));
        }

        public List<Cancha> Listar(int IdSede)
        {
            string Consulta = " Select * From Canchas Where IdSede = " + IdSede;
            DataTable Tabla = Conn.Listar(Consulta);
            List<Cancha> ListaCanchas = new List<Cancha>();
            foreach (DataRow Fila in Tabla.Rows)
            {
                ListaCanchas.Add(this.Mapear(Fila));
            }
            return ListaCanchas;
        }

        #endregion

        #region Miembros de IMapeador<Cancha>

        public Cancha Mapear(System.Data.DataRow Fila)
        {
            Cancha nCancha = null;
            if (Fila != null)
            {
                ISedesRepositorio repoSedes = new SedesRepositorio();
                Sede bSede = Fila.IsNull("IdSede") ? null : repoSedes.Buscar(Convert.ToInt32(Fila["IdSede"]));

                int IdCancha = Fila.IsNull("IdCanchas") ? 0 : Convert.ToInt32(Fila["IdCanchas"]);
                int Superficie = Fila.IsNull("Superficie") ? 0 : Convert.ToInt32(Fila["Superficie"]);
                int TipoCancha = Fila.IsNull("Tipo") ? 0 : Convert.ToInt32(Fila["Tipo"]);
                bool Luz = Fila.IsNull("Luz") ? false : Convert.ToBoolean(Fila["Luz"]);
                int Cantidad = Fila.IsNull("Cantidad") ? 1 : Convert.ToInt32(Fila["Cantidad"]);

                nCancha = new Cancha(IdCancha, bSede, (TipoCancha)TipoCancha, (TipoSuperficie)Superficie, Luz, Cantidad);
            }
            return nCancha;
        }

        #endregion
    }
}
