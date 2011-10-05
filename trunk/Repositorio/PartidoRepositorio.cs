using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;
using System.Data;

namespace Repositorio
{
    public class PartidoRepositorio : IPartidoRepositorio, IMapeador<Partido>
    {
        Conexion Conn;
        public PartidoRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de IPartidoRepositorio

        public int Agregar(Partido Partido)
        {
            string FechaFormateada = Partido.Fecha.Year + "/" + Partido.Fecha.Month + "/" + Partido.Fecha.Day;
            int IdTorneo = Partido.Torneo.IdTorneo;
            string Resultado = Partido.Resultado;
            int Ronda = Partido.Ronda;
            bool Estado = Partido.Estado;
            int Equipo1 = Partido.Equipo1.IdInscripcion;
            int Equipo2 = Partido.Equipo2.IdInscripcion;

            int IdPartido = Conn.Agregar("Partidos", "IdTorneo,Resultado,Fecha,Ronda,Estado", IdTorneo + ",'" + Resultado + "','" + FechaFormateada + "'," + Ronda + "," + (Estado?1:0));
            Conn.AgregarSinId("PartidoInscripcion", "IdPartido,IdInscripcion", IdPartido + "," + Equipo1);
            Conn.AgregarSinId("PartidoInscripcion", "IdPartido,IdInscripcion", IdPartido + "," + Equipo2);
            return IdPartido;
        }

        public void Modificar(Partido Partido)
        {
            string FechaFormateada = Partido.Fecha.Year + "/" + Partido.Fecha.Month + "/" + Partido.Fecha.Day;
            String Consulta = " Update Partidos Set ";
            Consulta += " Resultado = '" + Partido.Resultado + "', ";
            Consulta += " Fecha = '" + FechaFormateada + "', ";
            Consulta += "Ronda =" + Partido.Ronda+",";
            Consulta += " Estado = " + (Partido.Estado ? 1 : 0);
            Consulta += " Where IdPartido = " + Partido.IdPartido;
            Conn.ActualizarOEliminar(Consulta);


        }

        public Partido Buscar(int IdPartido)
        {
            String Consulta = " select * from Partidos Par inner join PartidoInscripcion Pins on Par.IdPartido = Pins.IdPartido where Pins.IdPartido =  " + IdPartido;
            DataTable Dt = Conn.Listar(Consulta);
            Partido NuevoPartido = new Partido();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    NuevoPartido = this.Mapear(Dt.Rows[i]);
                }
                else
                {
                    IInscripcionRepositorio InscRepo = new InscripcionRepositorio();
                    Inscripcion Jugador2 = InscRepo.Buscar(Convert.ToInt32(Dt.Rows[i]["IdInscripcion"]));
                    NuevoPartido.Equipo2 = Jugador2;

                }
            }
            return NuevoPartido;
        }

        public bool Existe(int IdPartido)
        {
            string Consulta = " Select Count(*) From Partidos Where IdPartido = " + IdPartido;
            DataRow Fila = Conn.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
            if (cantidad == 1)
                return true;
            else
                return false;
        }
        public List<Partido> Listar(int IdTorneo)
        {
            String Consulta = " Select IdPartido From Partidos Where IdTorneo = " + IdTorneo;
            DataTable TablaPartidos = Conn.Listar(Consulta);
            List<Partido> ListaPartidos = new List<Partido>();
            foreach (DataRow Fila in TablaPartidos.Rows)
            {
                ListaPartidos.Add(this.Buscar(Convert.ToInt32(Fila["IdPartido"])));
            }
            return ListaPartidos;
        }

        #endregion

        #region Miembros de IMapeador<Partido>

        public Partido Mapear(DataRow Fila)
        {
            Partido nPartido = null;
            if (Fila != null)
            {
                int IdPartido = Fila.IsNull("IdPartido") ? 0 : Convert.ToInt32(Fila["IdPartido"]);
                ITorneoRepositorio repoTorneos = new TorneoRepositorio();
                Torneo bTorneo = Fila.IsNull("IdTorneo") ? null : repoTorneos.Buscar(Convert.ToInt32(Fila["IdTorneo"]));

                IInscripcionRepositorio repoInscripciones = new InscripcionRepositorio();
                Inscripcion Equipo1 = repoInscripciones.Buscar(Fila.IsNull("IdInscripcion") ? 0 : Convert.ToInt32(Fila["IdInscripcion"]));
                
                DateTime Fecha = Fila.IsNull("Fecha") ? DateTime.Now : Convert.ToDateTime(Fila["Fecha"]);
                string Resultado = Fila.IsNull("Resultado") ? string.Empty : Fila["Resultado"].ToString();
                int Ronda = Fila.IsNull("Ronda") ? 0 : Convert.ToInt32(Fila["Ronda"]);
                bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                nPartido = new Partido();
                nPartido.IdPartido = IdPartido;
                nPartido.Fecha = Fecha;
                nPartido.Estado = Estado;
                
                nPartido.Equipo1 = Equipo1;
                nPartido.Estado = Estado;
                nPartido.Resultado = Resultado;
                nPartido.Ronda = Ronda;
                nPartido.Torneo = bTorneo;
                
            }

                return nPartido;
            }

        #endregion
        }
    }
