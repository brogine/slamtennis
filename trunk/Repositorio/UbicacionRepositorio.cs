using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;

namespace Repositorio
{
   public class UbicacionRepositorio:IUbicacionRepositorio,IMapeador<Pais>
    {
       Conexion Conex;
       public UbicacionRepositorio()
       {
           Conex = new Conexion();
       }
        #region Miembros de IUbicacionRepositorio

        public List<Dominio.Pais> ListarPaises()
        {
            Conex.Listar("select * from Paises");
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

        #region Miembros de IMapeador<Pais>

        public Pais Mapear(System.Data.DataRow Fila)
        {
            Pais Pais = null;
            if (Fila != null)
            {
                int IdPais = (Fila.IsNull("IdPais") == true ? 0 : Convert.ToInt32(Fila["IdPais"]));
                string Nombre = (Fila.IsNull("Nombre") == true ? string.Empty : Convert.ToString(Fila["Nombre"]));
                bool Estado = (Fila.IsNull("Estado") == true ? false : Convert.ToBoolean(Fila["Estado"]));
                Pais = new Pais(IdPais, Nombre, Estado);
            }
            return Pais;
        }

        #endregion
    }
}
