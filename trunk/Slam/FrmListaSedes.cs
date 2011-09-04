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
using System.Collections;

namespace Slam
{
    public partial class FrmListaSedes : Form, IListadoClubes, IListadoSedes
    {
        string ImplementaSedes = "SedesServicio";
        string ImplementaClubes = "ClubServicio";
        IListadoSedesServicio servicioSedes;
        IListadoClubServicio servicioClubes;
        public FrmListaSedes()
        {
            InitializeComponent();
            servicioSedes = (IListadoSedesServicio)AppContext.Instance.GetObject(ImplementaSedes);
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
        }

        private void FrmListaSedes_Load(object sender, EventArgs e)
        {
            servicioClubes.Listar(this);
            servicioSedes.ListarSedes(this);
        }

        private void BtnNueva_Click(object sender, EventArgs e)
        {
            FrmNuevaSede nuevaSede = new FrmNuevaSede();
            if(nuevaSede.ShowDialog() == DialogResult.OK)
                servicioSedes.ListarSedes(this);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvSedes.SelectedRows.Count == 1)
            {
                FrmNuevaSede modificarSede = new FrmNuevaSede(Convert.ToInt32(DgvSedes.SelectedRows[0].Cells["Id"].Value));
                if (modificarSede.ShowDialog() == DialogResult.OK)
                    servicioSedes.ListarSedes(this);
            }
            else
                MessageBox.Show("Seleccione una Sede de la grilla para continuar.");
        }

        #region Miembros de IListadoClubes

        public List<object> ListarClubes
        {
            set 
            {
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

        #region Miembros de IListadoSedes

        public int IdClub
        {
            get 
            {
                if (CboClubes.SelectedIndex > -1)
                    return Convert.ToInt32(((DictionaryEntry)CboClubes.SelectedItem).Value);
                else
                    return -1;
            }
        }

        public List<object> ListarSedes
        {
            set 
            {
                if (DgvSedes.ColumnCount > 0)
                    DgvSedes.Columns.Clear();
                DgvSedes.Columns.Add("Id", "Id");
                DgvSedes.Columns["Id"].Visible = false;
                DgvSedes.Columns.Add("Club", "Club al que pertenece");
                DgvSedes.Columns.Add("Direccion", "Direccion");
                if (DgvSedes.RowCount > 0)
                    DgvSedes.Rows.Clear();
                foreach (Object Sede in value)
                {
                    object[] datosSede = Sede.ToString().Split(',');
                    DgvSedes.Rows.Add(datosSede[0], datosSede[1], datosSede[2]);
                }
            }
        }

        #endregion

        private void CboClubes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servicioSedes.ListarSedes(this);
        }

        private void CboClubes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
