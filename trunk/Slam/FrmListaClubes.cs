﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio.InterfacesUI;
using Servicio;
using ApplicationContext;

namespace Slam
{
    public partial class FrmListaClubes : Form, IListadoClubes
    {
        string ImplementaClubes = "ClubServicio";
        IListadoClubServicio ClubServicio;
        public FrmListaClubes()
        {
            InitializeComponent();
        }

        private void FrmListaClubes_Load(object sender, EventArgs e)
        {
            ClubServicio = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            ClubServicio.Listar(this);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoClub NuevoClub = new FrmNuevoClub();
            NuevoClub.Show();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvClubes.SelectedRows.Count == 1)
            {
                FrmNuevoClub ModificarClub = new FrmNuevoClub(
                    Convert.ToInt32(DgvClubes.SelectedRows[0].Cells[0].Value));
                ModificarClub.Show();
            }
            else
                MessageBox.Show("Seleccione un Club de la grilla para modificar.");
        }

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {
            set 
            {
                if (DgvClubes.Columns.Count > 0)
                    DgvClubes.Columns.Clear();
                DgvClubes.Columns.Add("IdClub", "Club Nro");
                DgvClubes.Columns.Add("NombreClub", "Nombre");
                DgvClubes.Columns.Add("Presidente", "Presidente");
                DgvClubes.Columns.Add("Estado", "Estado");
                if (DgvClubes.Rows.Count > 0)
                    DgvClubes.Rows.Clear();
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    DgvClubes.Rows.Add(DatosClub[0], DatosClub[1], DatosClub[2], Convert.ToBoolean(DatosClub[3]));
                }
            }
        }

        #endregion
    }
}