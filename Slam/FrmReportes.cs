using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reportes;

namespace Slam
{
    public partial class FrmReportes : Form
    {
        IReportesServicio servicioReportes;
        public FrmReportes()
        {
            InitializeComponent();
            servicioReportes = new ReportesServicio();
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
            switch (e.Node.Text)
            {
                case "Ranking":

                    FrmReporteRanking frmReporteRanking = new FrmReporteRanking();
                    if (frmReporteRanking.ShowDialog() == DialogResult.OK)
                    {
                        int IdCategoria = frmReporteRanking.IdCategoria;
                        object reporteActual = servicioReportes.CrearInstancia(e.Node.Text, IdCategoria);
                        servicioReportes.Parametros("Categoria", IdCategoria);
                        RptViewer.ReportSource = reporteActual;
                    }
                    break;
            }
        }

    }
}
