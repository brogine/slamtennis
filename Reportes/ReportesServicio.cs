using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using Servicio;
using Servicio.InterfacesUI;
using System.Data;
using Dominio;

namespace Reportes
{
    public enum ListadoReportes { Ranking, Llave, Carnet, CuponInscripcion }

    public class ReportesServicio : IReportesServicio, IListadoJugadoresCategoria, ICarnetUI
    {
        #region Miembros de IReportesServicio

        object ReporteActual = null;
        int idCategoria = 0;
        int dniCarnet = 0;
        Tipo tipoPersona;
        public ReportesServicio()
        {
            ReporteActual = new object();
        }

        public object CrearInstancia(ListadoReportes NombreReporte, object Sender)
        {
            switch (NombreReporte)
            {
                case ListadoReportes.Ranking:
                    IListadoJugadoresCategoriaServicio servicioJugadores = new JugadorServicio();
                    RptRankingCategoria rptRankingCategoria = new RptRankingCategoria();
                    this.IdCategoria = (int)Sender;
                    ReporteActual = rptRankingCategoria;
                    servicioJugadores.ListarPorCategoria(this);
                    return ReporteActual;
                case ListadoReportes.Llave:
                    ILlaveTorneoServicio servicioLlave = new TorneoServicio();
                    DataSet Ds = servicioLlave.GetDatosPartido((int)Sender);
                    RptLlave rptLlave = new RptLlave();
                    rptLlave.SetDataSource(Ds);
                    ReporteActual = rptLlave;
                    return ReporteActual;
                case ListadoReportes.CuponInscripcion:
                    RptCuponInscripcion rptCuponInscripcion = new RptCuponInscripcion();
                    IInscripcionReporteServicio servicioInscripciones = new InscripcionServicio();
                    rptCuponInscripcion.SetDataSource(servicioInscripciones.BuscarPorId((int)Sender));
                    ReporteActual = rptCuponInscripcion;
                    return ReporteActual;
                case ListadoReportes.Carnet:
                    RptCarnet rptCarnet = new RptCarnet();
                    ICarnetServicio servicioCarnet = new CarnetServicio();
                    this.dniCarnet = Convert.ToInt32(Sender.ToString().Split(',')[0]);
                    this.tipoPersona = (Tipo)Enum.Parse(typeof(Tipo), (Sender.ToString().Split(',')[1]));
                    ReporteActual = rptCarnet;
                    servicioCarnet.BuscarDatos(this);
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

        #region Miembros de ICarnetUI

        public DataTable TablaDatos
        {
            set 
            {
                if (value.Rows.Count != 0)
                {
                    ((ReportClass)ReporteActual).SetDataSource(value);
                }
                else
                {
                    ReporteActual = null;
                }
            }
        }

        public int DniCarnet
        {
            get { return dniCarnet; }
        }

        public Dominio.Tipo TipoPersona
        {
            get { return tipoPersona; }
        }

        #endregion
    }
}
