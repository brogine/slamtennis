﻿namespace Slam
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
            this.CboListaClubes = new System.Windows.Forms.ComboBox();
            this.LblNombreClub = new System.Windows.Forms.Label();
            this.TxtDni = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkEstado = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CboListaClubes
            // 
            this.CboListaClubes.FormattingEnabled = true;
            this.CboListaClubes.Location = new System.Drawing.Point(183, 12);
            this.CboListaClubes.Name = "CboListaClubes";
            this.CboListaClubes.Size = new System.Drawing.Size(198, 21);
            this.CboListaClubes.TabIndex = 0;
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
            this.TxtDni.Location = new System.Drawing.Point(183, 39);
            this.TxtDni.Mask = "00.000.000";
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(140, 20);
            this.TxtDni.TabIndex = 2;
            this.TxtDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Esciba El Dni Del Jugador *";
            // 
            // ChkEstado
            // 
            this.ChkEstado.AutoSize = true;
            this.ChkEstado.Location = new System.Drawing.Point(15, 78);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(101, 17);
            this.ChkEstado.TabIndex = 4;
            this.ChkEstado.Text = "Afiliacion Activa";
            this.ChkEstado.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmNuevaAfiliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 124);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ChkEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDni);
            this.Controls.Add(this.LblNombreClub);
            this.Controls.Add(this.CboListaClubes);
            this.Name = "FrmNuevaAfiliacion";
            this.Text = "FrmNuevaAfiliacion";
            this.Load += new System.EventHandler(this.FrmNuevaAfiliacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboListaClubes;
        private System.Windows.Forms.Label LblNombreClub;
        private System.Windows.Forms.MaskedTextBox TxtDni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkEstado;
        private System.Windows.Forms.Button button1;
    }
}