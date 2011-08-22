using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;

namespace Repositorio
{
   public class UbicacionRepositorio:IUbicacionRepositorio
    {
       Conexion Conex;
       public UbicacionRepositorio()
       {
           Conex = new Conexion();
       }
        #region Miembros de IUbicacionRepositorio

        public List<Dominio.Pais> ListarPaises()
        {
            throw new NotImplementedException();
        }

        public void AgregarPais(Pais Pais)
        {
            Conex.Agregar("Paises", "Nombre,Estado", "'" + Pais.Nombre + "',1");
        }

        public List<Dominio.Provincia> ListarProvincias(Dominio.Pais Pais)
        {
            throw new NotImplementedException();
        }

        public void AgregarProvincia(Provincia Provincia)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Localidad> ListarLocalidades(Dominio.Provincia Provincia)
        {
            throw new NotImplementedException();
        }

        public void AgregarLocalidad(Localidad Localidad)
        {
            throw new NotImplementedException();
        }

        public int BuscarIdPais(string Nombre)
        {
            throw new NotImplementedException();
        }

        public int BuscarIdProvincia(string Nombre, int IdPais)
        {
            throw new NotImplementedException();
        }

        public int BuscarIdLocalidad(string Nombre, int IdProvincia)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
