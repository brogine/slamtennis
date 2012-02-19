namespace Slam
{
    partial class FrmReporteLlave
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
            this.DtpDesde = new System.Windows.Forms.DateTimePicker();
            this.CboTorneos = new System.Windows.Forms.ComboBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpHasta = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // DtpDesde
            // 
            this.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDesde.Location = new System.Drawing.Point(69, 18);
            this.DtpDesde.Name = "DtpDesde";
            this.DtpDesde.Size = new System.Drawing.Size(97, 20);
            this.DtpDesde.TabIndex = 0;
            this.DtpDesde.ValueChanged += new System.EventHandler(this.DtpDesde_ValueChanged);
            // 
            // CboTorneos
            // 
            this.CboTorneos.FormattingEnabled = true;
            this.CboTorneos.Location = new System.Drawing.Point(27, 86);
            this.CboTorneos.Name = "CboTorneos";
            this.CboTorneos.Size = new System.Drawing.Size(237, 21);
            this.CboTorneos.TabIndex = 1;
            this.CboTorneos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboTorneos_KeyPress);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(110, 125);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 2;
            this.BtnAceptar.Text = "Ver Llave";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(12, 18);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(41, 13);
            this.lblFechaDesde.TabIndex = 3;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(12, 44);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(38, 13);
            this.lblFechaHasta.TabIndex = 3;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Torneos:";
            // 
            // DtpHasta
            // 
            this.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpHasta.Location = new System.Drawing.Point(69, 44);
            this.DtpHasta.Name = "DtpHasta";
            this.DtpHasta.Size = new System.Drawing.Size(97, 20);
            this.DtpHasta.TabIndex = 0;
            this.DtpHasta.ValueChanged += new System.EventHandler(this.DtpHasta_ValueChanged);
            // 
            // FrmReporteLlave
            // 
            this.AcceptButton = this.BtnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 171);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.CboTorneos);
            this.Controls.Add(this.DtpHasta);
            this.Controls.Add(this.DtpDesde);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteLlave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteLlave";
            this.Load += new System.EventHandler(this.FrmReporteLlave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpDesde;
        private System.Windows.Forms.ComboBox CboTorneos;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpHasta;
    }
}