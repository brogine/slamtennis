﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;

namespace Servicio
{
   public class PartidoServicio:IPartidoServicio,IListadoPartidoServicio
    {
       
        IInscripcionRepositorio InscRepo;
            ITorneoRepositorio TornRepo;
            IPartidoRepositorio PartidoRepo;

            public PartidoServicio()
            {
                 InscRepo = new InscripcionRepositorio();
                 TornRepo = new TorneoRepositorio();
                 PartidoRepo = new PartidoRepositorio();
            }
        #region Miembros de IPartidoServicio

        public void Agregar(IPartidoUI UI)
        {
            Inscripcion Equipo1 = InscRepo.Buscar(UI.IdEquipo1);
            Inscripcion Equipo2 = InscRepo.Buscar(UI.IdEquipo2);
            Torneo Torneo = TornRepo.Buscar(UI.IdTorneo);

            Partido Partido = new Partido(Torneo, Equipo1, Equipo2, UI.Fecha, UI.Resultado, UI.Ronda, UI.Estado);
        }

        public void Modificar(IPartidoUI UI)
        {
           Partido Partido = PartidoRepo.Buscar(UI.IdPartido);
           Partido.Resultado = UI.Resultado;
           Partido.Fecha = UI.Fecha;
           Partido.Estado = UI.Estado;
           PartidoRepo.Modificar(Partido);
        }

        public void Buscar(IPartidoUI UI)
        {
            Partido Partido = PartidoRepo.Buscar(UI.IdPartido);
            UI.Estado = Partido.Estado;
            UI.IdEquipo1 = Partido.Equipo1.IdInscripcion;
            UI.IdEquipo2 = Partido.Equipo2.IdInscripcion;
            UI.Fecha = Partido.Fecha;
            UI.Resultado = Partido.Resultado;
            UI.Ronda = Partido.Ronda;
        }

        #endregion



        #region Miembros de IListadoPartidoServicio

        public void ListarPartidos(IListadoPartidos UI)
        {

            List<Partido> Lista = PartidoRepo.Listar(UI.IdTorneo);
            List<Object> ListaObjeto = new List<object>();

            foreach (Partido Partido in Lista)
            {
                object Objeto = new object();
                Objeto = Partido.Equipo1.Equipo.Jugador1.Apellido +" - "+ Partido.Equipo1.Equipo.Jugador2.Apellido+",";
                Objeto = Partido.Equipo2.Equipo.Jugador1.Apellido + " - " + Partido.Equipo2.Equipo.Jugador2.Apellido + ",";
                Objeto += Partido.Fecha + ",";
                Objeto += Partido.Ronda +",";
                Objeto += Partido.Resultado;
                ListaObjeto.Add(Objeto);
            }
            UI.ListarPartidos = ListaObjeto;
        }

        #endregion
    }
}
