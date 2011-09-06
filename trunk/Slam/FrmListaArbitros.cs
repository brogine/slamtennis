﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ApplicationContext;
using Servicio;
using Servicio.InterfacesUI;

namespace Slam
{
    public partial class FrmListaArbitros : Form, IListadoClubes
    {
    	string ImplementaClubes = "ClubServicio";
    	IListadoClubServicio servicioClubes;
    	//IListadoArbitroServicio servicioArbitros;
        public FrmListaArbitros()
        {
            InitializeComponent();
        }

        private void FrmListaArbitros_Load(object sender, EventArgs e)
        {
        	servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
        	servicioClubes.Listar(this);
        }

        private void CmbClubes_SelectionChangeCommitted(object sender, EventArgs e)
        {
        	servicioClubes.Listar(this);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaPersona nuevoJugador = new FrmNuevaPersona(TipoPersona.Arbitro);
            nuevoJugador.Show();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvArbitrosClub.SelectedRows.Count == 1)
            {
                FrmNuevaPersona modificarJugador = new FrmNuevaPersona(TipoPersona.Arbitro,
                    Convert.ToInt32(DgvArbitrosClub.SelectedRows[0].Cells["Dni"].Value));
            	if(modificarJugador.ShowDialog() == DialogResult.OK)
            		Application.DoEvents(); //TODO: Listar arbitros (Refrescar)
            }
            else
                MessageBox.Show("Elija un Arbitro de la grilla para Modificar", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    	
        #region Miembros de IListadoClubes
        
		public List<object> ListarClubes {
			set {
				CboClubes.Items.Add(new DictionaryEntry("Todos", "-1"));
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    CboClubes.Items.Add(new DictionaryEntry(DatosClub[1], DatosClub[0]));
                }
                CboClubes.DisplayMember = "Key";
                CboClubes.ValueMember = "Value";
                CboClubes.SelectedIndex = -1;
			}
		}
        
        #endregion
        
    }
}