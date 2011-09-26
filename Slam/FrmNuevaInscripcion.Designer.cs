namespace Slam
{
    partial class FrmNuevaInscripcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaInscripcion));
            this.CboTorneos = new System.Windows.Forms.ComboBox();
            this.TxtDniJugador1 = new System.Windows.Forms.MaskedTextBox();
            this.TxtDniJugador2 = new System.Windows.Forms.MaskedTextBox();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.ChkEstado = new System.Windows.Forms.CheckBox();
            this.LblTorneo = new System.Windows.Forms.Label();
            this.LblDniJugador1 = new System.Windows.Forms.Label();
            this.LblDniJugador2 = new System.Windows.Forms.Label();
            this.LblFechaInscripcion = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtNroInscripcion = new System.Windows.Forms.TextBox();
            this.lblNroInscripcion = new System.Windows.Forms.Label();
            this.EpInscripciones = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EpInscripciones)).BeginInit();
            this.SuspendLayout();
            // 
            // CboTorneos
            // 
            this.CboTorneos.FormattingEnabled = true;
            this.CboTorneos.Location = new System.Drawing.Point(175, 12);
            this.CboTorneos.Name = "CboTorneos";
            this.CboTorneos.Size = new System.Drawing.Size(151, 21);
            this.CboTorneos.TabIndex = 0;
            this.CboTorneos.Validating += new System.ComponentModel.CancelEventHandler(this.CboTorneos_Validating);
            this.CboTorneos.SelectionChangeCommitted += new System.EventHandler(this.CboTorneos_SelectionChangeCommitted);
            this.CboTorneos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboTorneos_KeyPress);
            // 
            // TxtDniJugador1
            // 
            this.TxtDniJugador1.Location = new System.Drawing.Point(175, 39);
            this.TxtDniJugador1.Mask = "00.000.000";
            this.TxtDniJugador1.Name = "TxtDniJugador1";
            this.TxtDniJugador1.Size = new System.Drawing.Size(99, 20);
            this.TxtDniJugador1.TabIndex = 1;
            this.TxtDniJugador1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtDniJugador1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TxtDniJugador1.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDniJugador1_Validating);
            this.TxtDniJugador1.Leave += new System.EventHandler(this.TxtDniJugador1_Leave);
            this.TxtDniJugador1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDniJugador1_KeyPress);
            // 
            // TxtDniJugador2
            // 
            this.TxtDniJugador2.Location = new System.Drawing.Point(175, 65);
            this.TxtDniJugador2.Mask = "00.000.000";
            this.TxtDniJugador2.Name = "TxtDniJugador2";
            this.TxtDniJugador2.Size = new System.Drawing.Size(99, 20);
            this.TxtDniJugador2.TabIndex = 1;
            this.TxtDniJugador2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtDniJugador2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TxtDniJugador2.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDniJugador2_Validating);
            this.TxtDniJugador2.Leave += new System.EventHandler(this.TxtDniJugador2_Leave);
            this.TxtDniJugador2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDniJugador2_KeyPress);
            // 
            // DtpFecha
            // 
            this.DtpFecha.Enabled = false;
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(176, 117);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(98, 20);
            this.DtpFecha.TabIndex = 2;
            // 
            // ChkEstado
            // 
            this.ChkEstado.AutoSize = true;
            this.ChkEstado.Location = new System.Drawing.Point(176, 144);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(59, 17);
            this.ChkEstado.TabIndex = 3;
            this.ChkEstado.Text = "Estado";
            this.ChkEstado.UseVisualStyleBackColor = true;
            // 
            // LblTorneo
            // 
            this.LblTorneo.AutoSize = true;
            this.LblTorneo.Location = new System.Drawing.Point(12, 15);
            this.LblTorneo.Name = "LblTorneo";
            this.LblTorneo.Size = new System.Drawing.Size(157, 13);
            this.LblTorneo.TabIndex = 4;
            this.LblTorneo.Text = "Torneo al que se va a Inscribir *";
            // 
            // LblDniJugador1
            // 
            this.LblDniJugador1.AutoSize = true;
            this.LblDniJugador1.Location = new System.Drawing.Point(74, 42);
            this.LblDniJugador1.Name = "LblDniJugador1";
            this.LblDniJugador1.Size = new System.Drawing.Size(95, 13);
            this.LblDniJugador1.TabIndex = 4;
            this.LblDniJugador1.Text = "Dni de Jugador 1 *";
            // 
            // LblDniJugador2
            // 
            this.LblDniJugador2.AutoSize = true;
            this.LblDniJugador2.Location = new System.Drawing.Point(74, 68);
            this.LblDniJugador2.Name = "LblDniJugador2";
            this.LblDniJugador2.Size = new System.Drawing.Size(95, 13);
            this.LblDniJugador2.TabIndex = 4;
            this.LblDniJugador2.Text = "Dni de Jugador 2 *";
            // 
            // LblFechaInscripcion
            // 
            this.LblFechaInscripcion.AutoSize = true;
            this.LblFechaInscripcion.Location = new System.Drawing.Point(64, 120);
            this.LblFechaInscripcion.Name = "LblFechaInscripcion";
            this.LblFechaInscripcion.Size = new System.Drawing.Size(106, 13);
            this.LblFechaInscripcion.TabIndex = 4;
            this.LblFechaInscripcion.Text = "Fecha de Inscripción";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(82, 167);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(75, 23);
            this.BtnAgregar.TabIndex = 5;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(199, 167);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtNroInscripcion
            // 
            this.TxtNroInscripcion.Location = new System.Drawing.Point(176, 91);
            this.TxtNroInscripcion.Name = "TxtNroInscripcion";
            this.TxtNroInscripcion.Size = new System.Drawing.Size(59, 20);
            this.TxtNroInscripcion.TabIndex = 23;
            // 
            // lblNroInscripcion
            // 
            this.lblNroInscripcion.AutoSize = true;
            this.lblNroInscripcion.Location = new System.Drawing.Point(73, 94);
            this.lblNroInscripcion.Name = "lblNroInscripcion";
            this.lblNroInscripcion.Size = new System.Drawing.Size(96, 13);
            this.lblNroInscripcion.TabIndex = 22;
            this.lblNroInscripcion.Text = "Nro. de Inscripción";
            // 
            // EpInscripciones
            // 
            this.EpInscripciones.ContainerControl = this;
            // 
            // FrmNuevaInscripcion
            // 
            this.AcceptButton = this.BtnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(358, 202);
            this.Controls.Add(this.TxtNroInscripcion);
            this.Controls.Add(this.lblNroInscripcion);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.LblFechaInscripcion);
            this.Controls.Add(this.LblDniJugador2);
            this.Controls.Add(this.LblDniJugador1);
            this.Controls.Add(this.LblTorneo);
            this.Controls.Add(this.ChkEstado);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.TxtDniJugador2);
            this.Controls.Add(this.TxtDniJugador1);
            this.Controls.Add(this.CboTorneos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmNuevaInscripcion";
            this.Text = "Nombre Por Codigo";
            this.Load += new System.EventHandler(this.FrmNuevaInscripcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpInscripciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboTorneos;
        private System.Windows.Forms.MaskedTextBox TxtDniJugador1;
        private System.Windows.Forms.MaskedTextBox TxtDniJugador2;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.CheckBox ChkEstado;
        private System.Windows.Forms.Label LblTorneo;
        private System.Windows.Forms.Label LblDniJugador1;
        private System.Windows.Forms.Label LblDniJugador2;
        private System.Windows.Forms.Label LblFechaInscripcion;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtNroInscripcion;
        private System.Windows.Forms.Label lblNroInscripcion;
        private System.Windows.Forms.ErrorProvider EpInscripciones;
    }
}