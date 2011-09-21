using System;
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
using System.Collections;
using System.IO;

namespace Slam
{
    public partial class FrmNuevaPersona : Form, IEmpleadoUI, IJugadorUI,
        IListadoPaises, IListadoProvincias, IListadoLocalidades, IArbitroUI
    {
        string ImplementaJugadores = "JugadorServicio";
        string ImplementaEmpleados = "EmpleadoServicio";
        string ImplementaArbitros = "ArbitroServicio";
        string ImplementaUbicacion = "UbicacionServicio";
        IJugadorServicio servicioJugadores;
        IEmpleadoServicio servicioEmpleados;
        IArbitroServicio servicioArbitros;
        IPaisServicio servicioPaises;
        IProvinciaServicio servicioProvincias;
        ILocalidadServicio servicioLocalidades;
        
        TipoPersona Tipo;
        public int Dni;
        int IdLocalidad;
        int EdadJugador;
        string PathFoto = "";
        public FrmNuevaPersona(TipoPersona _Tipo)
        {
            InitializeComponent();
            Tipo = _Tipo;
        }

        public FrmNuevaPersona(TipoPersona _Tipo, int _Dni)
        {
            InitializeComponent();
            Tipo = _Tipo;
            Dni = _Dni;
        }

        private void FrmNuevaPersona_Load(object sender, EventArgs e)
        {
            servicioPaises = (IPaisServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            servicioPaises.ListarPaises(this);
            servicioLocalidades = (ILocalidadServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            servicioProvincias = (IProvinciaServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            servicioProvincias.ListarProvincias(this);
            if (Dni > 0)
            {
                switch (Tipo)
                {
                    case TipoPersona.Arbitro:
                        GbDatosArbitro.Visible = true;
                        servicioArbitros = (IArbitroServicio)AppContext.Instance.GetObject(ImplementaArbitros);
                        servicioArbitros.Buscar(this);
                        break;
                    case TipoPersona.Empleado:
                        servicioEmpleados = (IEmpleadoServicio)AppContext.Instance.GetObject(ImplementaEmpleados);
                        servicioEmpleados.Buscar(this);
                        break;
                    case TipoPersona.Jugador:
                        servicioJugadores = (IJugadorServicio)AppContext.Instance.GetObject(ImplementaJugadores);
                        servicioJugadores.Buscar(this);
                        break;
                }
                servicioLocalidades.ListarLocalidades(this);
                CboLocalidades.SelectedValue = IdLocalidad;
            }
            else
            {
                switch (Tipo)
                {
                    case TipoPersona.Arbitro:
                        GbDatosArbitro.Visible = true;
                        servicioArbitros = (IArbitroServicio)AppContext.Instance.GetObject(ImplementaArbitros);
                        break;
                    case TipoPersona.Empleado:
                        servicioEmpleados = (IEmpleadoServicio)AppContext.Instance.GetObject(ImplementaEmpleados);
                        break;
                    case TipoPersona.Jugador:
                        servicioJugadores = (IJugadorServicio)AppContext.Instance.GetObject(ImplementaJugadores);
                        break;
                }
            }
            if (Tipo != TipoPersona.Empleado)
            {
            	LblPuesto.Visible = false;
            	TxtPuesto.Visible = false;
            }
            this.Text = "Nueva/o " + Tipo.ToString();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (EpNuevaPersona.GetError(TxtDni) == "" && EpNuevaPersona.GetError(TxtNombre) == "" &&
                EpNuevaPersona.GetError(TxtApellido) == "" && EpNuevaPersona.GetError(DtpFechaNac) == "" &&
                EpNuevaPersona.GetError(CboNacionalidad) == "" && EpNuevaPersona.GetError(RbFemenino) == "" &&
                EpNuevaPersona.GetError(CboProvincia) == "" && EpNuevaPersona.GetError(CboLocalidades) == "" &&
                EpNuevaPersona.GetError(TxtDomicilio) == "")
            {
                if (EpNuevaPersona.GetError(TxtUsuario) == "" && EpNuevaPersona.GetError(TxtPassword) == "")
                {
                    Dni = int.Parse(TxtDni.Text);
                    try
                    {
                        PbFoto.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        switch (Tipo)
                        {
                            case TipoPersona.Arbitro:
                                if (EpNuevaPersona.GetError(TxtNivel) == "" && EpNuevaPersona.GetError(TxtBadge) == "")
                                {
                                    if (servicioArbitros.Existe(Dni))
                                        servicioArbitros.Modificar(this);
                                    else
                                        servicioArbitros.Agregar(this);
                                }
                                break;
                            case TipoPersona.Empleado:
                                if (EpNuevaPersona.GetError(TxtPuesto) == "")
                                {
                                    if (servicioEmpleados.Existe(Dni))
                                        servicioEmpleados.Modificar(this);
                                    else
                                        servicioEmpleados.Agregar(this);
                                }
                                break;
                            case TipoPersona.Jugador:
                                if (GbMenor.Visible)
                                {
                                    if (EpNuevaPersona.GetError(TxtNombreTutor) == "" && EpNuevaPersona.GetError(TxtRelacion) == "")
                                    {
                                        if (servicioJugadores.Existe(Dni))
                                            servicioJugadores.Modificar(this);
                                        else
                                            servicioJugadores.Agregar(this);
                                    }
                                }
                                else
                                {
                                    if (servicioJugadores.Existe(Dni))
                                        servicioJugadores.Modificar(this);
                                    else
                                        servicioJugadores.Agregar(this);
                                }
                                break;
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Carga realizada con éxito.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " " + ex.StackTrace);
                    }
                }
                else
                {
                    MessageBox.Show("Complete los datos de Login porfavor.");
                    TcPersonas.SelectedTab = TpLogin;
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos de Datos Personales porfavor.");
                TcPersonas.SelectedTab = TpDatosPersonales;
            }
        }

        private void BtnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            FrmNuevaUbicacion nUbicacion = new FrmNuevaUbicacion();
            if (nUbicacion.ShowDialog() == DialogResult.OK)
            {
                servicioPaises.ListarPaises(this);
                servicioProvincias.ListarProvincias(this);
                servicioLocalidades.ListarLocalidades(this);
            }
        }
        
        private void BtnCancelarClick(object sender, EventArgs e)
        {
        	GC.Collect();
        	GC.WaitForPendingFinalizers();
        	this.DialogResult = DialogResult.Cancel;
        	this.Close();
        }
        
        #region Miembros de IEmpleadoUI

        int IEmpleadoUI.Dni
        {
            get
            {
                return Dni;
            }
            set
            {
                TxtDni.Text = value.ToString();
            }
        }

        public string Nombre
        {
            get
            {
                return TxtNombre.Text;
            }
            set
            {
                TxtNombre.Text = value;
            }
        }

        public string Apellido
        {
            get
            {
                return TxtApellido.Text;
            }
            set
            {
                TxtApellido.Text = value;
            }
        }

        public DateTime FechaNac
        {
            get
            {
                return DtpFechaNac.Value;
            }
            set
            {
                DtpFechaNac.Value = value;
            }
        }

        public int Nacionalidad
        {
            get
            {
                return Convert.ToInt32(((KeyValuePair<int, string>)CboNacionalidad.SelectedItem).Key);
            }
            set
            {
                CboNacionalidad.SelectedValue = value;
            }
        }

        public string Sexo
        {
            get
            {
                if (RbMasculino.Checked)
                    return "Masculino";
                else
                    return "Femenino";
            }
            set
            {
                if (value == "Femenino")
                    RbFemenino.Checked = true;
                else
                    RbMasculino.Checked = true;
            }
        }

        public string Puesto
        {
            get
            {
                return TxtPuesto.Text;
            }
            set
            {
                TxtPuesto.Text = value;
            }
        }

        public string Telefono
        {
            get
            {
                return TxtTelefono.Text;
            }
            set
            {
                TxtTelefono.Text = value;
            }
        }

        public string Celular
        {
            get
            {
                return TxtCelular.Text;
            }
            set
            {
                TxtCelular.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return TxtEmail.Text;
            }
            set
            {
                TxtEmail.Text = value;
            }
        }

        public int Provincia
        {
            get
            {
                return Convert.ToInt32(((KeyValuePair<int, string>)CboProvincia.SelectedItem).Key);
            }
            set
            {
                CboProvincia.SelectedValue = value;
            }
        }

        public int Localidad
        {
            get
            {
                return Convert.ToInt32(((KeyValuePair<int, string>)CboLocalidades.SelectedItem).Key);
            }
            set
            {
                IdLocalidad = value;
            }
        }

        public string Domicilio
        {
            get
            {
                return TxtDomicilio.Text;
            }
            set
            {
                TxtDomicilio.Text = value;
            }
        }

        public string Usuario
        {
            get
            {
                return TxtUsuario.Text;
            }
            set
            {
                TxtUsuario.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return TxtPassword.Text;
            }
            set
            {
                TxtPassword.Text = value;
            }
        }

        public bool Estado
        {
            get
            {
                return ChkEstado.Checked;
            }
            set
            {
                ChkEstado.Checked = value;
            }
        }

        #endregion

        #region Miembros de IJugadorUI

        int IJugadorUI.Dni
        {
            get
            {
                return Dni;
            }
            set
            {
                TxtDni.Text = value.ToString();
            }
        }

        public string Tutor
        {
            get
            {
                if (TxtNombreTutor.Text == "")
                    return "";
                else
                    return TxtNombreTutor.Text;
            }
            set
            {
                TxtNombreTutor.Text = value;
            }
        }

        public string RelacionTutor
        {
            get
            {
                return TxtRelacion.Text;
            }
            set
            {
                TxtRelacion.Text = value;
            }
        }

        public int Edad 
        {
            get { return EdadJugador; }
            set { EdadJugador = value; }
        }

        public string Foto
        {
            get
            {
                return PathFoto;
            }
            set
            {
                PathFoto = value;
                if (value != "")
                {
                    string Path = AppDomain.CurrentDomain.BaseDirectory + value;
                    if(File.Exists(Path))
                    {
                        FileStream Fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + value, FileMode.Open, FileAccess.Read);
                        PbFoto.Image = Image.FromStream(Fs);
                    }
                }
            }
        }


        #endregion

        #region Miembros de IListadoPaises

        public Dictionary<int, string> ListarPaises
        {
            set 
            {
                CboNacionalidad.DataSource = new BindingSource(value, null);
                CboNacionalidad.DisplayMember = "Value";
                CboNacionalidad.ValueMember = "Key";
                CboNacionalidad.SelectedIndex = -1;
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
                    CboProvincia.DataSource = new BindingSource(value, null);
                    CboProvincia.DisplayMember = "Value";
                    CboProvincia.ValueMember = "Key";
                    CboProvincia.SelectedIndex = -1;
                }
            }
        }

        public int Pais
        {
            get { return 1; }
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

        #endregion

        #region Miembros de IArbitroUI

        int IArbitroUI.Dni
        {
            get
            {
                return Dni;
            }
            set
            {
                TxtDni.Text = value.ToString();
            }
        }

        public string Badge
        {
            get
            {
                return TxtBadge.Text;
            }
            set
            {
                TxtBadge.Text = value;
            }
        }

        public int Nivel
        {
            get
            {
                return int.Parse(TxtNivel.Text);
            }
            set
            {
                TxtNivel.Text = value.ToString();
            }
        }

        #endregion

        private void DtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            if (Tipo == TipoPersona.Jugador)
            {
                int EdadTemp = DateTime.Today.Year - this.FechaNac.Year;
                if (new DateTime(DateTime.Today.Year, this.FechaNac.Month, this.FechaNac.Day) > DateTime.Today)
                    EdadTemp--;
                if (EdadTemp < 18)
                    GbMenor.Visible = true;
                else
                    GbMenor.Visible = false;
            }
        }

        #region Validaciones

        private void GbDatosPersonales_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNombre.Text == "")
                EpNuevaPersona.SetError(TxtNombre, "El campo no puede estar en blanco.");
            else
                EpNuevaPersona.SetError(TxtNombre, "");
            if (TxtApellido.Text == "")
                EpNuevaPersona.SetError(TxtApellido, "El campo no puede estar en blanco.");
            else
                EpNuevaPersona.SetError(TxtApellido, "");
            if (CboNacionalidad.SelectedIndex < 0)
                EpNuevaPersona.SetError(CboNacionalidad, "Debe elegir una Nacionalidad del Desplegable.");
            else
                EpNuevaPersona.SetError(CboNacionalidad, "");
            if (!RbFemenino.Checked && !RbMasculino.Checked)
                EpNuevaPersona.SetError(RbFemenino, "Debe elegir el sexo correspondiente.");
            else
                EpNuevaPersona.SetError(RbFemenino, "");
            if (Tipo == TipoPersona.Empleado)
            {
                if (TxtPuesto.Text == "")
                    EpNuevaPersona.SetError(TxtPuesto, "El campo no puede estar en blanco.");
                else
                    EpNuevaPersona.SetError(TxtPuesto, "");
            }
        }

        private void GbDatosArbitro_Validating(object sender, CancelEventArgs e)
        {
            if (Tipo == TipoPersona.Arbitro)
            {
                if (TxtNivel.Text == "")
                    EpNuevaPersona.SetError(TxtNivel, "El campo no puede estar en blanco.");
                else 
                {
                    int resultado = 0;
                    if (!int.TryParse(TxtNivel.Text, out resultado))
                        EpNuevaPersona.SetError(TxtNivel, "El campo debe ser un número.");
                    else
                        EpNuevaPersona.SetError(TxtNivel, "");
                }
                if (TxtBadge.Text == "")
                    EpNuevaPersona.SetError(TxtBadge, "El campo no puede estar en blanco.");
                else
                    EpNuevaPersona.SetError(TxtBadge, "");
            }
        }

        private void GbDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (CboLocalidades.SelectedIndex < 0)
                EpNuevaPersona.SetError(CboLocalidades, "Elija una Localidad del Desplegable.");
            else
                EpNuevaPersona.SetError(CboLocalidades, "");
            if (CboProvincia.SelectedIndex < 0)
                EpNuevaPersona.SetError(CboProvincia, "Elija una Provincia del Desplegable.");
            else
                EpNuevaPersona.SetError(CboProvincia, "");
            if (TxtDomicilio.Text == "")
                EpNuevaPersona.SetError(TxtDomicilio, "El campo no puede estar en blanco.");
            else
                EpNuevaPersona.SetError(TxtDomicilio, "");
        }

        private void GbDatosLogin_Validating(object sender, CancelEventArgs e)
        {
            if (TxtUsuario.Text == "")
                EpNuevaPersona.SetError(TxtUsuario, "El campo no puede estar en blanco.");
            else
                EpNuevaPersona.SetError(TxtUsuario, "");
            if (TxtPassword.Text == "")
                EpNuevaPersona.SetError(TxtPassword, "El campo no puede estar en blanco.");
            else
                EpNuevaPersona.SetError(TxtPassword, "");
        }

        private void GbMenor_Validating(object sender, CancelEventArgs e)
        {
            int EdadTemp = DateTime.Today.Year - this.FechaNac.Year;
            if (new DateTime(DateTime.Today.Year, this.FechaNac.Month, this.FechaNac.Day) > DateTime.Today)
                EdadTemp--;
            if (EdadTemp < 18)
            {
                if (TxtNombreTutor.Text == "")
                    EpNuevaPersona.SetError(TxtNombreTutor, "El campo no puede estar en blanco.");
                else
                    EpNuevaPersona.SetError(TxtNombreTutor, "");
                if (TxtRelacion.Text == "")
                    EpNuevaPersona.SetError(TxtRelacion, "El campo no puede estar en blanco.");
                else
                    EpNuevaPersona.SetError(TxtRelacion, "");
            }
        }

        private void CboNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboLocalidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        private void BtnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (!GbCambiarPassword.Visible)
                GbCambiarPassword.Visible = true;
            else
            {
                if (Password == TxtPasswordViejo.Text)
                {
                    TxtPassword.Text = TxtPasswordNuevo.Text;
                    switch (Tipo)
                    {
                        case TipoPersona.Arbitro:
                            servicioArbitros.Modificar(this);
                            break;
                        case TipoPersona.Empleado:
                            servicioEmpleados.Modificar(this);
                            break;
                        case TipoPersona.Jugador:
                            servicioJugadores.Modificar(this);
                            break;
                    }
                    MessageBox.Show("Password cambiado con éxito");
                    TxtPasswordViejo.Text = "";
                    TxtPasswordNuevo.Text = "";
                    GbCambiarPassword.Visible = false;
                }
                else
                    MessageBox.Show("Los Password no concuerdan.");
            }
        }

        private void TxtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    Dni = int.Parse(TxtDni.Text);
                    switch (Tipo)
                    {
                        case TipoPersona.Arbitro:
                            servicioArbitros.Buscar(this);
                            break;
                        case TipoPersona.Empleado:
                            servicioEmpleados.Buscar(this);
                            break;
                        case TipoPersona.Jugador:
                            servicioJugadores.Buscar(this);
                            break;
                    }
                    
                }
                catch (Exception ex)
                {
                    Blanquear();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboProvincia.SelectedIndex > -1)
            {
                servicioLocalidades.ListarLocalidades(this);
                CboLocalidades.SelectedValue = IdLocalidad;
            }
        }
        private void Blanquear()
        {
            this.TxtApellido.Text = "";
            this.TxtBadge.Text = "";
            this.TxtCelular.Text = "";
            this.TxtDni.Text = "";
            this.TxtDomicilio.Text = "";
            this.TxtEmail.Text = "";
            this.TxtNivel.Text = "";
            this.TxtNombre.Text = "";
            this.TxtNombreTutor.Text = "";
            this.TxtPassword.Text = "";
            this.TxtPasswordNuevo.Text = "";
            this.TxtPasswordViejo.Text = "";
            this.TxtPuesto.Text = "";
            this.TxtRelacion.Text = "";
            this.TxtTelefono.Text = "";
            this.TxtUsuario.Text = "";
            this.CboLocalidades.SelectedIndex = -1;
            this.CboNacionalidad.SelectedIndex = -1;
            this.CboProvincia.SelectedIndex = -1;
            this.ChkEstado.Checked = false;
        }
        private void BtnBuscarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Archivos de Imagen|*.jpg;*.gif;*.bmp;*.png;*.jpeg|Todos los Archivos|*.*";
            Ofd.Multiselect = false;
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PathFoto = Ofd.FileName;
                    PbFoto.Image = Image.FromFile(Ofd.FileName);
                }
                catch(Exception)
                {
                    MessageBox.Show("El archivo que buscó no es una foto soportada por el sistema. Busque nuevamente.");
                }
            }
        }


    }
}
