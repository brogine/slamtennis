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

namespace Slam
{
    public partial class FrmNuevaPersona : Form, IListadoEstadisticasDni, IEmpleadoUI
    {
    	string ImplementaEstadisticas = "EstadisticasServicio";
        string ImplementaJugadores = "JugadorServicio";
        string ImplementaEmpleados = "EmpleadoServicio";
        string ImplementaArbitros = "ArbitroServicio";
    	IListadoEstadisticasServicio servicioEstadisticas;
        IJugadorServicio servicioJugadores;
        IEmpleadoServicio servicioEmpleados;
        
        TipoPersona Tipo;
        int Dni;
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
            if (Dni > 0)
            {
                switch (Tipo)
                {
                    case TipoPersona.Arbitro:
                        break;
                    case TipoPersona.Empleado:
                        servicioEmpleados = (IEmpleadoServicio)AppContext.Instance.GetObject(ImplementaEmpleados);
                        servicioEmpleados.Buscar(this);
                        break;
                    case TipoPersona.Jugador:
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
                    switch (Tipo)
                    {
                        case TipoPersona.Arbitro:
                            break;
                        case TipoPersona.Empleado:
                            servicioEmpleados.Agregar(this);
                            break;
                        case TipoPersona.Jugador:
                            break;
                    }
					this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Complete los datos de Login porfavor.");
            }
            else
            {
                MessageBox.Show("Complete todos los campos de Datos Personales porfavor.");
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

        #region Miembros de IEmpleadoUI

        int IEmpleadoUI.Dni
        {
            get
            {
                return int.Parse(TxtDni.Text);
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
                return (int)CboNacionalidad.SelectedValue;
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
                return (int)CboProvincia.SelectedValue;
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
                return (int)CboLocalidades.SelectedValue;
            }
            set
            {
                CboLocalidades.SelectedValue = value;
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
    }
}
