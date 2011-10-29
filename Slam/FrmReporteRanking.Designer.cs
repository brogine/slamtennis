namespace Slam
{
    partial class FrmReporteRanking
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
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.LblCategoria = new System.Windows.Forms.Label();
            this.CboCategorias = new System.Windows.Forms.ComboBox();
            this.EpReporteRanking = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EpReporteRanking)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(158, 134);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 5;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // LblCategoria
            // 
            this.LblCategoria.AutoSize = true;
            this.LblCategoria.Location = new System.Drawing.Point(55, 98);
            this.LblCategoria.Name = "LblCategoria";
            this.LblCategoria.Size = new System.Drawing.Size(97, 13);
            this.LblCategoria.TabIndex = 4;
            this.LblCategoria.Text = "Elija una Categoría";
            // 
            // CboCategorias
            // 
            this.CboCategorias.FormattingEnabled = true;
            this.CboCategorias.Location = new System.Drawing.Point(158, 95);
            this.CboCategorias.Name = "CboCategorias";
            this.CboCategorias.Size = new System.Drawing.Size(171, 21);
            this.CboCategorias.TabIndex = 3;
            this.CboCategorias.Validating += new System.ComponentModel.CancelEventHandler(this.CboCategorias_Validating);
            // 
            // EpReporteRanking
            // 
            this.EpReporteRanking.ContainerControl = this;
            // 
            // FrmReporteRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 262);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.LblCategoria);
            this.Controls.Add(this.CboCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteRanking";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmReporteRanking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpReporteRanking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label LblCategoria;
        private System.Windows.Forms.ComboBox CboCategorias;
        private System.Windows.Forms.ErrorProvider EpReporteRanking;
    }
}