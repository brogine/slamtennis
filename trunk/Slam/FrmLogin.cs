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

namespace Slam
{
    public partial class FrmLogin : Form, ILoginUI
    {
        ILoginServicio LoginServicio;
        string ImplementaLogin = "LoginServicio";

        public FrmLogin()
        {
            InitializeComponent();
            try
            {
                LoginServicio = (ILoginServicio)AppContext.Instance.GetObject(ImplementaLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //if (EpLogin.GetError(TxtUsuario) == "" && EpLogin.GetError(TxtPassword) == "")
            //{
            //    try
            //    {
            //        if (LoginServicio.Validar(this) != 0)
            //        {
                          FrmPrincipal Principal = new FrmPrincipal(this);
                          Principal.Show();
                          this.Hide();
            //        }
            //        else
            //            MessageBox.Show("Datos de Login incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
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

        #region Miembros de ILoginUI

        public string Usuario
        {
            get { return TxtUsuario.Text; }
        }

        public string Password
        {
            get { return TxtPassword.Text; }
        }

        public int Dni
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Estado
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
