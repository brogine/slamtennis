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
        public enum Rondas : int
        {
            Primera_Ronda = 0, Segunda_Ronda = 1, Cuartos_Final = 2, Semi_Final = 3, Final = 4
        }
        Conexion Conn;

        public PartidoRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de IPartidoRepositorio

        public int Agregar(Partido Partido)
        {
            string FechaFormateada = Partido.Fecha.ToString("yyyyMMdd");
            int IdTorneo = Partido.Torneo.IdTorneo;
            string Resultado = Partido.Resultado;
            string Ronda = Partido.Ronda;
            bool Estado = Partido.Estado;
            int Equipo1 = Partido.Equipo1.IdInscripcion;
            int IdPartido = Conn.Agregar("Partidos", "IdTorneo,Resultado,Fecha,Ronda,Estado", IdTorneo + ",'" + Resultado + "','" + FechaFormateada + "','" + Ronda + "'," + (Estado ? 1 : 0));
            if (Partido.Equipo2 != null)
            {
                int Equipo2 = Partido.Equipo2.IdInscripcion;
                Conn.AgregarSinId("PartidoInscripcion", "IdPartido,IdInscripcion", IdPartido + "," + Equipo2);
            }
            
            Conn.AgregarSinId("PartidoInscripcion", "IdPartido,IdInscripcion", IdPartido + "," + Equipo1);
            
            
            return IdPartido;
        }

        public void Modificar(Partido Partido)
        {
            IEstadisticaRepositorio EstRepo = new EstadisticaRepositorio();
            IInscripcionRepositorio InscRepo = new InscripcionRepositorio();
            string FechaFormateada = Partido.Fecha.ToString("yyyyMMdd");
            String Consulta = " Update Partidos Set ";
            Consulta += " Fecha = '" + FechaFormateada + "', ";
            Consulta += "Ronda ='" + Partido.Ronda+"',";
            Consulta += " Estado = " + (Partido.Estado ? 1 : 0);
            Consulta += " Where IdPartido = " + Partido.IdPartido;
            Conn.ActualizarOEliminar(Consulta);
            // Agrega A Cada Jugador Los Partidos Perdidos y Ganados Segun Corresponda. Si Lo Entendes Te Doy U$S 100
            Partido Part = this.Buscar(Partido.IdPartido);
            if (Part.Resultado != Partido.Resultado)
            {
                Consulta = " Update Partidos Set Resultado = '" + Partido.Resultado +"' Where IdPartido = " + Partido.IdPartido;
                Conn.ActualizarOEliminar(Consulta);
                //Asignacion De Puntos Y Partidos Ganados Y Perdidos
                
                if (Partido.Torneo.TipoTorneo == TipoTorneo.Single)
                {
                    //Busqueda Binaria
                    Estadisticas Est1Jug1 = Partido.Equipo1.Equipo.Jugador1.Estadisticas.Find(delegate(Estadisticas e)
                         {
                             return e.Categoria.Id == Partido.Torneo.Categoria.Id;
                         });

              
                        Estadisticas Est2Jug1 = Partido.Equipo2.Equipo.Jugador1.Estadisticas.Find(delegate(Estadisticas e)
                        {
                            return e.Categoria.Id == Partido.Torneo.Categoria.Id;
                        });
 
                    //Si El Ganador Del Partido Es El Equipo 1
                    if (Partido.CalcularGanador(Partido.Resultado) == 1)
                    {
                        //Sumo Partidos Perdidos Y Ganados
                        
                        Est1Jug1.PG += 1;
                        Est2Jug1.PP += 1;
                        Est2Jug1.TorneosJugados += 1;                       
                        //Asignacion De Puntos Por Ronda
                        AsignarPuntos(Est2Jug1, Partido);
                        //Asignacion De Puntos Campeon
                        if (InscRepo.ListarActivas(Partido.Torneo.IdTorneo).Count == 2)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (Partido.Torneo.ListaPuntos[i].Ronda == "Campeon")
                                {
                                    Est1Jug1.Puntaje += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                                    Est1Jug1.TorneosJugados += 1;
                                    Est1Jug1.TorneosCompletados += 1;
                                    Partido.Torneo.Estado = (int)EstadoTorneo.Finalizado;
                                    TorneoRepositorio TorRep = new TorneoRepositorio();
                                    TorRep.Modificar(Partido.Torneo);
                                }
                            }
                        }
                        //Alta al equipo Ganador
                        Partido.Equipo1.Estado = true;
                        InscRepo.Modificar(Partido.Equipo1);
                        Partido.Equipo2.Estado = false;
                        InscRepo.Modificar(Partido.Equipo2);
                    }
                    //Si El Ganador Del Partido Es El Equipo 2
                    else
                    {
                        Est1Jug1.PP += 1;
                        Est2Jug1.PG += 1;
                        Est1Jug1.TorneosJugados += 1;
                        AsignarPuntos(Est1Jug1, Partido);
                        //Asigancion De Puntos Campeon
                        if (InscRepo.ListarActivas(Partido.Torneo.IdTorneo).Count == 2)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (Partido.Torneo.ListaPuntos[i].Ronda == "Campeon")
                                {
                                    Est2Jug1.TorneosJugados += 1;
                                    Est2Jug1.TorneosCompletados += 1;
                                    Est2Jug1.Puntaje += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                                    Partido.Torneo.Estado = (int)EstadoTorneo.Finalizado;
                                    TorneoRepositorio TorRep = new TorneoRepositorio();
                                    TorRep.Modificar(Partido.Torneo);
                                }
                            }

                        }
                        //Doy de alta al equipo Ganador
                        Partido.Equipo2.Estado = true;
                        InscRepo.Modificar(Partido.Equipo2);
                        Partido.Equipo1.Estado = false;
                        InscRepo.Modificar(Partido.Equipo1);
                    }
                    EstRepo.Modificar(Partido.Equipo1.Equipo.Jugador1, Est1Jug1);
                    EstRepo.Modificar(Partido.Equipo2.Equipo.Jugador1, Est2Jug1);
                }
                //Si El Torneo Es Doble
                if (Partido.Torneo.TipoTorneo == TipoTorneo.Doble)
                {
                    Estadisticas Equipo1Jugador1 = Partido.Equipo1.Equipo.Jugador1.Estadisticas.Find(delegate(Estadisticas e)
                    {
                        return e.Categoria.Id == Partido.Torneo.Categoria.Id;
                    });
                    Estadisticas Equipo1Jugador2 = Partido.Equipo1.Equipo.Jugador2.Estadisticas.Find(delegate(Estadisticas e)
                    {
                        return e.Categoria.Id == Partido.Torneo.Categoria.Id;
                    });
                    Estadisticas Equipo2Jugador1 = Partido.Equipo2.Equipo.Jugador1.Estadisticas.Find(delegate(Estadisticas e)
                    {
                        return e.Categoria.Id == Partido.Torneo.Categoria.Id;
                    });
                    Estadisticas Equipo2Jugador2 = Partido.Equipo2.Equipo.Jugador2.Estadisticas.Find(delegate(Estadisticas e)
                    {
                        return e.Categoria.Id == Partido.Torneo.Categoria.Id;
                    }); 
                    //Calculo El Equipo Ganador
                    if (Partido.CalcularGanador(Partido.Resultado) == 1)
                    {
                        Equipo1Jugador1.PartidosGanadosDoble++;
                        Equipo1Jugador2.PartidosGanadosDoble++;
                        Equipo2Jugador1.PartidosPerdidosDoble++;
                        Equipo2Jugador2.PartidosPerdidosDoble++;
                        Equipo2Jugador1.TorneosJugadosDoble++;
                        Equipo2Jugador2.TorneosJugadosDoble++;
                        AsignarPuntosDobles(Equipo2Jugador1, Equipo2Jugador2, Partido);
                        if (InscRepo.ListarActivas(Partido.Torneo.IdTorneo).Count == 2)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (Partido.Torneo.ListaPuntos[i].Ronda == "Campeon")
                                {
                                    Equipo1Jugador1.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                                    Equipo1Jugador2.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                                    Equipo1Jugador1.TorneosJugadosDoble++;
                                    Equipo1Jugador2.TorneosJugadosDoble++;
                                    Equipo1Jugador1.TorneosCompletadosDoble++;
                                    Equipo1Jugador2.TorneosCompletadosDoble++;
                                    Partido.Torneo.Estado = (int)EstadoTorneo.Finalizado;
                                    TorneoRepositorio TorRep = new TorneoRepositorio();
                                    TorRep.Modificar(Partido.Torneo);
                                }
                            }

                        }
                        Partido.Equipo1.Estado = true;
                        InscRepo.Modificar(Partido.Equipo1);
                        Partido.Equipo2.Estado = false;
                        InscRepo.Modificar(Partido.Equipo2);
                    }
                    else
                    {
                        Equipo2Jugador1.PartidosGanadosDoble++;
                        Equipo2Jugador2.PartidosGanadosDoble++;
                        Equipo1Jugador1.PartidosPerdidosDoble++;
                        Equipo1Jugador2.PartidosPerdidosDoble++;
                        Equipo1Jugador1.TorneosJugadosDoble++;
                        Equipo1Jugador2.TorneosJugadosDoble++;
                        AsignarPuntosDobles(Equipo1Jugador1, Equipo1Jugador2, Partido);
                        if (InscRepo.ListarActivas(Partido.Torneo.IdTorneo).Count == 2)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (Partido.Torneo.ListaPuntos[i].Ronda == "Campeon")
                                {

                                    Equipo2Jugador1.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                                    Equipo2Jugador2.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                                    Equipo2Jugador1.TorneosJugadosDoble++;
                                    Equipo2Jugador2.TorneosJugadosDoble++;
                                    Equipo2Jugador1.TorneosCompletadosDoble++;
                                    Equipo2Jugador2.TorneosCompletadosDoble++;
                                    Partido.Torneo.Estado = (int)EstadoTorneo.Finalizado;
                                    TorneoRepositorio TorRep= new TorneoRepositorio();
                                    TorRep.Modificar(Partido.Torneo);
                                }
                            }

                        }
                        //Damos de alta a los Ganadores
                        Partido.Equipo2.Estado = true;
                        InscRepo.Modificar(Partido.Equipo2);
                        Partido.Equipo1.Estado = false;
                        InscRepo.Modificar(Partido.Equipo1);
                    }
                    EstRepo.Modificar(Partido.Equipo1.Equipo.Jugador1, Equipo1Jugador1);
                    EstRepo.Modificar(Partido.Equipo1.Equipo.Jugador2, Equipo1Jugador2);
                    EstRepo.Modificar(Partido.Equipo2.Equipo.Jugador1, Equipo2Jugador1);
                    EstRepo.Modificar(Partido.Equipo2.Equipo.Jugador2, Equipo2Jugador2);
                }
            }
        }

        public Partido Buscar(int IdPartido)
        {
            String Consulta = " select * from Partidos Par inner join PartidoInscripcion Pins on Par.IdPartido = Pins.IdPartido where Pins.IdPartido =  " + IdPartido;
            DataTable Dt = Conn.Listar(Consulta);
            Partido NuevoPartido = new Partido();
            for (int i = 0; i < Dt.Rows.Count; i++)
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
                string Ronda = Fila.IsNull("Ronda") ? string.Empty : Fila["Ronda"].ToString();
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

        private void AsignarPuntos(Estadisticas Estadistica, Partido Partido)
        {
            if (Convert.ToInt32(Partido.Ronda) == (int)Rondas.Primera_Ronda)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "R1")
                    {
                        Estadistica.Puntaje += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }
                }
            }
            if (Convert.ToInt32(Partido.Ronda) == (int)Rondas.Segunda_Ronda)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "R2")
                    {
                        Estadistica.Puntaje += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }
                }
            }
            
            if (Convert.ToInt32(Partido.Ronda) == (int)Rondas.Cuartos_Final)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "CF")
                    {
                        Estadistica.Puntaje += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }
                }
            }
            if (Convert.ToInt32(Partido.Ronda) == (int)Rondas.Semi_Final)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "SF")
                    {
                        Estadistica.Puntaje += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }
                }
            }
            if (Convert.ToInt32(Partido.Ronda) == (int)Rondas.Final)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "F")
                    {
                        Estadistica.Puntaje += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }
                }
            }
           
        
        }

        private void AsignarPuntosDobles(Estadisticas EstadisticaEquipo1,Estadisticas EstadisticaEquipo2, Partido Partido)
        {
            if (Partido.Ronda == Rondas.Primera_Ronda.ToString())
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "R1")
                    {
                        EstadisticaEquipo1.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                        EstadisticaEquipo2.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }

                }
            }
            if (Partido.Ronda == Rondas.Segunda_Ronda.ToString())
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "R2")
                    {
                        EstadisticaEquipo1.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                        EstadisticaEquipo2.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }

                }
            }
            if (Partido.Ronda == Rondas.Cuartos_Final.ToString())
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "CF")
                    {
                        EstadisticaEquipo1.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                        EstadisticaEquipo2.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }

                }
            }
            if (Partido.Ronda == Rondas.Semi_Final.ToString())
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "SF")
                    {
                        EstadisticaEquipo1.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                        EstadisticaEquipo2.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }

                }
            }
            if (Partido.Ronda == Rondas.Final.ToString())
            {
                for (int i = 0; i < 6; i++)
                {
                    if (Partido.Torneo.ListaPuntos[i].Ronda == "F")
                    {
                        EstadisticaEquipo1.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                        EstadisticaEquipo2.PuntajeDoble += Partido.Torneo.ListaPuntos[i].CantidadPuntos;
                    }

                }
            }

        
        }
    }
}
