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
        IListadoClubServicio servicioClubes;
        IJugadorServicio ServicioJugador;
        string ImplementaJugador="JugadorServicio";

        string ImplementaAfiliacion = "AfiliacionServicio";
        IAfiliacionServicio AfilServ;
        public FrmNuevaAfiliacion()
        {
            InitializeComponent();
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioClubes.Listar(this);
        }

        public FrmNuevaAfiliacion(int IdClub, int DniJugador)
        {
            InitializeComponent();
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioClubes.Listar(this);
            this.IdClub = IdClub;
            this.Dni = DniJugador;
            this.CboListaClubes.Enabled = false;
            this.TxtDni.Enabled = false;
            

        }
        private void FrmNuevaAfiliacion_Load(object sender, EventArgs e)
        {
            
           AfilServ = (IAfiliacionServicio)AppContext.Instance.GetObject(ImplementaAfiliacion);
           ServicioJugador = (IJugadorServicio)AppContext.Instance.GetObject(ImplementaJugador);
           if (CboListaClubes.SelectedIndex > -1 && TxtDni.Text != "")
           {
               AfilServ.Buscar(this);
           }
        }

        #region Miembros de IAfiliacionUI

        public int IdClub
        {
            get
            {
                return Convert.ToInt32(((KeyValuePair<int,string>)CboListaClubes.SelectedItem).Key);
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
            FrmNuevaPersona NuevoJugador = new FrmNuevaPersona(TipoPersona.Jugador);
            if (NuevoJugador.ShowDialog() == DialogResult.OK)
            {
                TxtDni.Text = NuevoJugador.DniJugador.ToString();
            }
        }

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {
            set
            {
                Dictionary<int, string> ListaClubes = new Dictionary<int, string>();
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    ListaClubes.Add(Convert.ToInt32(DatosClub[0]), DatosClub[1].ToString());
                }
                CboListaClubes.DataSource = new BindingSource(ListaClubes, null);
                CboListaClubes.DisplayMember = "Value";
                CboListaClubes.ValueMember = "Key";
                CboListaClubes.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AfilServ.Existe(this))
            {
                AfilServ.Modificar(this);
            }
            else
            {
                AfilServ.Agregar(this);
            }
        }

        #endregion

        

        private void BtnComprobar_Click(object sender, EventArgs e)
        {
            if (TxtDni.Text == "")
            {
                MessageBox.Show("El Dni No Puede Estar En Blanco");
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
    }
}

