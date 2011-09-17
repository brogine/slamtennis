using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Dominio;
using Repositorio.Conexiones;

namespace Repositorio
{
    public class EmpleadoRepositorio : PersonaRepositorio, IEmpleadoRepositorio, IMapeador<Empleado>
    {
        Conexion Conn;
        public EmpleadoRepositorio()
        	: base()
        {
            Conn = new Conexion();
        }

        #region Miembros de IEmpleadoRepositorio

        public void Agregar(Empleado Empleado)
        {
            if (!base.Existe(Empleado.Dni))
                base.Agregar(Empleado);
            else
                base.Modificar(Empleado);
        	string Campos = "Dni, Puesto, Estado ";
            try
            {
                string Valores = Empleado.Dni + ",'" + Empleado.Puesto + "'," + (Empleado.Estado ? 1 : 0);
                Conn.AgregarSinId("Empleados", Campos, Valores);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudo agregar al empleado.", ex);
            }
        }

        public override bool Existe(int Dni)
        {
            string Consulta = " Select Count(*) From Empleados Where Dni = " + Dni;
            DataRow Fila = Conn.Buscar(Consulta);
            int cantidad = Convert.ToInt32(Fila[0]);
            if (cantidad == 1)
                return true;
            else
                return false;
        }

        public void Modificar(Empleado Empleado)
        {
        	base.Modificar(Empleado);
        	string Consulta = " Update Empleados Set ";
        	Consulta += " Puesto = '" + Empleado.Puesto + "',";
        	Consulta += " Estado = " + (Empleado.Estado ? 1 : 0);
        	Consulta += " Where Dni = " + Empleado.Dni;
            try
            {
                Conn.ActualizarOEliminar(Consulta);
            }
            catch (Exception ex)
            {
                throw new RepositorioExeption("No se pudo modificar al empleado.", ex);
            }
        }

        public Empleado Buscar(int Dni)
        {
            Empleado Emp = new Empleado();
            if (base.Existe(Dni))
            {
                if (Existe(Dni))
                {
                    string Consulta = " Select * From Empleados e inner join Personas p ";
                    Consulta += " on e.Dni = p.Dni inner join Login L on E.Dni = L.Dni ";
                    Consulta += " Where e.Dni = " + Dni;
                    return this.Mapear(Conn.Buscar(Consulta));
                }
                else
                {
                    string Consulta = " Select * From Personas P inner join Login L on P.Dni = L.Dni ";
                    Consulta += " Where P.Dni = " + Dni;
                    return this.Mapear(Conn.Buscar(Consulta));
                }
            }
            else
            {
                throw new RepositorioExeption("No Existen Registros en la Base de Datos con Dni: " + Dni.ToString());
            }
            
        }

        public List<Empleado> Listar()
        {
            string Consulta = " Select * From Empleados e inner join Personas p ";
            Consulta += " on e.Dni = p.Dni inner join Login L on E.Dni = L.Dni ";
            DataTable Tabla = Conn.Listar(Consulta);
            List<Empleado> ListaEmpleados = new List<Empleado>();
            foreach (DataRow Fila in Tabla.Rows) {
            	ListaEmpleados.Add(this.Mapear(Fila));
            }
            return ListaEmpleados;
        }

        #endregion

        #region Miembros de IMapeador<Empleado>

        public Empleado Mapear(System.Data.DataRow Fila)
        {
            Empleado bEmpleado = null;
            if (Fila != null)
            {
            	bEmpleado = new Empleado();
            	bEmpleado = base.MapearDatosPersonales(Fila, bEmpleado) as Empleado;

                if (Fila.Table.Columns.Contains("Puesto") && Fila.Table.Columns.Contains("Estado"))
                {
                    // Datos de Empleado
                    bEmpleado.Puesto = Fila.IsNull("Puesto") ? string.Empty : Fila["Puesto"].ToString();
                    ISedesRepositorio repoSedes = new SedesRepositorio();

                    bEmpleado.Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
                }
            }
            return bEmpleado;
        }

        #endregion
    }
}
