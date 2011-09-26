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
            if (!Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador1.Dni))
            {
                string FechaFormateada = Inscripcion.Fecha.Year + "/" + Inscripcion.Fecha.Month + "/" + Inscripcion.Fecha.Day;
                String Campos = " IdInscripcion, IdTorneo, Fecha, Estado ";
                String Valores = Inscripcion.IdInscripcion + "," + Inscripcion.Torneo.IdTorneo + ",'";
                Valores += FechaFormateada + "'," + (Inscripcion.Estado ? 1 : 0);
                return Conn.Agregar("Inscripciones", Campos, Valores);
            }
            else
                throw new RepositorioExeption("El Jugador ya está inscripto a ese Torneo.");
        }

        public void Modificar(Inscripcion Inscripcion)
        {
            String Consulta = " Update Inscripciones Set ";
            Consulta += " Estado = " + (Inscripcion.Estado ? 1 : 0);
            Consulta += " Where IdInscripcion = " + Inscripcion.IdInscripcion;
            Conn.ActualizarOEliminar(Consulta);
            //Modifica una inscripcion en el caso que se quiera cambiar al jugador inscripto al torneo
            if (Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador1.Dni) && 
                !Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador2.Dni))
            {
                Consulta = " Update InscripcionesJugador Set ";
                Consulta += " Dni = " + Inscripcion.Equipo.Jugador2.Dni;
                Consulta += " Where IdInscripcion = " + Inscripcion.IdInscripcion;
                Consulta += " And Dni = " + Inscripcion.Equipo.Jugador1.Dni;
                Conn.ActualizarOEliminar(Consulta);
            }
        }

        /// <summary>
        /// Verfica si Existe una Inscripción en un Torneo para un Jugador Específico
        /// </summary>
        /// <param name="IdTorneo">Torneo en el que se busca la inscripcion</param>
        /// <param name="DniJugador">Jugador a inscribir</param>
        /// <returns></returns>
        public bool Existe(int IdTorneo, int DniJugador)
        {
            String Consulta = " SELECT COUNT(*) From Inscripciones I INNER JOIN InscripcionesJugador J ";
            Consulta += " ON I.IdInscripcion = J.IdInscripcion WHERE I.IdTorneo = " + IdTorneo;
            Consulta += " AND J.Dni = " + DniJugador;
            DataRow Fila = Conn.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
            if (cantidad == 1)
                return true;
            else
                return false;
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
            String Consulta = " Select I.*, J.Dni From InscripcionesJugador J Inner Join Inscripciones I ";
            Consulta += " On J.IdInscripcion = I.IdInscripcion Inner Join Personas P ";
            Consulta += " On J.Dni = P.Dni Where I.IdTorneo = " + IdTorneo;
            DataTable TablaInscripciones = Conn.Listar(Consulta);
            List<Inscripcion> ListaInscripciones = new List<Inscripcion>();
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();

            foreach (DataRow Fila in TablaInscripciones.Rows)
            {
                if (!ListaInscripciones.Exists(delegate(Inscripcion I) { return I.IdInscripcion == Convert.ToInt32(Fila["IdInscripcion"]); }))
                    ListaInscripciones.Add(this.Mapear(Fila));
                else
                {
                    Inscripcion bInscripcion = ListaInscripciones.Find(delegate(Inscripcion I) { return I.IdInscripcion == Convert.ToInt32(Fila["IdInscripcion"]); });
                    int Indice = ListaInscripciones.FindIndex(delegate(Inscripcion I) { return I.IdInscripcion == Convert.ToInt32(Fila["IdInscripcion"]); });
                    bInscripcion.Equipo.Jugador2 = Fila.IsNull("Dni") ? null :
                        repoJugadores.Buscar(Convert.ToInt32(Fila["Dni"]));
                    ListaInscripciones[Indice] = bInscripcion;
                }
            }
            return ListaInscripciones;
        }

        public List<Inscripcion> ListarPorPartido(int IdPartido)
        {
            String Consulta = " Select * From Torneos T Inner Join Inscripciones I ";
            Consulta += " On T.IdTorneo = I.IdTorneo Inner Join Partidos P ";
            Consulta += " On T.IdTorneo = P.IdTorneo Where P.IdPartido = " + IdPartido;
            DataTable TablaInscripciones = Conn.Listar(Consulta);
            List<Inscripcion> ListaInscripciones = new List<Inscripcion>();
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            foreach (DataRow Fila in TablaInscripciones.Rows)
            {
                if (!ListaInscripciones.Exists(delegate(Inscripcion I) { return I.IdInscripcion == Convert.ToInt32(Fila["IdInscripcion"]); }))
                    ListaInscripciones.Add(this.Mapear(Fila));
                else
                {
                    Inscripcion bInscripcion = ListaInscripciones.Find(delegate(Inscripcion I) { return I.IdInscripcion == Convert.ToInt32(Fila["IdInscripcion"]); });
                    int Indice = ListaInscripciones.FindIndex(delegate(Inscripcion I) { return I.IdInscripcion == Convert.ToInt32(Fila["IdInscripcion"]); });
                    bInscripcion.Equipo.Jugador2 = Fila.IsNull("Dni") ? null :
                        repoJugadores.Buscar(Convert.ToInt32(Fila["Dni"]));
                    ListaInscripciones[Indice] = bInscripcion;
                }
            }
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
