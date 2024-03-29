﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    public class TorneoRepositorio : ITorneoRepositorio, IMapeador<Torneo>
    {
        Conexion Conex;

        #region Miembros de ITorneoRepositorio

        public TorneoRepositorio()
        {
            Conex = new Conexion();
        }
        
        public int Agregar(Torneo Torneo)
        {
            string FechaFormateadaInicio = Torneo.FechaInicio.ToString("yyyyMMdd");
            string FechaFormateadaFin = Torneo.FechaFin.ToString("yyyyMMdd");
            string FechaFormateadaInicioInscrip = Torneo.FechaInicioInscripcion.ToString("yyyyMMdd");
            string FechaFormateadaFinInscrip = Torneo.FechaFinInscripcion.ToString("yyyyMMdd");

            string valores = "'" + Torneo.Nombre + "','" + FechaFormateadaInicio + "','" + FechaFormateadaFin + "','" + FechaFormateadaInicioInscrip + "','" + FechaFormateadaFinInscrip + "',";
            valores += Torneo.Cupo + ",'" + Torneo.Sexo + "'," +(int) Torneo.TipoTorneo + "," + Torneo.Club.Id + "," + Torneo.Categoria.Id + "," +(Torneo.TipoInscripcion?1 :0)+ ",";
            valores += (int)Torneo.Superficie + "," +(int) Torneo.Estado;

            return Conex.Agregar("Torneos", "Nombre,FecInicio,FecFin,FecInicInsc,FecFinInsc,Cupo,Sexo,Tipo,IdClub,IdCategoria,TipoInscripcion,Superficie,Estado", valores);
        }

      
        public bool Existe(int IdTorneo)
        {
            String Consulta = " SELECT COUNT(*) from Torneos where IdTorneo = " + IdTorneo;
            
            DataRow Fila = Conex.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
            if (cantidad == 1)
                return true;
            else
                return false;
        }

        public void Modificar(Torneo Torneo)
        {
            string FechaFormateadaInicio = Torneo.FechaInicio.ToString("yyyyMMdd");
            string FechaFormateadaFin = Torneo.FechaFin.ToString("yyyyMMdd");
            string FechaFormateadaInicioInscrip = Torneo.FechaInicioInscripcion.ToString("yyyyMMdd");
            string FechaFormateadaFinInscrip = Torneo.FechaFinInscripcion.ToString("yyyyMMdd");

            string sql = "update Torneos set ";
            sql += "Nombre = '" + Torneo.Nombre + "'";
            sql += ",FecInicio = '" + FechaFormateadaInicio + "'";
            sql += ",FecFin = '" + FechaFormateadaFin + "'";
            sql += ",FecInicInsc = '" + FechaFormateadaInicioInscrip + "'";
            sql += ",FecFinInsc = '" + FechaFormateadaFinInscrip + "'";
            sql += ",Cupo = " + Torneo.Cupo;
            sql += ",Estado =" + (int)Torneo.Estado;
            sql += ",Sexo = '" + Torneo.Sexo + "'";
            sql += ",Tipo = " + (int)Torneo.TipoTorneo;
            sql += ",IdClub =" + Torneo.Club.Id;
            sql += ",IdCategoria =" + Torneo.Categoria.Id;
            sql += ",TipoInscripcion =" + (Torneo.TipoInscripcion?1:0);
            sql += ",Superficie =" + (int)Torneo.Superficie;
            
            sql += " where IdTorneo = " + Torneo.IdTorneo;
            Conex.ActualizarOEliminar(sql);
           

        }

        public Torneo Buscar(int IdTorneo)
        {
           string sql = "select * from Torneos where IdTorneo = " + IdTorneo + " Order By FecInicInsc Desc";
           DataRow Dr = Conex.Buscar(sql);
            return Mapear(Dr);
            
        }

        public List<Torneo> Listar()
        {
            string Sql = "select * from Torneos Order By FecInicInsc Desc";
            DataTable Tabla = Conex.Listar(Sql);
            List<Torneo> Lista = new List<Torneo>();

            foreach (DataRow Dr in Tabla.Rows)
            {
                Lista.Add(this.Mapear(Dr));
            }
            return Lista;
        }

        public TipoTorneo GetTipoTorneo(int IdTorneo)
        {
            string Consulta = " Select Tipo From Torneos Where IdTorneo = " + IdTorneo;
            DataRow Fila = Conex.Buscar(Consulta);
            return (TipoTorneo)Convert.ToInt32(Fila["Tipo"]);
        }

        public List<Torneo> ListarCerrados()
        {
            string Sql = "select * from Torneos where Estado = 1 or Estado = 2 Order By FecInicInsc Desc";
            DataTable Tabla = Conex.Listar(Sql);
            List<Torneo> Lista = new List<Torneo>();

            foreach (DataRow Dr in Tabla.Rows)
            {
                Lista.Add(this.Mapear(Dr));
            }
            return Lista;
        }

        public List<Torneo> ListarAbiertos()
        {
            string Sql = "select * from Torneos where Estado = 0 Order By FecInicInsc Desc";
            DataTable Tabla = Conex.Listar(Sql);
            List<Torneo> Lista = new List<Torneo>();

            foreach (DataRow Dr in Tabla.Rows)
            {
                Lista.Add(this.Mapear(Dr));
            }
            return Lista;
        }

        public void ActualizarTorneos()
        {
            DateTime Hoy = DateTime.Today;
            string HoyFormateado = Hoy.ToString("yyyyMMdd");
            string Sql = "select * from Torneos where Estado <> " + (int)EstadoTorneo.Cancelado + " And Estado <> " + (int)EstadoTorneo.Finalizado;
            DataTable Tabla = Conex.Listar(Sql);
            IInscripcionRepositorio InsRepo = new InscripcionRepositorio();


            foreach (DataRow Dr in Tabla.Rows)
            {
                Torneo Tor = this.Mapear(Dr);
                int Inscripciones = InsRepo.Listar(Tor.IdTorneo).Count;

                if (DateTime.Now > Tor.FechaFinInscripcion  && DateTime.Today < Tor.FechaInicio)
                {
                    Tor.Estado = (int)EstadoTorneo.Cerrado;
                }
                if (DateTime.Now >= Tor.FechaInicioInscripcion && DateTime.Today <= Tor.FechaFinInscripcion)
                {
                    Tor.Estado = (int)EstadoTorneo.Abierto;
                }
                if (DateTime.Now < Tor.FechaInicioInscripcion)
                {
                    Tor.Estado = (int)EstadoTorneo.NoIniciado;
                }
                
                if (DateTime.Now > Tor.FechaFin)
                {
                    Tor.Estado = (int)EstadoTorneo.Finalizado;
                }

                if (DateTime.Today >= Tor.FechaInicio && DateTime.Today <= Tor.FechaFin)
                {
                    Tor.Estado = (int)EstadoTorneo.Jugando;
                }
                
                if (Tor.Cupo < Inscripciones)
                {
                    if (Tor.FechaInicioInscripcion >= DateTime.Today && DateTime.Today < Tor.FechaFinInscripcion)
                    {
                        Tor.Estado = (int)EstadoTorneo.Abierto;
                    }
                }
                if (Tor.Cupo == Inscripciones)
                {
                    Tor.Estado = (int)EstadoTorneo.Cerrado;
                }
                this.Modificar(Tor);


            }

        }

        #endregion

        #region Miembros de IMapeador<Torneo>

        public Torneo Mapear(System.Data.DataRow Fila)
        {
            Torneo Torneo = null;
            if (Fila != null)
            {
                IClubRepositorio RepoClub = new ClubRepositorio();
                ICategoriaRepositorio CateRepo = new CategoriaRepositorio();
                IPuntosRepositorio PuntosRepo = new PuntosRepositorio();
                int IdClub = Fila.IsNull("IdClub") ? 0 : Convert.ToInt32(Fila["IdClub"]);
                Club Club = RepoClub.Buscar(IdClub);

                int IdCategoria = Fila.IsNull("IdCategoria") ? 0 : Convert.ToInt32(Fila["IdCategoria"]);
                Categoria Categoria = CateRepo.Buscar(IdCategoria);

                int IdTorneo = Fila.IsNull("IdTorneo") ? 0 : Convert.ToInt32(Fila["IdTorneo"]);
                string Nombre = Fila.IsNull("Nombre") ? string.Empty : Convert.ToString(Fila["Nombre"]);
                DateTime FecInicio = Fila.IsNull("FecInicio") ? DateTime.Today : Convert.ToDateTime(Fila["FecInicio"]);
                DateTime FecFin = Fila.IsNull("FecFin") ? DateTime.MaxValue : Convert.ToDateTime(Fila["FecFin"]);
                DateTime FecIniInsc = Fila.IsNull("FecInicInsc") ? DateTime.Today : Convert.ToDateTime(Fila["FecInicInsc"]);
                DateTime FecFinInsc = Fila.IsNull("FecFinInsc") ? DateTime.MaxValue : Convert.ToDateTime(Fila["FecFinInsc"]);
                int Cupo = Fila.IsNull("Cupo") ? 0 : Convert.ToInt32(Fila["Cupo"]);
                string Sexo = Fila.IsNull("Sexo") ? string.Empty : Convert.ToString(Fila["Sexo"]);
                TipoTorneo Tipo = Fila.IsNull("Tipo") ? 0 : (TipoTorneo)Convert.ToInt32(Fila["Tipo"]);
                bool TipoInscripcion = Fila.IsNull("TipoInscripcion") ? false : Convert.ToBoolean(Fila["TipoInscripcion"]);
                TipoSuperficie Superficie = Fila.IsNull("Superficie") ? 0 :(TipoSuperficie) Convert.ToInt32(Fila["Superficie"]);
                int Estado = Fila.IsNull("Estado") ? 0 : Convert.ToInt32(Fila["Estado"]);
                Torneo = new Torneo(IdTorneo, Nombre, FecInicio, FecFin, FecIniInsc, FecFinInsc, Cupo, Sexo, Tipo, Club, Categoria, TipoInscripcion, Superficie, Estado);
                
                if (PuntosRepo.ListarPuntos(IdTorneo) != null)
                {
                    Torneo.ListaPuntos = PuntosRepo.ListarPuntos(Torneo.IdTorneo);
                }
            }
            
            return Torneo;
        }
        #endregion
        
    }
}
