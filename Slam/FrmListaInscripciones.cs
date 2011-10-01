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
            FrmNuevaInscripcion nuevaInscripcion = new FrmNuevaInscripcion();
            if(nuevaInscripcion.ShowDialog() == DialogResult.OK)
                servicioInscripciones.ListarPorTorneo(this);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvListaInscripciones.SelectedRows.Count == 1)
            {
                FrmNuevaInscripcion modificarInscripcion = new FrmNuevaInscripcion
                    (Convert.ToInt32(DgvListaInscripciones.SelectedRows[0].Cells["Id"].Value));
                if (modificarInscripcion.ShowDialog() == DialogResult.OK)
                    servicioInscripciones.ListarPorTorneo(this);
            }
            else
                MessageBox.Show("Seleccione una Inscripción para modificarla.");
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
                        if (datosInscripcion.Length == 6)
                            DgvListaInscripciones.Rows.Add(datosInscripcion[0], datosInscripcion[2], datosInscripcion[3],
                                datosInscripcion[4]);
                        else
                            DgvListaInscripciones.Rows.Add(datosInscripcion[0], datosInscripcion[2], "No Inscripto",
                                datosInscripcion[3]);
                    else
                        DgvListaInscripciones.Rows.Add(datosInscripcion[0], datosInscripcion[2], datosInscripcion[3]);
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
    }
}
