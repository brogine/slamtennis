﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;
using System.Data;

namespace Repositorio
{
    public class ClubRepositorio : IClubRepositorio, IMapeador<Club>
    {
        Conexion Conn;
        public ClubRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de IClubRepositorio

        public int Agregar(Dominio.Club Club)
        {
            return Conn.Agregar("Clubes", "Presidente, Nombre, Estado", "'" + Club.Presidente + 
        	                    "','" + Club.Nombre + "'," + (Club.Estado ? 1 : 0));
        }

        public void Modificar(Dominio.Club Club)
        {
            string Sql = " Update Clubes Set Nombre = '" + Club.Nombre + "'," + 
                " Presidente = '" + Club.Presidente + "', Estado = " + 
                (Club.Estado ? 1 : 0);
            Conn.ActualizarOEliminar(Sql);
        }

        public Club Buscar(int IdClub)
        {
            string Sql = " Select * From Clubes Where IdClub = " + IdClub;
            return this.Mapear(Conn.Buscar(Sql));
        }

        public List<Dominio.Club> Listar()
        {
            string Sql = " Select * From Clubes ";
            DataTable Tabla = Conn.Listar(Sql);
            List<Club> ListaClubes = new List<Club>();
            foreach (DataRow Dr in Tabla.Rows)
            {
                ListaClubes.Add(this.Mapear(Dr));
            }
            return ListaClubes;
        }

        #endregion

        #region Miembros de IMapeador<Club>

        public Club Mapear(System.Data.DataRow Fila)
        {
            Club nClub = null;
            if (Fila != null)
            {
                EmpleadoRepositorio EmpleadoRepo = new EmpleadoRepositorio();
                int Id = (Fila.IsNull("IdClub") == true ? 0 : Convert.ToInt32(Fila["IdClub"]));
                string Nombre = (Fila.IsNull("Nombre") == true ? string.Empty : Fila["Nombre"].ToString());
                string Presidente = (Fila.IsNull("Presidente") == true ? string.Empty:Fila["Presidente"].ToString());
                bool Estado = (Fila.IsNull("Estado") == true ? false : Convert.ToBoolean(Fila["Estado"]));
                nClub = new Club(Id, Presidente, Nombre, Estado);
            }
            return nClub;
        }

        #endregion

    }
}
