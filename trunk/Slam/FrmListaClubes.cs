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
            try
            {
                ClubServicio = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
                ClubServicio.Listar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoClub NuevoClub = new FrmNuevoClub();
                if (NuevoClub.ShowDialog() == DialogResult.OK)
                    ClubServicio.Listar(this);
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
                if (DgvClubes.SelectedRows.Count == 1)
                {
                    FrmNuevoClub ModificarClub = new FrmNuevoClub(
                        Convert.ToInt32(DgvClubes.SelectedRows[0].Cells[0].Value));

                    if (ModificarClub.ShowDialog() == DialogResult.OK)
                    {
                        ClubServicio.Listar(this);
                    }
                }
                else
                    MessageBox.Show("Seleccione un Club de la grilla para modificar.");
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
                if (DgvClubes.Columns.Count > 0)
                    DgvClubes.Columns.Clear();
                DgvClubes.Columns.Add("IdClub", "Club Nro");
                DgvClubes.Columns.Add("NombreClub", "Nombre");
                DgvClubes.Columns.Add("Presidente", "Presidente");
                DgvClubes.Columns.Add("Estado", "Estado");
                DgvClubes.Columns["Estado"].Visible = false;
                
                if (DgvClubes.Rows.Count > 0)
                    DgvClubes.Rows.Clear();
                foreach (Object Club in value)
                {
                    Object[] DatosClub = Club.ToString().Split(',');
                    int IdFila = DgvClubes.Rows.Add(DatosClub[0], DatosClub[1], DatosClub[2], Convert.ToBoolean(DatosClub[3]));
                    if (Convert.ToBoolean(DatosClub[3]) == false)
                    {
                        DgvClubes.Rows[IdFila].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        #endregion
    }
}
