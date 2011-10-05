namespace Slam
{
    partial class FrmReportes
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
            this.RptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TvReportes = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // RptViewer
            // 
            this.RptViewer.ActiveViewIndex = -1;
            this.RptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RptViewer.DisplayGroupTree = false;
            this.RptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptViewer.Location = new System.Drawing.Point(0, 0);
            this.RptViewer.Name = "RptViewer";
            this.RptViewer.SelectionFormula = "";
            this.RptViewer.Size = new System.Drawing.Size(1142, 607);
            this.RptViewer.TabIndex = 0;
            this.RptViewer.ViewTimeSelectionFormula = "";
            // 
            // TvReportes
            // 
            this.TvReportes.Dock = System.Windows.Forms.DockStyle.Left;
            this.TvReportes.Location = new System.Drawing.Point(0, 0);
            this.TvReportes.Name = "TvReportes";
            this.TvReportes.Size = new System.Drawing.Size(188, 607);
            this.TvReportes.TabIndex = 1;
            this.TvReportes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvReportes_NodeMouseClick);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 607);
            this.Controls.Add(this.TvReportes);
            this.Controls.Add(this.RptViewer);
            this.Name = "FrmReportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RptViewer;
        private System.Windows.Forms.TreeView TvReportes;
    }
}