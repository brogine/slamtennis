namespace Slam
{
    partial class FrmPopUp
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
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.LblTorneo = new System.Windows.Forms.Label();
            this.LblCategoria = new System.Windows.Forms.Label();
            this.LblDescripcion2 = new System.Windows.Forms.Label();
            this.BtnCompletar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.ForeColor = System.Drawing.Color.White;
            this.LblDescripcion.Location = new System.Drawing.Point(63, 9);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(94, 13);
            this.LblDescripcion.TabIndex = 0;
            this.LblDescripcion.Text = "Se cerró el torneo:";
            // 
            // LblTorneo
            // 
            this.LblTorneo.AutoSize = true;
            this.LblTorneo.ForeColor = System.Drawing.Color.White;
            this.LblTorneo.Location = new System.Drawing.Point(27, 32);
            this.LblTorneo.Name = "LblTorneo";
            this.LblTorneo.Size = new System.Drawing.Size(81, 13);
            this.LblTorneo.TabIndex = 1;
            this.LblTorneo.Text = "Nombre Torneo";
            // 
            // LblCategoria
            // 
            this.LblCategoria.AutoSize = true;
            this.LblCategoria.ForeColor = System.Drawing.Color.White;
            this.LblCategoria.Location = new System.Drawing.Point(27, 54);
            this.LblCategoria.Name = "LblCategoria";
            this.LblCategoria.Size = new System.Drawing.Size(54, 13);
            this.LblCategoria.TabIndex = 1;
            this.LblCategoria.Text = "Categoría";
            // 
            // LblDescripcion2
            // 
            this.LblDescripcion2.AutoSize = true;
            this.LblDescripcion2.ForeColor = System.Drawing.Color.White;
            this.LblDescripcion2.Location = new System.Drawing.Point(24, 82);
            this.LblDescripcion2.Name = "LblDescripcion2";
            this.LblDescripcion2.Size = new System.Drawing.Size(182, 13);
            this.LblDescripcion2.TabIndex = 2;
            this.LblDescripcion2.Text = "Debe completar los datos de partidos";
            // 
            // BtnCompletar
            // 
            this.BtnCompletar.BackColor = System.Drawing.Color.DimGray;
            this.BtnCompletar.ForeColor = System.Drawing.Color.White;
            this.BtnCompletar.Location = new System.Drawing.Point(82, 101);
            this.BtnCompletar.Name = "BtnCompletar";
            this.BtnCompletar.Size = new System.Drawing.Size(75, 23);
            this.BtnCompletar.TabIndex = 0;
            this.BtnCompletar.Text = "Completar";
            this.BtnCompletar.UseVisualStyleBackColor = false;
            this.BtnCompletar.Click += new System.EventHandler(this.BtnCompletar_Click);
            // 
            // FrmPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(226, 136);
            this.Controls.Add(this.BtnCompletar);
            this.Controls.Add(this.LblDescripcion2);
            this.Controls.Add(this.LblCategoria);
            this.Controls.Add(this.LblTorneo);
            this.Controls.Add(this.LblDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(112, 24);
            this.Name = "FrmPopUp";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notificación";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmPopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label LblTorneo;
        private System.Windows.Forms.Label LblCategoria;
        private System.Windows.Forms.Label LblDescripcion2;
        private System.Windows.Forms.Button BtnCompletar;
    }
}