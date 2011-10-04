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
    public partial class FrmListaCategorias : Form, IListadoCategorias
    {
        string ImplementaCategorias = "CategoriaServicio";
        IListadoCategoriaServicio ServicioCategoria;
        public FrmListaCategorias()
        {
            InitializeComponent();
        }

        private void FrmListaCategorias_Load(object sender, EventArgs e)
        {
            ServicioCategoria = (IListadoCategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
            ServicioCategoria.Listar(this);
        }

        #region Miembros de IListadoCategorias

        public List<object> ListaUI
        {
            set 
            {
                if(DgvListaCategorias.Columns.Count > 0)
                    DgvListaCategorias.Columns.Clear();
                DgvListaCategorias.Columns.Add("Id","Id");
                DgvListaCategorias.Columns["Id"].Visible=false;
                DgvListaCategorias.Columns.Add("Nombre","Nombre");
                DgvListaCategorias.Columns.Add("EdadMin","Edad Minima");
                DgvListaCategorias.Columns.Add("EdadMax","Edad Maxima");
                DgvListaCategorias.Columns.Add("Estado", "Estado");
                DgvListaCategorias.Columns["Estado"].Visible = false;
                if (DgvListaCategorias.RowCount > 0)
                    DgvListaCategorias.Rows.Clear();
                foreach (object Categoria in value)
                {
                    object[] DatosCategoria = Categoria.ToString().Split(',');
                    int IdFila = DgvListaCategorias.Rows.Add(DatosCategoria);
                    if (!Convert.ToBoolean(DatosCategoria[4]))
                    {
                        DgvListaCategorias.Rows[IdFila].DefaultCellStyle.BackColor = Color.Red;

                    }
                }
            }
        }

        #endregion

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevaCategoria NuevaCat = new FrmNuevaCategoria();
            if (NuevaCat.ShowDialog() == DialogResult.OK)
                ServicioCategoria.Listar(this);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (DgvListaCategorias.SelectedRows.Count == 1)
            {
                FrmNuevaCategoria ModificarCat = new FrmNuevaCategoria(Convert.ToInt32(DgvListaCategorias.SelectedRows[0].Cells["Id"].Value));
                if(ModificarCat.ShowDialog() == DialogResult.OK)
                    ServicioCategoria.Listar(this);
            }
            else
            { 
                MessageBox.Show("Debe Seleccionar Una Categoria De La Lista Para Poder Modificarla");
            }
        }
    }
}
