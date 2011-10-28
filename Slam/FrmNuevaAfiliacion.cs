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
using System.Collections;
using ApplicationContext;

namespace Slam
{
    public partial class FrmNuevaAfiliacion : Form, IAfiliacionUI, IListadoClubes
    {
        string ImplementaClubes = "ClubServicio";
        string ImplementaJugador = "JugadorServicio";
        string ImplementaAfiliacion = "AfiliacionServicio";
        IListadoClubServicio servicioClubes;
        IJugadorServicio ServicioJugador;
        IAfiliacionServicio AfilServ;

        public FrmNuevaAfiliacion()
        {
             InitializeComponent();
             servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
             servicioClubes.ListarActivos(this);
        }

        public FrmNuevaAfiliacion(int IdClub, int DniJugador)
        {
             InitializeComponent();
             servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
             servicioClubes.ListarActivos(this);
             this.IdClub = IdClub;
             this.Dni = DniJugador;
             this.CboListaClubes.Enabled = false;
             this.TxtDni.Enabled = false;
        }
        private void FrmNuevaAfiliacion_Load(object sender, EventArgs e)
        {
            try
            {
                AfilServ = (IAfiliacionServicio)AppContext.Instance.GetObject(ImplementaAfiliacion);
                ServicioJugador = (IJugadorServicio)AppContext.Instance.GetObject(ImplementaJugador);
                if (CboListaClubes.SelectedIndex > -1 && TxtDni.Text != "")
                    AfilServ.Buscar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Miembros de IAfiliacionUI

        public int IdClub
        {
            get
            {
                return Convert.ToInt32(((KeyValuePair<int,string>)CboListaClubes.SelectedItem).Key); ;
            }
            set
            {
                CboListaClubes.SelectedValue = value;

            }
        }

        public int Dni
        {
            get
            {
                return Convert.ToInt32(TxtDni.Text);
            }
            set
            {
                TxtDni.Text = value.ToString();
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

        #endregion

        private void BtnNuevoJugador_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevaPersona NuevoJugador = new FrmNuevaPersona(TipoPersona.Jugador);
                if (NuevoJugador.ShowDialog() == DialogResult.OK)
                {
                    TxtDni.Text = NuevoJugador.Dni.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {

            set
            {
                if (value.Count>0)
                {
                Dictionary<int, string> ListaClubes = new Dictionary<int, string>();
                foreach (Object Torneo in value)
                {
                    Object[] DatosClub = Torneo.ToString().Split(',');
                    ListaClubes.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboListaClubes.DataSource = new BindingSource(ListaClubes, null);
                CboListaClubes.DisplayMember = "Value";
                CboListaClubes.ValueMember = "Key";
                CboListaClubes.SelectedIndex = -1;
            }
        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EpAfiliacion.GetError(TxtDni) == "" && EpAfiliacion.GetError(CboListaClubes) == "")
            {
                if (AfilServ.Existe(this))
                {
                    AfilServ.Modificar(this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    AfilServ.Agregar(this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Complete Todos Los Campos Antes De Continuar");
            }
        }
           
        

        #endregion

        private void BtnComprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDni.Text == "")
                {
                    LblExiste.ForeColor = Color.Red;
                    LblExiste.Text = "El Dni No Puede Estar En Blanco";
                }
                else
                {
                    if (ServicioJugador.Existe(int.Parse(TxtDni.Text)))
                    {
                        LblExiste.ForeColor = Color.Green;
                        LblExiste.Text = "El Jugador Existe En La Base De Datos";
                    }
                    else
                    {
                        LblExiste.ForeColor = Color.Red;
                        LblExiste.Text = "El Jugador NO Existe En La Base De Datos";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboListaClubes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboListaClubes_Validating(object sender, CancelEventArgs e)
        {
            if (CboListaClubes.SelectedIndex < 0)
                EpAfiliacion.SetError(CboListaClubes, "Debe Elegir un Club del desplegable.");
            else
                EpAfiliacion.SetError(CboListaClubes, "");
        }

        private void TxtDni_Validating(object sender, CancelEventArgs e)
        {
            if (TxtDni.Text == "")
                EpAfiliacion.SetError(TxtDni, "Este campo no puede estar en blanco.");
            else
            {
                EpAfiliacion.SetError(TxtDni, "");
            }
                if (LblExiste.Text == "")
                    EpAfiliacion.SetError(TxtDni, "Presione Botón Comprobar para validar existencia del jugador");
                else
                {
                    EpAfiliacion.SetError(TxtDni,"");
                }

                    if (LblExiste.BackColor == Color.Red)
                    {
                        EpAfiliacion.SetError(TxtDni, "El Jugador no Existe. No puede continuar.");
                    }
                    else
                    {
                        EpAfiliacion.SetError(TxtDni, "");
                    }
                }
            }
        }
    


