using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using Dominio;

namespace Servicio
{
    public class InscripcionServicio : IInscripcionServicio, IListadoInscripcionServicio
    {
        IInscripcionRepositorio repoInscripciones;
        public InscripcionServicio()
        {
            repoInscripciones = new InscripcionRepositorio();
        }

        #region Miembros de IInscripcionServicio

        public int Agregar(Servicio.InterfacesUI.IInscripcionUI UI)
        {
            if (!repoInscripciones.Existe(UI.IdTorneo, UI.DniJugador1))
            {
                ITorneoRepositorio repoTorneos = new TorneoRepositorio();
                IJugadorRepositorio repoJugadores = new JugadorRepositorio();
                Torneo bTorneo = repoTorneos.Buscar(UI.IdTorneo);
                Equipo nEquipo = new Equipo();
                nEquipo.Jugador1 = repoJugadores.Buscar(UI.DniJugador1);
                if (UI.DniJugador2 > 0)
                {
                    if (!repoInscripciones.Existe(UI.IdTorneo, UI.DniJugador2))
                        nEquipo.Jugador2 = repoJugadores.Buscar(UI.DniJugador2);
                    else
                        throw new ServicioExeption("El Jugador con Dni " + UI.DniJugador2 + " ya está Inscripto a ese torneo.");
                }
                Inscripcion nInscripcion = new Inscripcion(bTorneo, UI.Fecha, UI.Estado, nEquipo);
                return repoInscripciones.Agregar(nInscripcion);
            }
            else
                throw new ServicioExeption("El Jugador con Dni = " + UI.DniJugador1 + " ya está Inscripto a ese torneo.");
        }

        public void Modificar(Servicio.InterfacesUI.IInscripcionUI UI)
        {
            Inscripcion bInscripcion = repoInscripciones.Buscar(UI.IdInscripcion);
            bInscripcion.Estado = UI.Estado;
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            if(UI.ModificarJugador)
            {
                bInscripcion.Equipo.Jugador1 = repoJugadores.Buscar(UI.DniJugador1);
                bInscripcion.Equipo.Jugador2 = repoJugadores.Buscar(UI.DniJugador2);
            }
            if (bInscripcion.Equipo.Jugador2 == null && UI.DniJugador2 > 0)
                bInscripcion.Equipo.Jugador2 = repoJugadores.Buscar(UI.DniJugador2);
            repoInscripciones.Modificar(bInscripcion);
        }

        public bool Existe(int IdTorneo, int DniJugador)
        {
            return repoInscripciones.Existe(IdTorneo, DniJugador);
        }

        /// <summary>
        /// Valida que un la Categoría de un Jugador coincida con la del Torneo
        /// </summary>
        /// <param name="IdTorneo">Torneo al cual se desea validar</param>
        /// <param name="DniJugador">Jugador a validar</param>
        /// <returns>True: Correcto. False: Incorrecto</returns>
        public bool ValidarInscripcion(int IdTorneo, int DniJugador)
        {
            ITorneoRepositorio repoTorneos = new TorneoRepositorio();
            Torneo bTorneo = repoTorneos.Buscar(IdTorneo);
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            Jugador bJugador = repoJugadores.Buscar(DniJugador);
            ICategoriaRepositorio repoCategorias = new CategoriaRepositorio();
            Categoria bCategoria = repoCategorias.ObtenerPorEdad(bJugador.Edad);
            if (bTorneo.Categoria == bCategoria)
                return true;
            else
                return false;
        }

        public void Buscar(Servicio.InterfacesUI.IInscripcionUI UI)
        {
            Inscripcion bInscripcion = repoInscripciones.Buscar(UI.IdInscripcion);
            UI.DniJugador1 = bInscripcion.Equipo.Jugador1.Dni;
            if(bInscripcion.Equipo.Jugador2 != null)
                UI.DniJugador2 = bInscripcion.Equipo.Jugador2.Dni;
            UI.Estado = bInscripcion.Estado;
            UI.Fecha = bInscripcion.Fecha;
            UI.IdTorneo = bInscripcion.Torneo.IdTorneo;
            UI.IdInscripcion = bInscripcion.IdInscripcion;
        }

        #endregion

        #region Miembros de IListadoInscripcionServicio

        public void ListarPorTorneo(Servicio.InterfacesUI.IListadoInscripciones UI)
        {
            List<Inscripcion> ListaInscripciones = repoInscripciones.Listar(UI.IdTorneo);
            List<Object> ListaUI = new List<object>();
            ITorneoRepositorio repoTorneos = new TorneoRepositorio();
            TipoTorneo tipoTorneo = repoTorneos.GetTipoTorneo(UI.IdTorneo);
            foreach (Inscripcion Inscripcion in ListaInscripciones)
            {
                if (Inscripcion.Equipo.Jugador2 != null)
                {
                    ListaUI.Add(Inscripcion.IdInscripcion + "," + (int)tipoTorneo + "," +
                        Inscripcion.Equipo.Jugador1.Apellido + " " + Inscripcion.Equipo.Jugador1.Nombre + "," + 
                        Inscripcion.Equipo.Jugador2.Nombre + " " + Inscripcion.Equipo.Jugador2.Apellido + "," +
                        Inscripcion.Fecha.ToShortDateString() + "," + Inscripcion.Estado);
                }
                else
                {
                    ListaUI.Add(Inscripcion.IdInscripcion + "," + (int)tipoTorneo + "," +
                        Inscripcion.Equipo.Jugador1.Apellido + " " + Inscripcion.Equipo.Jugador1.Nombre + "," +
                        Inscripcion.Fecha.ToShortDateString() + "," + Inscripcion.Estado);
                }
            }
            UI.ListarPorTorneo = ListaUI;
        }

        public void ListarPorPartido(Servicio.InterfacesUI.IListadoInscripciones UI)
        {
            List<Inscripcion> ListaInscripciones = repoInscripciones.ListarPorPartido(UI.IdPartido);
            List<Object> ListaUI = new List<object>();
            foreach (Inscripcion Inscripcion in ListaInscripciones)
            {
                if (Inscripcion.Equipo.Jugador2 != null)
                {
                    ListaUI.Add(Inscripcion.IdInscripcion + "," + Inscripcion.Fecha.ToShortDateString() + "," + Inscripcion.Equipo.Jugador1.Apellido + " " +
                        Inscripcion.Equipo.Jugador1.Nombre + "," + Inscripcion.Equipo.Jugador2.Apellido + " " + 
                        Inscripcion.Equipo.Jugador2.Nombre + Inscripcion.Estado);
                }
                else
                {
                    ListaUI.Add(Inscripcion.IdInscripcion + "," + Inscripcion.Fecha.ToShortDateString() + "," + 
                        Inscripcion.Equipo.Jugador1.Apellido + " " + Inscripcion.Equipo.Jugador1.Nombre + "," + Inscripcion.Estado);
                }
            }
            UI.ListarPorPartido = ListaUI;
        }

        #endregion
    }
}
