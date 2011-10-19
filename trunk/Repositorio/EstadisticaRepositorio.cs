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
            string Campos = "Dni, PartidosGanados, PartidosPerdidos, IdCategoria, Puntos, TorneosJugados, TorneosCompletados, Estado, PartidosGanadosDobles, PartidosPerdidosDobles, PuntosDobles, TorneosJugadosDobles, TorneosCompletadosDobles";
    		string Valores = Jugador.Dni + "," + Estadistica.PG + "," + Estadistica.PP +",";
            Valores += Estadistica.Categoria.Id + "," + Estadistica.Puntaje + "," + Estadistica.TorneosJugados + ",";
            Valores += Estadistica.TorneosCompletados + "," + (Estadistica.Estado ? 1 : 0) + ",";
            Valores += Estadistica.PartidosGanadosDoble + ",";
            Valores += Estadistica.PartidosPerdidosDoble + ",";
            Valores += Estadistica.PuntajeDoble + ",";
            Valores += Estadistica.TorneosJugadosDoble + ",";
            Valores += Estadistica.TorneosCompletadosDoble;
            try
            {
                Conn.AgregarSinId("Jugadores", Campos, Valores);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudieron agregar las estadisticas del jugador.", ex);
            }
    	}
    	
    	public void Modificar(Jugador Jugador, Estadisticas Estadistica) {
    		string Consulta = " Update Jugadores Set ";
    		Consulta += " PartidosGanados = " + Estadistica.PG + ",";
    		Consulta += " PartidosPerdidos = " + Estadistica.PP + ",";
    		Consulta += " Puntos = " + Estadistica.Puntaje + ",";
            Consulta += " TorneosJugados = " + Estadistica.TorneosJugados + ",";
            Consulta += " TorneosCompletados = " + Estadistica.TorneosCompletados + ",";
    		Consulta += " Estado = " + (Estadistica.Estado ? 1 : 0);
            Consulta += " PartidosGanadosDobles = " + Estadistica.PartidosGanadosDoble + ",";
            Consulta += " PartidosPerdidosDobles = " + Estadistica.PartidosPerdidosDoble + ",";
            Consulta += " PuntosDobles = " + Estadistica.PuntajeDoble + ",";
            Consulta += " TorneosJugadosDobles = " + Estadistica.TorneosJugadosDoble + ",";
            Consulta += " TorneosCompletadosDobles = " + Estadistica.TorneosCompletadosDoble + ",";
    		Consulta += " Where Dni = " + Jugador.Dni + " And IdCategoria = " + Estadistica.Categoria.Id;
            try
            {
                Conn.ActualizarOEliminar(Consulta);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudieron modificar las estadisticas del jugador.", ex);
            }
    	}
    	
    	public Estadisticas Buscar(int Dni, int IdCategoria){
    		String Consulta = " Select * From Jugadores Where Dni = ";
    		Consulta += Dni + " And IdCategoria = " + IdCategoria;
    		return this.Mapear(Conn.Buscar(Consulta));
    	}

        public bool Existe(int Dni, int IdCategoria)
        {
            string Consulta = " Select Count(*) From Jugadores Where Dni = ";
            Consulta += Dni + " And IdCategoria = " + IdCategoria;
            DataRow Fila = Conn.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
            if (cantidad == 1)
                return true;
            else
                return false;
        }
    	
    	public List<Estadisticas> ListarPorDni(int Dni){
    		string Consulta = " Select * From Jugadores Where Dni = " + Dni;
    		List<Estadisticas> ListaEstadisticas = new List<Estadisticas>();
    		DataTable Tabla = Conn.Listar(Consulta);
    		foreach (DataRow Fila in Tabla.Rows) {
    			ListaEstadisticas.Add(this.Mapear(Fila));
    		}
    		return ListaEstadisticas;
    	}
    	
    	public List<Estadisticas> ListarPorCategoria(int IdCategoria){
            string Consulta = " Select * From Jugadores Where IdCategoria = " + IdCategoria + " and estado = 1 Order By Puntos ";
    		List<Estadisticas> ListaEstadisticas = new List<Estadisticas>();
    		DataTable Tabla = Conn.Listar(Consulta);
            int i = 1;
    		foreach (DataRow Fila in Tabla.Rows) {
                ListaEstadisticas.Add(this.Mapear(Fila));
                i++;
    		}
    		return ListaEstadisticas;
    	}

        public List<Estadisticas> ListarPorCategoriaClub(int IdClub, int IdCategoria)
        { 
            string Consulta = " Select J.*";
            Consulta +=" from Jugadores J inner join Afiliaciones A ";
            Consulta += " on A.Dni = J.Dni inner join Categorias C ";
            Consulta += " on J.IdCategoria = C.IdCategoria where j.IdCategoria =" + IdCategoria + " and a.IdClub= "+IdClub;
            List<Estadisticas> ListaEstadisticas = new List<Estadisticas>();
            DataTable Tabla = Conn.Listar(Consulta);
            foreach (DataRow Fila in Tabla.Rows)
            {
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
                ICategoriaRepositorio repoCategorias = new CategoriaRepositorio();
                Categoria bCategoria = repoCategorias.Buscar(Fila.IsNull("IdCategoria") ? 0 : Convert.ToInt32(Fila["IdCategoria"]));
                int Dni = Fila.IsNull("Dni") ? 0 : Convert.ToInt32(Fila["Dni"]);
                int PartidosPerdidos = Fila.IsNull("PartidosPerdidos") ? 0 : Convert.ToInt32(Fila["PartidosPerdidos"]);
                int PartidosGanados = Fila.IsNull("PartidosGanados") ? 0 : Convert.ToInt32(Fila["PartidosGanados"]);
                int PartidosJugados = PartidosGanados + PartidosPerdidos;
                int Puntos = Fila.IsNull("Puntos") ? 0 : Convert.ToInt32(Fila["Puntos"]);
                int TorneosCompletados = Fila.IsNull("TorneosCompletados") ? 0 : Convert.ToInt32(Fila["TorneosCompletados"]);
                int TorneosJugados = Fila.IsNull("TorneosJugados") ? 0 : Convert.ToInt32(Fila["TorneosJugados"]);
                bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                int PartidosPerdidosDoble = Fila.IsNull("PartidosPerdidosDobles") ? 0 : Convert.ToInt32(Fila["PartidosPerdidosDobles"]);
                int PartidosGanadosDoble = Fila.IsNull("PartidosGanadosDobles") ? 0 : Convert.ToInt32(Fila["PartidosGanadosDobles"]);
                int PartidosJugadosDoble = PartidosGanadosDoble + PartidosPerdidosDoble;
                int PuntosDoble = Fila.IsNull("PuntosDobles") ? 0 : Convert.ToInt32(Fila["PuntosDobles"]);
                int TorneosCompletadosDoble = Fila.IsNull("TorneosCompletadosDobles") ? 0 : Convert.ToInt32(Fila["TorneosCompletadosDobles"]);
                int TorneosJugadosDoble = Fila.IsNull("TorneosJugadosDobles") ? 0 : Convert.ToInt32(Fila["TorneosJugadosDobles"]);
                Estadistica = new Estadisticas(Dni, bCategoria, PartidosJugados, PartidosPerdidos, PartidosGanados,
                    Puntos,TorneosCompletados, TorneosJugados,PartidosJugadosDoble,PartidosPerdidosDoble,PartidosGanadosDoble,PuntosDoble,TorneosCompletadosDoble,TorneosJugadosDoble, Estado);
            }
            return Estadistica;
        }

        #endregion

        #region Miembros de IEstadisticaRepositorio


        public void AgregarDoble(Jugador Jugador, Estadisticas Estadistica)
        {
            string Campos = "Dni, PartidosGanadosDobles, PartidosPerdidosDobles, IdCategoria, PuntosDobles, TorneosJugadosDobles, TorneosCompletadosDobles, Estado";
            string Valores = Jugador.Dni + "," + Estadistica.PartidosGanadosDoble + "," + Estadistica.PartidosPerdidosDoble + ",";
            Valores += Estadistica.Categoria.Id + "," + Estadistica.PuntajeDoble + "," + Estadistica.TorneosJugadosDoble + ",";
            Valores += Estadistica.TorneosCompletadosDoble + "," + (Estadistica.Estado ? 1 : 0);
            try
            {
                Conn.AgregarSinId("Jugadores", Campos, Valores);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudieron agregar las estadisticas del jugador.", ex);
            }
        }

        #endregion
    }
}
