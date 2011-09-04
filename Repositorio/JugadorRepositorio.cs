using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;

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
            string Campos = "Dni, PartidosGanados, PartidosPerdidos, IdCategoria, Puntos, Estado";
            string Valores = Jugador.Dni + "," + Jugador.Estadisticas[0].PG + "," + Jugador.Estadisticas[0].PP;
            Valores += "," + Jugador.Estadisticas[0].Categoria.Id + "," + Jugador.Estadisticas[0].Puntaje;
            Valores += "," + (Jugador.Estadisticas[0].Estado ? 1 : 0);
            Conn.AgregarSinId("JugadorCategoria", Campos, Valores);
        }

        public void Modificar(Jugador Jugador)
        {
            base.Agregar(Jugador);
            string Consulta = " Update JugadorCategoria Set ";
            Consulta += " PartidosGanados = " + Jugador.Estadisticas[0].PG;
            Consulta += " PartidosPerdidos = " + Jugador.Estadisticas[0].PP;
            Consulta += " Puntos = " + Jugador.Estadisticas[0].Puntaje;
            Consulta += " Estado = " + (Jugador.Estadisticas[0].Estado ? 1 : 0);
            Conn.ActualizarOEliminar(Consulta);
        }

        public Jugador Buscar(int Dni)
        {
            throw new NotImplementedException();
        }

        public List<Jugador> Listar()
        {
            throw new NotImplementedException();
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
                //mapear datos de estadisticas
            }
            
            return nJugador;
        }

        #endregion
    }
}
