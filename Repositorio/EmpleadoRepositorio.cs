using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.Conexiones;
using Dominio;

namespace Repositorio
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio, IMapeador<Empleado>
    {
        Conexion Conn;
        public EmpleadoRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de IEmpleadoRepositorio

        public void Agregar(Dominio.Empleado Empleado)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Dominio.Empleado Empleado)
        {
            throw new NotImplementedException();
        }

        public Empleado BuscarPresidente(int IdClub)
        {
            string Sql = " Select E.Dni from Sedes S inner join ";
            Sql += " Empleados E on S.IdSede = E.IdSede ";
            Sql += " Where E.Puesto = 'Presidente' And S.IdClub = " + IdClub;
            int DniPresidente = Convert.ToInt32(Conn.Buscar(Sql)[0]);
            return this.Buscar(DniPresidente);
        }

        public Dominio.Empleado Buscar(int Dni)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Empleado> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Miembros de IMapeador<Empleado>

        public Empleado Mapear(System.Data.DataRow Fila)
        {
            Empleado bEmpleado = null;
            if (Fila != null)
            {
                //Agregate Root

                int Dni = (Fila.IsNull("Dni") == true ? 0 : Convert.ToInt32(Fila["Dni"]));
                string Nombre = (Fila.IsNull("Nombre") == true ? string.Empty : Convert.ToString(Fila["Nombre"]));
                string Apellido = (Fila.IsNull("Apellido") == true ? string.Empty : Convert.ToString(Fila["Apellido"]));
                DateTime FechaNac = (Fila.IsNull("FechaNacimiento") == true ? DateTime.Now : Convert.ToDateTime(Fila["FechaNacimiento"]));
                int Nacionalidad = (Fila.IsNull("Nacionalidad") == true ? 0 : Convert.ToInt32(Fila["Nacionalidad"]));
                string Sexo = (Fila.IsNull("Sexo") == true ? string.Empty : Convert.ToString(Fila["Sexo"]));
                bool Estado = (Fila.IsNull("Sexo") == true ? false : Convert.ToBoolean(Fila["Estado"]));
                //Value Object Contacto

                string Telefono = (Fila.IsNull("Telefono") == true ? string.Empty : Convert.ToString(Fila["Telefono"]));
                string Celular = (Fila.IsNull("Celular") == true ? string.Empty : Convert.ToString(Fila["Celular"]));
                string Email = (Fila.IsNull("Email") == true ? string.Empty : Convert.ToString(Fila["Email"]));

                // Value Object Domicilio

                int Provincia = (Fila.IsNull("Provincia") == true ? 0 : Convert.ToInt32(Fila["Provincia"]));
                int Localidad = (Fila.IsNull("Localidad") == true ? 0 : Convert.ToInt32(Fila["Localidad"]));
                string Domicilio = (Fila.IsNull("Domicilio") == true ? string.Empty : Convert.ToString(Fila["Domicilio"]));

                // Datos de Empleado
                string Puesto = (Fila.IsNull("Puesto") == true ? string.Empty : Fila["Puesto"].ToString());
                //Sede
            }
            return bEmpleado;
        }

        #endregion
    }
}
