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
            //foreach(ListadoReportes tiposReportes in servicioReportes.getReportes)
            TvReportes.Nodes["Index"].Nodes.Add("Llave", "Llave de Torneo");
            TvReportes.Nodes["Index"].Nodes.Add("Ranking", "Ranking por Categoria");
        }

        private void TvReportes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Llave":
                    RptLlave reporteLlave = new RptLlave();
                    
                    break;
                case "Ranking":
                    break;
            }
        }

    }
}
