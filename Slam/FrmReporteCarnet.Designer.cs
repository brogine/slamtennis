namespace Slam
{
    partial class FrmReporteCarnet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteCarnet));
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.CboTipo = new System.Windows.Forms.ComboBox();
            this.TxtDni = new System.Windows.Forms.MaskedTextBox();
            this.LblTipo = new System.Windows.Forms.Label();
            this.LblDni = new System.Windows.Forms.Label();
            this.EpCarnet = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EpCarnet)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(67, 134);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(148, 134);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // CboTipo
            // 
            this.CboTipo.FormattingEnabled = true;
            this.CboTipo.Location = new System.Drawing.Point(103, 32);
            this.CboTipo.Name = "CboTipo";
            this.CboTipo.Size = new System.Drawing.Size(121, 21);
            this.CboTipo.TabIndex = 1;
            this.CboTipo.Validating += new System.ComponentModel.CancelEventHandler(this.CboTipo_Validating);
            this.CboTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboTipo_KeyPress);
            // 
            // TxtDni
            // 
            this.TxtDni.Location = new System.Drawing.Point(103, 73);
            this.TxtDni.Mask = "00.000.000";
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(120, 20);
            this.TxtDni.TabIndex = 3;
            this.TxtDni.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.TxtDni.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDni_Validating);
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Location = new System.Drawing.Point(62, 35);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(28, 13);
            this.LblTipo.TabIndex = 4;
            this.LblTipo.Text = "Tipo";
            // 
            // LblDni
            // 
            this.LblDni.AutoSize = true;
            this.LblDni.Location = new System.Drawing.Point(67, 76);
            this.LblDni.Name = "LblDni";
            this.LblDni.Size = new System.Drawing.Size(23, 13);
            this.LblDni.TabIndex = 4;
            this.LblDni.Text = "Dni";
            // 
            // EpCarnet
            // 
            this.EpCarnet.ContainerControl = this;
            // 
            // FrmReporteCarnet
            // 
            this.AcceptButton = this.BtnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(292, 189);
            this.Controls.Add(this.LblDni);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.TxtDni);
            this.Controls.Add(this.CboTipo);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteCarnet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Carnet";
            this.Load += new System.EventHandler(this.FrmReporteCarnet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EpCarnet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ComboBox CboTipo;
        private System.Windows.Forms.MaskedTextBox TxtDni;
        private System.Windows.Forms.Label LblTipo;
        private System.Windows.Forms.Label LblDni;
        private System.Windows.Forms.ErrorProvider EpCarnet;
    }
}