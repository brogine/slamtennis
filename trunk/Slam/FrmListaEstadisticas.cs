﻿using System;
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
using Reportes;

namespace Slam
{
    public partial class FrmListaEstadisticas : Form, IListadoEstadisticasCategoria, IListadoClubes , IListadoCategorias
    {
        string ImplementaEstadisticas = "EstadisticasServicio";
        string ImplementaClubes = "ClubServicio";
        string ImplementaCategorias = "CategoriaServicio";
        string ImplementaReportes = "ReportesServicio";
        IListadoEstadisticasServicio servicioEstadisticas;
        IListadoClubServicio servicioClubes;
        IListadoCategoriaServicio servicioCategorias;
        public FrmListaEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmListaEstadisticas_Load(object sender, EventArgs e)
        {
            try
            {
                servicioEstadisticas = (IListadoEstadisticasServicio)AppContext.Instance.GetObject(ImplementaEstadisticas);
                servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
                servicioClubes.ListarActivos(this);
                servicioCategorias = (IListadoCategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
                servicioCategorias.ListarActivas(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        private void CboClubes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CboClubes.SelectedIndex > -1 && CboCategorias.SelectedIndex > -1)
                {
                    servicioEstadisticas.ListarPorCategoriaClub(this);
                    if (RBSingle.Checked == true)
                        servicioEstadisticas.ListarPorCategoriaClub(this);
                    else
                        servicioEstadisticas.ListarPorCategoriaClubDobles(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboCategorias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CboClubes.SelectedIndex > -1 && CboCategorias.SelectedIndex > -1)
                {
                    if (RBSingle.Checked == true)
                        servicioEstadisticas.ListarPorCategoriaClub(this);
                    else
                        servicioEstadisticas.ListarPorCategoriaClubDobles(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                DgvEstadisticas.Columns.Add("Dni", "Dni");
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
            try
            {
                if (DgvEstadisticas.SelectedRows.Count == 1)
                {
                    FrmEstadisticasJugador nuevaEstadistica = new FrmEstadisticasJugador(
                        Convert.ToInt32(DgvEstadisticas.SelectedRows[0].Cells["Dni"].Value),
                        DgvEstadisticas.SelectedRows[0].Cells["NombreApellido"].Value.ToString());
                    if (nuevaEstadistica.ShowDialog() == DialogResult.OK)
                        servicioEstadisticas.ListarPorCategoriaClub(this);
                }
                else
                    MessageBox.Show("Debe Seleccionar Un Jugador De La Lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnVerEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvEstadisticas.SelectedRows.Count == 1)
                {
                    FrmEstadisticasJugador modificarEstadistica = new FrmEstadisticasJugador(
                        Convert.ToInt32(DgvEstadisticas.SelectedRows[0].Cells["Dni"].Value),
                        (int)CboCategorias.SelectedValue,
                        DgvEstadisticas.SelectedRows[0].Cells["NombreApellido"].Value.ToString());
                    if (modificarEstadistica.ShowDialog() == DialogResult.OK)
                        servicioEstadisticas.ListarPorCategoriaClub(this);
                }
                else
                    MessageBox.Show("Debe Seleccionar Un Jugador De La Lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {
            set 
            {
                if (value.Count > 0)
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
        }

        #endregion

        #region Miembros de IListadoCategorias

        public List<object> ListaUI
        {
            set 
            {
                if (value.Count > 0)
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
        }

        #endregion

        private void RBSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (CboCategorias.SelectedIndex > -1 && CboClubes.SelectedIndex > -1)
                servicioEstadisticas.ListarPorCategoriaClub(this);
        }

        private void RBDoble_CheckedChanged(object sender, EventArgs e)
        {
            if (CboCategorias.SelectedIndex > -1 && CboClubes.SelectedIndex > -1)
                servicioEstadisticas.ListarPorCategoriaClubDobles(this);
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            if (CboCategorias.SelectedIndex > -1)
            {
                IReportesServicio servicioReportes = (IReportesServicio)AppContext.Instance.GetObject(ImplementaReportes);
                Object ReporteEstadisticas = servicioReportes.CrearInstancia(ListadoReportes.Ranking,
                    ((KeyValuePair<int, string>)CboCategorias.SelectedItem).Key);
                servicioReportes.Parametros("Categoria", ((KeyValuePair<int, string>)CboCategorias.SelectedItem).Value);
                FrmReportes reportes = new FrmReportes(ReporteEstadisticas);
                reportes.Show();
                reportes.BringToFront();
            }
            else
                MessageBox.Show("Debe elegir una categoría del desplegable para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
