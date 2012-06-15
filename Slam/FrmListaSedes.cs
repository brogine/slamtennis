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
    public partial class FrmListaSedes : Form, IListadoClubes, IListadoSedes, IListadoCanchas
    {
        string ImplementaSedes = "SedesServicio";
        string ImplementaClubes = "ClubServicio";
        string ImplementaCanchas = "CanchasServicio";
        IListadoSedesServicio servicioSedes;
        IListadoClubServicio servicioClubes;
        IListadoCanchasServicio servicioCanchas;

        public FrmListaSedes()
        {
            InitializeComponent();
            servicioSedes = (IListadoSedesServicio)AppContext.Instance.GetObject(ImplementaSedes);
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioCanchas = (IListadoCanchasServicio)AppContext.Instance.GetObject(ImplementaCanchas);
        }

        private void FrmListaSedes_Load(object sender, EventArgs e)
        {
            try
            {
                servicioClubes.ListarActivos(this);
                servicioSedes.Listar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnNueva_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevaSede nuevaSede = new FrmNuevaSede();
                if (nuevaSede.ShowDialog() == DialogResult.OK)
                    servicioSedes.Listar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSedes.SelectedRows.Count == 1)
                {
                    FrmNuevaSede modificarSede = new FrmNuevaSede(Convert.ToInt32(DgvSedes.SelectedRows[0].Cells["Id"].Value));
                    if (modificarSede.ShowDialog() == DialogResult.OK)
                        servicioSedes.Listar(this);
                }
                else
                    MessageBox.Show("Seleccione una Sede de la grilla para continuar.");
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
                CboClubes.Items.Add(new DictionaryEntry(string.Empty, "-1"));
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
            try
            {
                servicioSedes.Listar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboClubes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnNuevaCancha_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCanchas nuevaCancha = new FrmCanchas(this.IdClub);
                if (nuevaCancha.ShowDialog() == DialogResult.OK)
                    servicioCanchas.Listar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModificarCancha_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvCanchas.SelectedRows.Count == 1)
                {
                    FrmCanchas nuevaCancha = new FrmCanchas(this.IdClub, Convert.ToInt32(DgvCanchas.SelectedRows[0].Cells["Id"].Value));
                    if (nuevaCancha.ShowDialog() == DialogResult.OK)
                        servicioCanchas.Listar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Miembros de IListadoCanchas

        public int IdSede
        {
            get { return Convert.ToInt32(DgvSedes.SelectedRows[0].Cells["Id"].Value); }
        }

        public List<object> ListaCanchas
        {
            set 
            {
                if (DgvCanchas.ColumnCount > 0)
                    DgvCanchas.Columns.Clear();
                DgvCanchas.Columns.Add("Id", "Id");
                DgvCanchas.Columns["Id"].Visible = false;
                DgvCanchas.Columns.Add("Superficie", "Superficie");
                DgvCanchas.Columns.Add("Tipo", "Tipo");
                DgvCanchas.Columns.Add("Luz", "Luz");
                DgvCanchas.Columns.Add("Cantidad", "Cantidad");
                if (DgvCanchas.RowCount > 0)
                    DgvCanchas.Rows.Clear();
                foreach (Object cancha in value)
                {
                    object[] DatosCancha = cancha.ToString().Split(',');
                    DgvCanchas.Rows.Add(DatosCancha);
                }
            }
        }

        #endregion

        private void DgvSedes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DgvSedes.SelectedRows.Count == 1)
                {
                    servicioCanchas.Listar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
