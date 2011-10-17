using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;
using System.Data;

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
            try
            {
                Conex.Agregar("Paises", "Nombre,Estado", "'" + Pais.Nombre + "',1");
            }
            catch(Exception ex)
            {
                throw new RepositorioExeption("No se pudo agregar el pais.", ex);
            }
        }

        public List<Provincia> ListarProvincias(Pais Pais)
        {
            DataTable Tabla = Conex.Listar("Select * From Provincias where IdPais = " + Pais.IdPais);
            List<Provincia> ListaProvincia = new List<Provincia>();
            foreach (DataRow Dr in Tabla.Rows)
            {
                ListaProvincia.Add(MapearProvincia(Dr));
            }
            return ListaProvincia;
        }

        public void AgregarProvincia(Provincia Provincia)
        {
            try
            {
                Conex.Agregar("Provincias","Nombre,Estado,IdPais","'"+Provincia.Nombre+"',1,"+Provincia.Pais.IdPais);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudo agregar la provincia.", ex);
            }
        }

        public List<Localidad> ListarLocalidades(Provincia Provincia)
        {
            DataTable Tabla = Conex.Listar("Select * From Localidades where IdProvincia=" + Provincia.IdProvincia);
            List<Localidad> ListaLocalidad = new List<Localidad>();
            foreach (DataRow Dr in Tabla.Rows)
            {
                ListaLocalidad.Add(MapearLocalidad(Dr));
            }
            return ListaLocalidad;
        }

        public void AgregarLocalidad(Localidad Localidad)
        {
            try
            {
                Conex.Agregar("Localidades", "Nombre,Estado,IdProvincia", "'" + Localidad.Nombre + "',1," + Localidad.Provincia.IdProvincia);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudo agregar la localidad.", ex);
            }
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
                int IdLoc = (Fila.IsNull("IdLocalidad") == true ? 0 : Convert.ToInt32(Fila["IdLocalidad"]));
                string Nombre = (Fila.IsNull("Nombre") == true ? string.Empty : Convert.ToString(Fila["Nombre"]));
                bool Estado = (Fila.IsNull("Estado")==true ? false : Convert.ToBoolean(Fila["Estado"]));
                int IdProv = (Fila.IsNull("IdProvincia") == true ? 0 : Convert.ToInt32(Fila["IdProvincia"]));
                Provincia Prov = ObetenerProvincia(IdProv);
                Loc = new Localidad(IdLoc, Nombre, Estado, Prov);
            }
            return Loc;
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
                Prov = new Provincia(IdProv, Nombre, Estado, Pais);
            }
            return Prov;
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
