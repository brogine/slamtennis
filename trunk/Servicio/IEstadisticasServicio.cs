/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 06:58 p.m.
 * 
 */
using System;
using Servicio.InterfacesUI;

namespace Servicio
{
	/// <summary>
	/// Description of IEstadisticasServicio.
	/// </summary>
	public interface IEstadisticasServicio
	{
		void Agregar(IEstadisticasUI ui);
		
		void Modificar(IEstadisticasUI ui);
		
		void Buscar(IEstadisticasUI ui);
	}
}
