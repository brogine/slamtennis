/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 06:58 p.m.
 * 
 */
using System;

namespace Servicio.InterfacesUI
{
	/// <summary>
	/// Description of IEstadisticasUI.
	/// </summary>
	public interface IEstadisticasUI
	{
		int Dni { get; set; }

        int PartidosJugados { set; }
		
		int PartidosGanados { get; set; }
		
		int PartidosPerdidos { get; set; }
		
		int IdCategoria { get; set; }
		
		int Puntos { get; set; }

        int TorneosCompletados { get; set; }

        int TorneosJugados { get; set; }
		
		bool Estado { get; set; }
	}
}
