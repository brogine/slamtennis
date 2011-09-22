using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    public class InscripcionRepositorio : IInscripcionRepositorio, IMapeador<Inscripcion>
    {
        Conexion Conn;
        public InscripcionRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de IInscripcionRepositorio

        public int Agregar(Inscripcion Inscripcion)
        {
            string FechaFormateada = Inscripcion.Fecha.Year + "/" + Inscripcion.Fecha.Month + "/" + Inscripcion.Fecha.Day;
            String Campos = " IdInscripcion, IdTorneo, Fecha, Estado ";
            String Valores = Inscripcion.IdInscripcion + "," + Inscripcion.Torneo.IdTorneo + ",'";
            Valores += FechaFormateada + "'," + (Inscripcion.Estado ? 1 : 0);
            return Conn.Agregar("Inscripciones", Campos, Valores);
        }

        public void Modificar(Inscripcion Inscripcion)
        {
            String Consulta = " Update Inscripciones Set ";
            Consulta += " Estado = " + (Inscripcion.Estado ? 1 : 0);
            Conn.ActualizarOEliminar(Consulta);
        }

        public Inscripcion Buscar(int IdInscripcion)
        {
            String Consulta = " Select * From InscripcionesJugador J Inner Join Inscripciones I ";
            Consulta += " On J.IdInscripciones = I.IdInscripcion Where IdInscripcion = " + IdInscripcion;
            DataTable Tabla = Conn.Listar(Consulta);
            Inscripcion bInscripcion = null;
            if (Tabla.Rows.Count == 1)
            {
                bInscripcion = this.Mapear(Tabla.Rows[0]);
            }
            else
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    if (i == 0)
                        bInscripcion = this.Mapear(Tabla.Rows[i]);
                    else
                    {
                        IJugadorRepositorio repoJugadores = new JugadorRepositorio();
                        bInscripcion.Equipo.Jugador2 = Tabla.Rows[1].IsNull("Dni") ? null :
                            repoJugadores.Buscar(Convert.ToInt32(Tabla.Rows[1]["Dni"]));
                    }
                }
            }
            return bInscripcion;
        }

        public List<Inscripcion> Listar(int IdTorneo)
        {
            String Consulta = " Select * From InscripcionesJugador J Inner Join Inscripciones I ";
            Consulta += " On J.IdInscripciones = I.IdInscripcion Inner Join Personas P ";
            Consulta += " On J.Dni = P.Dni Where I.IdTorneo = " + IdTorneo;
            DataTable TablaInscripciones = Conn.Listar(Consulta);
            List<Inscripcion> ListaInscripciones = new List<Inscripcion>();
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            foreach (DataRow Fila in TablaInscripciones.Rows)
            {
                if (TablaInscripciones.Rows.Contains(Fila["IdInscripcion"]))
                {
                    bInscripcion.Equipo.Jugador2 = Tabla.Rows[1].IsNull("Dni") ? null :
                        repoJugadores.Buscar(Convert.ToInt32(Tabla.Rows[1]["Dni"]));
                }
            }
            ListaInscripciones.Add(this.Mapear(TablaInscripciones));
            return ListaInscripciones;
        }

        public List<Inscripcion> ListarPorPartido(int IdPartido)
        {
            String Consulta = " Select * From Torneos T Inner Join Inscripciones I ";
            Consulta += " On T.IdTorneo = I.IdTorneo Inner Join Partidos P ";
            Consulta += " On T.IdTorneo = P.IdTorneo Where P.IdPartido = " + IdPartido;
            DataTable TablaInscripciones = Conn.Listar(Consulta);
            List<Inscripcion> ListaInscripciones = new List<Inscripcion>();
            ListaInscripciones.Add(this.Mapear(TablaInscripciones));
            return ListaInscripciones;
        }

        #endregion

        #region Miembros de IMapeador<Inscripcion>

        public Inscripcion Mapear(DataRow Fila)
        {
            Inscripcion nInscripcion = null;
            
            if(Fila != null)
            {
                int IdInscripcion = Fila.IsNull("IdInscripcion") ? 0 : Convert.ToInt32(Fila["IdInscripcion"]);
                ITorneoRepositorio repoTorneos = new TorneoRepositorio();
                Torneo bTorneo = Fila.IsNull("IdTorneo") ? null : repoTorneos.Buscar(Convert.ToInt32(Fila["IdTorneo"]));
                DateTime Fecha = Fila.IsNull("Fecha") ? DateTime.Now : Convert.ToDateTime(Fila["Fecha"]);
                bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                IJugadorRepositorio repoJugadores = new JugadorRepositorio();
                Equipo nEquipo = new Equipo();
                nEquipo.Jugador1 = Fila.IsNull("Dni") ? null : repoJugadores.Buscar(Convert.ToInt32(Fila["Dni"]));

                nInscripcion = new Inscripcion(IdInscripcion, bTorneo, Fecha, Estado, nEquipo);
            }
            return nInscripcion;
        }

        #endregion
    }
}
