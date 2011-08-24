using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;
using System.Data;

namespace Repositorio
{
   public class UbicacionRepositorio:IUbicacionRepositorio,IMapeador<Pais>,IMapeador<Provincia>,IMapeador<Localidad>
    {
       Conexion Conex;
       public UbicacionRepositorio()
       {
           Conex = new Conexion();
       }
        #region Miembros de IUbicacionRepositorio

        public List<Dominio.Pais> ListarPaises()
        {
            DataTable Tabla = Conex.Listar("select * from Paises");
            List<Pais> ListaPaises = new List<Pais>();
            foreach (DataRow Dr in Tabla.Rows)
            {
                ListaPaises.Add( Mapear(Dr));
            }
            return ListaPaises;
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

        #region Miembros de IMapeador<Localidad>

        Localidad IMapeador<Localidad>.Mapear(DataRow Fila)
        {
            Localidad Loc = null;
            if (Fila != null)
            {
                
            }
        }

        #endregion

        #region Miembros de IMapeador<Provincia>

        Provincia IMapeador<Provincia>.Mapear(DataRow Fila)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
