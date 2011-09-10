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
        	base.Agregar(Empleado);
        	string Campos = "Dni, Puesto, Estado ";
        	string Valores = Empleado.Dni + ",'" + Empleado.Puesto + "'," + (Empleado.Estado ? 1 : 0);
        	Conn.AgregarSinId("Empleados", Campos, Valores);
        }

        public void Modificar(Empleado Empleado)
        {
        	base.Modificar(Empleado);
        	string Consulta = " Update Empleados Set ";
        	Consulta += " Puesto = '" + Empleado.Puesto + "',";
        	Consulta += " Estado = " + (Empleado.Estado ? 1 : 0);
        	Consulta += " Where Dni = " + Empleado.Dni;
        	Conn.ActualizarOEliminar(Consulta);
        }

        public Empleado Buscar(int Dni)
        {
            string Consulta = " Select * From Empleados e inner join Personas p ";
            Consulta += " on e.Dni = p.Dni inner join Login L on E.Dni = L.Dni ";
            Consulta += " Where e.Dni = " + Dni;
            return this.Mapear(Conn.Buscar(Consulta));
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
            	
                // Datos de Empleado
                bEmpleado.Puesto = Fila.IsNull("Puesto") ? string.Empty : Fila["Puesto"].ToString();
                ISedesRepositorio repoSedes = new SedesRepositorio();
                
                bEmpleado.Estado = Fila.IsNull("Estado") ? false : Convert.ToBoolean(Fila["Estado"]);
            }
            return bEmpleado;
        }

        #endregion
    }
}
