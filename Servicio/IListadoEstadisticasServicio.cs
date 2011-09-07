/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 06:50 p.m.
 * 
 */
using System;
using Servicio.InterfacesUI;

namespace Servicio
{
	/// <summary>
	/// Description of IListadoEstadisticasServicio.
	/// </summary>
	public interface IListadoEstadisticasServicio
	{
		void ListarPorCategoria(IListadoEstadisticasCategoria ui);
		
		void ListarPorDni(IListadoEstadisticasDni ui);
	}
}
