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
                ListaPaises.Add( MapearPais(Dr));
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

        #endregion

        #region Miembros de IMapeador<Pais>

        public Pais MapearPais(System.Data.DataRow Fila)
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

        Localidad MapearLocalidad(DataRow Fila)
        {
            Localidad Loc = null;
            if (Fila != null)
            {
                

            }
        }

        #endregion

        #region Miembros de IMapeador<Provincia>

        Provincia MapearProvincia(DataRow Fila)
        {
            Provincia Prov = null;
            if (Fila != null)
            {
                int IdProv = (Fila.IsNull("IdProvincia") == true ? 0 : Convert.ToInt32(Fila["IdProvincia"]));
                string Nombre = (Fila.IsNull("Nombre") == true ? string.Empty : Convert.ToString(Fila["Nombre"]));
                bool Estado = (Fila.IsNull("Estado") == true ? false : Convert.ToBoolean(Fila["Estado"]));
                int IdPais = (Fila.IsNull("IdPais") == true ? 0 : Convert.ToInt32(Fila["IdPais"]));
                Pais Pais = ObtenerPais(IdPais);
                
            }
        }

        #endregion

        #region Miembros de IUbicacionRepositorio


        public Pais ObtenerPais(int IdPais)
        {
           return this.MapearPais( Conex.Buscar("select * from Paises where IdPais=" + IdPais));
        }

        public Provincia ObetenerProvincia(int IdProvincia)
        {
            return this.MapearProvincia(Conex.Buscar("Select * from Provincias where IdProvincia="+IdProvincia));
        }

        public Localidad ObtenerLocalidad(int IdLocalidad)
        {
            return this.MapearLocalidad(Conex.Buscar("Select * from Localidades where IdLocalidad=" + IdLocalidad));
        }

        #endregion
    }
}
