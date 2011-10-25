using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Slam
{
    public partial class FrmReporteCarnet : Form
    {
        public FrmReporteCarnet()
        {
            InitializeComponent();
        }

        private void CboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmReporteCarnet_Load(object sender, EventArgs e)
        {
            CboTipo.DataSource = Enum.GetValues(typeof(TipoPersona));
            CboTipo.SelectedIndex = -1;
        }

        private void CboTipo_Validating(object sender, CancelEventArgs e)
        {
            if (CboTipo.SelectedIndex > -1)
                EpCarnet.SetError(CboTipo, "");
            else
                EpCarnet.SetError(CboTipo, "Debe seleccionar un Tipo");
        }

        private void TxtDni_Validating(object sender, CancelEventArgs e)
        {
            if (TxtDni.Text == "")
                EpCarnet.SetError(TxtDni, "Debe ingresar un Dni");
            else
                EpCarnet.SetError(TxtDni, "");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (EpCarnet.GetError(TxtDni) == "" && EpCarnet.GetError(CboTipo) == "")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public int Dni
        {
            get { return int.Parse(TxtDni.Text); }
        }

        public TipoPersona Tipo
        {
            get { return (TipoPersona)CboTipo.SelectedItem; }
        }
    }
}
