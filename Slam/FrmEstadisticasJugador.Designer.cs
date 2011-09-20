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
            ((System.ComponentModel.ISupportInitialize)(this.EpEstadisticas)).BeginInit();
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
            this.TxtPG.Location = new System.Drawing.Point(122, 39);
            this.TxtPG.Name = "TxtPG";
            this.TxtPG.Size = new System.Drawing.Size(41, 20);
            this.TxtPG.TabIndex = 1;
            this.TxtPG.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPG_Validating);
            // 
            // TxtTJ
            // 
            this.TxtTJ.Location = new System.Drawing.Point(122, 65);
            this.TxtTJ.Name = "TxtTJ";
            this.TxtTJ.Size = new System.Drawing.Size(41, 20);
            this.TxtTJ.TabIndex = 3;
            this.TxtTJ.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTJ_Validating);
            // 
            // TxtPuntos
            // 
            this.TxtPuntos.Location = new System.Drawing.Point(122, 91);
            this.TxtPuntos.Name = "TxtPuntos";
            this.TxtPuntos.Size = new System.Drawing.Size(41, 20);
            this.TxtPuntos.TabIndex = 5;
            this.TxtPuntos.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPuntos_Validating);
            // 
            // TxtTC
            // 
            this.TxtTC.Location = new System.Drawing.Point(317, 65);
            this.TxtTC.Name = "TxtTC";
            this.TxtTC.Size = new System.Drawing.Size(41, 20);
            this.TxtTC.TabIndex = 4;
            this.TxtTC.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTC_Validating);
            // 
            // TxtPP
            // 
            this.TxtPP.Location = new System.Drawing.Point(317, 39);
            this.TxtPP.Name = "TxtPP";
            this.TxtPP.Size = new System.Drawing.Size(41, 20);
            this.TxtPP.TabIndex = 2;
            this.TxtPP.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPP_Validating);
            // 
            // ChkEstado
            // 
            this.ChkEstado.AutoSize = true;
            this.ChkEstado.Location = new System.Drawing.Point(122, 117);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(59, 17);
            this.ChkEstado.TabIndex = 6;
            this.ChkEstado.Text = "Estado";
            this.ChkEstado.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(122, 153);
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
            this.BtnCancelar.Location = new System.Drawing.Point(204, 152);
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
            this.LblPG.Location = new System.Drawing.Point(25, 42);
            this.LblPG.Name = "LblPG";
            this.LblPG.Size = new System.Drawing.Size(91, 13);
            this.LblPG.TabIndex = 5;
            this.LblPG.Text = "Partidos Ganados";
            // 
            // LblTJ
            // 
            this.LblTJ.AutoSize = true;
            this.LblTJ.Location = new System.Drawing.Point(27, 68);
            this.LblTJ.Name = "LblTJ";
            this.LblTJ.Size = new System.Drawing.Size(89, 13);
            this.LblTJ.TabIndex = 5;
            this.LblTJ.Text = "Torneos Jugados";
            // 
            // LblPuntos
            // 
            this.LblPuntos.AutoSize = true;
            this.LblPuntos.Location = new System.Drawing.Point(76, 94);
            this.LblPuntos.Name = "LblPuntos";
            this.LblPuntos.Size = new System.Drawing.Size(40, 13);
            this.LblPuntos.TabIndex = 5;
            this.LblPuntos.Text = "Puntos";
            // 
            // LblPP
            // 
            this.LblPP.AutoSize = true;
            this.LblPP.Location = new System.Drawing.Point(201, 42);
            this.LblPP.Name = "LblPP";
            this.LblPP.Size = new System.Drawing.Size(89, 13);
            this.LblPP.TabIndex = 5;
            this.LblPP.Text = "Partidos Perdidos";
            // 
            // LblTC
            // 
            this.LblTC.AutoSize = true;
            this.LblTC.Location = new System.Drawing.Point(201, 68);
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
            this.LblJugador.Location = new System.Drawing.Point(201, 118);
            this.LblJugador.Name = "LblJugador";
            this.LblJugador.Size = new System.Drawing.Size(0, 13);
            this.LblJugador.TabIndex = 9;
            // 
            // LblPJ
            // 
            this.LblPJ.AutoSize = true;
            this.LblPJ.Location = new System.Drawing.Point(204, 91);
            this.LblPJ.Name = "LblPJ";
            this.LblPJ.Size = new System.Drawing.Size(88, 13);
            this.LblPJ.TabIndex = 10;
            this.LblPJ.Text = "Partidos Jugados";
            // 
            // TxtPJ
            // 
            this.TxtPJ.Location = new System.Drawing.Point(317, 91);
            this.TxtPJ.Name = "TxtPJ";
            this.TxtPJ.ReadOnly = true;
            this.TxtPJ.Size = new System.Drawing.Size(41, 20);
            this.TxtPJ.TabIndex = 4;
            this.TxtPJ.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTC_Validating);
            // 
            // FrmEstadisticasJugador
            // 
            this.AcceptButton = this.BtnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(393, 191);
            this.Controls.Add(this.LblPJ);
            this.Controls.Add(this.LblJugador);
            this.Controls.Add(this.LblPuntos);
            this.Controls.Add(this.LblTC);
            this.Controls.Add(this.LblPP);
            this.Controls.Add(this.LblTJ);
            this.Controls.Add(this.LblPG);
            this.Controls.Add(this.LblCategorias);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.ChkEstado);
            this.Controls.Add(this.TxtPP);
            this.Controls.Add(this.TxtPJ);
            this.Controls.Add(this.TxtTC);
            this.Controls.Add(this.TxtPuntos);
            this.Controls.Add(this.TxtTJ);
            this.Controls.Add(this.TxtPG);
            this.Controls.Add(this.CboCategorias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEstadisticasJugador";
            this.Text = "Estadisticas de Jugador";
            this.Load += new System.EventHandler(this.FrmEstadisticasJugador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpEstadisticas)).EndInit();
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
    }
}