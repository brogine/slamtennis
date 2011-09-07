﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    class AfiliacionRepositorio:IAfiliacionRepositorio,IMapeador<Afiliacion>
    {
        Conexion Conex;
       public AfiliacionRepositorio()
        {
            Conex = new Conexion();
        }
        #region Miembros de IAfiliacionRepositorio

        public void Agregar(Afiliacion Afiliacion)
        {
            Conex.AgregarSinId("Afiliaciones", "Dni,IdClub,FechaAlta,Estado", Afiliacion.Jugador.Dni + "," + Afiliacion.Club.Id + ",'" + DateTime.Today.ToShortDateString() + "'," + 1);
        }

        public void Modificar(Afiliacion Afiliacion)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Afiliacion> Listar(Club Club)
        {
            string Sql = "select * from Afiliaciones where IdClub =" + Club.Id;
            DataTable Tabla = Conex.Listar(Sql);
            List<Afiliacion> Lista = new List<Afiliacion>();

            foreach (DataRow Dr in Tabla.Rows)
            {
                Lista.Add(this.Mapear(Dr));
            }
            return Lista;
        }

        public Dominio.Afiliacion Buscar(Afiliacion Afiliacion)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Miembros de IMapeador<Afiliacion>

        public Afiliacion Mapear(System.Data.DataRow Fila)
        {
            Afiliacion Afiliacion = null;
            if (Fila!=null)
            {
                Afiliacion = new Afiliacion();
                IClubRepositorio RepoClub = new  ClubRepositorio();
                IJugadorRepositorio JugaRepo = new JugadorRepositorio();
                
                int IdClub = Fila.IsNull("IdClub") ? 0 : Convert.ToInt32(Fila["IdClub"]);
                Club Club = RepoClub.Buscar(IdClub);
                
                int Dni = Fila.IsNull("Dni")?0:Convert.ToInt32(Fila["Dni"]);
                Jugador Jugador = JugaRepo.Buscar(Dni);

               DateTime FecAlta = Fila.IsNull("FechaAlta") ? DateTime.Today : Convert.ToDateTime(Fila["FechaAlta"]);
               DateTime FecBaja = Fila.IsNull("FechaBaja") ? DateTime.MaxValue : Convert.ToDateTime(Fila["FechaBaja"]);

               bool Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);

               Afiliacion.Club = Club;
               Afiliacion.Jugador = Jugador;
               Afiliacion.FechaAlta = FecAlta;
               Afiliacion.FechaBaja = FecBaja;
               Afiliacion.Estado = Estado;
            }
            return Afiliacion;
        }

        #endregion
    }
}