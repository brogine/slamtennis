using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    public class JugadorRepositorio : PersonaRepositorio, IMapeador<Jugador>, IJugadorRepositorio
    {
        Conexion Conn;
        public JugadorRepositorio()
            : base()
        {
            Conn = new Conexion();
        }

        #region Miembros de IJugadorRepositorio

        public void Agregar(Jugador Jugador)
        {
            base.Agregar(Jugador);
        }

        public void Modificar(Jugador Jugador)
        {
            base.Modificar(Jugador);
        }

        public Jugador Buscar(int Dni)
        {
            string Consulta = " Select * From Personas Where Dni = " + Dni;
            IEstadisticaRepositorio repoEstadisticas = new EstadisticaRepositorio();
            Jugador bJugador = this.Mapear(Conn.Buscar(Consulta));
            bJugador.Estadisticas = repoEstadisticas.ListarPorDni(Dni);
            return bJugador;
        }

        public List<Jugador> Listar(int IdClub)
        {
        	string Consulta = " Select * From Personas";
        	List<Jugador> ListaJugadores = new List<Jugador>();
        	IEstadisticaRepositorio repoEstadisticas = new EstadisticaRepositorio();
        	DataTable Tabla = Conn.Listar(Consulta);
        	foreach (DataRow Fila in Tabla.Rows) {
        		Jugador Jugador = this.Mapear(Fila);
        		Jugador.Estadisticas = repoEstadisticas.ListarPorDni(Jugador.Dni);
        		ListaJugadores.Add(Jugador);
        	}
        	return ListaJugadores;
        }

        #endregion

        #region Miembros de IMapeador<Jugador>

        public Jugador Mapear(System.Data.DataRow Fila)
        {
            Jugador nJugador = null;

            if (Fila != null)
            {
                nJugador = new Jugador();
                nJugador = base.MapearDatosPersonales(Fila, nJugador) as Jugador;
                
                if (nJugador.Edad < 18)
                {
                    nJugador.DniTutor = (Fila.IsNull("DniTutor") == true ? 0 : Convert.ToInt32(Fila["DniTutor"]));
                    nJugador.RelacionTutor = (Fila.IsNull("Relacion") == true ? string.Empty : Convert.ToString(Fila["Relacion"]));
                }
            }
            
            return nJugador;
        }

        #endregion
    }
}
