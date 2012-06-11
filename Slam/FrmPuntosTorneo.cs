using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio.InterfacesUI;
using ApplicationContext;
using Servicio;

namespace Slam
{
    public partial class FrmPuntosTorneo : Form,IPuntosUI,IListadoTorneos
    {
        string ImplementaPuntos = "PuntosServicio";
        IPuntosServicio PuntosServicio;
        string ImplementaTorneos = "TorneoServicio";
        IListadoTorneoServicio TorneoServicio;
        int IdTorneoActual = 0;
        int cupo;

        public FrmPuntosTorneo()
        {
            InitializeComponent();
        }

        public FrmPuntosTorneo(int idTorneo)
        {
            InitializeComponent();
            this.IdTorneoActual = idTorneo;
        }

        #region Miembros de IPuntosUI

        public int IdTorneo
        {
            get { return ((KeyValuePair<int, string>)CboListaTorneos.SelectedItem).Key; }
        }

        public int PrimeraRonda
        {
            get
            {
                return Convert.ToInt32(TxtPrimeraRonda.Text);
            }
            set
            {
                TxtPrimeraRonda.Text = value.ToString();
            }
        }

        public int SegundaRonda
        {
            get
            {
                return Convert.ToInt32(TxtSegunaRonda.Text);
            }
            set
            {
                TxtSegunaRonda.Text = value.ToString();
            }
        }

        public int Campeon
        {
            get
            {
                return Convert.ToInt32(TxtCampeon.Text);
            }
            set
            {
                TxtCampeon.Text = value.ToString();
            }
        }

        public int CuartosFinal
        {
            get
            {
                return Convert.ToInt32(TxtCuartosFinal.Text);
            }
            set
            {
                TxtCuartosFinal.Text= value.ToString();
            }
        }

        public int SemiFinal
        {
            get
            {
                return Convert.ToInt32(TxtSemiFinal.Text);
            }
            set
            {
                TxtSemiFinal.Text = value.ToString();
            }
        }

        public int Final
        {
            get
            {
                return Convert.ToInt32(TxtFinal.Text);
            }
            set
            {
                TxtFinal.Text = value.ToString();
            }
        }

        #endregion

        private void FrmPuntosTorneo_Load(object sender, EventArgs e)
        {
            try
            {
                Blanquear();
                CboListaTorneos.SelectedIndex = -1;
                PuntosServicio = (IPuntosServicio)AppContext.Instance.GetObject(ImplementaPuntos);
                TorneoServicio = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
                TorneoServicio.Listar(this);
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

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
                CboListaTorneos.DataSource = new BindingSource(ListaTorneos, null);
                CboListaTorneos.DisplayMember = "Value";
                CboListaTorneos.ValueMember = "Key";
                if (IdTorneoActual > 0)
                    CboListaTorneos.SelectedValue = IdTorneoActual;
                else
                    CboListaTorneos.SelectedIndex = -1;
            }
        }

        #endregion

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PuntosServicio.Existe(this))
                {
                    PuntosServicio.Modificar(this);
                    Blanquear();
                    MessageBox.Show("Puntos Agregados Con Exito");
                }
                else
                {
                    PuntosServicio.Agregar(this);
                    Blanquear();
                    MessageBox.Show("Puntos Modificados Con Exito");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Blanquear()
        {
            this.TxtCuartosFinal.Text = "0";
            this.TxtFinal.Text = "0";
            this.TxtPrimeraRonda.Text = "0";
            this.TxtSegunaRonda.Text = "0";
            this.TxtSemiFinal.Text = "0";
            this.TxtCampeon.Text = "0";
        }

        #region Miembros de IPuntosUI

        public int Cupo
        {
            get
            {
                return cupo;
            }
            set
            {
                cupo = value;
            }
        }

        #endregion

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CboListaTorneos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (PuntosServicio.Existe(this))
                    PuntosServicio.Buscar(this);
                else
                    Blanquear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboListaTorneos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
