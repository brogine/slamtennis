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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (EpLogin.GetError(TxtUsuario) == "" && EpLogin.GetError(TxtPassword) == "")
            {
                FrmPrincipal Principal = new FrmPrincipal(this);
                Principal.Show();
                this.Hide();
            }
        }

        private void TxtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (TxtUsuario.Text == "")
                EpLogin.SetError(TxtUsuario, "Ingrese un Usuario válido.");
            else
                EpLogin.SetError(TxtUsuario, "");
        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TxtPassword.Text == "")
                EpLogin.SetError(TxtPassword, "Ingrese un Password válido.");
            else
                EpLogin.SetError(TxtPassword, "");
        }
    }
}
