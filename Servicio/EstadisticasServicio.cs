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
			
			//TODO: Repo Categorias por Id
			Categoria bCategoria = new Categoria();
			
			Estadisticas nEstadistica = new Estadisticas(bCategoria, ui.PartidosPerdidos,
			                                             ui.PartidosGanados, ui.Puntos, ui.Estado);
			
			repoEstadisticas.Agregar(bJugador, nEstadistica);
		}
		
		public void Modificar(IEstadisticasUI ui)
		{
			Estadisticas bEstadistica = repoEstadisticas.Buscar(ui.Dni, ui.IdCategoria);
			bEstadistica.PG = ui.PartidosGanados;
			bEstadistica.PP = ui.PartidosPerdidos;
			bEstadistica.Puntaje = ui.Puntos;
			bEstadistica.Estado = ui.Estado;
			
			IJugadorRepositorio repoJugadores = new JugadorRepositorio();
			Jugador bJugador = repoJugadores.Buscar(ui.Dni);
			
			repoEstadisticas.Modificar(bJugador, bEstadistica);
		}
		
		public void Buscar(IEstadisticasUI ui)
		{
			Estadisticas bEstadistica = repoEstadisticas.Buscar(ui.Dni, ui.IdCategoria);
			ui.Estado = bEstadistica.Estado;
			ui.PartidosGanados = bEstadistica.PG;
			ui.PartidosPerdidos = bEstadistica.PP;
			ui.PartidosJugados = bEstadistica.PJ;
			ui.Puntos = bEstadistica.Puntaje;
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
			foreach (Estadisticas Estadistica in ListaEstadisticas) {
				Object Objeto = new object();
				Jugador tempJugador = repoJugadores.Buscar(Estadistica.Dni);
				Objeto = tempJugador.Apellido + " " + tempJugador.Nombre + ",";
				Objeto += Estadistica.PJ + "," + Estadistica.PG + "," + Estadistica.PP + ",";
                Objeto += Estadistica.TorneosJugados + "," + Estadistica.TorneosCompletados + ",";
				Objeto += Estadistica.Puntaje + "," + Estadistica.Categoria.Nombre;
				ListaUI.Add(Objeto);
			}
			ui.ListarEstadisticas = ListaUI;
		}

        public void ListarPorCategoriaClub(IListadoEstadisticasCategoria ui)
        {
            List<Estadisticas> ListaEstadisticas = null;
            IJugadorRepositorio repoJugadores = new JugadorRepositorio();
            List<Object> ListaUI = new List<object>();
            foreach (Estadisticas Estadistica in ListaEstadisticas)
            {
                Object Objeto = new object();
                Jugador tempJugador = repoJugadores.Buscar(Estadistica.Dni);
                Objeto = tempJugador.Apellido + " " + tempJugador.Nombre + ",";
                Objeto += Estadistica.PJ + "," + Estadistica.PG + "," + Estadistica.PP + ",";
                Objeto += Estadistica.TorneosJugados + "," + Estadistica.TorneosCompletados + ",";
                Objeto += Estadistica.Puntaje + "," + Estadistica.Categoria.Nombre;
            }
            ui.ListarEstadisticas = ListaUI;
        }

		public void ListarPorDni(IListadoEstadisticasDni ui){
			List<Estadisticas> ListaEstadisticas = repoEstadisticas.ListarPorDni(ui.DniJugador);
			List<Object> ListaUI = new List<object>();
			foreach (Estadisticas estadistica in ListaEstadisticas) {
				Object Objeto = new object();
				Objeto = estadistica.PJ + "," + estadistica.PG + "," + estadistica.PP + ",";
				Objeto += estadistica.Puntaje + "," + estadistica.Categoria.Nombre;
				ListaUI.Add(Objeto);
			}
			ui.ListarEstadisticas = ListaUI;
		}
		
		#endregion
	}
}
