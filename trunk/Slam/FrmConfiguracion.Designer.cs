namespace Slam
{
    partial class FrmConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.CboConexiones = new System.Windows.Forms.ComboBox();
            this.LblConexiones = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.ChkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.TxtServidor = new System.Windows.Forms.TextBox();
            this.LblServidor = new System.Windows.Forms.Label();
            this.BtnProbar = new System.Windows.Forms.Button();
            this.LblConexionActual = new System.Windows.Forms.Label();
            this.BtnEstablecer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CboConexiones
            // 
            this.CboConexiones.FormattingEnabled = true;
            this.CboConexiones.Location = new System.Drawing.Point(105, 12);
            this.CboConexiones.Name = "CboConexiones";
            this.CboConexiones.Size = new System.Drawing.Size(208, 21);
            this.CboConexiones.TabIndex = 0;
            this.CboConexiones.SelectedIndexChanged += new System.EventHandler(this.CboConexiones_SelectedIndexChanged);
            this.CboConexiones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboConexiones_KeyPress);
            // 
            // LblConexiones
            // 
            this.LblConexiones.AutoSize = true;
            this.LblConexiones.Location = new System.Drawing.Point(26, 15);
            this.LblConexiones.Name = "LblConexiones";
            this.LblConexiones.Size = new System.Drawing.Size(73, 13);
            this.LblConexiones.TabIndex = 1;
            this.LblConexiones.Text = "Conectarse a:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(105, 210);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 2;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(188, 210);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(131, 88);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(132, 20);
            this.TxtUsuario.TabIndex = 4;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(131, 114);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(132, 20);
            this.TxtPassword.TabIndex = 4;
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(26, 91);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(87, 13);
            this.LblUsuario.TabIndex = 1;
            this.LblUsuario.Text = "Usuario de BDD:";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(26, 117);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(97, 13);
            this.LblPassword.TabIndex = 1;
            this.LblPassword.Text = "Password de BDD:";
            // 
            // ChkIntegratedSecurity
            // 
            this.ChkIntegratedSecurity.AutoSize = true;
            this.ChkIntegratedSecurity.Location = new System.Drawing.Point(131, 140);
            this.ChkIntegratedSecurity.Name = "ChkIntegratedSecurity";
            this.ChkIntegratedSecurity.Size = new System.Drawing.Size(147, 17);
            this.ChkIntegratedSecurity.TabIndex = 5;
            this.ChkIntegratedSecurity.Text = "Usar Seguridad Integrada";
            this.ChkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.ChkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.ChkIntegratedSecurity_CheckedChanged);
            // 
            // TxtServidor
            // 
            this.TxtServidor.Location = new System.Drawing.Point(131, 62);
            this.TxtServidor.Name = "TxtServidor";
            this.TxtServidor.Size = new System.Drawing.Size(132, 20);
            this.TxtServidor.TabIndex = 4;
            // 
            // LblServidor
            // 
            this.LblServidor.AutoSize = true;
            this.LblServidor.Location = new System.Drawing.Point(26, 65);
            this.LblServidor.Name = "LblServidor";
            this.LblServidor.Size = new System.Drawing.Size(49, 13);
            this.LblServidor.TabIndex = 1;
            this.LblServidor.Text = "Servidor:";
            // 
            // BtnProbar
            // 
            this.BtnProbar.Location = new System.Drawing.Point(68, 181);
            this.BtnProbar.Name = "BtnProbar";
            this.BtnProbar.Size = new System.Drawing.Size(112, 23);
            this.BtnProbar.TabIndex = 6;
            this.BtnProbar.Text = "Probar Conexión";
            this.BtnProbar.UseVisualStyleBackColor = true;
            this.BtnProbar.Click += new System.EventHandler(this.BtnProbar_Click);
            // 
            // LblConexionActual
            // 
            this.LblConexionActual.AutoSize = true;
            this.LblConexionActual.ForeColor = System.Drawing.Color.Green;
            this.LblConexionActual.Location = new System.Drawing.Point(152, 36);
            this.LblConexionActual.Name = "LblConexionActual";
            this.LblConexionActual.Size = new System.Drawing.Size(84, 13);
            this.LblConexionActual.TabIndex = 7;
            this.LblConexionActual.Text = "Conexión Actual";
            // 
            // BtnEstablecer
            // 
            this.BtnEstablecer.Location = new System.Drawing.Point(186, 181);
            this.BtnEstablecer.Name = "BtnEstablecer";
            this.BtnEstablecer.Size = new System.Drawing.Size(112, 23);
            this.BtnEstablecer.TabIndex = 8;
            this.BtnEstablecer.Text = "Usar ésta conexión";
            this.BtnEstablecer.UseVisualStyleBackColor = true;
            this.BtnEstablecer.Click += new System.EventHandler(this.BtnEstablecer_Click);
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 248);
            this.Controls.Add(this.BtnEstablecer);
            this.Controls.Add(this.LblConexionActual);
            this.Controls.Add(this.BtnProbar);
            this.Controls.Add(this.ChkIntegratedSecurity);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtServidor);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblServidor);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.LblConexiones);
            this.Controls.Add(this.CboConexiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboConexiones;
        private System.Windows.Forms.Label LblConexiones;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.CheckBox ChkIntegratedSecurity;
        private System.Windows.Forms.TextBox TxtServidor;
        private System.Windows.Forms.Label LblServidor;
        private System.Windows.Forms.Button BtnProbar;
        private System.Windows.Forms.Label LblConexionActual;
        private System.Windows.Forms.Button BtnEstablecer;
    }
}