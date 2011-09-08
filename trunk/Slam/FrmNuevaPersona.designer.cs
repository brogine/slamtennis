namespace Slam
{
    partial class FrmNuevaPersona
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaPersona));
        	this.TcPersonas = new System.Windows.Forms.TabControl();
        	this.TpDatosPersonales = new System.Windows.Forms.TabPage();
        	this.BtnCancelar = new System.Windows.Forms.Button();
        	this.BtnGuardar = new System.Windows.Forms.Button();
        	this.GbMenor = new System.Windows.Forms.GroupBox();
        	this.TxtRelacion = new System.Windows.Forms.TextBox();
        	this.LblRelacionMenor = new System.Windows.Forms.Label();
        	this.TxtNombreTutor = new System.Windows.Forms.TextBox();
        	this.LblNombreTutor = new System.Windows.Forms.Label();
        	this.TxtDniTutor = new System.Windows.Forms.MaskedTextBox();
        	this.LblDniTutor = new System.Windows.Forms.Label();
        	this.GbContacto = new System.Windows.Forms.GroupBox();
        	this.TxtEmail = new System.Windows.Forms.TextBox();
        	this.LblEmail = new System.Windows.Forms.Label();
        	this.TxtCelular = new System.Windows.Forms.TextBox();
        	this.LblCelular = new System.Windows.Forms.Label();
        	this.TxtTelefono = new System.Windows.Forms.TextBox();
        	this.LblTelefono = new System.Windows.Forms.Label();
        	this.GbDireccion = new System.Windows.Forms.GroupBox();
        	this.BtnAgregarLocalidad = new System.Windows.Forms.Button();
        	this.CboLocalidades = new System.Windows.Forms.ComboBox();
        	this.TxtDomicilio = new System.Windows.Forms.TextBox();
        	this.LblDomicilio = new System.Windows.Forms.Label();
        	this.CboProvincia = new System.Windows.Forms.ComboBox();
        	this.LblLocalidad = new System.Windows.Forms.Label();
        	this.LblProvincia = new System.Windows.Forms.Label();
        	this.GbDatosPersonales = new System.Windows.Forms.GroupBox();
        	this.RbFemenino = new System.Windows.Forms.RadioButton();
        	this.RbMasculino = new System.Windows.Forms.RadioButton();
        	this.LblSexo = new System.Windows.Forms.Label();
        	this.CboNacionalidad = new System.Windows.Forms.ComboBox();
        	this.DtpFechaNac = new System.Windows.Forms.DateTimePicker();
        	this.LblNacionalidad = new System.Windows.Forms.Label();
        	this.LblFechaNac = new System.Windows.Forms.Label();
        	this.TxtApellido = new System.Windows.Forms.TextBox();
        	this.LblApellido = new System.Windows.Forms.Label();
        	this.TxtNombre = new System.Windows.Forms.TextBox();
        	this.LblNombre = new System.Windows.Forms.Label();
        	this.TxtDni = new System.Windows.Forms.MaskedTextBox();
        	this.LblDni = new System.Windows.Forms.Label();
        	this.TpLogin = new System.Windows.Forms.TabPage();
        	this.BtnCambiarPassword = new System.Windows.Forms.Button();
        	this.GbCambiarPassword = new System.Windows.Forms.GroupBox();
        	this.TxtPasswordNuevo = new System.Windows.Forms.TextBox();
        	this.LblPasswordNuevo = new System.Windows.Forms.Label();
        	this.TxtPasswordViejo = new System.Windows.Forms.TextBox();
        	this.LblPasswordViejo = new System.Windows.Forms.Label();
        	this.GbDatosLogin = new System.Windows.Forms.GroupBox();
        	this.TxtPassword = new System.Windows.Forms.TextBox();
        	this.LblPassword = new System.Windows.Forms.Label();
        	this.TxtUsuario = new System.Windows.Forms.TextBox();
        	this.LblUsuario = new System.Windows.Forms.Label();
        	this.TpStats = new System.Windows.Forms.TabPage();
        	this.LblNombreCategoria = new System.Windows.Forms.Label();
        	this.DgvStats = new System.Windows.Forms.DataGridView();
        	this.LblPuesto = new System.Windows.Forms.Label();
        	this.TxtPuesto = new System.Windows.Forms.TextBox();
        	this.TcPersonas.SuspendLayout();
        	this.TpDatosPersonales.SuspendLayout();
        	this.GbMenor.SuspendLayout();
        	this.GbContacto.SuspendLayout();
        	this.GbDireccion.SuspendLayout();
        	this.GbDatosPersonales.SuspendLayout();
        	this.TpLogin.SuspendLayout();
        	this.GbCambiarPassword.SuspendLayout();
        	this.GbDatosLogin.SuspendLayout();
        	this.TpStats.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.DgvStats)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// TcPersonas
        	// 
        	this.TcPersonas.Controls.Add(this.TpDatosPersonales);
        	this.TcPersonas.Controls.Add(this.TpLogin);
        	this.TcPersonas.Controls.Add(this.TpStats);
        	this.TcPersonas.Location = new System.Drawing.Point(12, 12);
        	this.TcPersonas.Name = "TcPersonas";
        	this.TcPersonas.SelectedIndex = 0;
        	this.TcPersonas.Size = new System.Drawing.Size(663, 410);
        	this.TcPersonas.TabIndex = 0;
        	this.TcPersonas.SelectedIndexChanged += new System.EventHandler(this.TcPersonasSelectedIndexChanged);
        	// 
        	// TpDatosPersonales
        	// 
        	this.TpDatosPersonales.Controls.Add(this.BtnCancelar);
        	this.TpDatosPersonales.Controls.Add(this.BtnGuardar);
        	this.TpDatosPersonales.Controls.Add(this.GbMenor);
        	this.TpDatosPersonales.Controls.Add(this.GbContacto);
        	this.TpDatosPersonales.Controls.Add(this.GbDireccion);
        	this.TpDatosPersonales.Controls.Add(this.GbDatosPersonales);
        	this.TpDatosPersonales.Location = new System.Drawing.Point(4, 22);
        	this.TpDatosPersonales.Name = "TpDatosPersonales";
        	this.TpDatosPersonales.Padding = new System.Windows.Forms.Padding(3);
        	this.TpDatosPersonales.Size = new System.Drawing.Size(655, 384);
        	this.TpDatosPersonales.TabIndex = 0;
        	this.TpDatosPersonales.Text = "Datos Personales";
        	this.TpDatosPersonales.UseVisualStyleBackColor = true;
        	// 
        	// BtnCancelar
        	// 
        	this.BtnCancelar.Location = new System.Drawing.Point(515, 306);
        	this.BtnCancelar.Name = "BtnCancelar";
        	this.BtnCancelar.Size = new System.Drawing.Size(96, 35);
        	this.BtnCancelar.TabIndex = 27;
        	this.BtnCancelar.Text = "Cancelar";
        	this.BtnCancelar.UseVisualStyleBackColor = true;
        	this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelarClick);
        	// 
        	// BtnGuardar
        	// 
        	this.BtnGuardar.Location = new System.Drawing.Point(408, 306);
        	this.BtnGuardar.Name = "BtnGuardar";
        	this.BtnGuardar.Size = new System.Drawing.Size(96, 35);
        	this.BtnGuardar.TabIndex = 26;
        	this.BtnGuardar.Text = "Guardar";
        	this.BtnGuardar.UseVisualStyleBackColor = true;
        	this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
        	// 
        	// GbMenor
        	// 
        	this.GbMenor.Controls.Add(this.TxtRelacion);
        	this.GbMenor.Controls.Add(this.LblRelacionMenor);
        	this.GbMenor.Controls.Add(this.TxtNombreTutor);
        	this.GbMenor.Controls.Add(this.LblNombreTutor);
        	this.GbMenor.Controls.Add(this.TxtDniTutor);
        	this.GbMenor.Controls.Add(this.LblDniTutor);
        	this.GbMenor.Enabled = false;
        	this.GbMenor.Location = new System.Drawing.Point(6, 265);
        	this.GbMenor.Name = "GbMenor";
        	this.GbMenor.Size = new System.Drawing.Size(336, 108);
        	this.GbMenor.TabIndex = 25;
        	this.GbMenor.TabStop = false;
        	this.GbMenor.Text = "Tutor Del Menor";
        	this.GbMenor.Visible = false;
        	// 
        	// TxtRelacion
        	// 
        	this.TxtRelacion.Location = new System.Drawing.Point(144, 75);
        	this.TxtRelacion.Name = "TxtRelacion";
        	this.TxtRelacion.Size = new System.Drawing.Size(154, 20);
        	this.TxtRelacion.TabIndex = 23;
        	// 
        	// LblRelacionMenor
        	// 
        	this.LblRelacionMenor.AutoSize = true;
        	this.LblRelacionMenor.Location = new System.Drawing.Point(14, 78);
        	this.LblRelacionMenor.Name = "LblRelacionMenor";
        	this.LblRelacionMenor.Size = new System.Drawing.Size(116, 13);
        	this.LblRelacionMenor.TabIndex = 22;
        	this.LblRelacionMenor.Text = "Relacion Con El Menor";
        	// 
        	// TxtNombreTutor
        	// 
        	this.TxtNombreTutor.Location = new System.Drawing.Point(144, 49);
        	this.TxtNombreTutor.Name = "TxtNombreTutor";
        	this.TxtNombreTutor.ReadOnly = true;
        	this.TxtNombreTutor.Size = new System.Drawing.Size(154, 20);
        	this.TxtNombreTutor.TabIndex = 3;
        	// 
        	// LblNombreTutor
        	// 
        	this.LblNombreTutor.AutoSize = true;
        	this.LblNombreTutor.Location = new System.Drawing.Point(39, 56);
        	this.LblNombreTutor.Name = "LblNombreTutor";
        	this.LblNombreTutor.Size = new System.Drawing.Size(91, 13);
        	this.LblNombreTutor.TabIndex = 2;
        	this.LblNombreTutor.Text = "Nombre Del Tutor";
        	// 
        	// TxtDniTutor
        	// 
        	this.TxtDniTutor.Location = new System.Drawing.Point(144, 23);
        	this.TxtDniTutor.Mask = "00.000.000";
        	this.TxtDniTutor.Name = "TxtDniTutor";
        	this.TxtDniTutor.Size = new System.Drawing.Size(100, 20);
        	this.TxtDniTutor.TabIndex = 1;
        	this.TxtDniTutor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	this.TxtDniTutor.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
        	// 
        	// LblDniTutor
        	// 
        	this.LblDniTutor.AutoSize = true;
        	this.LblDniTutor.Location = new System.Drawing.Point(60, 30);
        	this.LblDniTutor.Name = "LblDniTutor";
        	this.LblDniTutor.Size = new System.Drawing.Size(70, 13);
        	this.LblDniTutor.TabIndex = 0;
        	this.LblDniTutor.Text = "Dni Del Tutor";
        	// 
        	// GbContacto
        	// 
        	this.GbContacto.Controls.Add(this.TxtEmail);
        	this.GbContacto.Controls.Add(this.LblEmail);
        	this.GbContacto.Controls.Add(this.TxtCelular);
        	this.GbContacto.Controls.Add(this.LblCelular);
        	this.GbContacto.Controls.Add(this.TxtTelefono);
        	this.GbContacto.Controls.Add(this.LblTelefono);
        	this.GbContacto.Location = new System.Drawing.Point(348, 155);
        	this.GbContacto.Name = "GbContacto";
        	this.GbContacto.Size = new System.Drawing.Size(301, 104);
        	this.GbContacto.TabIndex = 24;
        	this.GbContacto.TabStop = false;
        	this.GbContacto.Text = "Contacto";
        	// 
        	// TxtEmail
        	// 
        	this.TxtEmail.Location = new System.Drawing.Point(98, 76);
        	this.TxtEmail.Name = "TxtEmail";
        	this.TxtEmail.Size = new System.Drawing.Size(154, 20);
        	this.TxtEmail.TabIndex = 18;
        	// 
        	// LblEmail
        	// 
        	this.LblEmail.AutoSize = true;
        	this.LblEmail.Location = new System.Drawing.Point(50, 79);
        	this.LblEmail.Name = "LblEmail";
        	this.LblEmail.Size = new System.Drawing.Size(35, 13);
        	this.LblEmail.TabIndex = 4;
        	this.LblEmail.Text = "Email:";
        	// 
        	// TxtCelular
        	// 
        	this.TxtCelular.Location = new System.Drawing.Point(98, 47);
        	this.TxtCelular.Name = "TxtCelular";
        	this.TxtCelular.Size = new System.Drawing.Size(154, 20);
        	this.TxtCelular.TabIndex = 17;
        	// 
        	// LblCelular
        	// 
        	this.LblCelular.AutoSize = true;
        	this.LblCelular.Location = new System.Drawing.Point(50, 50);
        	this.LblCelular.Name = "LblCelular";
        	this.LblCelular.Size = new System.Drawing.Size(42, 13);
        	this.LblCelular.TabIndex = 2;
        	this.LblCelular.Text = "Celular:";
        	// 
        	// TxtTelefono
        	// 
        	this.TxtTelefono.Location = new System.Drawing.Point(98, 19);
        	this.TxtTelefono.Name = "TxtTelefono";
        	this.TxtTelefono.Size = new System.Drawing.Size(154, 20);
        	this.TxtTelefono.TabIndex = 16;
        	// 
        	// LblTelefono
        	// 
        	this.LblTelefono.AutoSize = true;
        	this.LblTelefono.Location = new System.Drawing.Point(40, 22);
        	this.LblTelefono.Name = "LblTelefono";
        	this.LblTelefono.Size = new System.Drawing.Size(52, 13);
        	this.LblTelefono.TabIndex = 0;
        	this.LblTelefono.Text = "Telefono:";
        	// 
        	// GbDireccion
        	// 
        	this.GbDireccion.Controls.Add(this.BtnAgregarLocalidad);
        	this.GbDireccion.Controls.Add(this.CboLocalidades);
        	this.GbDireccion.Controls.Add(this.TxtDomicilio);
        	this.GbDireccion.Controls.Add(this.LblDomicilio);
        	this.GbDireccion.Controls.Add(this.CboProvincia);
        	this.GbDireccion.Controls.Add(this.LblLocalidad);
        	this.GbDireccion.Controls.Add(this.LblProvincia);
        	this.GbDireccion.Location = new System.Drawing.Point(348, 9);
        	this.GbDireccion.Name = "GbDireccion";
        	this.GbDireccion.Size = new System.Drawing.Size(301, 140);
        	this.GbDireccion.TabIndex = 23;
        	this.GbDireccion.TabStop = false;
        	this.GbDireccion.Text = "Direccion";
        	// 
        	// BtnAgregarLocalidad
        	// 
        	this.BtnAgregarLocalidad.Location = new System.Drawing.Point(176, 107);
        	this.BtnAgregarLocalidad.Name = "BtnAgregarLocalidad";
        	this.BtnAgregarLocalidad.Size = new System.Drawing.Size(119, 23);
        	this.BtnAgregarLocalidad.TabIndex = 15;
        	this.BtnAgregarLocalidad.Text = "Nueva Localidad";
        	this.BtnAgregarLocalidad.UseVisualStyleBackColor = true;
        	this.BtnAgregarLocalidad.Click += new System.EventHandler(this.BtnAgregarLocalidad_Click);
        	// 
        	// CboLocalidades
        	// 
        	this.CboLocalidades.FormattingEnabled = true;
        	this.CboLocalidades.Location = new System.Drawing.Point(98, 46);
        	this.CboLocalidades.Name = "CboLocalidades";
        	this.CboLocalidades.Size = new System.Drawing.Size(154, 21);
        	this.CboLocalidades.TabIndex = 13;
        	// 
        	// TxtDomicilio
        	// 
        	this.TxtDomicilio.Location = new System.Drawing.Point(98, 76);
        	this.TxtDomicilio.Name = "TxtDomicilio";
        	this.TxtDomicilio.Size = new System.Drawing.Size(154, 20);
        	this.TxtDomicilio.TabIndex = 14;
        	// 
        	// LblDomicilio
        	// 
        	this.LblDomicilio.AutoSize = true;
        	this.LblDomicilio.Location = new System.Drawing.Point(36, 77);
        	this.LblDomicilio.Name = "LblDomicilio";
        	this.LblDomicilio.Size = new System.Drawing.Size(52, 13);
        	this.LblDomicilio.TabIndex = 8;
        	this.LblDomicilio.Text = "Domicilio:";
        	// 
        	// CboProvincia
        	// 
        	this.CboProvincia.FormattingEnabled = true;
        	this.CboProvincia.Location = new System.Drawing.Point(98, 17);
        	this.CboProvincia.Name = "CboProvincia";
        	this.CboProvincia.Size = new System.Drawing.Size(154, 21);
        	this.CboProvincia.TabIndex = 12;
        	// 
        	// LblLocalidad
        	// 
        	this.LblLocalidad.AutoSize = true;
        	this.LblLocalidad.Location = new System.Drawing.Point(36, 49);
        	this.LblLocalidad.Name = "LblLocalidad";
        	this.LblLocalidad.Size = new System.Drawing.Size(56, 13);
        	this.LblLocalidad.TabIndex = 4;
        	this.LblLocalidad.Text = "Localidad:";
        	// 
        	// LblProvincia
        	// 
        	this.LblProvincia.AutoSize = true;
        	this.LblProvincia.Location = new System.Drawing.Point(38, 20);
        	this.LblProvincia.Name = "LblProvincia";
        	this.LblProvincia.Size = new System.Drawing.Size(54, 13);
        	this.LblProvincia.TabIndex = 2;
        	this.LblProvincia.Text = "Provincia:";
        	// 
        	// GbDatosPersonales
        	// 
        	this.GbDatosPersonales.Controls.Add(this.TxtPuesto);
        	this.GbDatosPersonales.Controls.Add(this.LblPuesto);
        	this.GbDatosPersonales.Controls.Add(this.RbFemenino);
        	this.GbDatosPersonales.Controls.Add(this.RbMasculino);
        	this.GbDatosPersonales.Controls.Add(this.LblSexo);
        	this.GbDatosPersonales.Controls.Add(this.CboNacionalidad);
        	this.GbDatosPersonales.Controls.Add(this.DtpFechaNac);
        	this.GbDatosPersonales.Controls.Add(this.LblNacionalidad);
        	this.GbDatosPersonales.Controls.Add(this.LblFechaNac);
        	this.GbDatosPersonales.Controls.Add(this.TxtApellido);
        	this.GbDatosPersonales.Controls.Add(this.LblApellido);
        	this.GbDatosPersonales.Controls.Add(this.TxtNombre);
        	this.GbDatosPersonales.Controls.Add(this.LblNombre);
        	this.GbDatosPersonales.Controls.Add(this.TxtDni);
        	this.GbDatosPersonales.Controls.Add(this.LblDni);
        	this.GbDatosPersonales.Location = new System.Drawing.Point(6, 6);
        	this.GbDatosPersonales.Name = "GbDatosPersonales";
        	this.GbDatosPersonales.Size = new System.Drawing.Size(336, 253);
        	this.GbDatosPersonales.TabIndex = 22;
        	this.GbDatosPersonales.TabStop = false;
        	this.GbDatosPersonales.Text = "Datos Personales";
        	// 
        	// RbFemenino
        	// 
        	this.RbFemenino.AutoSize = true;
        	this.RbFemenino.Location = new System.Drawing.Point(195, 193);
        	this.RbFemenino.Name = "RbFemenino";
        	this.RbFemenino.Size = new System.Drawing.Size(71, 17);
        	this.RbFemenino.TabIndex = 8;
        	this.RbFemenino.TabStop = true;
        	this.RbFemenino.Text = "Femenino";
        	this.RbFemenino.UseVisualStyleBackColor = true;
        	// 
        	// RbMasculino
        	// 
        	this.RbMasculino.AutoSize = true;
        	this.RbMasculino.Location = new System.Drawing.Point(112, 193);
        	this.RbMasculino.Name = "RbMasculino";
        	this.RbMasculino.Size = new System.Drawing.Size(73, 17);
        	this.RbMasculino.TabIndex = 7;
        	this.RbMasculino.TabStop = true;
        	this.RbMasculino.Text = "Masculino";
        	this.RbMasculino.UseVisualStyleBackColor = true;
        	// 
        	// LblSexo
        	// 
        	this.LblSexo.AutoSize = true;
        	this.LblSexo.Location = new System.Drawing.Point(65, 197);
        	this.LblSexo.Name = "LblSexo";
        	this.LblSexo.Size = new System.Drawing.Size(34, 13);
        	this.LblSexo.TabIndex = 15;
        	this.LblSexo.Text = "Sexo:";
        	// 
        	// CboNacionalidad
        	// 
        	this.CboNacionalidad.FormattingEnabled = true;
        	this.CboNacionalidad.Location = new System.Drawing.Point(112, 157);
        	this.CboNacionalidad.Name = "CboNacionalidad";
        	this.CboNacionalidad.Size = new System.Drawing.Size(154, 21);
        	this.CboNacionalidad.TabIndex = 5;
        	// 
        	// DtpFechaNac
        	// 
        	this.DtpFechaNac.CustomFormat = "YYYYmmdd";
        	this.DtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.DtpFechaNac.Location = new System.Drawing.Point(112, 120);
        	this.DtpFechaNac.Name = "DtpFechaNac";
        	this.DtpFechaNac.Size = new System.Drawing.Size(107, 20);
        	this.DtpFechaNac.TabIndex = 4;
        	// 
        	// LblNacionalidad
        	// 
        	this.LblNacionalidad.AutoSize = true;
        	this.LblNacionalidad.Location = new System.Drawing.Point(34, 160);
        	this.LblNacionalidad.Name = "LblNacionalidad";
        	this.LblNacionalidad.Size = new System.Drawing.Size(72, 13);
        	this.LblNacionalidad.TabIndex = 8;
        	this.LblNacionalidad.Text = "Nacionalidad:";
        	// 
        	// LblFechaNac
        	// 
        	this.LblFechaNac.AutoSize = true;
        	this.LblFechaNac.Location = new System.Drawing.Point(43, 124);
        	this.LblFechaNac.Name = "LblFechaNac";
        	this.LblFechaNac.Size = new System.Drawing.Size(63, 13);
        	this.LblFechaNac.TabIndex = 6;
        	this.LblFechaNac.Text = "Fecha Nac:";
        	// 
        	// TxtApellido
        	// 
        	this.TxtApellido.Location = new System.Drawing.Point(112, 86);
        	this.TxtApellido.Name = "TxtApellido";
        	this.TxtApellido.Size = new System.Drawing.Size(187, 20);
        	this.TxtApellido.TabIndex = 3;
        	// 
        	// LblApellido
        	// 
        	this.LblApellido.AutoSize = true;
        	this.LblApellido.Location = new System.Drawing.Point(59, 89);
        	this.LblApellido.Name = "LblApellido";
        	this.LblApellido.Size = new System.Drawing.Size(47, 13);
        	this.LblApellido.TabIndex = 4;
        	this.LblApellido.Text = "Apellido:";
        	// 
        	// TxtNombre
        	// 
        	this.TxtNombre.Location = new System.Drawing.Point(112, 55);
        	this.TxtNombre.Name = "TxtNombre";
        	this.TxtNombre.Size = new System.Drawing.Size(187, 20);
        	this.TxtNombre.TabIndex = 2;
        	// 
        	// LblNombre
        	// 
        	this.LblNombre.AutoSize = true;
        	this.LblNombre.Location = new System.Drawing.Point(59, 58);
        	this.LblNombre.Name = "LblNombre";
        	this.LblNombre.Size = new System.Drawing.Size(47, 13);
        	this.LblNombre.TabIndex = 2;
        	this.LblNombre.Text = "Nombre:";
        	// 
        	// TxtDni
        	// 
        	this.TxtDni.Location = new System.Drawing.Point(112, 23);
        	this.TxtDni.Mask = "00.000.000";
        	this.TxtDni.Name = "TxtDni";
        	this.TxtDni.Size = new System.Drawing.Size(100, 20);
        	this.TxtDni.TabIndex = 1;
        	this.TxtDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	this.TxtDni.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
        	// 
        	// LblDni
        	// 
        	this.LblDni.AutoSize = true;
        	this.LblDni.Location = new System.Drawing.Point(77, 26);
        	this.LblDni.Name = "LblDni";
        	this.LblDni.Size = new System.Drawing.Size(29, 13);
        	this.LblDni.TabIndex = 0;
        	this.LblDni.Text = "DNI:";
        	// 
        	// TpLogin
        	// 
        	this.TpLogin.Controls.Add(this.BtnCambiarPassword);
        	this.TpLogin.Controls.Add(this.GbCambiarPassword);
        	this.TpLogin.Controls.Add(this.GbDatosLogin);
        	this.TpLogin.Location = new System.Drawing.Point(4, 22);
        	this.TpLogin.Name = "TpLogin";
        	this.TpLogin.Size = new System.Drawing.Size(655, 384);
        	this.TpLogin.TabIndex = 2;
        	this.TpLogin.Text = "Datos de Login";
        	this.TpLogin.UseVisualStyleBackColor = true;
        	// 
        	// BtnCambiarPassword
        	// 
        	this.BtnCambiarPassword.Location = new System.Drawing.Point(280, 177);
        	this.BtnCambiarPassword.Name = "BtnCambiarPassword";
        	this.BtnCambiarPassword.Size = new System.Drawing.Size(114, 23);
        	this.BtnCambiarPassword.TabIndex = 25;
        	this.BtnCambiarPassword.Text = "Cambiar Password";
        	this.BtnCambiarPassword.UseVisualStyleBackColor = true;
        	// 
        	// GbCambiarPassword
        	// 
        	this.GbCambiarPassword.Controls.Add(this.TxtPasswordNuevo);
        	this.GbCambiarPassword.Controls.Add(this.LblPasswordNuevo);
        	this.GbCambiarPassword.Controls.Add(this.TxtPasswordViejo);
        	this.GbCambiarPassword.Controls.Add(this.LblPasswordViejo);
        	this.GbCambiarPassword.Location = new System.Drawing.Point(173, 215);
        	this.GbCambiarPassword.Name = "GbCambiarPassword";
        	this.GbCambiarPassword.Size = new System.Drawing.Size(302, 79);
        	this.GbCambiarPassword.TabIndex = 24;
        	this.GbCambiarPassword.TabStop = false;
        	this.GbCambiarPassword.Text = "Cambiar Password";
        	this.GbCambiarPassword.Visible = false;
        	// 
        	// TxtPasswordNuevo
        	// 
        	this.TxtPasswordNuevo.Location = new System.Drawing.Point(98, 48);
        	this.TxtPasswordNuevo.Name = "TxtPasswordNuevo";
        	this.TxtPasswordNuevo.Size = new System.Drawing.Size(154, 20);
        	this.TxtPasswordNuevo.TabIndex = 20;
        	// 
        	// LblPasswordNuevo
        	// 
        	this.LblPasswordNuevo.AutoSize = true;
        	this.LblPasswordNuevo.Location = new System.Drawing.Point(3, 51);
        	this.LblPasswordNuevo.Name = "LblPasswordNuevo";
        	this.LblPasswordNuevo.Size = new System.Drawing.Size(89, 13);
        	this.LblPasswordNuevo.TabIndex = 20;
        	this.LblPasswordNuevo.Text = "Password nuevo:";
        	// 
        	// TxtPasswordViejo
        	// 
        	this.TxtPasswordViejo.Location = new System.Drawing.Point(98, 19);
        	this.TxtPasswordViejo.Name = "TxtPasswordViejo";
        	this.TxtPasswordViejo.Size = new System.Drawing.Size(154, 20);
        	this.TxtPasswordViejo.TabIndex = 19;
        	// 
        	// LblPasswordViejo
        	// 
        	this.LblPasswordViejo.AutoSize = true;
        	this.LblPasswordViejo.Location = new System.Drawing.Point(11, 22);
        	this.LblPasswordViejo.Name = "LblPasswordViejo";
        	this.LblPasswordViejo.Size = new System.Drawing.Size(81, 13);
        	this.LblPasswordViejo.TabIndex = 19;
        	this.LblPasswordViejo.Text = "Password viejo:";
        	// 
        	// GbDatosLogin
        	// 
        	this.GbDatosLogin.Controls.Add(this.TxtPassword);
        	this.GbDatosLogin.Controls.Add(this.LblPassword);
        	this.GbDatosLogin.Controls.Add(this.TxtUsuario);
        	this.GbDatosLogin.Controls.Add(this.LblUsuario);
        	this.GbDatosLogin.Location = new System.Drawing.Point(173, 79);
        	this.GbDatosLogin.Name = "GbDatosLogin";
        	this.GbDatosLogin.Size = new System.Drawing.Size(302, 79);
        	this.GbDatosLogin.TabIndex = 23;
        	this.GbDatosLogin.TabStop = false;
        	this.GbDatosLogin.Text = "Datos de Login";
        	// 
        	// TxtPassword
        	// 
        	this.TxtPassword.Location = new System.Drawing.Point(98, 48);
        	this.TxtPassword.Name = "TxtPassword";
        	this.TxtPassword.Size = new System.Drawing.Size(154, 20);
        	this.TxtPassword.TabIndex = 20;
        	// 
        	// LblPassword
        	// 
        	this.LblPassword.AutoSize = true;
        	this.LblPassword.Location = new System.Drawing.Point(36, 51);
        	this.LblPassword.Name = "LblPassword";
        	this.LblPassword.Size = new System.Drawing.Size(56, 13);
        	this.LblPassword.TabIndex = 20;
        	this.LblPassword.Text = "Password:";
        	// 
        	// TxtUsuario
        	// 
        	this.TxtUsuario.Location = new System.Drawing.Point(98, 19);
        	this.TxtUsuario.Name = "TxtUsuario";
        	this.TxtUsuario.Size = new System.Drawing.Size(154, 20);
        	this.TxtUsuario.TabIndex = 19;
        	// 
        	// LblUsuario
        	// 
        	this.LblUsuario.AutoSize = true;
        	this.LblUsuario.Location = new System.Drawing.Point(46, 22);
        	this.LblUsuario.Name = "LblUsuario";
        	this.LblUsuario.Size = new System.Drawing.Size(46, 13);
        	this.LblUsuario.TabIndex = 19;
        	this.LblUsuario.Text = "Usuario:";
        	// 
        	// TpStats
        	// 
        	this.TpStats.Controls.Add(this.LblNombreCategoria);
        	this.TpStats.Controls.Add(this.DgvStats);
        	this.TpStats.Location = new System.Drawing.Point(4, 22);
        	this.TpStats.Name = "TpStats";
        	this.TpStats.Padding = new System.Windows.Forms.Padding(3);
        	this.TpStats.Size = new System.Drawing.Size(655, 384);
        	this.TpStats.TabIndex = 1;
        	this.TpStats.Text = "Stats";
        	this.TpStats.UseVisualStyleBackColor = true;
        	// 
        	// LblNombreCategoria
        	// 
        	this.LblNombreCategoria.Location = new System.Drawing.Point(26, 11);
        	this.LblNombreCategoria.Name = "LblNombreCategoria";
        	this.LblNombreCategoria.Size = new System.Drawing.Size(295, 23);
        	this.LblNombreCategoria.TabIndex = 1;
        	this.LblNombreCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// DgvStats
        	// 
        	this.DgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.DgvStats.Location = new System.Drawing.Point(26, 40);
        	this.DgvStats.Name = "DgvStats";
        	this.DgvStats.Size = new System.Drawing.Size(600, 306);
        	this.DgvStats.TabIndex = 0;
        	// 
        	// LblPuesto
        	// 
        	this.LblPuesto.Location = new System.Drawing.Point(34, 215);
        	this.LblPuesto.Name = "LblPuesto";
        	this.LblPuesto.Size = new System.Drawing.Size(72, 23);
        	this.LblPuesto.TabIndex = 16;
        	this.LblPuesto.Text = "Puesto:";
        	this.LblPuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// TxtPuesto
        	// 
        	this.TxtPuesto.Location = new System.Drawing.Point(112, 217);
        	this.TxtPuesto.Name = "TxtPuesto";
        	this.TxtPuesto.Size = new System.Drawing.Size(100, 20);
        	this.TxtPuesto.TabIndex = 17;
        	// 
        	// FrmNuevaPersona
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(679, 425);
        	this.Controls.Add(this.TcPersonas);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "FrmNuevaPersona";
        	this.Text = "Nombre por codigo";
        	this.Load += new System.EventHandler(this.FrmNuevaPersona_Load);
        	this.TcPersonas.ResumeLayout(false);
        	this.TpDatosPersonales.ResumeLayout(false);
        	this.GbMenor.ResumeLayout(false);
        	this.GbMenor.PerformLayout();
        	this.GbContacto.ResumeLayout(false);
        	this.GbContacto.PerformLayout();
        	this.GbDireccion.ResumeLayout(false);
        	this.GbDireccion.PerformLayout();
        	this.GbDatosPersonales.ResumeLayout(false);
        	this.GbDatosPersonales.PerformLayout();
        	this.TpLogin.ResumeLayout(false);
        	this.GbCambiarPassword.ResumeLayout(false);
        	this.GbCambiarPassword.PerformLayout();
        	this.GbDatosLogin.ResumeLayout(false);
        	this.GbDatosLogin.PerformLayout();
        	this.TpStats.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.DgvStats)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.TextBox TxtPuesto;
        private System.Windows.Forms.Label LblPuesto;
        private System.Windows.Forms.Label LblNombreCategoria;

        #endregion

        private System.Windows.Forms.TabControl TcPersonas;
        private System.Windows.Forms.TabPage TpDatosPersonales;
        private System.Windows.Forms.TabPage TpStats;
        private System.Windows.Forms.GroupBox GbMenor;
        private System.Windows.Forms.TextBox TxtRelacion;
        private System.Windows.Forms.Label LblRelacionMenor;
        private System.Windows.Forms.TextBox TxtNombreTutor;
        private System.Windows.Forms.Label LblNombreTutor;
        private System.Windows.Forms.MaskedTextBox TxtDniTutor;
        private System.Windows.Forms.Label LblDniTutor;
        private System.Windows.Forms.GroupBox GbContacto;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtCelular;
        private System.Windows.Forms.Label LblCelular;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label LblTelefono;
        private System.Windows.Forms.GroupBox GbDireccion;
        private System.Windows.Forms.Button BtnAgregarLocalidad;
        private System.Windows.Forms.ComboBox CboLocalidades;
        private System.Windows.Forms.TextBox TxtDomicilio;
        private System.Windows.Forms.Label LblDomicilio;
        private System.Windows.Forms.ComboBox CboProvincia;
        private System.Windows.Forms.Label LblLocalidad;
        private System.Windows.Forms.Label LblProvincia;
        private System.Windows.Forms.GroupBox GbDatosPersonales;
        private System.Windows.Forms.RadioButton RbFemenino;
        private System.Windows.Forms.RadioButton RbMasculino;
        private System.Windows.Forms.Label LblSexo;
        private System.Windows.Forms.ComboBox CboNacionalidad;
        private System.Windows.Forms.DateTimePicker DtpFechaNac;
        private System.Windows.Forms.Label LblNacionalidad;
        private System.Windows.Forms.Label LblFechaNac;
        private System.Windows.Forms.TextBox TxtApellido;
        private System.Windows.Forms.Label LblApellido;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.MaskedTextBox TxtDni;
        private System.Windows.Forms.Label LblDni;
        private System.Windows.Forms.TabPage TpLogin;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.GroupBox GbDatosLogin;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.DataGridView DgvStats;
        private System.Windows.Forms.GroupBox GbCambiarPassword;
        private System.Windows.Forms.TextBox TxtPasswordNuevo;
        private System.Windows.Forms.Label LblPasswordNuevo;
        private System.Windows.Forms.TextBox TxtPasswordViejo;
        private System.Windows.Forms.Label LblPasswordViejo;
        private System.Windows.Forms.Button BtnCambiarPassword;
    }
}