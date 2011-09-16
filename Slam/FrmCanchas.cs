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
    public partial class FrmCanchas : Form, ICanchasUI
    {
        string ImplementaCanchas = "CanchasServicio";
        ICanchasServicio servicioCanchas;
        int IdCanchaActual = 0;
        public FrmCanchas()
        {
            InitializeComponent();
        }

        public FrmCanchas(int IdCancha)
        {
            InitializeComponent();
            this.IdCanchaActual = IdCancha;
        }

        private void FrmCanchas_Load(object sender, EventArgs e)
        {
            servicioCanchas = (ICanchasServicio)AppContext.Instance.GetObject(ImplementaCanchas);
        }

        private void CboSede_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboSuperficie_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboSede_Validating(object sender, CancelEventArgs e)
        {
            if (CboSede.SelectedIndex < 0)
                EpCanchas.SetError(CboSede, "Debe Seleccionar a qué Sede pertenece");
            else
                EpCanchas.SetError(CboSede, "");
        }

        private void CboSuperficie_Validating(object sender, CancelEventArgs e)
        {
            if (CboSuperficie.SelectedIndex < 0)
                EpCanchas.SetError(CboSuperficie, "Debe Seleccionar la superficie de la cancha");
            else
                EpCanchas.SetError(CboSuperficie, "");
        }

        private void CboTipo_Validating(object sender, CancelEventArgs e)
        {
            if (CboTipo.SelectedIndex < 0)
                EpCanchas.SetError(CboTipo, "Debe Seleccionar el tipo de cancha");
            else
                EpCanchas.SetError(CboTipo, "");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (EpCanchas.GetError(CboSede) == "" && EpCanchas.GetError(CboSuperficie) == "" && EpCanchas.GetError(CboTipo) == "")
            {
                try
                {
                    if (IdCancha > 0)
                        servicioCanchas.Modificar(this);
                    else
                        servicioCanchas.Agregar(this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region Miembros de ICanchasUI

        public int IdCancha
        {
            get { return IdCanchaActual; }
        }

        public int IdSede
        {
            get { return (int)CboSede.SelectedValue; }
        }

        public int TipoCancha
        {
            get
            {
                return (int)CboTipo.SelectedValue;
            }
            set
            {
                CboTipo.SelectedValue = value;
            }
        }

        public int Superficie
        {
            get
            {
                return (int)CboSuperficie.SelectedValue;
            }
            set
            {
                CboSuperficie.SelectedValue = value;
            }
        }

        public bool Luz
        {
            get
            {
                return ChkLuz.Checked;
            }
            set
            {
                ChkLuz.Checked = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return int.Parse(TxtCantidad.Text);
            }
            set
            {
                TxtCantidad.Text = value.ToString();
            }
        }

        #endregion
    }
}
