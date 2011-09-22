using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;
using System.Data;

namespace Repositorio
{
    public class PartidoRepositorio : IPartidoRepositorio, IMapeador<Partido>
    {
        Conexion Conn;
        public PartidoRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de IPartidoRepositorio

        public int Agregar(Partido Partido)
        {
            string FechaFormateada = Partido.Fecha.Year + "/" + Partido.Fecha.Month + "/" + Partido.Fecha.Day;
            String Campos = " IdTorneo, Resultado, Fecha, Ronda, Estado ";
            String Valores = Partido.Torneo.IdTorneo + ",'" + Partido.Resultado + "','" + FechaFormateada;
            Valores += "'," + Partido.Ronda + "," + (Partido.Estado ? 1 : 0);
            return Conn.Agregar("Partidos", Campos, Valores);
        }

        public void Modificar(Partido Partido)
        {
            string FechaFormateada = Partido.Fecha.Year + "/" + Partido.Fecha.Month + "/" + Partido.Fecha.Day;
            String Consulta = " Update Partidos Set ";
            Consulta += " Resultado = '" + Partido.Resultado + "', ";
            Consulta += " Fecha = '" + FechaFormateada + "', ";
            Consulta += " Ronda = " + Partido.Ronda + ", ";
            Consulta += " Estado = " + (Partido.Estado ? 1 : 0);
            Consulta += " Where IdPartido = " + Partido.IdPartido;
            Conn.ActualizarOEliminar(Consulta);
        }

        public Partido Buscar(int IdPartido)
        {
            String Consulta = " Select * From Partidos Where IdPartido = " + IdPartido;
            return this.Mapear(Conn.Buscar(Consulta));
        }

        public List<Partido> Listar(int IdTorneo)
        {
            String Consulta = " Select * From Partidos Where IdTorneo = " + IdTorneo;
            DataTable TablaPartidos = Conn.Listar(Consulta);
            List<Partido> ListaPartidos = new List<Partido>();
            foreach (DataRow Fila in TablaPartidos.Rows)
            {
                ListaPartidos.Add(this.Mapear(Fila));
            }
            return ListaPartidos;
        }

        #endregion

        #region Miembros de IMapeador<Partido>

        public Partido Mapear(System.Data.DataRow Fila)
        {
            Partido nPartido = null;
            if (Fila != null)
            {
                int IdPartido = Fila.IsNull("IdPartido") ? 0 : Convert.ToInt32(Fila["IdPartido"]);
                ITorneoRepositorio repoTorneos = new TorneoRepositorio();
                Torneo bTorneo = Fila.IsNull("IdTorneo") ? null : repoTorneos.Buscar(Convert.ToInt32(Fila["IdTorneo"]));
                IInscripcionRepositorio repoInscripciones = new InscripcionRepositorio();
                List<Inscripcion> ListaInscripciones = repoInscripciones.ListarPorPartido(IdPartido);
                DateTime Fecha = Fila.IsNull("Fecha") ? DateTime.Now : Convert.ToDateTime(Fila["Fecha"]);
                string Resultado = Fila.IsNull("Resultado") ? string.Empty : Fila["Resultado"].ToString();
                int Ronda = Fila.IsNull("Ronda") ? 0 : Convert.ToInt32(Fila["Ronda"]);
                IArbitroRepositorio repoArbitros = new ArbitroRepositorio();
                List<Arbitro> ListaArbitros = repoArbitros.Listar(IdPartido);
                bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);

                nPartido = new Partido(IdPartido, bTorneo, ListaInscripciones, Fecha, Resultado, Ronda, ListaArbitros, Estado);
            }
            return nPartido;
        }

        #endregion
    }
}
