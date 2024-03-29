﻿using System;
using System.Collections.Generic;
using System.Data;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;

namespace Servicio
{
    public class TorneoServicio : ITorneoServicio, IListadoTorneoServicio,ILlaveTorneoServicio
    {
        ITorneoRepositorio TorneoRepo;
        public TorneoServicio()
        {
            TorneoRepo = new TorneoRepositorio();
        }

        #region Miembros de ITorneoServicio

        public int Agregar(ITorneoUI UI)
        {
            IClubRepositorio ClubRepo = new ClubRepositorio();
            ICategoriaRepositorio CatRepo = new CategoriaRepositorio();
            
            Club Club = ClubRepo.Buscar(UI.IdClub);
            Categoria Categoria = CatRepo.Buscar(UI.IdCategoria);
            string Nombre = UI.Nombre;
            string Sexo = UI.Sexo;
            TipoSuperficie Superficie = (TipoSuperficie)UI.Superficie;
            DateTime FechaInicio = UI.FechaInicio;
            DateTime FechaFin = UI.FechaFin;
            DateTime FechaFinInscripcion = UI.FechaFinInscripcion;
            DateTime FechaInicioInscripcion = UI.FechaInicioInscripcion;
            int Cupo = UI.Cupo;
            bool TipoInscripcion = UI.TipoInscripcion;
            TipoTorneo Tipo =(TipoTorneo) UI.Tipo;
            int Estado = UI.Estado;

            Torneo NuevoTorneo = new Torneo(Nombre, FechaInicio, FechaFin, FechaInicioInscripcion, FechaFinInscripcion, Cupo, Sexo, Tipo, Club, Categoria, TipoInscripcion, Superficie, Estado);
            return TorneoRepo.Agregar(NuevoTorneo);
        }

        public bool Existe(int IdTorneo)
        {
            ITorneoRepositorio TorneoRepo = new TorneoRepositorio();
            return TorneoRepo.Existe(IdTorneo);
        }

        public void Modificar(ITorneoUI UI)
        {
            IClubRepositorio ClubRepo = new ClubRepositorio();
            ICategoriaRepositorio CatRepo = new CategoriaRepositorio();
            Club Club = ClubRepo.Buscar(UI.IdClub);
            Categoria Cat = CatRepo.Buscar(UI.IdCategoria);
            Torneo Torneo = TorneoRepo.Buscar(UI.IdTorneo);
            Torneo.Nombre = UI.Nombre;
            Torneo.Cupo = UI.Cupo;
            Torneo.FechaInicio = UI.FechaInicio;
            Torneo.FechaFin = UI.FechaFin;
            Torneo.FechaInicioInscripcion = UI.FechaInicioInscripcion;
            Torneo.FechaFinInscripcion = UI.FechaFinInscripcion;
            Torneo.Sexo = UI.Sexo;
            Torneo.Superficie = (TipoSuperficie)UI.Superficie;
            Torneo.TipoInscripcion = UI.TipoInscripcion;
            Torneo.TipoTorneo = (TipoTorneo)UI.Tipo;
            Torneo.Club = Club;
            Torneo.Categoria = Cat;
            TorneoRepo.Modificar(Torneo);
        }

        public void EnviarEmailTorneo(int IdTorneo)
        {
            Torneo Torneo = TorneoRepo.Buscar(IdTorneo);
            IJugadorRepositorio jugadorrepo = new JugadorRepositorio();
            List<Jugador> listado = jugadorrepo.Listar(Torneo.Club.Id);
            string email = string.Empty;
            foreach (Jugador item in listado)
            {
                if (Torneo.Sexo == item.Sexo || Torneo.Sexo == "Mixto")
                {
                    if (item.Contacto.Email != string.Empty)
                    {
                        email += item.Contacto.Email + ",";
                    }
                }
            }
            if (email == string.Empty)
                return;
            Email enviaremail = new Email();
            enviaremail.Asunto = "Apertura de Torneo";
            enviaremail.EmailDestino = email.Substring(0, email.Length - 1);
            enviaremail.Prioridad = PrioridadEmail.Normal;
            enviaremail.Remitente = Torneo.Club.Nombre;
            enviaremail.IsHtml = true;
            System.IO.StreamReader sr = new System.IO.StreamReader("Torneo.html");
            string html = sr.ReadToEnd();
            html = html.Replace("##TORNEO##", Torneo.Nombre);
            html = html.Replace("##CLUB##", Torneo.Club.Nombre);
            html = html.Replace("##CATEGORIA##", Torneo.Categoria.Nombre);
            html = html.Replace("##TIPO##", Torneo.TipoTorneo.ToString());
            html = html.Replace("##SEXO##", Torneo.Sexo);
            html = html.Replace("##CUPO##", Torneo.Cupo.ToString());
            html = html.Replace("##SUPERFICIE##", Torneo.Superficie.ToString());
            html = html.Replace("##INSCRIPCION##", Torneo.FechaInicioInscripcion.ToShortDateString() + " - " + Torneo.FechaFinInscripcion.ToShortDateString());
            html = html.Replace("##FECHATORNEO##", Torneo.FechaInicio.ToShortDateString() + " - " + Torneo.FechaFin.ToShortDateString());
            enviaremail.Mensaje = html;
            enviaremail.Enviar();

        }

        public void Buscar(ITorneoUI UI)
        {
            Torneo Torneo = TorneoRepo.Buscar(UI.IdTorneo);
            UI.Nombre = Torneo.Nombre;
            UI.Cupo = Torneo.Cupo;
            UI.IdClub = Torneo.Club.Id;
            UI.IdCategoria = Torneo.Categoria.Id;            
            UI.FechaFinInscripcion = Torneo.FechaFinInscripcion;
            UI.FechaInicio = Torneo.FechaInicio;
            UI.FechaInicioInscripcion = Torneo.FechaInicioInscripcion;
            UI.Sexo = Torneo.Sexo;
            UI.Tipo =(int) Torneo.TipoTorneo;
            UI.TipoInscripcion = Torneo.TipoInscripcion;
            UI.Superficie = (int)Torneo.Superficie;
            UI.FechaFin = Torneo.FechaFin;
            UI.Estado = Torneo.Estado;
        }

        public int GetTipoTorneo(int IdTorneo)
        {
            return (int)TorneoRepo.GetTipoTorneo(IdTorneo);
        }

        public void Actualizar()
        {
            TorneoRepo.ActualizarTorneos();
        }

        #endregion

        #region Miembros de IListadoTorneoServicio

        public void Listar(IListadoTorneos UI)
        {
            List<Torneo> ListaTorneo = TorneoRepo.Listar();
            List<Object> Lista = new List<object>();
            foreach (Torneo Torneo in ListaTorneo)
            {
                Lista.Add(Torneo.IdTorneo + ","+Torneo.Club.Nombre+"," + Torneo.Nombre + "," + Torneo.Categoria.Nombre + "," + Torneo.Sexo + "," + Torneo.Cupo + "," + Torneo.FechaInicio.ToShortDateString() + "," + Torneo.FechaFin.ToShortDateString() + "," + Torneo.FechaInicioInscripcion.ToShortDateString() + "," + Torneo.FechaFinInscripcion.ToShortDateString() + "," + Torneo.TipoTorneo.ToString() + "," + (Torneo.TipoInscripcion == true ? "Abierto" : "Cerrado") + "," + Torneo.Estado);
            }
            
            UI.ListaUI = Lista;
        }

        public void ListarCerrados(IListadoTorneos UI)
        {
            List<Torneo> ListaTorneo = TorneoRepo.ListarCerrados();
            List<Object> Lista = new List<object>();
            foreach (Torneo Torneo in ListaTorneo)
            {
                Lista.Add(  Torneo.IdTorneo + "," + 
                            Torneo.Club.Nombre + "," + 
                            Torneo.Nombre + "," + 
                            Torneo.Categoria.Nombre + "," + 
                            Torneo.Sexo + "," + 
                            Torneo.Cupo + "," + 
                            Torneo.FechaInicio.ToShortDateString() + "," + 
                            Torneo.FechaFin.ToShortDateString() + "," + 
                            Torneo.FechaInicioInscripcion.ToShortDateString() + "," + 
                            Torneo.FechaFinInscripcion.ToShortDateString() + "," + 
                            Torneo.TipoTorneo.ToString() + "," + 
                            (Torneo.TipoInscripcion == true ? "Abierto" : "Cerrado") + "," + 
                            Torneo.Estado);
            }

            UI.ListaUI = Lista;
        }

        public void ListarAbiertos(IListadoTorneos UI)
        {
            List<Torneo> ListaTorneo = TorneoRepo.ListarAbiertos();
            List<Object> Lista = new List<object>();
            foreach (Torneo Torneo in ListaTorneo)
            {
                Lista.Add(Torneo.IdTorneo + "," + Torneo.Club.Nombre + "," + Torneo.Nombre + "," + Torneo.Categoria.Nombre + "," + Torneo.Sexo + "," + Torneo.Cupo + "," + Torneo.FechaInicio.ToShortDateString() + "," + Torneo.FechaFin.ToShortDateString() + "," + Torneo.FechaInicioInscripcion.ToShortDateString() + "," + Torneo.FechaFinInscripcion.ToShortDateString() + "," + Torneo.TipoTorneo.ToString() + "," + (Torneo.TipoInscripcion == true ? "Abierto" : "Cerrado") + "," + Torneo.Estado);
            }

            UI.ListaUI = Lista;
        }

        #endregion

        #region ITorneoServicio Members


        public void GetFechas(IFechasTorneoUI ui)
        {
            TorneoRepo = new TorneoRepositorio();
            Torneo ret = TorneoRepo.Buscar(ui.IdTorneo);
            ui.Nombre = ret.Nombre;
            ui.FechaInicio = ret.FechaInicio;
            ui.FechaFinInscripcion = ret.FechaFinInscripcion;
            ui.Estado = ret.Estado;
            ui.FechaFin = ret.FechaFin;
            ui.FechaInicioInscripcion = ret.FechaInicioInscripcion;
            
        }

        #endregion

        #region ILlaveTorneoService Members

        public System.Data.DataSet GetDatosPartido(int idtorneo)
        {
            DataSet Ds = new DataSet();
            Torneo torneo = TorneoRepo.Buscar(idtorneo);
            IPartidoRepositorio partidorepo = new PartidoRepositorio();
            List<Partido> listado = partidorepo.Listar(idtorneo);
            DataTable DtTorneo = new DataTable("Datos");
            DtTorneo.Columns.Add("Categoria");
            DtTorneo.Columns.Add("Torneo");
            DtTorneo.Columns.Add("Club");
            DtTorneo.Columns.Add("FechaInicio");
            DtTorneo.Columns.Add("FechaFin");
            //Tabla de Torneos
            DtTorneo.Rows.Add(torneo.Categoria.Nombre, torneo.Nombre, torneo.Club.Nombre,
                torneo.FechaInicio.ToShortDateString(), torneo.FechaFin.ToShortDateString());
            Ds.Tables.Add(DtTorneo);

            //Tabla Partidos
            DataTable DtPartido = new DataTable("Partido");
            DtPartido.Columns.Add("Equipo1");
            DtPartido.Columns.Add("Equipo2");
            DtPartido.Columns.Add("Resultado");
            DtPartido.Columns.Add("Ronda");
            DtPartido.Columns.Add("Ganador");
            DtPartido.Columns.Add("Fecha");
            
            foreach (Partido item in listado)
            {
                string ResultadoTemp = item.Resultado.Replace("/", "").Replace("-","").Trim();
                int Ganador = 0;
                string EquipoGanador = "";
                if (ResultadoTemp != "")
                    Ganador = item.CalcularGanador(item.Resultado);

                DtPartido.BeginLoadData();
                if (torneo.TipoTorneo == TipoTorneo.Doble)
                {
                    if (Ganador == 1)
                    {
                        EquipoGanador = item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre + " - " +
                            item.Equipo1.Equipo.Jugador2.Apellido + " " + item.Equipo1.Equipo.Jugador2.Nombre;
                    }
                    else if (Ganador == 2)
                    {
                        EquipoGanador = item.Equipo2.Equipo.Jugador1.Apellido + " " + item.Equipo2.Equipo.Jugador1.Nombre + " - " +
                            item.Equipo2.Equipo.Jugador2.Apellido + " " + item.Equipo2.Equipo.Jugador2.Nombre;
                    }
                    if (item.Equipo2 != null)
                    {
                        DtPartido.Rows.Add(item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre + " - " +
                            item.Equipo1.Equipo.Jugador2.Apellido + " " + item.Equipo1.Equipo.Jugador2.Nombre,
                            item.Equipo2.Equipo.Jugador1.Apellido + " " + item.Equipo2.Equipo.Jugador1.Nombre + " - " +
                            item.Equipo2.Equipo.Jugador2.Apellido + " " + item.Equipo2.Equipo.Jugador2.Nombre,
                            (ResultadoTemp != "" ? item.Resultado : "No se jugó"), item.Ronda, EquipoGanador, item.Fecha.ToShortDateString());
                    }
                    else
                    {
                        EquipoGanador = item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre + " - " +
                            item.Equipo1.Equipo.Jugador2.Apellido + " " + item.Equipo1.Equipo.Jugador2.Nombre;
                        DtPartido.Rows.Add(item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre,
                            item.Equipo1.Equipo.Jugador2.Apellido + " " + item.Equipo1.Equipo.Jugador2.Nombre,
                            "BYE", " ",
                            (ResultadoTemp != "" ? item.Resultado : "No se jugó"), item.Ronda, EquipoGanador, item.Fecha.ToShortDateString());
                    }
                }
                else
                {
                    if (Ganador == 1)
                    {
                        EquipoGanador = item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre;
                    }
                    else if(Ganador == 2)
                    {
                        EquipoGanador = item.Equipo2.Equipo.Jugador1.Apellido + " " + item.Equipo2.Equipo.Jugador1.Nombre;
                    }
                    if (item.Equipo2 != null)
                    {
                        DtPartido.Rows.Add(item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre,
                            item.Equipo2.Equipo.Jugador1.Apellido + " " + item.Equipo2.Equipo.Jugador1.Nombre,
                            (ResultadoTemp != "" ? item.Resultado : "No se jugó"), item.Ronda, EquipoGanador, item.Fecha.ToShortDateString());
                    }
                    else
                    {
                        EquipoGanador = item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre;
                        DtPartido.Rows.Add(item.Equipo1.Equipo.Jugador1.Apellido + " " + item.Equipo1.Equipo.Jugador1.Nombre,
                            "BYE", (ResultadoTemp != "" ? item.Resultado : "No se jugó"), item.Ronda, EquipoGanador, item.Fecha.ToShortDateString());
                    }
                }
                DtPartido.EndLoadData();
            }

            Ds.Tables.Add(DtPartido);
            return Ds;
        }

        #endregion
    }
}
