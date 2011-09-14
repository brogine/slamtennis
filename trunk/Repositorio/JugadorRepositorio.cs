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
            Conn.AgregarSinId("Jugadores", "Dni,PartidosGanados,PartidosPerdidos,IdCategoria,Puntos,Estado", Jugador.Dni+",0,0,1,0,1");
        }

        public void Modificar(Jugador Jugador)
        {
            base.Modificar(Jugador);
        }

        public Jugador Buscar(int Dni)
        {
            string Consulta = " Select * From Personas P inner join ";
            Consulta += " Login L on P.Dni = L.Dni ";
            Consulta += " Where P.Dni = " + Dni;
            IEstadisticaRepositorio repoEstadisticas = new EstadisticaRepositorio();
            Jugador bJugador = this.Mapear(Conn.Buscar(Consulta));
            bJugador.Estadisticas = repoEstadisticas.ListarPorDni(Dni);
            return bJugador;
        }

        public List<Jugador> Listar(int IdClub)
        {
        	string Consulta = " select P.Dni, P.Nombre, P.Apellido, P.FechaNacimiento, p.Nacionalidad, p.Sexo, ";
            Consulta += " L.Usuario, L.Password, L.Estado ";
            Consulta += " from Jugadores J inner join Afiliaciones A ";
            Consulta += " on j.Dni = a.Dni inner join Personas P on P.Dni = J.Dni ";
            Consulta += " inner join Login L on P.Dni = L.Dni ";
            Consulta += " where a.IdClub= " + IdClub;
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
