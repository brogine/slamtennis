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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            this.RptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TvReportes = new System.Windows.Forms.TreeView();
            this.SpReportes = new System.Windows.Forms.SplitContainer();
            this.SpReportes.Panel1.SuspendLayout();
            this.SpReportes.Panel2.SuspendLayout();
            this.SpReportes.SuspendLayout();
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
            this.RptViewer.Size = new System.Drawing.Size(984, 607);
            this.RptViewer.TabIndex = 0;
            this.RptViewer.ViewTimeSelectionFormula = "";
            // 
            // TvReportes
            // 
            this.TvReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvReportes.Location = new System.Drawing.Point(0, 0);
            this.TvReportes.Name = "TvReportes";
            this.TvReportes.Size = new System.Drawing.Size(154, 607);
            this.TvReportes.TabIndex = 1;
            this.TvReportes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvReportes_NodeMouseClick);
            // 
            // SpReportes
            // 
            this.SpReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpReportes.Location = new System.Drawing.Point(0, 0);
            this.SpReportes.Name = "SpReportes";
            // 
            // SpReportes.Panel1
            // 
            this.SpReportes.Panel1.Controls.Add(this.TvReportes);
            // 
            // SpReportes.Panel2
            // 
            this.SpReportes.Panel2.Controls.Add(this.RptViewer);
            this.SpReportes.Size = new System.Drawing.Size(1142, 607);
            this.SpReportes.SplitterDistance = 154;
            this.SpReportes.TabIndex = 2;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 607);
            this.Controls.Add(this.SpReportes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.SpReportes.Panel1.ResumeLayout(false);
            this.SpReportes.Panel2.ResumeLayout(false);
            this.SpReportes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RptViewer;
        private System.Windows.Forms.TreeView TvReportes;
        private System.Windows.Forms.SplitContainer SpReportes;
    }
}