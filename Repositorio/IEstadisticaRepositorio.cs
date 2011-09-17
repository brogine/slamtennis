/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 05/09/2011
 * Hora: 08:33 p.m.
 * 
 */
using System;
using System.Collections.Generic;
using Dominio;

namespace Repositorio
{
	/// <summary>
	/// Description of IEstadisticaRepositorio.
	/// </summary>
	public interface IEstadisticaRepositorio
	{
		void Agregar(Jugador Jugador, Estadisticas Estadistica);
		
		void Modificar(Jugador Jugador, Estadisticas Estadistica);
		
		Estadisticas Buscar(int Dni, int IdCategoria);

        bool Existe(int Dni, int IdCategoria);
		
		List<Estadisticas> ListarPorDni(int Dni);
		
		List<Estadisticas> ListarPorCategoria(int IdCategoria);
	}
}
