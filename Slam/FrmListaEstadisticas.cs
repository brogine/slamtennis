using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio.InterfacesUI;
using Servicio;
using ApplicationContext;

namespace Slam
{
    public partial class FrmListaEstadisticas : Form, IListadoEstadisticasCategoria, IListadoClubes
    {
        string ImplementaEstadisticas = "EstadisticasServicio";
        string ImplementaClubes = "ClubServicio";
        IListadoEstadisticasServicio servicioEstadisticas;
        IListadoClubServicio servicioClubes;
        public FrmListaEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmListaEstadisticas_Load(object sender, EventArgs e)
        {
            servicioEstadisticas = (IListadoEstadisticasServicio)AppContext.Instance.GetObject(ImplementaEstadisticas);
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioClubes.Listar(this);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        private void CboClubes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboClubes.SelectedIndex > -1 && CboCategorias.SelectedIndex > -1)
            {
                servicioEstadisticas.ListarPorCategoriaClub(this);
            }
        }

        private void CboCategorias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboClubes.SelectedIndex > -1 && CboCategorias.SelectedIndex > -1)
            {
                servicioEstadisticas.ListarPorCategoriaClub(this);
            }
        }

        private void CboClubes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboCategorias_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #region Miembros de IListadoEstadisticasCategoria

        public List<object> ListarEstadisticas
        {
            set 
            { 
                throw new NotImplementedException(); 
            }
        }

        public int IdClub
        {
            get { return (int)CboClubes.SelectedValue; }
        }

        public int IdCategoria
        {
            get { return (int)CboCategorias.SelectedValue; }
        }

        #endregion

        private void BtnNuevaEstadistica_Click(object sender, EventArgs e)
        {

        }

        private void BtnVerEstadisticas_Click(object sender, EventArgs e)
        {

        }

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {
            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}
