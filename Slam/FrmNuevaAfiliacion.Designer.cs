namespace Slam
{
    partial class FrmNuevaAfiliacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaAfiliacion));
            this.CboListaClubes = new System.Windows.Forms.ComboBox();
            this.LblNombreClub = new System.Windows.Forms.Label();
            this.TxtDni = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkEstado = new System.Windows.Forms.CheckBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnComprobar = new System.Windows.Forms.Button();
            this.LblExiste = new System.Windows.Forms.Label();
            this.BtnNuevoJugador = new System.Windows.Forms.Button();
            this.EpAfiliacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EpAfiliacion)).BeginInit();
            this.SuspendLayout();
            // 
            // CboListaClubes
            // 
            this.CboListaClubes.FormattingEnabled = true;
            this.CboListaClubes.Location = new System.Drawing.Point(183, 12);
            this.CboListaClubes.Name = "CboListaClubes";
            this.CboListaClubes.Size = new System.Drawing.Size(198, 21);
            this.CboListaClubes.TabIndex = 0;
            this.CboListaClubes.Validating += new System.ComponentModel.CancelEventHandler(this.CboListaClubes_Validating);
            this.CboListaClubes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboListaClubes_KeyPress);
            // 
            // LblNombreClub
            // 
            this.LblNombreClub.AutoSize = true;
            this.LblNombreClub.Location = new System.Drawing.Point(12, 20);
            this.LblNombreClub.Name = "LblNombreClub";
            this.LblNombreClub.Size = new System.Drawing.Size(165, 13);
            this.LblNombreClub.TabIndex = 1;
            this.LblNombreClub.Text = "Seleccione Un Club De La Lista *";
            // 
            // TxtDni
            // 
            this.TxtDni.Location = new System.Drawing.Point(177, 23);
            this.TxtDni.Mask = "00.000.000";
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(140, 20);
            this.TxtDni.TabIndex = 2;
            this.TxtDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtDni.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TxtDni.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDni_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Esciba El Dni Del Jugador *";
            // 
            // ChkEstado
            // 
            this.ChkEstado.AutoSize = true;
            this.ChkEstado.Location = new System.Drawing.Point(15, 179);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(101, 17);
            this.ChkEstado.TabIndex = 4;
            this.ChkEstado.Text = "Afiliacion Activa";
            this.ChkEstado.UseVisualStyleBackColor = true;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(306, 173);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 5;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnComprobar);
            this.groupBox1.Controls.Add(this.LblExiste);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtDni);
            this.groupBox1.Location = new System.Drawing.Point(15, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Si el jugador esta cargado en la base de datos  escriba el DNI";
            // 
            // BtnComprobar
            // 
            this.BtnComprobar.Location = new System.Drawing.Point(242, 50);
            this.BtnComprobar.Name = "BtnComprobar";
            this.BtnComprobar.Size = new System.Drawing.Size(75, 23);
            this.BtnComprobar.TabIndex = 9;
            this.BtnComprobar.Text = "Comprobar";
            this.BtnComprobar.UseVisualStyleBackColor = true;
            this.BtnComprobar.Click += new System.EventHandler(this.BtnComprobar_Click);
            // 
            // LblExiste
            // 
            this.LblExiste.AutoSize = true;
            this.LblExiste.Location = new System.Drawing.Point(6, 60);
            this.LblExiste.Name = "LblExiste";
            this.LblExiste.Size = new System.Drawing.Size(0, 13);
            this.LblExiste.TabIndex = 8;
            // 
            // BtnNuevoJugador
            // 
            this.BtnNuevoJugador.Location = new System.Drawing.Point(15, 150);
            this.BtnNuevoJugador.Name = "BtnNuevoJugador";
            this.BtnNuevoJugador.Size = new System.Drawing.Size(101, 23);
            this.BtnNuevoJugador.TabIndex = 7;
            this.BtnNuevoJugador.Text = "Nuevo Jugador";
            this.BtnNuevoJugador.UseVisualStyleBackColor = true;
            this.BtnNuevoJugador.Click += new System.EventHandler(this.BtnNuevoJugador_Click);
            // 
            // EpAfiliacion
            // 
            this.EpAfiliacion.ContainerControl = this;
            // 
            // FrmNuevaAfiliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 208);
            this.Controls.Add(this.BtnNuevoJugador);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.ChkEstado);
            this.Controls.Add(this.LblNombreClub);
            this.Controls.Add(this.CboListaClubes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNuevaAfiliacion";
            this.Text = "Nueva Afiliación";
            this.Load += new System.EventHandler(this.FrmNuevaAfiliacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EpAfiliacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboListaClubes;
        private System.Windows.Forms.Label LblNombreClub;
        private System.Windows.Forms.MaskedTextBox TxtDni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkEstado;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnNuevoJugador;
        private System.Windows.Forms.Button BtnComprobar;
        private System.Windows.Forms.Label LblExiste;
        private System.Windows.Forms.ErrorProvider EpAfiliacion;
    }
}