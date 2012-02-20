using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.Common;

namespace Slam
{
    public partial class FrmConfiguracion : Form
    {
        XmlDocument doc;
        XmlNodeList ListaNodos;
        string dir = System.AppDomain.CurrentDomain.BaseDirectory + "\\Configuracion.xml";
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            doc = new XmlDocument();
            try
            {
                doc.Load(dir);
            }
            catch (Exception)
            {
                throw new Exception("El archivo de Configuración no se encuentra.");
            }

            ListaNodos = doc.GetElementsByTagName("config");

            object elemento = new object();
            foreach (XmlNode Nodo in ListaNodos)
            {
                CboConexiones.Items.Add(Nodo.Attributes["nombre"].Value);
                if (Convert.ToBoolean(Nodo.Attributes["Default"].Value))
                    elemento = Nodo.Attributes["nombre"].Value;
            }
            CboConexiones.SelectedItem = elemento;
        }

        private void ChkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIntegratedSecurity.Checked)
            {
                TxtUsuario.Enabled = false;
                TxtUsuario.Text = "";
                TxtPassword.Enabled = false;
                TxtPassword.Text = "";
            }
            else
            {
                TxtUsuario.Enabled = true;
                TxtPassword.Enabled = true;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        private void CboConexiones_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnProbar_Click(object sender, EventArgs e)
        {
            IDbConnection Conn = null;
            try
            {
            DbProviderFactory Dpf = DbProviderFactories.GetFactory(ListaNodos[CboConexiones.SelectedIndex].Attributes["Proveedor"].Value);
            Conn = Dpf.CreateConnection();
            Conn.ConnectionString = ListaNodos[CboConexiones.SelectedIndex].Attributes["ConnectionString"].Value;
         
                Conn.Open();
                MessageBox.Show("Conexión con la base de datos establecida con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }

        private void CboConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboConexiones.SelectedItem.ToString() == "MySQL")
                ChkIntegratedSecurity.Enabled = false;
            else
                ChkIntegratedSecurity.Enabled = true;

            //Datos de Conexion
            string ConnString = ListaNodos[CboConexiones.SelectedIndex].Attributes["ConnectionString"].Value;
            string Servidor = ConnString.Substring(ConnString.IndexOf("Server="), ConnString.IndexOf(";Database"));
            TxtServidor.Text = Servidor.Replace("Server=", "");
            if (ConnString.Contains("Integrated Security"))
                ChkIntegratedSecurity.Checked = true;
            else
            {
                ChkIntegratedSecurity.Checked = false;
                string Usuario = ConnString.Substring(ConnString.IndexOf("Uid="), ConnString.IndexOf(";Pwd=") - ConnString.IndexOf("Uid="));
                TxtUsuario.Text = Usuario.Replace("Uid=", "");
                string Password = ConnString.Substring(ConnString.IndexOf("Pwd="), ConnString.LastIndexOf(';') - ConnString.IndexOf("Pwd="));
                TxtPassword.Text = Password.Replace("Pwd=", "");
            }

            //Verifico cual es la conexion actual
            if (Convert.ToBoolean(ListaNodos[CboConexiones.SelectedIndex].Attributes["Default"].Value))
            {
                LblConexionActual.Visible = true;
                BtnEstablecer.Enabled = false;
            }
            else
            {
                LblConexionActual.Visible = false;
                BtnEstablecer.Enabled = true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            String ConnString = "";
            if (ChkIntegratedSecurity.Checked)
                ConnString = "Server=" + TxtServidor.Text + ";Database=SlamDB;Integrated Security =SSPI;";
            else
                ConnString = "Server=" + TxtServidor.Text + ";Database=SlamDB;Uid=" + TxtUsuario.Text + ";Pwd=" + TxtPassword.Text + ";";
            ListaNodos[CboConexiones.SelectedIndex].Attributes["ConnectionString"].Value = ConnString;
            doc.Save(dir);
            this.Close();
        }

        private void BtnEstablecer_Click(object sender, EventArgs e)
        {
            ListaNodos[CboConexiones.SelectedIndex].Attributes["Default"].Value = "True";
            foreach (XmlNode nodo in ListaNodos)
            {
                if (nodo.Attributes["nombre"].Value != CboConexiones.SelectedItem.ToString())
                    nodo.Attributes["Default"].Value = "False";
            }
            BtnEstablecer.Enabled = false;
            LblConexionActual.Visible = true;
            doc.Save(dir);
        }

    }
}
