using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio;
using ApplicationContext;
using Servicio.InterfacesUI;
using System.Collections;

namespace Slam
{
    public partial class FrmListaInscripciones : Form, IListadoInscripciones, IListadoTorneos
    {
        string ImplementaInscripciones = "InscripcionServicio";
        string ImplementaTorneos = "TorneoServicio";
        IListadoInscripcionServicio servicioInscripciones;
        IListadoTorneoServicio servicioTorneos;
        public FrmListaInscripciones()
        {
            InitializeComponent();
        }

        private void FrmListaInscripciones_Load(object sender, EventArgs e)
        {
            servicioInscripciones = (IListadoInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarTorneos(this);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        private void CboTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servicioInscripciones.ListarPorTorneo(this);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvListaInscripciones.SelectedColumns.Count == 1)
            {

            }
            else
                MessageBox.Show("Seleccione una Inscripción para modificarla.");
        }

        #region Miembros de IListadoInscripciones

        public List<object> ListarPorTorneo
        {
            set 
            { 
                throw new NotImplementedException(); 
            }
        }

        public List<object> ListarPorPartido
        {
            set { throw new NotImplementedException(); }
        }

        public int IdTorneo
        {
            get { return (int)CboTorneos.SelectedValue; }
        }

        public int IdPartido
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region Miembros de IListadoTorneos

        public List<object> ListaUI
        {
            set 
            {
                Dictionary<int, string> ListaTorneos = new Dictionary<int, string>();
                foreach (Object Torneo in value)
                {
                    Object[] DatosTorneo = Torneo.ToString().Split(',');
                    ListaTorneos.Add(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[1].ToString());
                }
                CboTorneos.DataSource = new BindingSource(ListaTorneos, null);
                CboTorneos.DisplayMember = "Value";
                CboTorneos.ValueMember = "Key";
                CboTorneos.SelectedIndex = -1;
            }
        }

        #endregion
    }
}
