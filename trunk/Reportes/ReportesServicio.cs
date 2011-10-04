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
        static int idCategoria = 0;
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
                    idCategoria = Convert.ToInt32(Sender);
                    IListadoJugadoresCategoriaServicio servicioJugadores = new JugadorServicio();
                    RptRankingCategoria rptRankingCategoria = new RptRankingCategoria();
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

        public void Parametros(string[] NombresParametros, object[] ValorParametros)
        {
            for(int i = 0; i < NombresParametros.Length; i++)
            {
                ((ReportClass)ReporteActual).SetParameterValue(NombresParametros[i], ValorParametros[i]);
            }
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
