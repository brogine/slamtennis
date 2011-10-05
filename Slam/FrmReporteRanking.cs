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
using Reportes;
using System.Collections;

namespace Slam
{
    public partial class FrmReporteRanking : Form, IListadoCategorias
    {
        string ImplementaCategorias = "CategoriaServicio";
        IListadoCategoriaServicio servicioCategorias;
        public FrmReporteRanking()
        {
            InitializeComponent();
        }

        private void FrmReporteRanking_Load(object sender, EventArgs e)
        {
            servicioCategorias = (IListadoCategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
            servicioCategorias.Listar(this);
        }

        private void CboCategorias_Validating(object sender, CancelEventArgs e)
        {
            if (CboCategorias.SelectedIndex < 0)
                EpReporteRanking.SetError(CboCategorias, "Debe Elegir una Categoría para Proceder.");
            else
                EpReporteRanking.SetError(CboCategorias, "");
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (EpReporteRanking.GetError(CboCategorias) == "")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public int IdCategoria
        {
            get { return Convert.ToInt32(((KeyValuePair<int, string>)CboCategorias.SelectedItem).Key); }
        }

        #region Miembros de IListadoCategorias

        public List<object> ListaUI
        {
            set
            {
                Dictionary<int, string> ListaCategorias = new Dictionary<int, string>();
                foreach (Object Torneo in value)
                {
                    Object[] DatosCategoria = Torneo.ToString().Split(',');
                    ListaCategorias.Add(Convert.ToInt32(DatosCategoria[0]), DatosCategoria[1].ToString());
                }
                CboCategorias.DataSource = new BindingSource(ListaCategorias, null);
                CboCategorias.DisplayMember = "Value";
                CboCategorias.ValueMember = "Key";
                CboCategorias.SelectedIndex = -1;
            }
        }

        #endregion
    }
}
