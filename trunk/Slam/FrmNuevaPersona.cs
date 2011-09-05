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
    public partial class FrmNuevaPersona : Form
    {
        TipoPersona Tipo;
        public FrmNuevaPersona(TipoPersona _Tipo)
        {
            InitializeComponent();
            Tipo = _Tipo;
        }

        public FrmNuevaPersona(TipoPersona _Tipo, int _Dni)
        {
            InitializeComponent();
            Tipo = _Tipo;
        }

        private void FrmNuevaPersona_Load(object sender, EventArgs e)
        {
            if (Tipo == TipoPersona.Empleado)
                TpStats.Parent = null;
            this.Text = "Nueva/o " + Tipo.ToString();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtDni.Text != string.Empty && TxtNombre.Text != string.Empty &&
                TxtApellido.Text != string.Empty && DtpFechaNac.Value != DateTime.Today &&
                CboNacionalidad.SelectedIndex > -1 && (RbMasculino.Checked || RbMasculino.Checked) &&
                CboProvincia.SelectedIndex > -1 && CboLocalidades.SelectedIndex > -1 &&
                TxtDomicilio.Text != string.Empty)
            {
                if (TxtUsuario.Text != string.Empty && TxtPassword.Text != string.Empty)
                {
					this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Complete los datos de Login porfavor.");
            }
            else
            {
                MessageBox.Show("Complete todos los campos de Datos Personales porfavor.");
            }
        }

        private void BtnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            FrmNuevaUbicacion nUbicacion = new FrmNuevaUbicacion();
            nUbicacion.Show();
        }
        
        void BtnCancelarClick(object sender, EventArgs e)
        {
        	GC.Collect();
        	GC.WaitForPendingFinalizers();
        	this.DialogResult = DialogResult.Cancel;
        	this.Close();
        }
    }
}
