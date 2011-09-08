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
    public partial class FrmNuevoClub : Form, IClubUI
    {
        string ImplementaClubes = "ClubServicio";
        IClubServicio ClubServicio;
        int idClub = -1;
        public FrmNuevoClub()
        {
            InitializeComponent();
        }

        public FrmNuevoClub(int idClub)
        {
            InitializeComponent();
            this.idClub = idClub;
        }

        private void FrmNuevoClub_Load(object sender, EventArgs e)
        {
            ClubServicio = (IClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            if (idClub == -1)
            {
                ChkEstado.Checked = true;
                ChkEstado.Enabled = false;
                this.Text = "Nuevo Club";
            }
            else
            {
                this.Text = "Modificar Club";
                ClubServicio.Buscar(this);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClubServicio.Agregar(this);
            this.DialogResult= DialogResult.OK;
        }

        #region Miembros de IClubUI

        public int IdClub
        {
            get
            {
                return idClub;
            }
            set
            {
                idClub = value;
            }
        }

        public int DniPresidente
        {
            get
            {
                return int.Parse(TxtNombrePresidente.Text);
            }
            set
            {
                TxtNombrePresidente.Text = value.ToString();
            }
        }

        public string NombrePresidente
        {
            get { return TxtNombrePresidente.Text; }
            set { TxtNombrePresidente.Text = value; }
        }

        public string NombreClub
        {
            get
            {
                return TxtNombreClub.Text;
            }
            set
            {
                TxtNombreClub.Text = value;
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

    }
}
