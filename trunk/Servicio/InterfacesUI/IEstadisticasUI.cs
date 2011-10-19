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

        int PartidosJugadosDobles { set; }

        int PartidosGanadosDobles { get; set; }

        int PartidosPerdidosDobles { get; set; }

        int TorneosCompletadosDobles { get; set; }

        int TorneosJugadosDobles { get; set; }

        int PuntosDobles { get; set; }

		bool Estado { get; set; }
	}
}
