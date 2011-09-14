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

namespace Slam
{
    public partial class FrmNuevaPersona : Form, IListadoEstadisticasDni, IEmpleadoUI, IJugadorUI,
        IListadoPaises, IListadoProvincias, IListadoLocalidades, IArbitroUI
    {
    	string ImplementaEstadisticas = "EstadisticasServicio";
        string ImplementaJugadores = "JugadorServicio";
        string ImplementaEmpleados = "EmpleadoServicio";
        string ImplementaArbitros = "ArbitroServicio";
        string ImplementaUbicacion = "UbicacionServicio";
    	IListadoEstadisticasServicio servicioEstadisticas;
        IJugadorServicio servicioJugadores;
        IEmpleadoServicio servicioEmpleados;
        IArbitroServicio servicioArbitros;
        IPaisServicio servicioPaises;
        IProvinciaServicio servicioProvincias;
        ILocalidadServicio servicioLocalidades;
        
        TipoPersona Tipo;
        int Dni;
        int IdLocalidad;
        int EdadJugador;
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
            servicioProvincias = (IProvinciaServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
            servicioProvincias.ListarProvincias(this);
            servicioLocalidades = (ILocalidadServicio)AppContext.Instance.GetObject(ImplementaUbicacion);
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
            if (Tipo == TipoPersona.Empleado)
                TpStats.Parent = null;
            else{
            	LblPuesto.Visible = false;
            	TxtPuesto.Visible = false;
            	servicioEstadisticas = (IListadoEstadisticasServicio)AppContext.Instance.GetObject(ImplementaEstadisticas);
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
                        switch (Tipo)
                        {
                            case TipoPersona.Arbitro:
                                if (servicioArbitros.Existe(Dni))
                                    servicioArbitros.Modificar(this);
                                else
                                    servicioArbitros.Agregar(this);
                                break;
                            case TipoPersona.Empleado:
                                if (servicioEmpleados.Existe(Dni))
                                    servicioEmpleados.Modificar(this);
                                else
                                    servicioEmpleados.Agregar(this);
                                break;
                            case TipoPersona.Jugador:
                                if (servicioJugadores.Existe(Dni))
                                    servicioJugadores.Modificar(this);
                                else
                                    servicioJugadores.Agregar(this);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " " + ex.InnerException.ToString());
                    }
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Carga realizada con éxito.");
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
            nUbicacion.Show();
        }
        
        void BtnCancelarClick(object sender, EventArgs e)
        {
        	GC.Collect();
        	GC.WaitForPendingFinalizers();
        	this.DialogResult = DialogResult.Cancel;
        	this.Close();
        }
        
        void TcPersonasSelectedIndexChanged(object sender, EventArgs e)
        {
        	if(TcPersonas.SelectedIndex == 2) {
        		if(TxtDni.Text != "")
        			servicioEstadisticas.ListarPorDni(this);
        		else
        			MessageBox.Show("Debe buscar un " + Tipo.ToString() + " para ver sus estadísticas.");
        	}
        }

        #region Miembros de IListadoEstadisticasDni

        public List<object> ListarEstadisticas {
			set {
        		LblNombreCategoria.Text = "";
        		if(DgvStats.ColumnCount > 0)
        			DgvStats.Columns.Clear();
        		DgvStats.Columns.Add("pj", "Partidos Jugados");
        		DgvStats.Columns.Add("pg", "Partidos Ganados");
        		DgvStats.Columns.Add("pp", "Partidos Perdidos");
        		DgvStats.Columns.Add("puntos", "Puntos");
        		if(DgvStats.RowCount > 0)
        			DgvStats.Rows.Clear();
        		foreach (object estadistica in value) {
        			object[] estadisticas = estadistica.ToString().Split(',');
        			DgvStats.Rows.Add(estadisticas[0], estadisticas[1], estadisticas[2],
        			                  estadisticas[3]);
        			if(LblNombreCategoria.Text == "")
        				LblNombreCategoria.Text = estadisticas[4].ToString();
        		}
			}
		}
    	
		public int DniJugador {
			get {
        		return int.Parse(TxtDni.Text);
			}
        }

        #endregion

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

        public int DniTutor
        {
            get
            {
                if (TxtDniTutor.Text == "")
                    return 0;
                else
                    return int.Parse(TxtDniTutor.Text);
            }
            set
            {
                TxtDniTutor.Text = value.ToString();
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

        private void CboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servicioLocalidades.ListarLocalidades(this);
        }

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
                if (TxtDniTutor.Text == "")
                    EpNuevaPersona.SetError(TxtDniTutor, "El campo no puede estar en blanco.");
                else
                    EpNuevaPersona.SetError(TxtDniTutor, "");
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

    }
}
