﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using Dominio;
using System.Data;

namespace Servicio
{
    public class InscripcionServicio : IInscripcionServicio, IListadoInscripcionServicio, IInscripcionReporteServicio
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
                try
                {
                    Torneo bTorneo = repoTorneos.Buscar(UI.IdTorneo);
                    Equipo nEquipo = new Equipo();
                    nEquipo.Jugador1 = repoJugadores.Buscar(UI.DniJugador1);
                    bool CategoriaCorrecta = false;
                    foreach (Estadisticas Estadistica in nEquipo.Jugador1.Estadisticas)
                    {
                        if (Estadistica.Categoria.Id == bTorneo.Categoria.Id)
                        {
                            CategoriaCorrecta = true;
                            break;
                        }
                    }
                    if (!CategoriaCorrecta)
                        throw new ServicioException("La Categoría del primer Jugador a Inscribirse no corresponde con la del Torneo."); 
                    if (UI.DniJugador2 > 0)
                    {
                        if (!repoInscripciones.Existe(UI.IdTorneo, UI.DniJugador2))
                            nEquipo.Jugador2 = repoJugadores.Buscar(UI.DniJugador2);
                        else
                            throw new ServicioException("El Jugador con Dni " + UI.DniJugador2 + " ya está Inscripto a ese torneo.");
                        foreach (Estadisticas Estadistica in nEquipo.Jugador2.Estadisticas)
                        {
                            if (Estadistica.Categoria.Id == bTorneo.Categoria.Id)
                            {
                                CategoriaCorrecta = true;
                                break;
                            }
                        }
                    }
                    if (!CategoriaCorrecta)
                        throw new ServicioException("La Categoría del segundo Jugador a Inscribirse no corresponde con la del Torneo."); 
                    Inscripcion nInscripcion = new Inscripcion(bTorneo, UI.Fecha, nEquipo);
                    return repoInscripciones.Agregar(nInscripcion);
                }
                catch (Exception ex)
                {
                    throw new ServicioException(ex.Message);
                }
            }
            else
                throw new ServicioException("El Jugador con Dni = " + UI.DniJugador1 + " ya está Inscripto a ese torneo.");
        }

        public int UltimaInscripcion()
        {
            return repoInscripciones.UltimaInscripcion();
        }

        public void Modificar(Servicio.InterfacesUI.IInscripcionUI UI)
        {
            Inscripcion bInscripcion = repoInscripciones.Buscar(UI.IdInscripcion);
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

        public void Eliminar(int IdInscripcion)
        {
            repoInscripciones.Eliminar(IdInscripcion);
        }

        public void Eliminar(int dni,int idtorneo)
        {
            repoInscripciones.Eliminar(dni, idtorneo);
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
                        Inscripcion.Fecha.ToShortDateString());
                }
                else
                {
                    ListaUI.Add(Inscripcion.IdInscripcion + "," + (int)tipoTorneo + "," +
                        Inscripcion.Equipo.Jugador1.Apellido + " " + Inscripcion.Equipo.Jugador1.Nombre + "," +
                        string.Empty+"," +
                        Inscripcion.Fecha.ToShortDateString());
                }
            }
            
            ITorneoRepositorio TorneoRepo = new TorneoRepositorio();
            Torneo Torneo = TorneoRepo.Buscar(UI.IdTorneo);
            if (Torneo.Estado == (int) EstadoTorneo.Cerrado && ListaUI.Count%2!=0)
            {

                ListaUI.Add(0 + "," + (int)tipoTorneo + ",BYE,,,");
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
                        Inscripcion.Equipo.Jugador2.Nombre);
                }
                else
                {
                    ListaUI.Add(Inscripcion.IdInscripcion + "," + Inscripcion.Fecha.ToShortDateString() + "," + 
                        Inscripcion.Equipo.Jugador1.Apellido + " " + Inscripcion.Equipo.Jugador1.Nombre);
                }
            }
            UI.ListarPorPartido = ListaUI;
        }

        #endregion

        #region Miembros de IInscripcionReporteServicio

        public DataTable BuscarPorId(int IdInscripcion)
        {
            DataTable ObjetoReporte = new DataTable("Datos");
            ObjetoReporte.Columns.Add("NroInscripcion");
            ObjetoReporte.Columns.Add("Jugador1");
            ObjetoReporte.Columns.Add("Jugador2");
            ObjetoReporte.Columns.Add("Torneo");
            ObjetoReporte.Columns.Add("Fecha");
            Inscripcion Inscripcion = repoInscripciones.Buscar(IdInscripcion);
            if (Inscripcion.Equipo.Jugador2 != null)
            {
                ObjetoReporte.Rows.Add(Inscripcion.IdInscripcion, Inscripcion.Equipo.Jugador1.Apellido + " " +
                    Inscripcion.Equipo.Jugador1.Nombre, Inscripcion.Equipo.Jugador2.Apellido + " " +
                    Inscripcion.Equipo.Jugador2.Nombre, Inscripcion.Torneo.Nombre, Inscripcion.Fecha.ToShortDateString());
            }
            else
            {
                ObjetoReporte.Rows.Add(Inscripcion.IdInscripcion, Inscripcion.Equipo.Jugador1.Apellido + " " +
                    Inscripcion.Equipo.Jugador1.Nombre, "", Inscripcion.Torneo.Nombre, Inscripcion.Fecha.ToShortDateString());
            }
            return ObjetoReporte;
        }

        #endregion

        #region Miembros de IListadoInscripcionServicio


        public void ListarActivas(Servicio.InterfacesUI.IListadoInscripciones UI)
        {
            List<Inscripcion> ListaInscripciones = repoInscripciones.ListarActivas(UI.IdTorneo);
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
                        Inscripcion.Fecha.ToShortDateString());
                }
                else
                {
                    ListaUI.Add(Inscripcion.IdInscripcion + "," + (int)tipoTorneo + "," +
                        Inscripcion.Equipo.Jugador1.Apellido + " " + Inscripcion.Equipo.Jugador1.Nombre + "," +
                        string.Empty + "," +
                        Inscripcion.Fecha.ToShortDateString());
                }
            }

            ITorneoRepositorio TorneoRepo = new TorneoRepositorio();
            Torneo Torneo = TorneoRepo.Buscar(UI.IdTorneo);
            if (Torneo.Estado == (int)EstadoTorneo.Cerrado && ListaUI.Count % 2 != 0)
            {

                ListaUI.Add(0 + "," + (int)tipoTorneo + ",BYE,,,");
            }
            UI.ListarPorTorneo = ListaUI;
        }

        #endregion
    }
}
