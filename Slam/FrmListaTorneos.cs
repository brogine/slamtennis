using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio;
using Servicio.InterfacesUI;
using ApplicationContext;

namespace Slam
{
    public partial class FrmListaTorneos : Form, IListadoTorneos
    {
        string ImplementaTorneos = "TorneoServicio";
        IListadoTorneoServicio TorneoServicio;
        public FrmListaTorneos()
        {
            InitializeComponent();
        }

        private void FrmListaTorneos_Load(object sender, EventArgs e)
        {
            TorneoServicio = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            TorneoServicio.ListarTorneos(this);
        }

  

        #region Miembros de IListadoTorneos

        public List<object> ListaUI
        {
            set 
            {
            if (DgvListaTorneos.ColumnCount > 0)
                    DgvListaTorneos.Columns.Clear();
                DgvListaTorneos.Columns.Add("IdTorneo", "IdTorneo");
                DgvListaTorneos.Columns.Add("Nombre", "Nombre");
                DgvListaTorneos.Columns.Add("Categoria", "Categoria");
                DgvListaTorneos.Columns.Add("Sexo", "Sexo");
                DgvListaTorneos.Columns.Add("Cupo", "Cupo");
                DgvListaTorneos.Columns.Add("FecIni", "Inicio Del Torneo");
                DgvListaTorneos.Columns.Add("FecFin", "Fin Del Torneo");
                DgvListaTorneos.Columns.Add("FecIniInsc", "Inicio De Inscripciones");
                DgvListaTorneos.Columns.Add("FecFinInsc", "Fin De Inscripciones");
                DgvListaTorneos.Columns.Add("Tipo", "Tipo");
                DgvListaTorneos.Columns.Add("TipoInsc", "Tipo De Inscripcion");
                DgvListaTorneos.Columns.Add("Estado", "Estado");
                DgvListaTorneos.Columns["Estado"].Visible=false;
                DgvListaTorneos.Columns["IdTorneo"].Visible=false;
                if (DgvListaTorneos.RowCount > 0)
                    DgvListaTorneos.Rows.Clear();
                foreach (object Torneo in value)
                {
                    object[] DatosTorneo = Torneo.ToString().Split(',');
                    int index = DgvListaTorneos.Rows.Add(DatosTorneo);
                    if(Convert.ToBoolean(DatosTorneo[11])==false)
                    {
                    DgvListaTorneos.Rows[index].DefaultCellStyle.BackColor=Color.Red;
                    }
                }
            }
            
            }
        }

        #endregion
    }

