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
            this.label1 = new System.Windows.Forms.Label();
            this.CboListaTorneo = new System.Windows.Forms.ComboBox();
            this.GrpEquipo1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GrpEquipo2 = new System.Windows.Forms.GroupBox();
            this.CboEquipo2 = new System.Windows.Forms.ComboBox();
            this.DtpFechaPartido = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtResultado = new System.Windows.Forms.MaskedTextBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrpEquipo1.SuspendLayout();
            this.GrpEquipo2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Un Torneo De La Lista";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "VS";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Del Partido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resultado";
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
            // FrmNuevoPartido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 179);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtResultado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpFechaPartido);
            this.Controls.Add(this.GrpEquipo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GrpEquipo1);
            this.Controls.Add(this.CboListaTorneo);
            this.Controls.Add(this.label1);
            this.Name = "FrmNuevoPartido";
            this.Text = "FrmNuevoPartido";
            this.GrpEquipo1.ResumeLayout(false);
            this.GrpEquipo2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboListaTorneo;
        private System.Windows.Forms.GroupBox GrpEquipo1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GrpEquipo2;
        private System.Windows.Forms.ComboBox CboEquipo2;
        private System.Windows.Forms.DateTimePicker DtpFechaPartido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TxtResultado;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnSalir;
    }
}