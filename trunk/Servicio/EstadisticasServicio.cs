/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 07:01 p.m.
 * 
 */
using System;
using System.Collections.Generic;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;

namespace Servicio
{
	/// <summary>
	/// Description of EstadisticasServicio.
	/// </summary>
	public class EstadisticasServicio : IEstadisticasServicio, IListadoEstadisticasServicio
	{
		IEstadisticaRepositorio repoEstadisticas;
		public EstadisticasServicio()
		{
			repoEstadisticas = new EstadisticaRepositorio();
		}
		
		#region Miembros de IEstadisticasServicio
		
		public void Agregar(IEstadisticasUI ui)
		{
			IJugadorRepositorio repoJugadores = new JugadorRepositorio();
			Jugador bJugador = repoJugadores.Buscar(ui.Dni);
			ICategoriaRepositorio CatRepo = new CategoriaRepositorio();
			
            Categoria bCategoria = CatRepo.Buscar(ui.IdCategoria);

            Estadisticas nEstadistica = new Estadisticas(0, bCategoria, 0, ui.PartidosPerdidos,
			                                             ui.PartidosGanados, ui.Puntos, ui.TorneosCompletados,
                                                         ui.TorneosJugados, ui.Estado);
			
			repoEstadisticas.Agregar(bJugador, nEstadistica);
		}
		
		public void Modificar(IEstadisticasUI ui)
		{
			Estadisticas bEstadistica = repoEstadisticas.Buscar(ui.Dni, ui.IdCategoria);
			bEstadistica.PG = ui.PartidosGanados;
			bEstadistica.PP = ui.PartidosPerdidos;
			bEstadistica.Puntaje = ui.Puntos;
			bEstadistica.Estado = ui.Estado;
            bEstadistica.TorneosCompletados = ui.TorneosCompletados;
            bEstadistica.TorneosJugados = ui.TorneosJugados;
			
			IJugadorRepositorio repoJugadores = new JugadorRepositorio();
			Jugador bJugador = repoJugadores.Buscar(ui.Dni);
			
			repoEstadisticas.Modificar(bJugador, bEstadistica);
		}

        public bool Existe(IEstadisticasUI ui)
        {
            return repoEstadisticas.Existe(ui.Dni, ui.IdCategoria);
        }
		
		public void Buscar(IEstadisticasUI ui)
		{
			Estadisticas bEstadistica = repoEstadisticas.Buscar(ui.Dni, ui.IdCategoria);
            if (bEstadistica != null)
            {
                ui.Estado = bEstadistica.Estado;
                ui.PartidosGanados = bEstadistica.PG;
                ui.PartidosPerdidos = bEstadistica.PP;
                ui.PartidosJugados = bEstadistica.PJ;
                ui.TorneosCompletados = bEstadistica.TorneosCompletados;
                ui.TorneosJugados = bEstadistica.TorneosJugados;
                ui.Puntos = bEstadistica.Puntaje;
            }
		}
		
		#endregion
		
		#region Miembros de IListadoEstadisticasServicio
		
		/// <summary>
		/// Lista las Estadísticas de todos los jugadores en una Categoría
		/// (Principalmente para reportes)
		/// </summary>
		/// <param name="ui"></param>
		public void ListarPorCategoria(IListadoEstadisticasCategoria ui)
		{
			List<Estadisticas> ListaEstadisticas = repoEstadisticas.ListarPorCategoria(ui.IdCategoria);
			IJugadorRepositorio repoJugadores = new JugadorRepositorio();
			List<Object> ListaUI = new List<object>();
            int i = 1;
			foreach (Estadisticas Estadistica in ListaEstadisticas) {
				Object Objeto = new object();
				Jugador tempJugador = repoJugadores.Buscar(Estadistica.Dni);
                Objeto = tempJugador.Dni + ",";
				Objeto += tempJugador.Apellido + " " + tempJugador.Nombre + ",";
				Objeto += Estadistica.PJ + "," + Estadistica.PG + "," + Estadistica.PP + ",";
                Objeto += Estadistica.TorneosJugados + "," + Estadistica.TorneosCompletados + ",";
				Objeto += Estadistica.Puntaje.ToString() + ",";
                Objeto += i.ToString();
				ListaUI.Add(Objeto);
                i++;
			}
			ui.ListarEstadisticas = ListaUI;
		}

        public void ListarPorCategoriaClub(IListadoEstadisticasCategoria ui)
        {
            List<Estadisticas> ListaEstadisticas = repoEstadisticas.ListarPorCategoriaClub(ui.IdClub, ui.IdCategoria);
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            List<Object> ListaUI = new List<object>();
            foreach (Estadisticas Estadistica in ListaEstadisticas)
            {
                Object Objeto = new object();
                Jugador tempJugador = repoJugadores.Buscar(Estadistica.Dni);
                Objeto = tempJugador.Dni + ",";
                Objeto += tempJugador.Apellido + " " + tempJugador.Nombre + ",";
                Objeto += Estadistica.PJ + "," + Estadistica.PG + "," + Estadistica.PP + ",";
                Objeto += Estadistica.TorneosJugados + "," + Estadistica.TorneosCompletados + ",";
                Objeto += Estadistica.Puntaje.ToString();
                ListaUI.Add(Objeto);
            }
            ui.ListarEstadisticas = ListaUI;
        }

		public void ListarPorDni(IListadoEstadisticasDni ui){
			List<Estadisticas> ListaEstadisticas = repoEstadisticas.ListarPorDni(ui.DniJugador);
			List<Object> ListaUI = new List<object>();
			foreach (Estadisticas Estadistica in ListaEstadisticas) {
                Object Objeto = new object();
                Objeto = Estadistica.PJ + "," + Estadistica.PG + "," + Estadistica.PP + ",";
                Objeto += Estadistica.TorneosJugados + "," + Estadistica.TorneosCompletados + ",";
                Objeto += Estadistica.Puntaje.ToString();
                ListaUI.Add(Objeto);
			}
			ui.ListarEstadisticas = ListaUI;
		}
		
		#endregion



        #region Miembros de IListadoEstadisticasServicio


        public void ListarPorCategoriaDobles(IListadoEstadisticasCategoria ui)
        {
            List<Estadisticas> ListaEstadisticas = repoEstadisticas.ListarPorCategoria(ui.IdCategoria);
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            List<Object> ListaUI = new List<object>();
            int i = 1;
            foreach (Estadisticas Estadistica in ListaEstadisticas)
            {
                Object Objeto = new object();
                Jugador tempJugador = repoJugadores.Buscar(Estadistica.Dni);
                Objeto = tempJugador.Dni + ",";
                Objeto += tempJugador.Apellido + " " + tempJugador.Nombre + ",";
                Objeto += Estadistica.PartidosJugadosDoble + "," + Estadistica.PartidosGanadosDoble + "," + Estadistica.PartidosPerdidosDoble + ",";
                Objeto += Estadistica.TorneosJugadosDoble + "," + Estadistica.TorneosCompletadosDoble + ",";
                Objeto += Estadistica.PuntajeDoble.ToString() + ",";
                Objeto += i.ToString();
                ListaUI.Add(Objeto);
                i++;
            }
            ui.ListarEstadisticas = ListaUI;
        }

        public void ListarPorCategoriaClubDobles(IListadoEstadisticasCategoria ui)
        {
            List<Estadisticas> ListaEstadisticas = repoEstadisticas.ListarPorCategoriaClub(ui.IdClub, ui.IdCategoria);
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            List<Object> ListaUI = new List<object>();
            foreach (Estadisticas Estadistica in ListaEstadisticas)
            {
                Object Objeto = new object();
                Jugador tempJugador = repoJugadores.Buscar(Estadistica.Dni);
                Objeto = tempJugador.Dni + ",";
                Objeto += tempJugador.Apellido + " " + tempJugador.Nombre + ",";
                Objeto += Estadistica.PartidosJugadosDoble + "," + Estadistica.PartidosGanadosDoble + "," + Estadistica.PartidosPerdidosDoble + ",";
                Objeto += Estadistica.TorneosJugadosDoble + "," + Estadistica.TorneosCompletadosDoble + ",";
                Objeto += Estadistica.PuntajeDoble.ToString();
                ListaUI.Add(Objeto);
            }
            ui.ListarEstadisticas = ListaUI;
        }

        public void ListarPorDniDobles(IListadoEstadisticasDni ui)
        {
            List<Estadisticas> ListaEstadisticas = repoEstadisticas.ListarPorDni(ui.DniJugador);
            List<Object> ListaUI = new List<object>();
            foreach (Estadisticas Estadistica in ListaEstadisticas)
            {
                Object Objeto = new object();
                Objeto = Estadistica.PartidosJugadosDoble + "," + Estadistica.PartidosGanadosDoble + "," + Estadistica.PartidosGanadosDoble + ",";
                Objeto += Estadistica.TorneosJugadosDoble + "," + Estadistica.TorneosCompletadosDoble + ",";
                Objeto += Estadistica.PuntajeDoble.ToString();
                ListaUI.Add(Objeto);
            }
            ui.ListarEstadisticas = ListaUI;
        }

        #endregion
    }
}
