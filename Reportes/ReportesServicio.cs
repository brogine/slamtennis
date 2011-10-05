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
    public enum ListadoReportes { Ranking, Llave }

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
                    DsRankingCategoria ds = new DsRankingCategoria();
                    IListadoJugadoresCategoriaServicio servicioJugadores = new JugadorServicio();
                    RptRankingCategoria rptRankingCategoria = new RptRankingCategoria();
                    this.IdCategoria = (int)Sender;
                    ReporteActual = rptRankingCategoria;
                    servicioJugadores.ListarJugadoresCategoria(this);
                    return ReporteActual;
                case "Llave":
                    RptLlave rptLlave = new RptLlave();
                    ReporteActual = rptLlave;
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
