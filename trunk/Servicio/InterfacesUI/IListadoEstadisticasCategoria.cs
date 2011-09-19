/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 06:55 p.m.
 * 
 */
using System;
using System.Collections.Generic;

namespace Servicio.InterfacesUI
{
	/// <summary>
	/// Description of IListadoEstadisticas.
	/// </summary>
	public interface IListadoEstadisticasCategoria
	{
		List<Object> ListarEstadisticas { set; }

        int IdClub { get; }

		int IdCategoria { get; }
	}
}
