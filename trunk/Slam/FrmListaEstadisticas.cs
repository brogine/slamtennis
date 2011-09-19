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
    public partial class FrmListaEstadisticas : Form, IListadoEstadisticasCategoria, IListadoClubes, IListadoCategorias
    {
        string ImplementaEstadisticas = "EstadisticasServicio";
        string ImplementaClubes = "ClubServicio";
        string ImplementaCategorias = "CategoriaServicio";
        IListadoEstadisticasServicio servicioEstadisticas;
        IListadoClubServicio servicioClubes;
        IListadoCategoriaServicio servicioCategorias;
        public FrmListaEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmListaEstadisticas_Load(object sender, EventArgs e)
        {
            servicioEstadisticas = (IListadoEstadisticasServicio)AppContext.Instance.GetObject(ImplementaEstadisticas);
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioClubes.Listar(this);
            servicioCategorias = (IListadoCategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
            servicioCategorias.Listar(this);
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
                if (DgvEstadisticas.ColumnCount > 0)
                    DgvEstadisticas.Columns.Clear();
                DgvEstadisticas.Columns.Add("NombreApellido", "Nombre y Apellido");
                DgvEstadisticas.Columns.Add("pj", "PJ");
                DgvEstadisticas.Columns.Add("pg", "PG");
                DgvEstadisticas.Columns.Add("pp", "PP");
                DgvEstadisticas.Columns.Add("tj", "TJ");
                DgvEstadisticas.Columns.Add("tc", "TC");
                DgvEstadisticas.Columns.Add("puntos", "Puntos");
                if (DgvEstadisticas.RowCount > 0)
                    DgvEstadisticas.Rows.Clear();
                foreach (object estadistica in value)
                {
                    object[] estadisticas = estadistica.ToString().Split(',');
                    DgvEstadisticas.Rows.Add(estadisticas);
                }
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
            set 
            {
                Dictionary<int, string> ListaClubes = new Dictionary<int, string>();
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    ListaClubes.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboClubes.DataSource = new BindingSource(ListaClubes, null);
                CboClubes.DisplayMember = "Value";
                CboClubes.ValueMember = "Key";
                CboClubes.SelectedIndex = -1;
            }
        }

        #endregion

        private void BtnReporte_Click(object sender, EventArgs e)
        {

        }

        #region Miembros de IListadoCategorias

        public List<object> ListaUI
        {
            set 
            {
                Dictionary<int, string> ListaCategorias = new Dictionary<int, string>();
                foreach (Object Categoria in value)
                {
                    Object[] DatosClub = Categoria.ToString().Split(',');
                    ListaCategorias.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboCategorias.DataSource = new BindingSource(ListaCategorias, null);
                CboCategorias.DisplayMember = "Value";
                CboCategorias.ValueMember = "Key";
                CboCategorias.SelectedIndex = -1;
            }
        }

        #endregion
    }
}
