/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 07:37 p.m.
 * 
 */
using System;
using System.Collections.Generic;

namespace Servicio.InterfacesUI
{
	/// <summary>
	/// Description of IListadoEstadisticasDni.
	/// </summary>
	public interface IListadoEstadisticasDni
	{
		List<Object> ListarEstadisticas { set; }
		
		int DniJugador { get; }
	}
}
