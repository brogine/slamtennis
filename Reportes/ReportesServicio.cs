using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;

namespace Reportes
{
    public enum ListadoReportes { Ranking, Llave }

    public class ReportesServicio : IReportesServicio
    {
        #region Miembros de IReportesServicio

        object ReporteActual = null;

        public ReportesServicio()
        {
            ReporteActual = new object();
        }

        public object CrearInstancia(string NombreReporte)
        {
            switch (NombreReporte)
            {
                case "Ranking":
                    RptRankingCategoria rptRankingCategoria = new RptRankingCategoria();
                    ReporteActual = rptRankingCategoria;
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
    }
}
