namespace Slam
{
    partial class FrmNuevaUbicacion
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
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.GbLocalidades = new System.Windows.Forms.GroupBox();
            this.CboListaLocalidades = new System.Windows.Forms.ComboBox();
            this.BtnAgregarLocalidad = new System.Windows.Forms.Button();
            this.GbProvincias = new System.Windows.Forms.GroupBox();
            this.BtnAgregarProvincia = new System.Windows.Forms.Button();
            this.CboListaProvincias = new System.Windows.Forms.ComboBox();
            this.GbPaises = new System.Windows.Forms.GroupBox();
            this.BtnAgregarPais = new System.Windows.Forms.Button();
            this.CboListaPaises = new System.Windows.Forms.ComboBox();
            this.EpVerificador = new System.Windows.Forms.ErrorProvider(this.components);
            this.GbLocalidades.SuspendLayout();
            this.GbProvincias.SuspendLayout();
            this.GbPaises.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EpVerificador)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(252, 195);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(75, 23);
            this.BtnCerrar.TabIndex = 5;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // GbLocalidades
            // 
            this.GbLocalidades.Controls.Add(this.CboListaLocalidades);
            this.GbLocalidades.Controls.Add(this.BtnAgregarLocalidad);
            this.GbLocalidades.Location = new System.Drawing.Point(12, 135);
            this.GbLocalidades.Name = "GbLocalidades";
            this.GbLocalidades.Size = new System.Drawing.Size(315, 54);
            this.GbLocalidades.TabIndex = 6;
            this.GbLocalidades.TabStop = false;
            this.GbLocalidades.Text = "Lista De Localidades";
            // 
            // CboListaLocalidades
            // 
            this.CboListaLocalidades.FormattingEnabled = true;
            this.CboListaLocalidades.Location = new System.Drawing.Point(6, 21);
            this.CboListaLocalidades.Name = "CboListaLocalidades";
            this.CboListaLocalidades.Size = new System.Drawing.Size(175, 21);
            this.CboListaLocalidades.TabIndex = 1;
            // 
            // BtnAgregarLocalidad
            // 
            this.BtnAgregarLocalidad.Location = new System.Drawing.Point(187, 19);
            this.BtnAgregarLocalidad.Name = "BtnAgregarLocalidad";
            this.BtnAgregarLocalidad.Size = new System.Drawing.Size(122, 23);
            this.BtnAgregarLocalidad.TabIndex = 0;
            this.BtnAgregarLocalidad.Text = "Agregar Localidad";
            this.BtnAgregarLocalidad.UseVisualStyleBackColor = true;
            this.BtnAgregarLocalidad.Click += new System.EventHandler(this.BtnAgregarLocalidad_Click);
            // 
            // GbProvincias
            // 
            this.GbProvincias.Controls.Add(this.BtnAgregarProvincia);
            this.GbProvincias.Controls.Add(this.CboListaProvincias);
            this.GbProvincias.Location = new System.Drawing.Point(12, 78);
            this.GbProvincias.Name = "GbProvincias";
            this.GbProvincias.Size = new System.Drawing.Size(315, 51);
            this.GbProvincias.TabIndex = 4;
            this.GbProvincias.TabStop = false;
            this.GbProvincias.Text = "Lista De Provincias";
            // 
            // BtnAgregarProvincia
            // 
            this.BtnAgregarProvincia.Location = new System.Drawing.Point(187, 17);
            this.BtnAgregarProvincia.Name = "BtnAgregarProvincia";
            this.BtnAgregarProvincia.Size = new System.Drawing.Size(122, 23);
            this.BtnAgregarProvincia.TabIndex = 1;
            this.BtnAgregarProvincia.Text = "Agregar Provincia";
            this.BtnAgregarProvincia.UseVisualStyleBackColor = true;
            this.BtnAgregarProvincia.Click += new System.EventHandler(this.BtnAgregarProvincia_Click);
            // 
            // CboListaProvincias
            // 
            this.CboListaProvincias.FormattingEnabled = true;
            this.CboListaProvincias.Location = new System.Drawing.Point(6, 19);
            this.CboListaProvincias.Name = "CboListaProvincias";
            this.CboListaProvincias.Size = new System.Drawing.Size(175, 21);
            this.CboListaProvincias.TabIndex = 0;
            this.CboListaProvincias.SelectionChangeCommitted += new System.EventHandler(this.CboListaProvincias_SelectionChangeCommitted);
            // 
            // GbPaises
            // 
            this.GbPaises.Controls.Add(this.BtnAgregarPais);
            this.GbPaises.Controls.Add(this.CboListaPaises);
            this.GbPaises.Location = new System.Drawing.Point(12, 12);
            this.GbPaises.Name = "GbPaises";
            this.GbPaises.Size = new System.Drawing.Size(315, 50);
            this.GbPaises.TabIndex = 3;
            this.GbPaises.TabStop = false;
            this.GbPaises.Text = "Lista de Paises";
            // 
            // BtnAgregarPais
            // 
            this.BtnAgregarPais.Location = new System.Drawing.Point(187, 17);
            this.BtnAgregarPais.Name = "BtnAgregarPais";
            this.BtnAgregarPais.Size = new System.Drawing.Size(122, 23);
            this.BtnAgregarPais.TabIndex = 1;
            this.BtnAgregarPais.Text = "Agregar Pais";
            this.BtnAgregarPais.UseVisualStyleBackColor = true;
            this.BtnAgregarPais.Click += new System.EventHandler(this.BtnAgregarPais_Click);
            // 
            // CboListaPaises
            // 
            this.CboListaPaises.FormattingEnabled = true;
            this.CboListaPaises.Location = new System.Drawing.Point(6, 19);
            this.CboListaPaises.Name = "CboListaPaises";
            this.CboListaPaises.Size = new System.Drawing.Size(175, 21);
            this.CboListaPaises.TabIndex = 0;
            this.CboListaPaises.SelectionChangeCommitted += new System.EventHandler(this.CboListaPaises_SelectionChangeCommitted);
            // 
            // EpVerificador
            // 
            this.EpVerificador.ContainerControl = this;
            // 
            // FrmNuevaUbicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 229);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.GbLocalidades);
            this.Controls.Add(this.GbProvincias);
            this.Controls.Add(this.GbPaises);
            this.Name = "FrmNuevaUbicacion";
            this.Text = "FrmNuevaUbicacion";
            this.Load += new System.EventHandler(this.FrmNuevaUbicacion_Load);
            this.GbLocalidades.ResumeLayout(false);
            this.GbProvincias.ResumeLayout(false);
            this.GbPaises.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EpVerificador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.GroupBox GbLocalidades;
        private System.Windows.Forms.ComboBox CboListaLocalidades;
        private System.Windows.Forms.Button BtnAgregarLocalidad;
        private System.Windows.Forms.GroupBox GbProvincias;
        private System.Windows.Forms.Button BtnAgregarProvincia;
        private System.Windows.Forms.ComboBox CboListaProvincias;
        private System.Windows.Forms.GroupBox GbPaises;
        private System.Windows.Forms.Button BtnAgregarPais;
        private System.Windows.Forms.ComboBox CboListaPaises;
        private System.Windows.Forms.ErrorProvider EpVerificador;
    }
}