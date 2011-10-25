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
       
        int cupo;
        public FrmPuntosTorneo()
        {
            InitializeComponent();
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
            Blanquear();
          CboListaTorneos.SelectedIndex = -1;
          PuntosServicio =  (IPuntosServicio)AppContext.Instance.GetObject(ImplementaPuntos);
          TorneoServicio = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
          TorneoServicio.ListarTorneos(this);


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
                CboListaTorneos.SelectedIndex = -1;
                
            }
        }

        #endregion

        private void CboListaTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (PuntosServicio.Existe(this))
            {
                PuntosServicio.Buscar(this);
            }
            else
            {
                Blanquear();
            }
  
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

            if (PuntosServicio.Existe(this))
            {
                try
                {
                    PuntosServicio.Modificar(this);
                    Blanquear();
                    
                    MessageBox.Show("Puntos Agregados Con Exito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                try
                {
                    PuntosServicio.Agregar(this);
                    Blanquear();
                    MessageBox.Show("Puntos Modificados Con Exito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
    }
}
