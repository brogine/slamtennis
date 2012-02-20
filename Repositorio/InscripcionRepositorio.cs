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
            if (Inscripcion.Torneo.Estado == (int)EstadoTorneo.Abierto)
            {
                if (Inscripcion.Torneo.Cupo > this.Listar(Inscripcion.Torneo.IdTorneo).Count)
                {
                    if (Inscripcion.IdInscripcion > 0)
                    {
                        if (!Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador1.Dni))
                            Conn.AgregarSinId("InscripcionesJugador", "Dni, IdInscripcion", Inscripcion.Equipo.Jugador1.Dni + "," + Inscripcion.IdInscripcion);
                        if (Inscripcion.Equipo.Jugador2 != null && !Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador2.Dni))
                            Conn.AgregarSinId("InscripcionesJugador", "Dni, IdInscripcion", Inscripcion.Equipo.Jugador2.Dni + "," + Inscripcion.IdInscripcion);
                        return Inscripcion.IdInscripcion;
                    }
                    else
                    {
                        if (!Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador1.Dni))
                        {
                            string FechaFormateada = Inscripcion.Fecha.Year + "/" + Inscripcion.Fecha.Month + "/" + Inscripcion.Fecha.Day;
                            String Campos = " IdTorneo, Fecha, Estado";
                            String Valores = Inscripcion.Torneo.IdTorneo + ",'";
                            Valores += FechaFormateada + "',1";
                            int IdInscripcion = Conn.Agregar("Inscripciones", Campos, Valores);
                            Conn.AgregarSinId("InscripcionesJugador", "Dni, IdInscripcion", Inscripcion.Equipo.Jugador1.Dni + "," + IdInscripcion);
                            if (Inscripcion.Equipo.Jugador2 != null)
                            {
                                Conn.AgregarSinId("InscripcionesJugador", "Dni, IdInscripcion", Inscripcion.Equipo.Jugador2.Dni + "," + IdInscripcion);
                            }
                            if (Inscripcion.Torneo.Cupo == this.Listar(Inscripcion.Torneo.IdTorneo).Count)
                            {
                                ITorneoRepositorio TorneoRepo = new TorneoRepositorio();
                                Inscripcion.Torneo.Estado = (int)EstadoTorneo.Cerrado;
                                TorneoRepo.Modificar(Inscripcion.Torneo);
                            }
                            return IdInscripcion;
                        }
                        else
                            throw new RepositorioExeption("El Jugador ya está inscripto a ese Torneo.");
                    }
                }
                else
                    throw new RepositorioExeption("El Torneo al que desea inscribirse ya está completo.");
            }
            else
                throw new RepositorioExeption("El Torneo al que desea inscribirse se encuentra cerrado para inscripción.");
        }

        public int UltimaInscripcion()
        {
            string query = "select max(IdInscripcion) from Inscripciones";
            int retorno = 0;
            DataRow fila = Conn.Buscar(query);
            if (fila != null || fila.IsNull(0) == false)
            {
                if (!string.IsNullOrEmpty(fila[0].ToString()))
                {
                    retorno = Convert.ToInt32(fila[0]);
                }
            }
            return retorno;
        }

        public void Modificar(Inscripcion Inscripcion)
        {
            //Verifica si en la inscripcion hay un solo jugador y si el torneo es de dobles, agregue al segundo jugador
            ITorneoRepositorio repoTorneos = new TorneoRepositorio();
            TipoTorneo tipoTorneo = repoTorneos.GetTipoTorneo(Inscripcion.Torneo.IdTorneo);
            if (tipoTorneo == TipoTorneo.Doble)
            {
                if (Inscripcion.Equipo.Jugador2 != null)
                    this.Agregar(Inscripcion);
                else
                //Modifica una inscripcion en el caso que se quiera cambiar al jugador inscripto al torneo
                if (Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador1.Dni) &&
                    !Existe(Inscripcion.Torneo.IdTorneo, Inscripcion.Equipo.Jugador2.Dni))
                {
                    String Consulta = " Update InscripcionesJugador Set ";
                    Consulta += " Dni = " + Inscripcion.Equipo.Jugador2.Dni;
                    Consulta += " Estado = " + (Inscripcion.Estado ? 1 : 0);
                    Consulta += " Where IdInscripcion = " + Inscripcion.IdInscripcion;
                    Consulta += " And Dni = " + Inscripcion.Equipo.Jugador1.Dni;
                    Conn.ActualizarOEliminar(Consulta);
                }
            }

        }

        public void Eliminar(int IdInscripcion)
        {   IInscripcionRepositorio InscRepo = new InscripcionRepositorio();
            Inscripcion Insc = InscRepo.Buscar(IdInscripcion);
            
            String Consulta = " Delete From Inscripciones Where IdInscripcion = " + IdInscripcion;
            Conn.ActualizarOEliminar(Consulta);
            Consulta = " Delete From InscripcionesJugador Where IdInscripcion = " + IdInscripcion;
            Conn.ActualizarOEliminar(Consulta);

            if (Insc.Torneo.FechaFinInscripcion <= DateTime.Today && Insc.Torneo.Estado == (int) EstadoTorneo.Cerrado)
            {
                Insc.Torneo.Estado = (int)EstadoTorneo.Abierto;
                ITorneoRepositorio TorneoRepo = new TorneoRepositorio();
                TorneoRepo.Modificar(Insc.Torneo);
            }
        }

        public void Eliminar(int dni, int idtorneo)
        {
            IInscripcionRepositorio InscRepo = new InscripcionRepositorio();
            Inscripcion Insc = InscRepo.Buscar(dni, idtorneo);

            String Consulta = " Delete From Inscripciones Where IdInscripcion = " + Insc.IdInscripcion;
            Conn.ActualizarOEliminar(Consulta);
            Consulta = " Delete From InscripcionesJugador Where IdInscripcion = " + Insc.IdInscripcion;
            Conn.ActualizarOEliminar(Consulta);

            if (Insc.Torneo.FechaFinInscripcion <= DateTime.Today && Insc.Torneo.Estado == (int)EstadoTorneo.Cerrado)
            {
                Insc.Torneo.Estado = (int)EstadoTorneo.Abierto;
                ITorneoRepositorio TorneoRepo = new TorneoRepositorio();
                TorneoRepo.Modificar(Insc.Torneo);
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
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            if (!repoJugadores.Existe(DniJugador))
                return false;
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
            Consulta += " On J.IdInscripcion = I.IdInscripcion Where J.IdInscripcion = " + IdInscripcion;
            DataTable Tabla = Conn.Listar(Consulta);
            Inscripcion bInscripcion = null;
            if (Tabla.Rows.Count == 1)
                bInscripcion = this.Mapear(Tabla.Rows[0]);
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

        public Inscripcion Buscar(int Dni,int IdTorneo)
        {
            String Consulta = " Select * From InscripcionesJugador J Inner Join Inscripciones I ";
            Consulta += " On J.IdInscripcion = I.IdInscripcion Where J.Dni = " + Dni + " and i.IdTorneo = " + IdTorneo;
            DataTable Tabla = Conn.Listar(Consulta);
            Inscripcion bInscripcion = null;
            if (Tabla.Rows.Count == 1)
                bInscripcion = this.Mapear(Tabla.Rows[0]);
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
                Boolean Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                IJugadorRepositorio repoJugadores = new JugadorRepositorio();
                Equipo nEquipo = new Equipo();
                nEquipo.Jugador1 = Fila.IsNull("Dni") ? null : repoJugadores.Buscar(Convert.ToInt32(Fila["Dni"]));
                nInscripcion = new Inscripcion(IdInscripcion, bTorneo, Fecha, nEquipo, Estado);
            }
            return nInscripcion;
        }

        #endregion

        #region Miembros de IInscripcionRepositorio


        public List<Inscripcion> ListarActivas(int IdTorneo)
        {
            String Consulta = " Select I.*, J.Dni From InscripcionesJugador J Inner Join Inscripciones I ";
            Consulta += " On J.IdInscripcion = I.IdInscripcion Inner Join Personas P ";
            Consulta += " On J.Dni = P.Dni Where I.IdTorneo = " + IdTorneo + " and I.Estado = 1";
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

        #region Miembros de IInscripcionRepositorio


        public void BajaInscripcion(Inscripcion Inscripcion)
        {
            String Consulta = " Update Inscripciones Set ";
            Consulta += " Estado = 0";
            Consulta += " Where IdInscripcion = " + Inscripcion.IdInscripcion;
            Conn.ActualizarOEliminar(Consulta);
        }

        #endregion
    }
}
