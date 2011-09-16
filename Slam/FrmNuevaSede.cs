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
using System.Text.RegularExpressions;

namespace Slam
{
    public partial class FrmNuevaSede : Form, IListadoPaises, IListadoProvincias, IListadoClubes, IListadoLocalidades, ISedesUI
    {
        string ImplementaUbicacion = "UbicacionServicio";
        string ImplementaClubes = "ClubServicio";
        string ImplementaSedes = "SedesServicio";
        IPaisServicio servicioPaises;
        IProvinciaServicio servicioProvincias;
        ILocalidadServicio servicioLocalidades;
        IListadoClubServicio servicioClubes;
        ISedesServicio servicioSedes;
        int IdSedeModificar = 0;
        public FrmNuevaSede()
        {
            InitializeComponent();
        }

        public FrmNuevaSede(int idSede)
        {
            InitializeComponent();
            this.IdSedeModificar = idSede;
        }

        private void FrmNuevaSede_Load(object sender, EventArgs e)
        {
            servicioPaises = (IPaisServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            servicioProvincias = (IProvinciaServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            servicioLocalidades = (ILocalidadServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            servicioClubes = (IListadoClubServicio)AppContext.Instance.GetObject(ImplementaClubes);
            servicioSedes = (ISedesServicio)AppContext.Instance.GetObject(ImplementaSedes);
            servicioClubes.Listar(this);
            servicioPaises.ListarPaises(this);
            if (IdSedeModificar > 0)
            {
                this.Text = "Modificar Sede";
                servicioSedes.Buscar(this);
            }
            else
                this.Text = "Nueva Sede";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (EpSedes.GetError(CboClubes) == "" && EpSedes.GetError(TxtDireccion) == "" && EpSedes.GetError(CboProvincias) == ""
                && EpSedes.GetError(CboLocalidades) == "" && EpSedes.GetError(CboPaises) == "" && EpSedes.GetError(TxtEmail) == ""
                && EpSedes.GetError(TxtCelular) == "" && EpSedes.GetError(TxtTelefono) == "")
            {
                try
                {
                    if (IdSedeModificar > 0)
                        servicioSedes.Modificar(this);
                    else
                        servicioSedes.Agregar(this);
                    MessageBox.Show("Acción Realizada con éxito.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        #region Validating
        private void CboClubes_Validating(object sender, CancelEventArgs e)
        {
            if (CboClubes.SelectedIndex < 0)
                EpSedes.SetError(CboClubes, "Seleccione un Club del desplegable");
            else
                EpSedes.SetError(CboClubes, "");
        }

        private void TxtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (TxtDireccion.Text == "")
                EpSedes.SetError(TxtDireccion, "Ingrese una Dirección");
            else
                EpSedes.SetError(TxtDireccion, "");
        }

        private void CboProvincias_Validating(object sender, CancelEventArgs e)
        {
            if (CboProvincias.SelectedIndex < 0)
                EpSedes.SetError(CboProvincias, "Seleccione una Provincia del desplegable");
            else
                EpSedes.SetError(CboProvincias, "");
        }

        private void CboLocalidades_Validating(object sender, CancelEventArgs e)
        {
            if (CboLocalidades.SelectedIndex < 0)
                EpSedes.SetError(CboLocalidades, "Seleccione una Localidad del desplegable");
            else
                EpSedes.SetError(CboLocalidades, "");
        }

        private void CboPaises_Validating(object sender, CancelEventArgs e)
        {
            if (CboPaises.SelectedIndex < 0)
                EpSedes.SetError(CboPaises, "Seleccione un Pais del desplegable");
            else
                EpSedes.SetError(CboPaises, "");
        }

        private void TxtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (TxtTelefono.Text != "")
            {
                int result = 0;
                if (!int.TryParse(TxtTelefono.Text, out result))
                    EpSedes.SetError(TxtTelefono, "Solo números admitidos.");
                else
                    EpSedes.SetError(TxtTelefono, "");
            }
        }

        private void TxtCelular_Validating(object sender, CancelEventArgs e)
        {
            if (TxtCelular.Text != "")
            {
                int result = 0;
                if (!int.TryParse(TxtCelular.Text, out result))
                    EpSedes.SetError(TxtCelular, "Solo números admitidos.");
                else
                    EpSedes.SetError(TxtCelular, "");
            }
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (TxtEmail.Text != "")
            {
                string Patron = @"(\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
                Regex Rx = new Regex(Patron);

                if(!Rx.IsMatch(TxtEmail.Text))
                    EpSedes.SetError(TxtEmail, "Email inválido. Ej: usuario@ejemplo.com");
                else
                    EpSedes.SetError(TxtEmail, "");
            }
        }

        #endregion

        #region Miembros de IListadoProvincias

        public Dictionary<int, string> ListarProvincias
        {
            set 
            {
                if (value.Count > 0)
                {
                    CboProvincias.DataSource = new BindingSource(value, null);
                    CboProvincias.DisplayMember = "Value";
                    CboProvincias.ValueMember = "Key";
                    CboProvincias.SelectedIndex = -1;
                }
            }
        }

        public int Pais
        {
            get { return (int)CboPaises.SelectedValue; }
        }

        #endregion

        #region Miembros de IListadoPaises

        public Dictionary<int, string> ListarPaises
        {
            set 
            {
                CboPaises.DataSource = new BindingSource(value, null);
                CboPaises.DisplayMember = "Value";
                CboPaises.ValueMember = "Key";
                CboPaises.SelectedIndex = -1;
            }
        }

        #endregion

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

        #region Miembros de IListadoLocalidades

        public Dictionary<int, string> ListarLocalidades
        {
            set 
            {
                if (value.Count > 0)
                {
                    CboLocalidades.DataSource = new BindingSource(value, null);
                    CboLocalidades.DisplayMember = "Value";
                    CboLocalidades.ValueMember = "Key";
                    CboLocalidades.SelectedIndex = -1;
                }
            }
        }

        public int Provincia
        {
            get { return (int)CboProvincias.SelectedValue; }
        }

        #endregion

        #region Miembros de ISedesUI

        public int IdSede
        {
            get { return IdSedeModificar; }
            set { IdSedeModificar = value; }
        }

        public int IdClub
        {
            get { return Convert.ToInt32(((DictionaryEntry)CboClubes.SelectedItem).Value); }
            set 
            {
                foreach (object elemento in CboClubes.Items)
                {
                    if (Convert.ToInt32(((DictionaryEntry)elemento).Value) == value)
                    {
                        CboClubes.SelectedItem = elemento;
                        break;
                    }
                }
            }
        }

        public string Direccion
        {
            get { return TxtDireccion.Text; }
            set { TxtDireccion.Text = value; }
        }

        public int IdLocalidad
        {
            get { return Convert.ToInt32(((KeyValuePair<int, string>)CboLocalidades.SelectedItem).Key); }
            set 
            {
                string[] ids = servicioLocalidades.ObtenerUbicacion(value).Split(',');
                foreach (KeyValuePair<int, string> elemento in CboPaises.Items)
                {
                    if (elemento.Key == int.Parse(ids[0]))
                    {
                        CboPaises.SelectedItem = elemento;
                        servicioProvincias.ListarProvincias(this);
                        break;
                    }
                }

                foreach (KeyValuePair<int, string> elemento in CboProvincias.Items)
                {
                    if (elemento.Key == int.Parse(ids[1]))
                    {
                        CboProvincias.SelectedItem = elemento;
                        servicioLocalidades.ListarLocalidades(this);
                        break;
                    }
                }

                foreach (KeyValuePair<int, string> elemento in CboLocalidades.Items)
                {
                    if (elemento.Key == value)
                    {
                        CboLocalidades.SelectedItem = elemento;
                        break;
                    }
                }
            }
        }

        public string Telefono
        {
            get { return TxtTelefono.Text; }
            set { TxtTelefono.Text = value; }
        }

        public string Celular
        {
            get { return TxtCelular.Text; }
            set { TxtCelular.Text = value; }
        }

        public string Email
        {
            get { return TxtEmail.Text; }
            set { TxtEmail.Text = value; }
        }

        #endregion

        private void CboPaises_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servicioProvincias.ListarProvincias(this);
        }

        private void CboProvincias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servicioLocalidades.ListarLocalidades(this);
        }

        private void CboClubes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboPaises_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboProvincias_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboLocalidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
