/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 08:02 p.m.
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using ApplicationContext;
using Servicio;
using Servicio.InterfacesUI;

namespace Slam
{
	/// <summary>
	/// Formulario con la lista de Empleados de la Federación
	/// </summary>
	public partial class FrmListaEmpleados : Form, IListadoEmpleados
	{
		IListadoEmpleadoServicio servicioEmpleados;
		string ImplementaEmpleados = "EmpleadoServicio";
		public FrmListaEmpleados()
		{
			InitializeComponent();
		}
		
		void FrmListaEmpleadosLoad(object sender, EventArgs e)
		{
			servicioEmpleados = (IListadoEmpleadoServicio)AppContext.Instance.GetObject(ImplementaEmpleados);
			servicioEmpleados.ListarEmpleados(this);
		}
		
		void BtnNuevoClick(object sender, EventArgs e)
		{
			FrmNuevaPersona nuevoEmpleado = new FrmNuevaPersona(TipoPersona.Empleado);
			if(nuevoEmpleado.ShowDialog() == DialogResult.OK)
				servicioEmpleados.ListarEmpleados(this);
		}
		
		void BtnModificarClick(object sender, EventArgs e)
		{
			if(DgvEmpleados.SelectedRows.Count == 1)
			{
				int dni = Convert.ToInt32(DgvEmpleados.SelectedRows[0].Cells["Dni"].Value);
				FrmNuevaPersona modificarEmpleado = new FrmNuevaPersona(TipoPersona.Empleado,
				                dni);
				if(modificarEmpleado.ShowDialog() == DialogResult.OK)
					servicioEmpleados.ListarEmpleados(this);
			}
		}
		
		public System.Collections.Generic.List<object> ListaEmpleados {
			set {
				if(DgvEmpleados.ColumnCount > 0)
					DgvEmpleados.Columns.Clear();
				DgvEmpleados.Columns.Add("Dni", "Dni");
				DgvEmpleados.Columns.Add("ApellidoNombre", "Apellido y Nombre");
				DgvEmpleados.Columns.Add("Puesto", "Puesto");
				if(DgvEmpleados.RowCount > 0)
					DgvEmpleados.Rows.Clear();
				foreach (object empleado in value) {
					object[] datos = empleado.ToString().Split(',');
					DgvEmpleados.Rows.Add(datos);
				}
			}
		}
	}
}
