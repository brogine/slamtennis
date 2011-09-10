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
        }

        public FrmNuevaAfiliacion(int IdClub, int DniJugador)
        {
            InitializeComponent();
            this.IdClub = IdClub;
            this.Dni = DniJugador;
        }
        private void FrmNuevaAfiliacion_Load(object sender, EventArgs e)
        {
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioClubes.Listar(this);
           AfilServ = (IAfiliacionServicio)AppContext.Instance.GetObject(ImplementaAfiliacion);
           ServicioJugador = (IJugadorServicio)AppContext.Instance.GetObject(ImplementaJugador);
        }

        #region Miembros de IAfiliacionUI

        public int IdClub
        {
            get
            {
                return Convert.ToInt32(((DictionaryEntry)CboListaClubes.SelectedItem).Value);
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
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    CboListaClubes.Items.Add(new DictionaryEntry(DatosClub[1], DatosClub[0]));
                }
                CboListaClubes.DisplayMember = "Key";
                CboListaClubes.ValueMember = "Value";
                CboListaClubes.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                AfilServ.Agregar(this);
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

