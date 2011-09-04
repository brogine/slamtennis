using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;
using System.Data;

namespace Repositorio
{
    public class SedesRepositorio : ISedesRepositorio, IMapeador<Sede>
    {
        Conexion Conn;
        public SedesRepositorio()
        {
            Conn = new Conexion();
        }

        #region Miembros de ISedeRepositorio

        public int Agregar(Dominio.Sede Sede)
        {
            string Campos = "IdClub, Direccion, IdLocalidad, Telefono, Celular, Email";
            string Valores = Sede.Club.Id + ",'" + Sede.Ubicacion.Domicilio + "'," + Sede.Ubicacion.Localidad.IdLocalidad;
            Valores += ",'" + Sede.Contacto.Telefono + "','" + Sede.Contacto.Celular + "','";
            Valores += Sede.Contacto.Email + "'";
            return Conn.Agregar("Sedes", Campos, Valores);
        }

        public void Modificar(Dominio.Sede Sede)
        {
            string Consulta = " Update Sedes Set ";
            Consulta += " IdClub = " + Sede.Club.Id + ",";
            Consulta += " Direccion = '" + Sede.Ubicacion.Domicilio + "',";
            Consulta += " IdLocalidad = " + Sede.Ubicacion.Localidad.IdLocalidad + ",";
            Consulta += " Telefono = '" + Sede.Contacto.Telefono + "',";
            Consulta += " Celular = '" + Sede.Contacto.Celular + "',";
            Consulta += " Email = '" + Sede.Contacto.Email + "'";
            Consulta += " Where IdSede = " + Sede.Id;
            Conn.ActualizarOEliminar(Consulta);
        }

        public Dominio.Sede Buscar(int Id)
        {
            string Consulta = " Select * From Sedes Where IdSede = " + Id;
            return this.Mapear(Conn.Buscar(Consulta));
        }

        public List<Dominio.Sede> Listar()
        {
            string Consulta = " Select * From Sedes ";
            DataTable Tabla = Conn.Listar(Consulta);
            List<Sede> ListaSedes = new List<Sede>();
            foreach (DataRow Fila in Tabla.Rows)
            {
                ListaSedes.Add(this.Mapear(Fila));
            }
            return ListaSedes;
        }

        #endregion

        #region Miembros de IMapeador<Sede>

        public Sede Mapear(System.Data.DataRow Fila)
        {
            Sede mSede = null;
            if (Fila != null)
            {
                int Id = Fila.IsNull("IdSede") ? 0 : Convert.ToInt32(Fila["IdSede"]);

                //Value Object Club
                IClubRepositorio repoClubes = new ClubRepositorio();
                Club mClub = Fila.IsNull("IdClub") ? null : 
                    repoClubes.Buscar(Convert.ToInt32(Fila["IdClub"]));

                //Value Object Ubicacion
                IUbicacionRepositorio repoUbicacion = new UbicacionRepositorio();
                Localidad mLocalidad = Fila.IsNull("IdLocalidad") ? null : 
                    repoUbicacion.ObtenerLocalidad(Convert.ToInt32(Fila["IdLocalidad"]));
                string mDireccion = Fila.IsNull("Direccion") ? string.Empty :
                    Fila["Direccion"].ToString();
                Ubicacion mUbicacion = new Ubicacion(mLocalidad, mDireccion);

                //Value Object Contacto
                string mTelefono = Fila.IsNull("Telefono") ? string.Empty : Fila["Telefono"] .ToString();
                string mCelular = Fila.IsNull("Celular") ? string.Empty : Fila["Celular"].ToString();
                string mEmail = Fila.IsNull("Email") ? string.Empty : Fila["Email"].ToString();
                Contacto mContacto = new Contacto(mTelefono, mCelular, mEmail);

                mSede = new Sede(Id, mClub, mContacto, mUbicacion);
            }
            return mSede;
        }

        #endregion
    }
}
