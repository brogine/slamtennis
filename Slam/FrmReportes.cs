using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reportes;
using ApplicationContext;

namespace Slam
{
    public partial class FrmReportes : Form
    {
        string ImplementaReportes = "ReportesServicio";
        IReportesServicio servicioReportes;
        public FrmReportes()
        {
            InitializeComponent();
            servicioReportes = (IReportesServicio)AppContext.Instance.GetObject(ImplementaReportes);
        }

        public FrmReportes(Object Reporte)
        {
            InitializeComponent();
            servicioReportes = (IReportesServicio)AppContext.Instance.GetObject(ImplementaReportes);
            RptViewer.ReportSource = Reporte;
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            TvReportes.Nodes.Add("Index", "Reportes");
            string[] Values =
                System.Enum.GetNames(typeof(ListadoReportes));
            foreach (string TipoReporte in Values)
            {
                TvReportes.Nodes["Index"].Nodes.Add(TipoReporte);
            }
        }

        private void TvReportes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                switch (e.Node.Text)
                {
                    case "Ranking":
                        FrmReporteRanking frmReporteRanking = new FrmReporteRanking();
                        if (frmReporteRanking.ShowDialog() == DialogResult.OK)
                        {
                            int IdCategoria = frmReporteRanking.IdCategoria;
                            string Categoria = frmReporteRanking.Categoria;
                            object reporteActual = 
                                servicioReportes.CrearInstancia((ListadoReportes)Enum.Parse(typeof(ListadoReportes), e.Node.Text)
                                                                ,IdCategoria);
                            servicioReportes.Parametros("Categoria", Categoria);
                            RptViewer.ReportSource = reporteActual;
                        }
                        break;
                    case "Carnet":
                        FrmReporteCarnet frmReporteCarnet = new FrmReporteCarnet();
                        if (frmReporteCarnet.ShowDialog() == DialogResult.OK)
                        {
                            int Dni = frmReporteCarnet.Dni;
                            TipoPersona Tipo = frmReporteCarnet.Tipo;
                            object reporteActual = servicioReportes.CrearInstancia((ListadoReportes)Enum.Parse(typeof(ListadoReportes), e.Node.Text), Dni + "," + Tipo.ToString());
                            if (reporteActual == null)
                            {
                                MessageBox.Show("El Dni de la persona no existe, Verifique", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                RptViewer.ReportSource = reporteActual;
                            }
                        }
                        break;
                    case "Llave":
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.WindowState = FormWindowState.Maximized;
        }

    }
}
