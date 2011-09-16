namespace Slam
{
    partial class FrmCanchas
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
            this.EpCanchas = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.CboSuperficie = new System.Windows.Forms.ComboBox();
            this.CboTipo = new System.Windows.Forms.ComboBox();
            this.ChkLuz = new System.Windows.Forms.CheckBox();
            this.LblSuperficie = new System.Windows.Forms.Label();
            this.LblTipo = new System.Windows.Forms.Label();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.CboSede = new System.Windows.Forms.ComboBox();
            this.LblSede = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EpCanchas)).BeginInit();
            this.SuspendLayout();
            // 
            // EpCanchas
            // 
            this.EpCanchas.ContainerControl = this;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(92, 172);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 5;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(173, 172);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // CboSuperficie
            // 
            this.CboSuperficie.FormattingEnabled = true;
            this.CboSuperficie.Items.AddRange(new object[] {
            "Polvo de Ladrillo",
            "Cesped Verde",
            "Dura",
            "Sintetica"});
            this.CboSuperficie.Location = new System.Drawing.Point(173, 59);
            this.CboSuperficie.Name = "CboSuperficie";
            this.CboSuperficie.Size = new System.Drawing.Size(121, 21);
            this.CboSuperficie.TabIndex = 1;
            this.CboSuperficie.Validating += new System.ComponentModel.CancelEventHandler(this.CboSuperficie_Validating);
            this.CboSuperficie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboSuperficie_KeyPress);
            // 
            // CboTipo
            // 
            this.CboTipo.FormattingEnabled = true;
            this.CboTipo.Items.AddRange(new object[] {
            "Para Single",
            "Para Double"});
            this.CboTipo.Location = new System.Drawing.Point(173, 86);
            this.CboTipo.Name = "CboTipo";
            this.CboTipo.Size = new System.Drawing.Size(121, 21);
            this.CboTipo.TabIndex = 2;
            this.CboTipo.Validating += new System.ComponentModel.CancelEventHandler(this.CboTipo_Validating);
            this.CboTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboTipo_KeyPress);
            // 
            // ChkLuz
            // 
            this.ChkLuz.AutoSize = true;
            this.ChkLuz.Location = new System.Drawing.Point(173, 113);
            this.ChkLuz.Name = "ChkLuz";
            this.ChkLuz.Size = new System.Drawing.Size(69, 17);
            this.ChkLuz.TabIndex = 3;
            this.ChkLuz.Text = "Tiene luz";
            this.ChkLuz.UseVisualStyleBackColor = true;
            // 
            // LblSuperficie
            // 
            this.LblSuperficie.AutoSize = true;
            this.LblSuperficie.Location = new System.Drawing.Point(106, 62);
            this.LblSuperficie.Name = "LblSuperficie";
            this.LblSuperficie.Size = new System.Drawing.Size(61, 13);
            this.LblSuperficie.TabIndex = 4;
            this.LblSuperficie.Text = "Superficie *";
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Location = new System.Drawing.Point(132, 89);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(35, 13);
            this.LblTipo.TabIndex = 4;
            this.LblTipo.Text = "Tipo *";
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Location = new System.Drawing.Point(118, 142);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(49, 13);
            this.LblCantidad.TabIndex = 4;
            this.LblCantidad.Text = "Cantidad";
            // 
            // CboSede
            // 
            this.CboSede.FormattingEnabled = true;
            this.CboSede.Location = new System.Drawing.Point(173, 32);
            this.CboSede.Name = "CboSede";
            this.CboSede.Size = new System.Drawing.Size(121, 21);
            this.CboSede.TabIndex = 0;
            this.CboSede.Validating += new System.ComponentModel.CancelEventHandler(this.CboSede_Validating);
            this.CboSede.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboSede_KeyPress);
            // 
            // LblSede
            // 
            this.LblSede.AutoSize = true;
            this.LblSede.Location = new System.Drawing.Point(36, 35);
            this.LblSede.Name = "LblSede";
            this.LblSede.Size = new System.Drawing.Size(131, 13);
            this.LblSede.TabIndex = 4;
            this.LblSede.Text = "Sede a la que pertenece *";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(173, 139);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(55, 20);
            this.TxtCantidad.TabIndex = 4;
            // 
            // FrmCanchas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 207);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.LblSede);
            this.Controls.Add(this.LblSuperficie);
            this.Controls.Add(this.ChkLuz);
            this.Controls.Add(this.CboTipo);
            this.Controls.Add(this.CboSede);
            this.Controls.Add(this.CboSuperficie);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Name = "FrmCanchas";
            this.Text = "FrmCanchas";
            this.Load += new System.EventHandler(this.FrmCanchas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpCanchas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider EpCanchas;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label LblTipo;
        private System.Windows.Forms.Label LblSuperficie;
        private System.Windows.Forms.CheckBox ChkLuz;
        private System.Windows.Forms.ComboBox CboTipo;
        private System.Windows.Forms.ComboBox CboSuperficie;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label LblSede;
        private System.Windows.Forms.ComboBox CboSede;
        private System.Windows.Forms.TextBox TxtCantidad;
    }
}