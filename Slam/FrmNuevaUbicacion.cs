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
            try
            {
                PaisServicio = (IPaisServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
                PaisServicio.ListarPaises(this);
                ProvinciaServicio = (IProvinciaServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
                LocalidadServicio = (ILocalidadServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboListaPaises_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CboListaPaises.SelectedIndex > -1)
                    ProvinciaServicio.ListarProvincias(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CboListaProvincias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CboListaPaises.SelectedIndex > -1 && CboListaProvincias.SelectedIndex > -1)
                    LocalidadServicio.ListarLocalidades(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregarPais_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboListaPaises.Text != "")
                {
                    PaisServicio.AgregarPais(this);
                    PaisServicio.ListarPaises(this);
                }
                else
                    MessageBox.Show("El nombre del Pais no puede estar en blanco.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregarProvincia_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboListaProvincias.Text != "")
                {
                    ProvinciaServicio.AgregarProvincia(this, this);
                    ProvinciaServicio.ListarProvincias(this);
                }
                else
                    MessageBox.Show("El nombre de la Provincia no puede estar en blanco.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboListaLocalidades.Text != "")
                {
                    LocalidadServicio.AgregarLocalidad(this, this);
                    LocalidadServicio.ListarLocalidades(this);
                }
                else
                    MessageBox.Show("El nombre de la Localidad no puede estar en blanco.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        #region Miembros de IListadoPaises

        public List<Object> ListarPaises
        {
            set 
            {
                if (value.Count > 0)
                {

                    Dictionary<int, string> ListaPais = new Dictionary<int, string>();
                    foreach (Object Pais in value)
                    {
                        Object[] DatosPais = Pais.ToString().Split(',');
                        ListaPais.Add(Convert.ToInt32(DatosPais[0]), DatosPais[1].ToString());
                    }
                    CboListaPaises.DataSource = new BindingSource(ListaPais, null);
                    CboListaPaises.DisplayMember = "Value";
                    CboListaPaises.ValueMember = "Key";
                    CboListaPaises.SelectedIndex = 0;

                }

            }
        }

        #endregion

        #region Miembros de IListadoProvincias

        public List<Object> ListarProvincias
        {
            set
            {
                if (value.Count > 0)
                {
                    
                Dictionary<int, string> ListaProvincias = new Dictionary<int, string>();
                foreach (Object Provincia in value)
                {
                    Object[] DatosProvincia = Provincia.ToString().Split(',');
                    ListaProvincias.Add(Convert.ToInt32(DatosProvincia[0]), DatosProvincia[1].ToString());
                }
                CboListaProvincias.DataSource = new BindingSource(ListaProvincias, null);
                CboListaProvincias.DisplayMember = "Value";
                CboListaProvincias.ValueMember = "Key";
                CboListaProvincias.SelectedIndex = 0;

                }
            }
        }

        public int Pais
        {
            get { return Convert.ToInt32(((KeyValuePair<int, string>)CboListaPaises.SelectedItem).Key); }
        }

        #endregion

        #region Miembros de IListadoLocalidades

        public List<Object> ListarLocalidades
        {
            set 
            {
                if (value.Count > 0)
                {
                    Dictionary<int, string> ListaLocalidades = new Dictionary<int, string>();
                    foreach (Object Localidad in value)
                    {
                        Object[] DatosLocalidades = Localidad.ToString().Split(',');
                        ListaLocalidades.Add(Convert.ToInt32(DatosLocalidades[0]), DatosLocalidades[1].ToString());
                    }
                    CboListaLocalidades.DataSource = new BindingSource(ListaLocalidades, null);
                    CboListaLocalidades.DisplayMember = "Value";
                    CboListaLocalidades.ValueMember = "Key";
                    CboListaLocalidades.SelectedIndex = 0;
                }
            }
        }

        public int Provincia
        {
            get { return Convert.ToInt32(((KeyValuePair<int, string>)CboListaProvincias.SelectedItem).Key); }
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
