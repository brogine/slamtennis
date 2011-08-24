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

namespace Slam
{
    public partial class FrmNuevaUbicacion : Form, IListadoPaises, IListadoProvincias,
        IListadoLocalidades, IUbicacionUI
    {
        string ImplementaUbicacion = "UbicacionServicio";
        IPaisServicio PaisServicio;
        IProvinciaServicio ProvinciaServicio;
        ILocalidadServicio LocalidadServicio;

        public FrmNuevaUbicacion()
        {
            InitializeComponent();
        }

        private void FrmNuevaUbicacion_Load(object sender, EventArgs e)
        {
            PaisServicio = (IPaisServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
     
            PaisServicio.ListarPaises(this);
            ProvinciaServicio = (IProvinciaServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            LocalidadServicio = (ILocalidadServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
        }

        private void CboListaPaises_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(CboListaPaises.SelectedIndex > -1)
                ProvinciaServicio.ListarProvincias(this);
        }

        private void CboListaProvincias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(CboListaPaises.SelectedIndex > -1 && CboListaProvincias.SelectedIndex > -1)
                LocalidadServicio.ListarLocalidades(this);
        }

        private void BtnAgregarPais_Click(object sender, EventArgs e)
        {
            if (CboListaPaises.Text != "")
                PaisServicio.AgregarPais(this);
            else
                MessageBox.Show("El nombre del Pais no puede estar en blanco.");
        }

        private void BtnAgregarProvincia_Click(object sender, EventArgs e)
        {
            if (CboListaProvincias.Text != "")
                ProvinciaServicio.AgregarProvincia(this);
            else
                MessageBox.Show("El nombre de la Provincia no puede estar en blanco.");
        }

        private void BtnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            if (CboListaLocalidades.Text != "")
                LocalidadServicio.AgregarLocalidad(this);
            else
                MessageBox.Show("El nombre de la Localidad no puede estar en blanco.");
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        #region Miembros de IListadoPaises

        public Dictionary<int,string> ListarPaises
        {
            set 
            {
                CboListaPaises.DataSource = new BindingSource(value, null);
                CboListaPaises.DisplayMember = "Value";
                CboListaPaises.ValueMember = "Key";
                CboListaPaises.SelectedIndex = -1;
            }
        }

        #endregion

        #region Miembros de IListadoProvincias

        public Dictionary<int, string> ListarProvincias
        {
            set 
            {
                CboListaProvincias.DataSource = new BindingSource(value, null);
                CboListaProvincias.DisplayMember = "Value";
                CboListaProvincias.ValueMember = "Key";
                CboListaProvincias.SelectedIndex = -1;
            }
        }

        public int Pais
        {
            get { return (int)CboListaPaises.SelectedValue; }
        }

        #endregion

        #region Miembros de IListadoLocalidades

        public Dictionary<int, string> ListarLocalidades
        {
            set 
            {
                CboListaLocalidades.DataSource = new BindingSource(value, null);
                CboListaLocalidades.DisplayMember = "Value";
                CboListaLocalidades.ValueMember = "Key";
                CboListaLocalidades.SelectedIndex = -1;
            }
        }

        public int Provincia
        {
            get { return (int)CboListaProvincias.SelectedValue; }
        }

        #endregion

        #region Miembros de IUbicacionUI

        public string NombrePais
        {
            get { return CboListaPaises.Text; }
        }

        public string NombreProvincia
        {
            get { return CboListaProvincias.Text; }
        }

        public string NombreLocalidad
        {
            get { return CboListaLocalidades.Text; }
        }

        #endregion
    }
}
