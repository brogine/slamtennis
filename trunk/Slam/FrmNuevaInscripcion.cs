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
using Reportes;

namespace Slam
{
    public partial class FrmNuevaInscripcion : Form, IListadoTorneos, IInscripcionUI
    {
        string ImplementaTorneos = "TorneoServicio";
        string ImplementaInscripciones = "InscripcionServicio";
        IListadoTorneoServicio servicioTorneos;
        IInscripcionServicio servicioInscripciones;
        ITorneoServicio servicioTorneoTipo;
        int IdInscripcionActual = 0;
        bool ModificarInscripcion = false;
      
        public FrmNuevaInscripcion()
        {
            InitializeComponent();
            this.Text = "Nueva Inscripción";
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarTorneosAbiertos(this);
            servicioInscripciones = (IInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
            ChkEstado.Checked = true;
        }

        public FrmNuevaInscripcion(int IdInscripcion)
        {
            InitializeComponent();
            IdInscripcionActual = IdInscripcion;
            this.Text = "Modificar Inscripción";
            servicioTorneos = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
            servicioTorneos.ListarTorneosAbiertos(this);
            servicioInscripciones = (IInscripcionServicio)AppContext.Instance.GetObject(ImplementaInscripciones);
            servicioInscripciones.Buscar(this);
        }

        private void FrmNuevaInscripcion_Load(object sender, EventArgs e)
        {
            
            servicioTorneoTipo = (ITorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
        }

        #region Miembros de IListadoTorneos

        public List<object> ListaUI
        {
            set 
            {
                Dictionary<int, string> ListaTorneos = new Dictionary<int, string>();
                if (value.Count > 0)
                {
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
        }

        #endregion

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (EpInscripciones.GetError(CboTorneos) == "" && EpInscripciones.GetError(TxtDniJugador1) == "" &&
                    EpInscripciones.GetError(TxtDniJugador2) == "")
                {
                    bool crearReporte = false;
                    if (IdInscripcionActual > 0)
                    {
                        servicioInscripciones.Modificar(this);
                        if (MessageBox.Show("Inscripción Nro: " + IdInscripcionActual + " Actualizada con éxito" + ". ¿Desea generar comprobante?",
                            "Inscripción a Torneo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            crearReporte = true;
                    }
                    else
                    {
                        IdInscripcionActual = servicioInscripciones.Agregar(this);
                        if (MessageBox.Show("Inscripción Realizada con éxito. Nro Inscripción: " + IdInscripcionActual + ". ¿Desea generar comprobante?",
                            "Inscripción a Torneo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            crearReporte = true;
                    }
                    if (crearReporte)
                    {
                        IReportesServicio servicioReportes = new ReportesServicio();
                        object ReportedeInscripcion = servicioReportes.CrearInstancia("CuponInscripcion", IdInscripcionActual);
                        FrmReportes frmReportes = new FrmReportes(ReportedeInscripcion);
                        frmReportes.MdiParent = this.MdiParent;
                        frmReportes.Show();
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Complete todos los campos antes de continuar.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CboTorneos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #region Miembros de IInscripcionUI

        public int IdInscripcion
        {
            get
            {
                return IdInscripcionActual;
            }
            set
            {
                IdInscripcionActual = value;
                CboTorneos.SelectedValue = value;
                TxtNroInscripcion.Text = value.ToString();
            }
        }

        public int IdTorneo
        {
            get
            {
                return (int)CboTorneos.SelectedValue;
            }
            set
            {
                CboTorneos.SelectedValue = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return DtpFecha.Value;
            }
            set
            {
                DtpFecha.Value = value;
            }
        }

        public bool Estado
        {
            get
            {
                return ChkEstado.Checked;
            }
            set
            {
                ChkEstado.Checked = value;
            }
        }

        public int DniJugador1
        {
            get
            {
                return int.Parse(TxtDniJugador1.Text);
            }
            set
            {
                TxtDniJugador1.Text = value.ToString();
            }
        }

        public int DniJugador2
        {
            get
            {
                if (TxtDniJugador2.Text == "")
                    return 0;
                else
                    return int.Parse(TxtDniJugador2.Text);
            }
            set
            {
                TxtDniJugador2.Text = value.ToString();
            }
        }

        public bool ModificarJugador
        {
            get { return ModificarInscripcion; }
        }

        #endregion

        private void CboTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TipoTorneo tipoTorneo = (TipoTorneo)servicioTorneoTipo.GetTipoTorneo((int)CboTorneos.SelectedValue);
            if (tipoTorneo == TipoTorneo.Single)
            {
                TxtDniJugador2.Enabled = false;
                TxtNroInscripcion.Enabled = false;
            }
            else
            {
                TxtDniJugador2.Enabled = true;
                TxtNroInscripcion.Enabled = true;
            }
        }

        private void CboTorneos_Validating(object sender, CancelEventArgs e)
        {
            if (CboTorneos.SelectedIndex < 0)
                EpInscripciones.SetError(CboTorneos, "Debe Elegir un Torneo del Desplegable");
            else
                EpInscripciones.SetError(CboTorneos, "");
        }

        private void TxtDniJugador1_Validating(object sender, CancelEventArgs e)
        {
            if (TxtDniJugador1.Text == "")
                EpInscripciones.SetError(TxtDniJugador1, "Ingrese un Dni de un Jugador Válido");
            else
                EpInscripciones.SetError(TxtDniJugador1, "");
        }

        private void TxtDniJugador2_Validating(object sender, CancelEventArgs e)
        {
            if(EpInscripciones.GetError(TxtDniJugador2) != "Ingrese un Dni de un Jugador Válido")
            {
                if (TxtDniJugador2.Text == "")
                    EpInscripciones.SetError(TxtDniJugador2, "Ingrese un Dni de un Jugador Válido");
                else
                    EpInscripciones.SetError(TxtDniJugador2, "");
            }
        }

        private void TxtDniJugador1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtDniJugador1.Text != "")
                if (e.KeyChar == 13)
                    this.ValidarJugador(TxtDniJugador1);
        }

        private void TxtDniJugador2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtDniJugador2.Text != "")
                if (e.KeyChar == 13)
                    this.ValidarJugador(TxtDniJugador2);
        }

        private void TxtDniJugador1_Leave(object sender, EventArgs e)
        {
            this.ValidarJugador(TxtDniJugador1);
        }

        private void TxtDniJugador2_Leave(object sender, EventArgs e)
        {
            this.ValidarJugador(TxtDniJugador2);
        }

        private void ValidarJugador(MaskedTextBox Control)
        {
            if (servicioInscripciones.Existe((int)CboTorneos.SelectedValue, int.Parse(Control.Text)))
                EpInscripciones.SetError(Control, "El Jugador ya está inscripto en ese torneo.");
            else
            {
                if (!servicioInscripciones.ValidarInscripcion((int)CboTorneos.SelectedValue, int.Parse(Control.Text)))
                    EpInscripciones.SetError(Control, "La Categoría del Jugador no corresponde con la del Torneo o El Dni No corresponde a un Jugador Existente");
                else
                    EpInscripciones.SetError(Control, "");
            }
        }
    }
}
