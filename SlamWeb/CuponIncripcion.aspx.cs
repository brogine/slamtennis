using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reportes;

namespace SlamWeb
{
    public partial class CuponIncripcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToBoolean(Session["Logeado"]))
                {
                    Response.Redirect("Login.aspx");
                }
                int inscripcion = Convert.ToInt32(Session["NroIncripcion"]);
                IReportesServicio servicioReportes = new ReportesServicio();
                object ReportedeInscripcion = servicioReportes.CrearInstancia(ListadoReportes.CuponInscripcion, inscripcion);
                ReportViewerInscrip.ReportSource = ReportedeInscripcion;
                ReportViewerInscrip.RefreshReport();
            }
            catch { }
        }
    }
}
