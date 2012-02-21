using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio;
using Servicio.InterfacesUI;
using ApplicationContext;

namespace Slam
{
    public partial class FrmListaTorneos : Form, IListadoTorneos
    {
        string ImplementaTorneos = "TorneoServicio";
        IListadoTorneoServicio TorneoServicio;
        public FrmListaTorneos()
        {
            InitializeComponent();
        }

        private void FrmListaTorneos_Load(object sender, EventArgs e)
        {
            try
            {
                TorneoServicio = (IListadoTorneoServicio)AppContext.Instance.GetObject(ImplementaTorneos);
                TorneoServicio.Actualizar();
                TorneoServicio.Listar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

  

        #region Miembros de IListadoTorneos

        public List<object> ListaUI
        {
            set 
            {
            if (DgvListaTorneos.ColumnCount > 0)
                    DgvListaTorneos.Columns.Clear();
                DgvListaTorneos.Columns.Add("IdTorneo", "IdTorneo");
                DgvListaTorneos.Columns.Add("Club", "Organiza");
                DgvListaTorneos.Columns.Add("Nombre", "Nombre");
                DgvListaTorneos.Columns.Add("Categoria", "Categoria");
                DgvListaTorneos.Columns.Add("Sexo", "Sexo");
                DgvListaTorneos.Columns.Add("Cupo", "Cupo");
                DgvListaTorneos.Columns.Add("FecIni", "Inicio Del Torneo");
                DgvListaTorneos.Columns.Add("FecFin", "Fin Del Torneo");
                DgvListaTorneos.Columns.Add("FecIniInsc", "Inicio De Inscripciones");
                DgvListaTorneos.Columns.Add("FecFinInsc", "Fin De Inscripciones");
                DgvListaTorneos.Columns.Add("Tipo", "Tipo");
                DgvListaTorneos.Columns.Add("TipoInsc", "Tipo De Inscripcion");
                DgvListaTorneos.Columns.Add("Estado", "Estado");
                DgvListaTorneos.Columns["IdTorneo"].Visible=false;
                if (DgvListaTorneos.RowCount > 0)
                    DgvListaTorneos.Rows.Clear();
                foreach (object Torneo in value)
                {
                    object[] DatosTorneo = Torneo.ToString().Split(',');
                    DatosTorneo[12] = ((EstadoTorneo)Convert.ToInt32(DatosTorneo[12])).ToString();
                    DgvListaTorneos.Rows.Add(DatosTorneo);

                }
            }
            
            }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoTorneo NuevoTorneo = new FrmNuevoTorneo();
            NuevoTorneo.ShowDialog();
            if (NuevoTorneo.DialogResult == DialogResult.OK)
            {
                TorneoServicio.Actualizar();
                TorneoServicio.Listar(this);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvListaTorneos.SelectedRows.Count == 1)
            {
                FrmNuevoTorneo ModificaTorneo = new FrmNuevoTorneo(Convert.ToInt32(DgvListaTorneos.SelectedRows[0].Cells["IdTorneo"].Value));
                
                if (ModificaTorneo.ShowDialog() == DialogResult.OK)
                    {
                    TorneoServicio.Actualizar();
                    TorneoServicio.Listar(this);
                    }
            }
             else
             { 
            MessageBox.Show("Debe Seleccionar un Torneo De La Lista");
             }
           
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }

        #endregion
    }

