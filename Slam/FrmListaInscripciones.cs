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

namespace Slam
{
    public partial class FrmListaInscripciones : Form, IListadoInscripciones
    {
        string ImplementaInscripciones = "InscripcionServicio";
        IListadoInscripcionServicio servicioInscripciones;
        public FrmListaInscripciones()
        {
            InitializeComponent();
        }

        private void FrmListaInscripciones_Load(object sender, EventArgs e)
        {
            servicioInscripciones = (IListadoInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
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
    }
}
