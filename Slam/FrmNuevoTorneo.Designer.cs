namespace Slam
{
    partial class FrmNuevoTorneo
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.DTPInicioTorneo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPFinTorneo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DTPInicioInscripciones = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DTPFinInscripciones = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBMixto = new System.Windows.Forms.RadioButton();
            this.RBFemenino = new System.Windows.Forms.RadioButton();
            this.RBMasculino = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBDouble = new System.Windows.Forms.RadioButton();
            this.RBSingle = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.CboClub = new System.Windows.Forms.ComboBox();
            this.CboCategoria = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CboSuperficie = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ChkInscripcion = new System.Windows.Forms.CheckBox();
            this.EPTorneos = new System.Windows.Forms.ErrorProvider(this.components);
            this.LblEstado = new System.Windows.Forms.Label();
            this.CboCupo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPTorneos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Del Torneo";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(164, 5);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(187, 20);
            this.TxtNombre.TabIndex = 1;
            this.TxtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.TxtNombre_Validating);
            // 
            // DTPInicioTorneo
            // 
            this.DTPInicioTorneo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPInicioTorneo.Location = new System.Drawing.Point(164, 134);
            this.DTPInicioTorneo.Name = "DTPInicioTorneo";
            this.DTPInicioTorneo.Size = new System.Drawing.Size(83, 20);
            this.DTPInicioTorneo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inicio Del Torneo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fin Del Torneo";
            // 
            // DTPFinTorneo
            // 
            this.DTPFinTorneo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFinTorneo.Location = new System.Drawing.Point(365, 133);
            this.DTPFinTorneo.Name = "DTPFinTorneo";
            this.DTPFinTorneo.Size = new System.Drawing.Size(83, 20);
            this.DTPFinTorneo.TabIndex = 5;
            this.DTPFinTorneo.Validating += new System.ComponentModel.CancelEventHandler(this.DTPFinTorneo_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Inicio De Inscripciones";
            // 
            // DTPInicioInscripciones
            // 
            this.DTPInicioInscripciones.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPInicioInscripciones.Location = new System.Drawing.Point(164, 99);
            this.DTPInicioInscripciones.Name = "DTPInicioInscripciones";
            this.DTPInicioInscripciones.Size = new System.Drawing.Size(83, 20);
            this.DTPInicioInscripciones.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fin De Inscripciones";
            // 
            // DTPFinInscripciones
            // 
            this.DTPFinInscripciones.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFinInscripciones.Location = new System.Drawing.Point(365, 99);
            this.DTPFinInscripciones.Name = "DTPFinInscripciones";
            this.DTPFinInscripciones.Size = new System.Drawing.Size(83, 20);
            this.DTPFinInscripciones.TabIndex = 9;
            this.DTPFinInscripciones.Validating += new System.ComponentModel.CancelEventHandler(this.DTPFinInscripciones_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBMixto);
            this.groupBox1.Controls.Add(this.RBFemenino);
            this.groupBox1.Controls.Add(this.RBMasculino);
            this.groupBox1.Location = new System.Drawing.Point(15, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 48);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sexo";
            this.groupBox1.Validating += new System.ComponentModel.CancelEventHandler(this.groupBox1_Validating);
            // 
            // RBMixto
            // 
            this.RBMixto.AutoSize = true;
            this.RBMixto.Location = new System.Drawing.Point(202, 16);
            this.RBMixto.Name = "RBMixto";
            this.RBMixto.Size = new System.Drawing.Size(50, 17);
            this.RBMixto.TabIndex = 2;
            this.RBMixto.TabStop = true;
            this.RBMixto.Text = "Mixto";
            this.RBMixto.UseVisualStyleBackColor = true;
            // 
            // RBFemenino
            // 
            this.RBFemenino.AutoSize = true;
            this.RBFemenino.Location = new System.Drawing.Point(110, 16);
            this.RBFemenino.Name = "RBFemenino";
            this.RBFemenino.Size = new System.Drawing.Size(71, 17);
            this.RBFemenino.TabIndex = 1;
            this.RBFemenino.TabStop = true;
            this.RBFemenino.Text = "Femenino";
            this.RBFemenino.UseVisualStyleBackColor = true;
            // 
            // RBMasculino
            // 
            this.RBMasculino.AutoSize = true;
            this.RBMasculino.Location = new System.Drawing.Point(12, 16);
            this.RBMasculino.Name = "RBMasculino";
            this.RBMasculino.Size = new System.Drawing.Size(73, 17);
            this.RBMasculino.TabIndex = 0;
            this.RBMasculino.TabStop = true;
            this.RBMasculino.Text = "Masculino";
            this.RBMasculino.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBDouble);
            this.groupBox2.Controls.Add(this.RBSingle);
            this.groupBox2.Location = new System.Drawing.Point(308, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 48);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo De Torneo";
            this.groupBox2.Validating += new System.ComponentModel.CancelEventHandler(this.groupBox2_Validating);
            // 
            // RBDouble
            // 
            this.RBDouble.AutoSize = true;
            this.RBDouble.Location = new System.Drawing.Point(74, 16);
            this.RBDouble.Name = "RBDouble";
            this.RBDouble.Size = new System.Drawing.Size(59, 17);
            this.RBDouble.TabIndex = 1;
            this.RBDouble.TabStop = true;
            this.RBDouble.Text = "Double";
            this.RBDouble.UseVisualStyleBackColor = true;
            // 
            // RBSingle
            // 
            this.RBSingle.AutoSize = true;
            this.RBSingle.Location = new System.Drawing.Point(14, 16);
            this.RBSingle.Name = "RBSingle";
            this.RBSingle.Size = new System.Drawing.Size(54, 17);
            this.RBSingle.TabIndex = 0;
            this.RBSingle.TabStop = true;
            this.RBSingle.Text = "Single";
            this.RBSingle.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Club Organizador";
            // 
            // CboClub
            // 
            this.CboClub.FormattingEnabled = true;
            this.CboClub.Location = new System.Drawing.Point(164, 31);
            this.CboClub.Name = "CboClub";
            this.CboClub.Size = new System.Drawing.Size(187, 21);
            this.CboClub.TabIndex = 13;
            this.CboClub.Validating += new System.ComponentModel.CancelEventHandler(this.CboClub_Validating);
            // 
            // CboCategoria
            // 
            this.CboCategoria.FormattingEnabled = true;
            this.CboCategoria.Location = new System.Drawing.Point(164, 58);
            this.CboCategoria.Name = "CboCategoria";
            this.CboCategoria.Size = new System.Drawing.Size(187, 21);
            this.CboCategoria.TabIndex = 14;
            this.CboCategoria.Validating += new System.ComponentModel.CancelEventHandler(this.CboCategoria_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Categoria";
            // 
            // CboSuperficie
            // 
            this.CboSuperficie.FormattingEnabled = true;
            this.CboSuperficie.Location = new System.Drawing.Point(307, 230);
            this.CboSuperficie.Name = "CboSuperficie";
            this.CboSuperficie.Size = new System.Drawing.Size(134, 21);
            this.CboSuperficie.TabIndex = 16;
            this.CboSuperficie.Validating += new System.ComponentModel.CancelEventHandler(this.CboSuperficie_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Superficie";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Estado";
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(281, 284);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 20;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(371, 284);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 21;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Cupo";
            // 
            // ChkInscripcion
            // 
            this.ChkInscripcion.AutoSize = true;
            this.ChkInscripcion.Location = new System.Drawing.Point(116, 235);
            this.ChkInscripcion.Name = "ChkInscripcion";
            this.ChkInscripcion.Size = new System.Drawing.Size(96, 17);
            this.ChkInscripcion.TabIndex = 25;
            this.ChkInscripcion.Text = "Torneo Abierto";
            this.ChkInscripcion.UseVisualStyleBackColor = true;
            // 
            // EPTorneos
            // 
            this.EPTorneos.ContainerControl = this;
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Location = new System.Drawing.Point(64, 271);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(0, 13);
            this.LblEstado.TabIndex = 26;
            // 
            // CboCupo
            // 
            this.CboCupo.FormattingEnabled = true;
            this.CboCupo.Items.AddRange(new object[] {
            "8",
            "16",
            "32"});
            this.CboCupo.Location = new System.Drawing.Point(50, 233);
            this.CboCupo.Name = "CboCupo";
            this.CboCupo.Size = new System.Drawing.Size(45, 21);
            this.CboCupo.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Puntos Del Torneo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmNuevoTorneo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CboCupo);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.ChkInscripcion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CboSuperficie);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CboCategoria);
            this.Controls.Add(this.CboClub);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DTPFinInscripciones);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DTPInicioInscripciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DTPFinTorneo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DTPInicioTorneo);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmNuevoTorneo";
            this.Text = "FrmNuevoTorneo";
            this.Load += new System.EventHandler(this.FrmNuevoTorneo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPTorneos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.DateTimePicker DTPInicioTorneo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPFinTorneo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTPInicioInscripciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DTPFinInscripciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBMixto;
        private System.Windows.Forms.RadioButton RBFemenino;
        private System.Windows.Forms.RadioButton RBMasculino;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBDouble;
        private System.Windows.Forms.RadioButton RBSingle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CboClub;
        private System.Windows.Forms.ComboBox CboCategoria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CboSuperficie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ChkInscripcion;
        private System.Windows.Forms.ErrorProvider EPTorneos;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.ComboBox CboCupo;
        private System.Windows.Forms.Button button1;
    }
}