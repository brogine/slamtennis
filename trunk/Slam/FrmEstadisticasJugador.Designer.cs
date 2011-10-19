namespace Slam
{
    partial class FrmEstadisticasJugador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstadisticasJugador));
            this.CboCategorias = new System.Windows.Forms.ComboBox();
            this.TxtPG = new System.Windows.Forms.TextBox();
            this.TxtTJ = new System.Windows.Forms.TextBox();
            this.TxtPuntos = new System.Windows.Forms.TextBox();
            this.TxtTC = new System.Windows.Forms.TextBox();
            this.TxtPP = new System.Windows.Forms.TextBox();
            this.ChkEstado = new System.Windows.Forms.CheckBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblCategorias = new System.Windows.Forms.Label();
            this.LblPG = new System.Windows.Forms.Label();
            this.LblTJ = new System.Windows.Forms.Label();
            this.LblPuntos = new System.Windows.Forms.Label();
            this.LblPP = new System.Windows.Forms.Label();
            this.LblTC = new System.Windows.Forms.Label();
            this.EpEstadisticas = new System.Windows.Forms.ErrorProvider(this.components);
            this.LblJugador = new System.Windows.Forms.Label();
            this.LblPJ = new System.Windows.Forms.Label();
            this.TxtPJ = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtPartPerDob = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTornCompDob = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtPartJugDob = new System.Windows.Forms.TextBox();
            this.TxtPartGanDob = new System.Windows.Forms.TextBox();
            this.TxtTorJugDob = new System.Windows.Forms.TextBox();
            this.TxtPuntosDob = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EpEstadisticas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CboCategorias
            // 
            this.CboCategorias.FormattingEnabled = true;
            this.CboCategorias.Location = new System.Drawing.Point(122, 12);
            this.CboCategorias.Name = "CboCategorias";
            this.CboCategorias.Size = new System.Drawing.Size(204, 21);
            this.CboCategorias.TabIndex = 0;
            this.CboCategorias.Validating += new System.ComponentModel.CancelEventHandler(this.CboCategorias_Validating);
            this.CboCategorias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboCategorias_KeyPress);
            // 
            // TxtPG
            // 
            this.TxtPG.Location = new System.Drawing.Point(103, 24);
            this.TxtPG.Name = "TxtPG";
            this.TxtPG.Size = new System.Drawing.Size(41, 20);
            this.TxtPG.TabIndex = 1;
            this.TxtPG.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPG_Validating);
            // 
            // TxtTJ
            // 
            this.TxtTJ.Location = new System.Drawing.Point(103, 50);
            this.TxtTJ.Name = "TxtTJ";
            this.TxtTJ.Size = new System.Drawing.Size(41, 20);
            this.TxtTJ.TabIndex = 3;
            this.TxtTJ.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTJ_Validating);
            // 
            // TxtPuntos
            // 
            this.TxtPuntos.Location = new System.Drawing.Point(103, 76);
            this.TxtPuntos.Name = "TxtPuntos";
            this.TxtPuntos.Size = new System.Drawing.Size(41, 20);
            this.TxtPuntos.TabIndex = 5;
            this.TxtPuntos.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPuntos_Validating);
            // 
            // TxtTC
            // 
            this.TxtTC.Location = new System.Drawing.Point(267, 49);
            this.TxtTC.Name = "TxtTC";
            this.TxtTC.Size = new System.Drawing.Size(41, 20);
            this.TxtTC.TabIndex = 4;
            this.TxtTC.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTC_Validating);
            // 
            // TxtPP
            // 
            this.TxtPP.Location = new System.Drawing.Point(267, 20);
            this.TxtPP.Name = "TxtPP";
            this.TxtPP.Size = new System.Drawing.Size(41, 20);
            this.TxtPP.TabIndex = 2;
            this.TxtPP.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPP_Validating);
            // 
            // ChkEstado
            // 
            this.ChkEstado.AutoSize = true;
            this.ChkEstado.Location = new System.Drawing.Point(23, 183);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(59, 17);
            this.ChkEstado.TabIndex = 6;
            this.ChkEstado.Text = "Estado";
            this.ChkEstado.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(493, 178);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(575, 177);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 8;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblCategorias
            // 
            this.LblCategorias.AutoSize = true;
            this.LblCategorias.Location = new System.Drawing.Point(62, 15);
            this.LblCategorias.Name = "LblCategorias";
            this.LblCategorias.Size = new System.Drawing.Size(54, 13);
            this.LblCategorias.TabIndex = 5;
            this.LblCategorias.Text = "Categoría";
            // 
            // LblPG
            // 
            this.LblPG.AutoSize = true;
            this.LblPG.Location = new System.Drawing.Point(6, 27);
            this.LblPG.Name = "LblPG";
            this.LblPG.Size = new System.Drawing.Size(91, 13);
            this.LblPG.TabIndex = 5;
            this.LblPG.Text = "Partidos Ganados";
            // 
            // LblTJ
            // 
            this.LblTJ.AutoSize = true;
            this.LblTJ.Location = new System.Drawing.Point(8, 53);
            this.LblTJ.Name = "LblTJ";
            this.LblTJ.Size = new System.Drawing.Size(89, 13);
            this.LblTJ.TabIndex = 5;
            this.LblTJ.Text = "Torneos Jugados";
            // 
            // LblPuntos
            // 
            this.LblPuntos.AutoSize = true;
            this.LblPuntos.Location = new System.Drawing.Point(57, 79);
            this.LblPuntos.Name = "LblPuntos";
            this.LblPuntos.Size = new System.Drawing.Size(40, 13);
            this.LblPuntos.TabIndex = 5;
            this.LblPuntos.Text = "Puntos";
            // 
            // LblPP
            // 
            this.LblPP.AutoSize = true;
            this.LblPP.Location = new System.Drawing.Point(172, 27);
            this.LblPP.Name = "LblPP";
            this.LblPP.Size = new System.Drawing.Size(89, 13);
            this.LblPP.TabIndex = 5;
            this.LblPP.Text = "Partidos Perdidos";
            // 
            // LblTC
            // 
            this.LblTC.AutoSize = true;
            this.LblTC.Location = new System.Drawing.Point(151, 56);
            this.LblTC.Name = "LblTC";
            this.LblTC.Size = new System.Drawing.Size(110, 13);
            this.LblTC.TabIndex = 5;
            this.LblTC.Text = "Torneos Completados";
            // 
            // EpEstadisticas
            // 
            this.EpEstadisticas.ContainerControl = this;
            // 
            // LblJugador
            // 
            this.LblJugador.AutoSize = true;
            this.LblJugador.Location = new System.Drawing.Point(14, 154);
            this.LblJugador.Name = "LblJugador";
            this.LblJugador.Size = new System.Drawing.Size(0, 13);
            this.LblJugador.TabIndex = 9;
            // 
            // LblPJ
            // 
            this.LblPJ.AutoSize = true;
            this.LblPJ.Location = new System.Drawing.Point(173, 79);
            this.LblPJ.Name = "LblPJ";
            this.LblPJ.Size = new System.Drawing.Size(88, 13);
            this.LblPJ.TabIndex = 10;
            this.LblPJ.Text = "Partidos Jugados";
            // 
            // TxtPJ
            // 
            this.TxtPJ.Location = new System.Drawing.Point(267, 75);
            this.TxtPJ.Name = "TxtPJ";
            this.TxtPJ.ReadOnly = true;
            this.TxtPJ.Size = new System.Drawing.Size(41, 20);
            this.TxtPJ.TabIndex = 4;
            this.TxtPJ.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTC_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPP);
            this.groupBox1.Controls.Add(this.LblPJ);
            this.groupBox1.Controls.Add(this.LblPuntos);
            this.groupBox1.Controls.Add(this.LblPP);
            this.groupBox1.Controls.Add(this.LblTJ);
            this.groupBox1.Controls.Add(this.TxtTC);
            this.groupBox1.Controls.Add(this.LblPG);
            this.groupBox1.Controls.Add(this.LblTC);
            this.groupBox1.Controls.Add(this.TxtPJ);
            this.groupBox1.Controls.Add(this.TxtPG);
            this.groupBox1.Controls.Add(this.TxtTJ);
            this.groupBox1.Controls.Add(this.TxtPuntos);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 108);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtPartPerDob);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtTornCompDob);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtPartJugDob);
            this.groupBox2.Controls.Add(this.TxtPartGanDob);
            this.groupBox2.Controls.Add(this.TxtTorJugDob);
            this.groupBox2.Controls.Add(this.TxtPuntosDob);
            this.groupBox2.Location = new System.Drawing.Point(342, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 108);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doble";
            // 
            // TxtPartPerDob
            // 
            this.TxtPartPerDob.Location = new System.Drawing.Point(267, 20);
            this.TxtPartPerDob.Name = "TxtPartPerDob";
            this.TxtPartPerDob.Size = new System.Drawing.Size(41, 20);
            this.TxtPartPerDob.TabIndex = 2;
            this.TxtPartPerDob.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPP_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Partidos Jugados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Puntos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Partidos Perdidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Torneos Jugados";
            // 
            // TxtTornCompDob
            // 
            this.TxtTornCompDob.Location = new System.Drawing.Point(267, 49);
            this.TxtTornCompDob.Name = "TxtTornCompDob";
            this.TxtTornCompDob.Size = new System.Drawing.Size(41, 20);
            this.TxtTornCompDob.TabIndex = 4;
            this.TxtTornCompDob.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTC_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Partidos Ganados";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Torneos Completados";
            // 
            // TxtPartJugDob
            // 
            this.TxtPartJugDob.Location = new System.Drawing.Point(267, 75);
            this.TxtPartJugDob.Name = "TxtPartJugDob";
            this.TxtPartJugDob.ReadOnly = true;
            this.TxtPartJugDob.Size = new System.Drawing.Size(41, 20);
            this.TxtPartJugDob.TabIndex = 4;
            this.TxtPartJugDob.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTC_Validating);
            // 
            // TxtPartGanDob
            // 
            this.TxtPartGanDob.Location = new System.Drawing.Point(103, 24);
            this.TxtPartGanDob.Name = "TxtPartGanDob";
            this.TxtPartGanDob.Size = new System.Drawing.Size(41, 20);
            this.TxtPartGanDob.TabIndex = 1;
            this.TxtPartGanDob.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPG_Validating);
            // 
            // TxtTorJugDob
            // 
            this.TxtTorJugDob.Location = new System.Drawing.Point(103, 50);
            this.TxtTorJugDob.Name = "TxtTorJugDob";
            this.TxtTorJugDob.Size = new System.Drawing.Size(41, 20);
            this.TxtTorJugDob.TabIndex = 3;
            this.TxtTorJugDob.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTJ_Validating);
            // 
            // TxtPuntosDob
            // 
            this.TxtPuntosDob.Location = new System.Drawing.Point(103, 76);
            this.TxtPuntosDob.Name = "TxtPuntosDob";
            this.TxtPuntosDob.Size = new System.Drawing.Size(41, 20);
            this.TxtPuntosDob.TabIndex = 5;
            this.TxtPuntosDob.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPuntos_Validating);
            // 
            // FrmEstadisticasJugador
            // 
            this.AcceptButton = this.BtnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(673, 209);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblJugador);
            this.Controls.Add(this.LblCategorias);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.ChkEstado);
            this.Controls.Add(this.CboCategorias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEstadisticasJugador";
            this.Text = "Estadisticas de Jugador";
            this.Load += new System.EventHandler(this.FrmEstadisticasJugador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpEstadisticas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboCategorias;
        private System.Windows.Forms.TextBox TxtPG;
        private System.Windows.Forms.TextBox TxtTJ;
        private System.Windows.Forms.TextBox TxtPuntos;
        private System.Windows.Forms.TextBox TxtTC;
        private System.Windows.Forms.TextBox TxtPP;
        private System.Windows.Forms.CheckBox ChkEstado;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblCategorias;
        private System.Windows.Forms.Label LblPG;
        private System.Windows.Forms.Label LblTJ;
        private System.Windows.Forms.Label LblPuntos;
        private System.Windows.Forms.Label LblPP;
        private System.Windows.Forms.Label LblTC;
        private System.Windows.Forms.ErrorProvider EpEstadisticas;
        private System.Windows.Forms.Label LblJugador;
        private System.Windows.Forms.Label LblPJ;
        private System.Windows.Forms.TextBox TxtPJ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtPartPerDob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTornCompDob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPartJugDob;
        private System.Windows.Forms.TextBox TxtPartGanDob;
        private System.Windows.Forms.TextBox TxtTorJugDob;
        private System.Windows.Forms.TextBox TxtPuntosDob;
    }
}