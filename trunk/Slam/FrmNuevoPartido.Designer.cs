﻿namespace Slam
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
            this.LblTorneo = new System.Windows.Forms.Label();
            this.CboListaTorneo = new System.Windows.Forms.ComboBox();
            this.GrpEquipo1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.GrpEquipo1.SuspendLayout();
            this.GrpEquipo2.SuspendLayout();
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
            // 
            // GrpEquipo1
            // 
            this.GrpEquipo1.Controls.Add(this.comboBox1);
            this.GrpEquipo1.Location = new System.Drawing.Point(12, 43);
            this.GrpEquipo1.Name = "GrpEquipo1";
            this.GrpEquipo1.Size = new System.Drawing.Size(252, 61);
            this.GrpEquipo1.TabIndex = 2;
            this.GrpEquipo1.TabStop = false;
            this.GrpEquipo1.Text = "Seleccione El Equipo 1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 21);
            this.comboBox1.TabIndex = 0;
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
            this.LblResultado.Location = new System.Drawing.Point(313, 117);
            this.LblResultado.Name = "LblResultado";
            this.LblResultado.Size = new System.Drawing.Size(55, 13);
            this.LblResultado.TabIndex = 6;
            this.LblResultado.Text = "Resultado";
            // 
            // TxtResultado
            // 
            this.TxtResultado.Location = new System.Drawing.Point(374, 110);
            this.TxtResultado.Mask = "0-0/0-0/0-0";
            this.TxtResultado.Name = "TxtResultado";
            this.TxtResultado.Size = new System.Drawing.Size(100, 20);
            this.TxtResultado.TabIndex = 7;
            this.TxtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtResultado.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(421, 144);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 8;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(504, 144);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 9;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
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
            // FrmNuevoPartido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 179);
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
            this.GrpEquipo1.ResumeLayout(false);
            this.GrpEquipo2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTorneo;
        private System.Windows.Forms.ComboBox CboListaTorneo;
        private System.Windows.Forms.GroupBox GrpEquipo1;
        private System.Windows.Forms.ComboBox comboBox1;
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
    }
}