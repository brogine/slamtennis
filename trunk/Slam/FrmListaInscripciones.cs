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
        IListadoInscripcionServicio servicioListadoInscripciones;
        IInscripcionServicio servicioInscripciones;
        IListadoTorneoServicio servicioTorneos;
        public FrmListaInscripciones()
        {
            InitializeComponent();
        }

        private void FrmListaInscripciones_Load(object sender, EventArgs e)
        {
            if (CboTorneos.SelectedIndex > -1)
            {
                BtnAgregar.Enabled = true;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
            }
            else
            {
                BtnAgregar.Enabled = false;
                BtnModificar.Enabled = false;
                BtnEliminar.Enabled = false;
            }
            try
            {
                servicioListadoInscripciones = (IListadoInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
                servicioInscripciones = (IInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
                servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
                servicioTorneos.Listar(this);
                
            }
            catch (Exception ex)
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

        private void CboTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                servicioListadoInscripciones.ListarPorTorneo(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevaInscripcion nuevaInscripcion = new FrmNuevaInscripcion();
                if (nuevaInscripcion.ShowDialog() == DialogResult.OK)
                    if (CboTorneos.SelectedIndex > -1)
                        servicioListadoInscripciones.ListarPorTorneo(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvListaInscripciones.SelectedRows.Count == 1)
                {
                    FrmNuevaInscripcion modificarInscripcion = new FrmNuevaInscripcion
                        (Convert.ToInt32(DgvListaInscripciones.SelectedRows[0].Cells["Id"].Value));
                    if (modificarInscripcion.ShowDialog() == DialogResult.OK)
                        servicioListadoInscripciones.ListarPorTorneo(this);
                }
                else
                    MessageBox.Show("Seleccione una Inscripción para modificarla.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Miembros de IListadoInscripciones

        public List<object> ListarPorTorneo
        {
            set
            {
                TipoTorneo tipoDeTorneo = TipoTorneo.Single;
                if (value.Count > 0)
                {
                    foreach (object Inscripcion in value)
                    {
                        object[] datos = Inscripcion.ToString().Split(',');
                        tipoDeTorneo = (TipoTorneo)Convert.ToInt32(datos[1]);
                        if (tipoDeTorneo == TipoTorneo.Doble)
                            break;
                    }
                }
                if (DgvListaInscripciones.ColumnCount > 0)
                    DgvListaInscripciones.Columns.Clear();
                DgvListaInscripciones.Columns.Add("Id", "Nro. Inscripción");
                DgvListaInscripciones.Columns.Add("Jugador1", "Jugador1");
                if (tipoDeTorneo == TipoTorneo.Doble)
                    DgvListaInscripciones.Columns.Add("Jugador2", "Jugador2");
                DgvListaInscripciones.Columns.Add("Fecha", "Fecha de Inscripción");
                if (DgvListaInscripciones.RowCount > 0)
                    DgvListaInscripciones.Rows.Clear();
                foreach (object Inscripcion in value)
                {
                    object[] datosInscripcion = Inscripcion.ToString().Split(',');
                    if (tipoDeTorneo == TipoTorneo.Doble)
                        if (datosInscripcion.Length == 5)
                            DgvListaInscripciones.Rows.Add(datosInscripcion[0], datosInscripcion[2], datosInscripcion[3],
                                datosInscripcion[4]);
                        else
                            DgvListaInscripciones.Rows.Add(datosInscripcion[0], datosInscripcion[2], "No Inscripto",
                                datosInscripcion[4]);
                    else
                        DgvListaInscripciones.Rows.Add(datosInscripcion[0], datosInscripcion[2], datosInscripcion[4]);
                }
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
                    ListaTorneos.Add(Convert.ToInt32(DatosTorneo[0]), DatosTorneo[2].ToString());
                }
                CboTorneos.DataSource = new BindingSource(ListaTorneos, null);
                CboTorneos.DisplayMember = "Value";
                CboTorneos.ValueMember = "Key";
                CboTorneos.SelectedIndex = -1;
            }
        }

        #endregion

        private void CboTorneos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvListaInscripciones.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar esa inscripción?", "¿Está Seguro?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    servicioInscripciones.Eliminar(Convert.ToInt32(DgvListaInscripciones.SelectedRows[0].Cells["Id"].Value));
                    
                    servicioListadoInscripciones.ListarPorTorneo(this);
                }
            }
            else
                MessageBox.Show("Debe elegir una Inscripción para eliminarla.");
        }

        private void CboTorneos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTorneos.SelectedIndex > -1)
            {
                BtnAgregar.Enabled = true;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
            }
            else
            {
                BtnAgregar.Enabled = false;
                BtnEliminar.Enabled = false;
                BtnModificar.Enabled = false;
            
            }
        }
    }
}
