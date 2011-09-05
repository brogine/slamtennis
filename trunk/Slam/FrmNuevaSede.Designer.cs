namespace Slam
{
    partial class FrmNuevaSede
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaSede));
            this.CboClubes = new System.Windows.Forms.ComboBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.CboProvincias = new System.Windows.Forms.ComboBox();
            this.CboLocalidades = new System.Windows.Forms.ComboBox();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblClubes = new System.Windows.Forms.Label();
            this.LblDireccion = new System.Windows.Forms.Label();
            this.LblProvincia = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblTelefono = new System.Windows.Forms.Label();
            this.LblLocalidad = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.EpSedes = new System.Windows.Forms.ErrorProvider(this.components);
            this.LblCelular = new System.Windows.Forms.Label();
            this.TxtCelular = new System.Windows.Forms.TextBox();
            this.LblPais = new System.Windows.Forms.Label();
            this.CboPaises = new System.Windows.Forms.ComboBox();
            this.LblExplicacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EpSedes)).BeginInit();
            this.SuspendLayout();
            // 
            // CboClubes
            // 
            this.CboClubes.FormattingEnabled = true;
            this.CboClubes.Location = new System.Drawing.Point(175, 28);
            this.CboClubes.Name = "CboClubes";
            this.CboClubes.Size = new System.Drawing.Size(121, 21);
            this.CboClubes.TabIndex = 0;
            this.CboClubes.Validating += new System.ComponentModel.CancelEventHandler(this.CboClubes_Validating);
            this.CboClubes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboClubes_KeyPress);
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(175, 55);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(121, 20);
            this.TxtDireccion.TabIndex = 1;
            this.TxtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDireccion_Validating);
            // 
            // CboProvincias
            // 
            this.CboProvincias.FormattingEnabled = true;
            this.CboProvincias.Location = new System.Drawing.Point(175, 108);
            this.CboProvincias.Name = "CboProvincias";
            this.CboProvincias.Size = new System.Drawing.Size(121, 21);
            this.CboProvincias.TabIndex = 3;
            this.CboProvincias.Validating += new System.ComponentModel.CancelEventHandler(this.CboProvincias_Validating);
            this.CboProvincias.SelectionChangeCommitted += new System.EventHandler(this.CboProvincias_SelectionChangeCommitted);
            this.CboProvincias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboProvincias_KeyPress);
            // 
            // CboLocalidades
            // 
            this.CboLocalidades.FormattingEnabled = true;
            this.CboLocalidades.Location = new System.Drawing.Point(175, 135);
            this.CboLocalidades.Name = "CboLocalidades";
            this.CboLocalidades.Size = new System.Drawing.Size(121, 21);
            this.CboLocalidades.TabIndex = 4;
            this.CboLocalidades.Validating += new System.ComponentModel.CancelEventHandler(this.CboLocalidades_Validating);
            this.CboLocalidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboLocalidades_KeyPress);
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Location = new System.Drawing.Point(175, 162);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(121, 20);
            this.TxtTelefono.TabIndex = 5;
            this.TxtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTelefono_Validating);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(175, 214);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(121, 20);
            this.TxtEmail.TabIndex = 7;
            this.TxtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmail_Validating);
            // 
            // LblClubes
            // 
            this.LblClubes.AutoSize = true;
            this.LblClubes.Location = new System.Drawing.Point(51, 31);
            this.LblClubes.Name = "LblClubes";
            this.LblClubes.Size = new System.Drawing.Size(118, 13);
            this.LblClubes.TabIndex = 6;
            this.LblClubes.Text = "* Club al que pertenece";
            // 
            // LblDireccion
            // 
            this.LblDireccion.AutoSize = true;
            this.LblDireccion.Location = new System.Drawing.Point(110, 58);
            this.LblDireccion.Name = "LblDireccion";
            this.LblDireccion.Size = new System.Drawing.Size(59, 13);
            this.LblDireccion.TabIndex = 7;
            this.LblDireccion.Text = "* Dirección";
            // 
            // LblProvincia
            // 
            this.LblProvincia.AutoSize = true;
            this.LblProvincia.Location = new System.Drawing.Point(111, 111);
            this.LblProvincia.Name = "LblProvincia";
            this.LblProvincia.Size = new System.Drawing.Size(58, 13);
            this.LblProvincia.TabIndex = 8;
            this.LblProvincia.Text = "* Provincia";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(137, 217);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(32, 13);
            this.LblEmail.TabIndex = 11;
            this.LblEmail.Text = "Email";
            // 
            // LblTelefono
            // 
            this.LblTelefono.AutoSize = true;
            this.LblTelefono.Location = new System.Drawing.Point(120, 165);
            this.LblTelefono.Name = "LblTelefono";
            this.LblTelefono.Size = new System.Drawing.Size(49, 13);
            this.LblTelefono.TabIndex = 10;
            this.LblTelefono.Text = "Teléfono";
            // 
            // LblLocalidad
            // 
            this.LblLocalidad.AutoSize = true;
            this.LblLocalidad.Location = new System.Drawing.Point(109, 138);
            this.LblLocalidad.Name = "LblLocalidad";
            this.LblLocalidad.Size = new System.Drawing.Size(60, 13);
            this.LblLocalidad.TabIndex = 9;
            this.LblLocalidad.Text = "* Localidad";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(94, 260);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 8;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(175, 260);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 9;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // EpSedes
            // 
            this.EpSedes.ContainerControl = this;
            // 
            // LblCelular
            // 
            this.LblCelular.AutoSize = true;
            this.LblCelular.Location = new System.Drawing.Point(130, 191);
            this.LblCelular.Name = "LblCelular";
            this.LblCelular.Size = new System.Drawing.Size(39, 13);
            this.LblCelular.TabIndex = 15;
            this.LblCelular.Text = "Celular";
            // 
            // TxtCelular
            // 
            this.TxtCelular.Location = new System.Drawing.Point(175, 188);
            this.TxtCelular.Name = "TxtCelular";
            this.TxtCelular.Size = new System.Drawing.Size(121, 20);
            this.TxtCelular.TabIndex = 6;
            this.TxtCelular.Validating += new System.ComponentModel.CancelEventHandler(this.TxtCelular_Validating);
            // 
            // LblPais
            // 
            this.LblPais.AutoSize = true;
            this.LblPais.Location = new System.Drawing.Point(135, 84);
            this.LblPais.Name = "LblPais";
            this.LblPais.Size = new System.Drawing.Size(34, 13);
            this.LblPais.TabIndex = 17;
            this.LblPais.Text = "* Pais";
            // 
            // CboPaises
            // 
            this.CboPaises.FormattingEnabled = true;
            this.CboPaises.Location = new System.Drawing.Point(175, 81);
            this.CboPaises.Name = "CboPaises";
            this.CboPaises.Size = new System.Drawing.Size(121, 21);
            this.CboPaises.TabIndex = 2;
            this.CboPaises.Validating += new System.ComponentModel.CancelEventHandler(this.CboPaises_Validating);
            this.CboPaises.SelectionChangeCommitted += new System.EventHandler(this.CboPaises_SelectionChangeCommitted);
            this.CboPaises.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboPaises_KeyPress);
            // 
            // LblExplicacion
            // 
            this.LblExplicacion.AutoSize = true;
            this.LblExplicacion.Location = new System.Drawing.Point(91, 244);
            this.LblExplicacion.Name = "LblExplicacion";
            this.LblExplicacion.Size = new System.Drawing.Size(169, 13);
            this.LblExplicacion.TabIndex = 18;
            this.LblExplicacion.Text = "Los Campos con * son obligatorios";
            // 
            // FrmNuevaSede
            // 
            this.AcceptButton = this.BtnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(361, 313);
            this.Controls.Add(this.LblExplicacion);
            this.Controls.Add(this.LblPais);
            this.Controls.Add(this.CboPaises);
            this.Controls.Add(this.LblCelular);
            this.Controls.Add(this.TxtCelular);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.LblTelefono);
            this.Controls.Add(this.LblLocalidad);
            this.Controls.Add(this.LblProvincia);
            this.Controls.Add(this.LblDireccion);
            this.Controls.Add(this.LblClubes);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.CboLocalidades);
            this.Controls.Add(this.CboProvincias);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.CboClubes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNuevaSede";
            this.Text = "FrmNuevaSede";
            this.Load += new System.EventHandler(this.FrmNuevaSede_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpSedes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboClubes;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.ComboBox CboProvincias;
        private System.Windows.Forms.ComboBox CboLocalidades;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblClubes;
        private System.Windows.Forms.Label LblDireccion;
        private System.Windows.Forms.Label LblProvincia;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblTelefono;
        private System.Windows.Forms.Label LblLocalidad;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ErrorProvider EpSedes;
        private System.Windows.Forms.Label LblCelular;
        private System.Windows.Forms.TextBox TxtCelular;
        private System.Windows.Forms.Label LblPais;
        private System.Windows.Forms.ComboBox CboPaises;
        private System.Windows.Forms.Label LblExplicacion;
    }
}