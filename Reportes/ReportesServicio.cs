using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using Servicio;
using Servicio.InterfacesUI;
using System.Data;

namespace Reportes
{
    public enum ListadoReportes { Ranking, Llave, Carnet }

    public class ReportesServicio : IReportesServicio, IListadoJugadoresCategoria
    {
        #region Miembros de IReportesServicio

        object ReporteActual = null;
        int idCategoria = 0;
        public ReportesServicio()
        {
            ReporteActual = new object();
        }

        public object CrearInstancia(string NombreReporte, object Sender)
        {
            switch (NombreReporte)
            {
                case "Ranking":
                    IListadoJugadoresCategoriaServicio servicioJugadores = new JugadorServicio();
                    RptRankingCategoria rptRankingCategoria = new RptRankingCategoria();
                    this.IdCategoria = (int)Sender;
                    ReporteActual = rptRankingCategoria;
                    servicioJugadores.ListarJugadoresCategoria(this);
                    return ReporteActual;
                case "Llave":
                    ILlaveTorneoService servicioLlave = new TorneoServicio();
                    DataSet Ds = servicioLlave.GetDatosPartido((int)Sender);
                    RptLlave rptLlave = new RptLlave();
                    rptLlave.SetDataSource(Ds);
                    ReporteActual = rptLlave;
                    return ReporteActual;
                case "CuponInscripcion":
                    RptCuponInscripcion rptCuponInscripcion = new RptCuponInscripcion();
                    IInscripcionReporteServicio servicioInscripciones = new InscripcionServicio();
                    rptCuponInscripcion.SetDataSource(servicioInscripciones.BuscarPorId((int)Sender));
                    ReporteActual = rptCuponInscripcion;
                    return ReporteActual;
                default:
                    return null;
            }
        }

        public void Parametros(string NombresParametro, object ValorParametro)
        {
            ((ReportClass)ReporteActual).SetParameterValue(NombresParametro, ValorParametro);
        }

        #endregion

        #region Miembros de IListadoJugadoresCategoria

        public DataTable Listar
        {
            set { ((ReportClass)ReporteActual).SetDataSource(value); }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        #endregion

    }
}
