using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    class TorneoRepositorio : ITorneoRepositorio, IMapeador<Torneo>
    {

        Conexion Conex;
        #region Miembros de ITorneoRepositorio

        public TorneoRepositorio()
        {
            Conex = new Conexion();
        }

        public void Agregar(Torneo Torneo)
        {
            string FechaFormateadaInicio = Torneo.FechaInicio.Year + "/" + Torneo.FechaInicio.Month + "/" + Torneo.FechaInicio.Day;
            string FechaFormateadaFin = Torneo.FechaFin.Year + "/" + Torneo.FechaFin.Month + "/" + Torneo.FechaFin.Day;
            string FechaFormateadaInicioInscrip = Torneo.FechaInicioInscripcion.Year + "/" + Torneo.FechaInicioInscripcion.Month + "/" + Torneo.FechaInicioInscripcion.Day;
            string FechaFormateadaFinInscrip = Torneo.FechaFinInscripcion.Year + "/" + Torneo.FechaFinInscripcion.Month + "/" + Torneo.FechaFinInscripcion.Day;

            string valores = "'" + Torneo.Nombre + "','" + FechaFormateadaInicio + "','" + FechaFormateadaFin + "','" + FechaFormateadaInicioInscrip + "','" + FechaFormateadaFinInscrip + "',";
            valores += Torneo.Cupo + "','" + Torneo.Sexo + "'," + Torneo.TipoTorneo + "," + Torneo.Club.Id + "," + Torneo.Categoria.Id + "," + Torneo.TipoInscripcion + ",";
            valores += Torneo.Superficie + "," + Torneo.Estado;

            Conex.Agregar("Torneos", "Nombre,FecInicio,FecFin,FecInicInsc,FecFinInsc,Cupo,Sexo,Tipo,IdClub,IdCategoria,TipoInscripcion,Superficie,Estado", valores);
        }

        public void Modificar(Torneo Torneo)
        {
            string FechaFormateadaInicio = Torneo.FechaInicio.Year + "/" + Torneo.FechaInicio.Month + "/" + Torneo.FechaInicio.Day;
            string FechaFormateadaFin = Torneo.FechaFin.Year + "/" + Torneo.FechaFin.Month + "/" + Torneo.FechaFin.Day;
            string FechaFormateadaInicioInscrip = Torneo.FechaInicioInscripcion.Year + "/" + Torneo.FechaInicioInscripcion.Month + "/" + Torneo.FechaInicioInscripcion.Day;
            string FechaFormateadaFinInscrip = Torneo.FechaFinInscripcion.Year + "/" + Torneo.FechaFinInscripcion.Month + "/" + Torneo.FechaFinInscripcion.Day;

            string sql = "update Torneos set ";
            sql += "Nombre = '" + Torneo.Nombre + "'";
            sql += ",FecInicio = '" + Torneo.FechaInicio + "'";
            sql += ",FecFin = '" + Torneo.FechaFin + "'";
            sql += ",FecInicInsc = '" + Torneo.FechaInicioInscripcion + "'";
            sql += ",FecFinInsc = '" + Torneo.FechaFinInscripcion + "'";
            sql += ",Cupo = " + Torneo.Cupo;
            sql += ",Sexo = '" + Torneo.Sexo + "'";
            sql += ",Tipo = " + Torneo.TipoTorneo;
            sql += ",IdClub =" + Torneo.Club.Id;
            sql += ",IdCategoria =" + Torneo.Categoria.Id;
            sql += ",TipoInscripcion =" + Torneo.TipoInscripcion;
            sql += ",Superficie =" + Torneo.Superficie;
            sql += ",Estado =" + Torneo.Estado;
        }

        public Torneo Buscar(int IdTorneo)
        {
           string sql = "select * from Torneos where Id Torneo = " + IdTorneo;
           return this.Mapear(Conex.Buscar(sql));
            
        }

        public List<Torneo> Listar()
        {
            string Sql = "select * from Torneos";
            DataTable Tabla = Conex.Listar(Sql);
            List<Torneo> Lista = new List<Torneo>();

            foreach (DataRow Dr in Tabla.Rows)
            {
                Lista.Add(this.Mapear(Dr));
            }
            return Lista;
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

                int IdClub = Fila.IsNull("IdClub") ? 0 : Convert.ToInt32(Fila["IdClub"]);
                Club Club = RepoClub.Buscar(IdClub);

                int IdCategoria = Fila.IsNull("IdCategoria") ? 0 : Convert.ToInt32(Fila["IdCategoria"]);
                Categoria Categoria = CateRepo.Buscar(IdCategoria);

                int IdTorneo = Fila.IsNull("IdTorneo") ? 0 : Convert.ToInt32(Fila["IdTorneo"]);
                string Nombre = Fila.IsNull("Nombre") ? string.Empty : Convert.ToString(Fila["Nombre"]);
                DateTime FecInicio = Fila.IsNull("FecInicio") ? DateTime.Today : Convert.ToDateTime(Fila["FecInicio"]);
                DateTime FecFin = Fila.IsNull("FecFin") ? DateTime.MaxValue : Convert.ToDateTime(Fila["FecFin"]);
                DateTime FecIniInsc = Fila.IsNull("FecIniInsc") ? DateTime.Today : Convert.ToDateTime(Fila["FecIniInsc"]);
                DateTime FecFinInsc = Fila.IsNull("FecFinInsc") ? DateTime.MaxValue : Convert.ToDateTime(Fila["FecFinInsc"]);
                int Cupo = Fila.IsNull("Cupo") ? 0 : Convert.ToInt32(Fila["Cupo"]);
                string Sexo = Fila.IsNull("Sexo") ? string.Empty : Convert.ToString(Fila["Sexo"]);
                TipoTorneo Tipo = Fila.IsNull("Tipo") ? 0 : (TipoTorneo)Convert.ToInt32(Fila["Tipo"]);
                bool TipoInscripcion = Fila.IsNull("TipoInscripcion") ? false : Convert.ToBoolean(Fila["TipoInscripcion"]);
                TipoSuperficie Superficie = Fila.IsNull("Superficie") ? 0 :(TipoSuperficie) Convert.ToInt32(Fila["Superficie"]);
                bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                Torneo = new Torneo(IdTorneo, Nombre, FecInicio, FecFin, FecIniInsc, FecFinInsc, Cupo, Sexo, Tipo, Club,Categoria, TipoInscripcion, Superficie, Estado);

            }
            return Torneo;

        #endregion
        }
    }
}
