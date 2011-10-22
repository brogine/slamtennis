namespace Slam
{
    partial class FrmNuevoPartido
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
            this.components = new System.ComponentModel.Container();
            this.LblTorneo = new System.Windows.Forms.Label();
            this.CboListaTorneo = new System.Windows.Forms.ComboBox();
            this.GrpEquipo1 = new System.Windows.Forms.GroupBox();
            this.CboEquipo1 = new System.Windows.Forms.ComboBox();
            this.LblVs = new System.Windows.Forms.Label();
            this.GrpEquipo2 = new System.Windows.Forms.GroupBox();
            this.CboEquipo2 = new System.Windows.Forms.ComboBox();
            this.DtpFechaPartido = new System.Windows.Forms.DateTimePicker();
            this.LblFecha = new System.Windows.Forms.Label();
            this.LblResultado = new System.Windows.Forms.Label();
            this.TxtResultado = new System.Windows.Forms.MaskedTextBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.ChkEstado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRonda = new System.Windows.Forms.TextBox();
            this.EPPartidos = new System.Windows.Forms.ErrorProvider(this.components);
            this.GrpEquipo1.SuspendLayout();
            this.GrpEquipo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPPartidos)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTorneo
            // 
            this.LblTorneo.AutoSize = true;
            this.LblTorneo.Location = new System.Drawing.Point(12, 19);
            this.LblTorneo.Name = "LblTorneo";
            this.LblTorneo.Size = new System.Drawing.Size(171, 13);
            this.LblTorneo.TabIndex = 0;
            this.LblTorneo.Text = "Seleccione Un Torneo De La Lista";
            // 
            // CboListaTorneo
            // 
            this.CboListaTorneo.FormattingEnabled = true;
            this.CboListaTorneo.Location = new System.Drawing.Point(189, 16);
            this.CboListaTorneo.Name = "CboListaTorneo";
            this.CboListaTorneo.Size = new System.Drawing.Size(219, 21);
            this.CboListaTorneo.TabIndex = 1;
            this.CboListaTorneo.Validating += new System.ComponentModel.CancelEventHandler(this.CboListaTorneo_Validating);
            this.CboListaTorneo.SelectedIndexChanged += new System.EventHandler(this.CboListaTorneo_SelectedIndexChanged);
            // 
            // GrpEquipo1
            // 
            this.GrpEquipo1.Controls.Add(this.CboEquipo1);
            this.GrpEquipo1.Location = new System.Drawing.Point(12, 43);
            this.GrpEquipo1.Name = "GrpEquipo1";
            this.GrpEquipo1.Size = new System.Drawing.Size(252, 61);
            this.GrpEquipo1.TabIndex = 2;
            this.GrpEquipo1.TabStop = false;
            this.GrpEquipo1.Text = "Seleccione El Equipo 1";
            // 
            // CboEquipo1
            // 
            this.CboEquipo1.FormattingEnabled = true;
            this.CboEquipo1.Location = new System.Drawing.Point(6, 19);
            this.CboEquipo1.Name = "CboEquipo1";
            this.CboEquipo1.Size = new System.Drawing.Size(237, 21);
            this.CboEquipo1.TabIndex = 0;
            this.CboEquipo1.Validating += new System.ComponentModel.CancelEventHandler(this.CboEquipo1_Validating);
            // 
            // LblVs
            // 
            this.LblVs.AutoSize = true;
            this.LblVs.Location = new System.Drawing.Point(270, 70);
            this.LblVs.Name = "LblVs";
            this.LblVs.Size = new System.Drawing.Size(21, 13);
            this.LblVs.TabIndex = 1;
            this.LblVs.Text = "VS";
            // 
            // GrpEquipo2
            // 
            this.GrpEquipo2.Controls.Add(this.CboEquipo2);
            this.GrpEquipo2.Location = new System.Drawing.Point(297, 43);
            this.GrpEquipo2.Name = "GrpEquipo2";
            this.GrpEquipo2.Size = new System.Drawing.Size(282, 61);
            this.GrpEquipo2.TabIndex = 3;
            this.GrpEquipo2.TabStop = false;
            this.GrpEquipo2.Text = "Seleccione El Equipo 2";
            // 
            // CboEquipo2
            // 
            this.CboEquipo2.FormattingEnabled = true;
            this.CboEquipo2.Location = new System.Drawing.Point(6, 19);
            this.CboEquipo2.Name = "CboEquipo2";
            this.CboEquipo2.Size = new System.Drawing.Size(270, 21);
            this.CboEquipo2.TabIndex = 0;
            this.CboEquipo2.Validating += new System.ComponentModel.CancelEventHandler(this.CboEquipo2_Validating);
            // 
            // DtpFechaPartido
            // 
            this.DtpFechaPartido.Location = new System.Drawing.Point(107, 111);
            this.DtpFechaPartido.Name = "DtpFechaPartido";
            this.DtpFechaPartido.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaPartido.TabIndex = 4;
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(9, 117);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(92, 13);
            this.LblFecha.TabIndex = 5;
            this.LblFecha.Text = "Fecha Del Partido";
            // 
            // LblResultado
            // 
            this.LblResultado.AutoSize = true;
            this.LblResultado.Location = new System.Drawing.Point(146, 151);
            this.LblResultado.Name = "LblResultado";
            this.LblResultado.Size = new System.Drawing.Size(55, 13);
            this.LblResultado.TabIndex = 6;
            this.LblResultado.Text = "Resultado";
            // 
            // TxtResultado
            // 
            this.TxtResultado.Location = new System.Drawing.Point(207, 144);
            this.TxtResultado.Mask = "0-0/0-0/00-00";
            this.TxtResultado.Name = "TxtResultado";
            this.TxtResultado.Size = new System.Drawing.Size(100, 20);
            this.TxtResultado.TabIndex = 7;
            this.TxtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(421, 144);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 8;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(504, 144);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 9;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // ChkEstado
            // 
            this.ChkEstado.AutoSize = true;
            this.ChkEstado.Location = new System.Drawing.Point(12, 150);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(56, 17);
            this.ChkEstado.TabIndex = 1;
            this.ChkEstado.Text = "Activo";
            this.ChkEstado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ronda";
            // 
            // TxtRonda
            // 
            this.TxtRonda.Location = new System.Drawing.Point(358, 110);
            this.TxtRonda.Name = "TxtRonda";
            this.TxtRonda.Size = new System.Drawing.Size(103, 20);
            this.TxtRonda.TabIndex = 11;
            this.TxtRonda.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRonda_Validating);
            // 
            // EPPartidos
            // 
            this.EPPartidos.ContainerControl = this;
            // 
            // FrmNuevoPartido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 177);
            this.Controls.Add(this.TxtRonda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkEstado);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtResultado);
            this.Controls.Add(this.LblResultado);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.DtpFechaPartido);
            this.Controls.Add(this.GrpEquipo2);
            this.Controls.Add(this.LblVs);
            this.Controls.Add(this.GrpEquipo1);
            this.Controls.Add(this.CboListaTorneo);
            this.Controls.Add(this.LblTorneo);
            this.Name = "FrmNuevoPartido";
            this.Text = "FrmNuevoPartido";
            this.Load += new System.EventHandler(this.FrmNuevoPartido_Load);
            this.GrpEquipo1.ResumeLayout(false);
            this.GrpEquipo2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EPPartidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTorneo;
        private System.Windows.Forms.ComboBox CboListaTorneo;
        private System.Windows.Forms.GroupBox GrpEquipo1;
        private System.Windows.Forms.ComboBox CboEquipo1;
        private System.Windows.Forms.Label LblVs;
        private System.Windows.Forms.GroupBox GrpEquipo2;
        private System.Windows.Forms.ComboBox CboEquipo2;
        private System.Windows.Forms.DateTimePicker DtpFechaPartido;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblResultado;
        private System.Windows.Forms.MaskedTextBox TxtResultado;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.CheckBox ChkEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRonda;
        private System.Windows.Forms.ErrorProvider EPPartidos;
    }
}