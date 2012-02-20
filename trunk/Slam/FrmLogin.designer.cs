namespace Slam
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.LblOlvidoPassword = new System.Windows.Forms.LinkLabel();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.EpLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbPrimerInicio = new System.Windows.Forms.GroupBox();
            this.BtnCrearCuenta = new System.Windows.Forms.Button();
            this.txtBienvenido = new System.Windows.Forms.TextBox();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EpLogin)).BeginInit();
            this.gbPrimerInicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.LblOlvidoPassword);
            this.gbLogin.Controls.Add(this.LblPassword);
            this.gbLogin.Controls.Add(this.LblUsuario);
            this.gbLogin.Controls.Add(this.BtnCancelar);
            this.gbLogin.Controls.Add(this.BtnAceptar);
            this.gbLogin.Controls.Add(this.TxtPassword);
            this.gbLogin.Controls.Add(this.TxtUsuario);
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(359, 180);
            this.gbLogin.TabIndex = 1;
            this.gbLogin.TabStop = false;
            // 
            // LblOlvidoPassword
            // 
            this.LblOlvidoPassword.AutoSize = true;
            this.LblOlvidoPassword.Location = new System.Drawing.Point(123, 157);
            this.LblOlvidoPassword.Name = "LblOlvidoPassword";
            this.LblOlvidoPassword.Size = new System.Drawing.Size(124, 13);
            this.LblOlvidoPassword.TabIndex = 4;
            this.LblOlvidoPassword.TabStop = true;
            this.LblOlvidoPassword.Text = "¿Olvidó su constraseña?";
            this.LblOlvidoPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblOlvidoPassword_LinkClicked);
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(93, 79);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(53, 13);
            this.LblPassword.TabIndex = 11;
            this.LblPassword.Text = "Password";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(93, 33);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(43, 13);
            this.LblUsuario.TabIndex = 10;
            this.LblUsuario.Text = "Usuario";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(193, 122);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(96, 122);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "&Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(168, 76);
            this.TxtPassword.MaxLength = 20;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(100, 20);
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPassword_Validating);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(168, 30);
            this.TxtUsuario.MaxLength = 20;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtUsuario.TabIndex = 0;
            this.TxtUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUsuario_Validating);
            // 
            // EpLogin
            // 
            this.EpLogin.ContainerControl = this;
            // 
            // gbPrimerInicio
            // 
            this.gbPrimerInicio.Controls.Add(this.BtnCrearCuenta);
            this.gbPrimerInicio.Controls.Add(this.txtBienvenido);
            this.gbPrimerInicio.Location = new System.Drawing.Point(12, 12);
            this.gbPrimerInicio.Name = "gbPrimerInicio";
            this.gbPrimerInicio.Size = new System.Drawing.Size(359, 180);
            this.gbPrimerInicio.TabIndex = 2;
            this.gbPrimerInicio.TabStop = false;
            this.gbPrimerInicio.Visible = false;
            // 
            // BtnCrearCuenta
            // 
            this.BtnCrearCuenta.Location = new System.Drawing.Point(128, 151);
            this.BtnCrearCuenta.Name = "BtnCrearCuenta";
            this.BtnCrearCuenta.Size = new System.Drawing.Size(106, 23);
            this.BtnCrearCuenta.TabIndex = 1;
            this.BtnCrearCuenta.Text = "Crear Cuenta";
            this.BtnCrearCuenta.UseVisualStyleBackColor = true;
            this.BtnCrearCuenta.Click += new System.EventHandler(this.BtnCrearCuenta_Click);
            // 
            // txtBienvenido
            // 
            this.txtBienvenido.Location = new System.Drawing.Point(49, 14);
            this.txtBienvenido.Multiline = true;
            this.txtBienvenido.Name = "txtBienvenido";
            this.txtBienvenido.ReadOnly = true;
            this.txtBienvenido.Size = new System.Drawing.Size(263, 131);
            this.txtBienvenido.TabIndex = 10;
            this.txtBienvenido.Text = resources.GetString("txtBienvenido.Text");
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.BtnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(385, 208);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.gbPrimerInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EpLogin)).EndInit();
            this.gbPrimerInicio.ResumeLayout(false);
            this.gbPrimerInicio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.LinkLabel LblOlvidoPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.ErrorProvider EpLogin;
        private System.Windows.Forms.GroupBox gbPrimerInicio;
        private System.Windows.Forms.TextBox txtBienvenido;
        private System.Windows.Forms.Button BtnCrearCuenta;
    }
}