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
    public partial class FrmReporteLlave : Form, IListadoTorneos
    {
        IListadoTorneoServicio TorneosServicio;
        string ImplementaTorneos = "TorneoServicio";
        List<object> ListaTorneos;
        List<object> ListaTorneosView;
        public FrmReporteLlave()
        {
            InitializeComponent();
        }

        private void CboTorneos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmReporteLlave_Load(object sender, EventArgs e)
        {
            DtpDesde.Value = DateTime.Today.AddDays(-60);
            TorneosServicio = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            TorneosServicio.Listar(this);
            this.ActualizarView();
        }

        #region IListadoTorneos Members

        public List<object> ListaUI
        {
            set 
            {
                this.ListaTorneos = value;
                this.ListaTorneosView = new List<object>();
            }
        }

        #endregion

        private void DtpDesde_ValueChanged(object sender, EventArgs e)
        {
            this.ActualizarView();
        }

        private void DtpHasta_ValueChanged(object sender, EventArgs e)
        {
            this.ActualizarView();
        }

        private void ActualizarView()
        {
            if (this.ListaTorneosView.Count > 0)
                this.ListaTorneosView.Clear();
            foreach (object torneo in this.ListaTorneos)
            {
                Object[] DatosTorneo = torneo.ToString().Split(',');
                if (DateTime.Parse(DatosTorneo[6].ToString()) >= DtpDesde.Value &&
                    DateTime.Parse(DatosTorneo[7].ToString()) <= DtpHasta.Value)
                    this.ListaTorneosView.Add(torneo);
            }
            Dictionary<int, string> ListaTorneos = new Dictionary<int, string>();
            foreach (Object Torneo in ListaTorneosView)
            {
                Object[] DatosTorneo = Torneo.ToString().Split(',');
                ListaTorneos.Add(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[2].ToString());
            }
            CboTorneos.DataSource = new BindingSource(ListaTorneos, null);
            CboTorneos.DisplayMember = "Value";
            CboTorneos.ValueMember = "Key";
            CboTorneos.SelectedIndex = -1;
        }
    }
}
