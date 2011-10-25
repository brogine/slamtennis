using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using Dominio;
using System.Data;

namespace Servicio
{
    public class CarnetServicio : ICarnetServicio
    {
        #region Miembros de ICarnetServicio

        public void BuscarDatos(Servicio.InterfacesUI.ICarnetUI UI)
        {
            DataTable TablaDatos = new DataTable("Persona");
            TablaDatos.Columns.Add("Foto", System.Type.GetType("System.Byte[]"));
            TablaDatos.Columns.Add("Nombre");
            TablaDatos.Columns.Add("Apellido");
            TablaDatos.Columns.Add("Dni");
            TablaDatos.Columns.Add("Categoria");
            TablaDatos.Columns.Add("Club");
            TablaDatos.Columns.Add("Puesto");
            TablaDatos.Columns.Add("Badge");
            TablaDatos.Columns.Add("TipoPersona");

            switch (UI.TipoPersona)
            {
                case Dominio.Tipo.Jugador:
                    IJugadorRepositorio repoJugadores = new JugadorRepositorio();
                    Jugador bJugador = repoJugadores.Buscar(UI.DniCarnet);
                    TablaDatos.Rows.Add(bJugador.Foto, bJugador.Nombre, bJugador.Apellido, bJugador.Dni,
                        bJugador.Estadisticas[0].Categoria.Nombre, "", "", "", "Jugador");
                    UI.TablaDatos = TablaDatos;
                    break;
                case Tipo.Arbitro:
                    IArbitroRepositorio repoArbitros = new ArbitroRepositorio();
                    Arbitro bArbitro = repoArbitros.Buscar(UI.DniCarnet);
                    TablaDatos.Rows.Add(bArbitro.Foto, bArbitro.Nombre, bArbitro.Apellido, bArbitro.Dni,
                        "", "", "", bArbitro.Badge, Tipo.Arbitro.ToString());
                    UI.TablaDatos = TablaDatos;
                    break;
                case Tipo.Empleado:
                    IEmpleadoRepositorio repoEmpleados = new EmpleadoRepositorio();
                    Empleado bEmpleado = repoEmpleados.Buscar(UI.DniCarnet);
                    TablaDatos.Rows.Add(bEmpleado.Foto, bEmpleado.Apellido, bEmpleado.Nombre, bEmpleado.Dni,
                        "", "", bEmpleado.Puesto, "", Tipo.Empleado.ToString());
                    UI.TablaDatos = TablaDatos;
                    break;
            }
        }

        #endregion
    }
}
