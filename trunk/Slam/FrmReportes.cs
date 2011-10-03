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
            IEnumerator<ListadoReportes> Values =
                (IEnumerator<ListadoReportes>)System.Enum.GetValues(typeof(ListadoReportes)).GetEnumerator();
            IEnumerator<ListadoReportes> Names =
                (IEnumerator<ListadoReportes>)System.Enum.GetNames(typeof(ListadoReportes)).GetEnumerator();
            while(!Values.MoveNext() && !Names.MoveNext())
            {
                TvReportes.Nodes["Index"].Nodes.Add(Values.ToString(), Names.ToString());
            }
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
