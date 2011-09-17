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
    public partial class FrmListaArbitros : Form, IListadoArbitros
    {
        string ImplementaArbitros = "ArbitroServicio";
        IListadoArbitrosServicio servicioArbitros;
        public FrmListaArbitros()
        {
            InitializeComponent();
        }

        private void FrmListaArbitros_Load(object sender, EventArgs e)
        {
            servicioArbitros = (IListadoArbitrosServicio)AppContext.Instance.GetObject(ImplementaArbitros);
            servicioArbitros.ListarArbitros(this);
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
                if (modificarJugador.ShowDialog() == DialogResult.OK)
                    servicioArbitros.ListarArbitros(this);
            }
            else
                MessageBox.Show("Elija un Arbitro de la grilla para Modificar", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #region Miembros de IListadoArbitros

        public List<object> ListarArbitros
        {
            set 
            {
                if (DgvArbitrosClub.ColumnCount > 0)
                    DgvArbitrosClub.Columns.Clear();
                DgvArbitrosClub.Columns.Add("Dni", "Dni");
                DgvArbitrosClub.Columns.Add("ApellidoNombre", "Apellido y Nombre");
                DgvArbitrosClub.Columns.Add("Nivel", "Nivel");
                DgvArbitrosClub.Columns.Add("Badge", "Badge");
                if (DgvArbitrosClub.RowCount > 0)
                    DgvArbitrosClub.Rows.Clear();
                foreach (object Arbitro in value)
                {
                    object[] DatosArbitro = Arbitro.ToString().Split(',');
                    DgvArbitrosClub.Rows.Add(DatosArbitro);
                }
            }
        }

        #endregion
    }
}
