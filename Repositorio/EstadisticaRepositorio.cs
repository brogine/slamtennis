using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Dominio;
using Repositorio.Conexiones;

namespace Repositorio
{
    public class EstadisticaRepositorio : IEstadisticaRepositorio, IMapeador<Estadisticas>
    {
    	Conexion Conn;
    	public EstadisticaRepositorio(){
    		Conn = new Conexion();
    	}
    	
    	#region Miembros de IEstadisticaRepositorio
    	
        public void Agregar(Jugador Jugador, Estadisticas Estadistica) {
    		string Campos = "Dni, PartidosGanados, PartidosPerdidos, IdCategoria, Puntos, Estado";
    		string Valores = Jugador.Dni + "," + Estadistica.PG + "," + Estadistica.PP +",";
    		Valores += Estadistica.Categoria.Id + "," + Estadistica.Puntaje + "," + (Estadistica.Estado ? 1 : 0);
    		Conn.AgregarSinId("JugadorCategoria", Campos, Valores);
    	}
    	
    	public void Modificar(Jugador Jugador, Estadisticas Estadistica) {
    		string Consulta = " Update JugadorCategoria Set ";
    		Consulta += " PartidosGanados = " + Estadistica.PG + ",";
    		Consulta += " PartidosPerdidos = " + Estadistica.PP + ",";
    		Consulta += " Puntos = " + Estadistica.Puntaje + ",";
    		Consulta += " Estado = " + (Estadistica.Estado ? 1 : 0);
    		Consulta += " Where Dni = " + Jugador.Dni + " And IdCategoria = " + Estadistica.Categoria.Id;
    		Conn.ActualizarOEliminar(Consulta);
    	}
    	
    	public Estadisticas Buscar(int Dni, int IdCategoria){
    		String Consulta = " Select * From JugadorCategoria Where Dni = ";
    		Consulta += Dni + " And IdCategoria = " + IdCategoria;
    		return this.Mapear(Conn.Buscar(Consulta));
    	}
    	
    	public List<Estadisticas> ListarPorDni(int Dni){
    		string Consulta = " Select * From JugadorCategoria Where Dni = " + Dni;
    		List<Estadisticas> ListaEstadisticas = new List<Estadisticas>();
    		DataTable Tabla = Conn.Listar(Consulta);
    		foreach (DataRow Fila in Tabla.Rows) {
    			ListaEstadisticas.Add(this.Mapear(Fila));
    		}
    		return ListaEstadisticas;
    	}
    	
    	public List<Estadisticas> ListarPorCategoria(int IdCategoria){
    		string Consulta = " Select * From JugadorCategoria Where IdCategoria = " + IdCategoria;
    		List<Estadisticas> ListaEstadisticas = new List<Estadisticas>();
    		DataTable Tabla = Conn.Listar(Consulta);
    		foreach (DataRow Fila in Tabla.Rows) {
    			ListaEstadisticas.Add(this.Mapear(Fila));
    		}
    		return ListaEstadisticas;
    	}
    	
    	#endregion

        #region Miembros de IMapeador<Estadisticas>

        public Estadisticas Mapear(DataRow Fila)
        {
        	Estadisticas Estadistica = null;
            if (Fila != null)
            {
                //Categoria repo 
                Categoria bCategoria = null; //TODO: Traer categoria por repo
                int Dni = Fila.IsNull("Dni") ? 0 : Convert.ToInt32(Fila["Dni"]);
                int PartidosPerdidos = Fila.IsNull("PartidosPerdidos") ? 0 : Convert.ToInt32(Fila["PartidosPerdidos"]);
                int PartidosGanados = Fila.IsNull("PartidosGanados") ? 0 : Convert.ToInt32(Fila["PartidosGanados"]);
                int Puntos = Fila.IsNull("Puntos") ? 0 : Convert.ToInt32(Fila["Puntos"]);
                bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                Estadistica = new Estadisticas(bCategoria, PartidosPerdidos, PartidosGanados,
                    Puntos, Estado);
            }
            return Estadistica;
        }

        #endregion
    }
}
