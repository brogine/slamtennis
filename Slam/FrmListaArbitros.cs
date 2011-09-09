using System;
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
    public partial class FrmListaArbitros : Form
    {
    	//IListadoArbitroServicio servicioArbitros;
        public FrmListaArbitros()
        {
            InitializeComponent();
        }

        private void FrmListaArbitros_Load(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaPersona nuevoArbitro = new FrmNuevaPersona(TipoPersona.Arbitro);
            nuevoArbitro.Show();
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
    	
    }
}
