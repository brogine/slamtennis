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
            if (TxtDni.Text != string.Empty && TxtNombre.Text != string.Empty &&
                TxtApellido.Text != string.Empty && DtpFechaNac.Value != DateTime.Today &&
                CboNacionalidad.SelectedIndex > -1 && (RbMasculino.Checked || RbMasculino.Checked) &&
                CboProvincia.SelectedIndex > -1 && CboLocalidades.SelectedIndex > -1 &&
                TxtDomicilio.Text != string.Empty)
            {
                if (TxtUsuario.Text != string.Empty && TxtPassword.Text != string.Empty)
                {
                    Dni = int.Parse(TxtDni.Text);
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
        			MessageBox.Show("Debe buscar un Jugador para ver sus estadísticas.");
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

        public int DniTutor
        {
            get
            {
                return int.Parse(TxtDniTutor.Text);
            }
            set
            {
                TxtDniTutor.Text = value.ToString();
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
                if (Edad < 18)
                    GbMenor.Visible = true;
            }
        }
    }
}
