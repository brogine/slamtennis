namespace Slam
{
    partial class FrmNuevoClub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoClub));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNombreClub = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblNombrePresidente = new System.Windows.Forms.Label();
            this.BtnComprobar = new System.Windows.Forms.Button();
            this.TxtDniPresidente = new System.Windows.Forms.MaskedTextBox();
            this.ChkEstado = new System.Windows.Forms.CheckBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese El Nombre Del Club";
            // 
            // TxtNombreClub
            // 
            this.TxtNombreClub.Location = new System.Drawing.Point(162, 17);
            this.TxtNombreClub.Name = "TxtNombreClub";
            this.TxtNombreClub.Size = new System.Drawing.Size(219, 20);
            this.TxtNombreClub.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese el Dni Del Presidente";
            // 
            // LblNombrePresidente
            // 
            this.LblNombrePresidente.AutoSize = true;
            this.LblNombrePresidente.Location = new System.Drawing.Point(12, 76);
            this.LblNombrePresidente.Name = "LblNombrePresidente";
            this.LblNombrePresidente.Size = new System.Drawing.Size(0, 13);
            this.LblNombrePresidente.TabIndex = 3;
            // 
            // BtnComprobar
            // 
            this.BtnComprobar.Location = new System.Drawing.Point(265, 44);
            this.BtnComprobar.Name = "BtnComprobar";
            this.BtnComprobar.Size = new System.Drawing.Size(116, 23);
            this.BtnComprobar.TabIndex = 4;
            this.BtnComprobar.Text = "Comprobar Nombre";
            this.BtnComprobar.UseVisualStyleBackColor = true;
            this.BtnComprobar.Click += new System.EventHandler(this.BtnComprobar_Click);
            // 
            // TxtDniPresidente
            // 
            this.TxtDniPresidente.Location = new System.Drawing.Point(162, 47);
            this.TxtDniPresidente.Mask = "00.000.000";
            this.TxtDniPresidente.Name = "TxtDniPresidente";
            this.TxtDniPresidente.Size = new System.Drawing.Size(100, 20);
            this.TxtDniPresidente.TabIndex = 5;
            this.TxtDniPresidente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChkEstado
            // 
            this.ChkEstado.AutoSize = true;
            this.ChkEstado.Location = new System.Drawing.Point(15, 101);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(80, 17);
            this.ChkEstado.TabIndex = 6;
            this.ChkEstado.Text = "Club Activo";
            this.ChkEstado.UseVisualStyleBackColor = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(306, 97);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmNuevoClub
            // 
            this.AcceptButton = this.BtnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 128);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.ChkEstado);
            this.Controls.Add(this.TxtDniPresidente);
            this.Controls.Add(this.BtnComprobar);
            this.Controls.Add(this.LblNombrePresidente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNombreClub);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNuevoClub";
            this.Text = "FrmNuevoClub";
            this.Load += new System.EventHandler(this.FrmNuevoClub_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNombreClub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblNombrePresidente;
        private System.Windows.Forms.Button BtnComprobar;
        private System.Windows.Forms.MaskedTextBox TxtDniPresidente;
        private System.Windows.Forms.CheckBox ChkEstado;
        private System.Windows.Forms.Button BtnGuardar;
    }
}