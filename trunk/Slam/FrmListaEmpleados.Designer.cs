/*
 * Creado por SharpDevelop.
 * Usuario: Rubio
 * Fecha: 07/09/2011
 * Hora: 08:02 p.m.
 * 
 */
namespace Slam
{
	partial class FrmListaEmpleados
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaEmpleados));
			this.BtnModificar = new System.Windows.Forms.Button();
			this.BtnNuevo = new System.Windows.Forms.Button();
			this.DgvEmpleados = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.DgvEmpleados)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnModificar
			// 
			this.BtnModificar.Location = new System.Drawing.Point(340, 289);
			this.BtnModificar.Name = "BtnModificar";
			this.BtnModificar.Size = new System.Drawing.Size(75, 23);
			this.BtnModificar.TabIndex = 5;
			this.BtnModificar.Text = "Modificar";
			this.BtnModificar.UseVisualStyleBackColor = true;
			this.BtnModificar.Click += new System.EventHandler(this.BtnModificarClick);
			// 
			// BtnNuevo
			// 
			this.BtnNuevo.Location = new System.Drawing.Point(197, 289);
			this.BtnNuevo.Name = "BtnNuevo";
			this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
			this.BtnNuevo.TabIndex = 4;
			this.BtnNuevo.Text = "Nuevo";
			this.BtnNuevo.UseVisualStyleBackColor = true;
			this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevoClick);
			// 
			// DgvEmpleados
			// 
			this.DgvEmpleados.AllowUserToAddRows = false;
			this.DgvEmpleados.AllowUserToDeleteRows = false;
			this.DgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvEmpleados.Location = new System.Drawing.Point(12, 21);
			this.DgvEmpleados.Name = "DgvEmpleados";
			this.DgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgvEmpleados.Size = new System.Drawing.Size(582, 262);
			this.DgvEmpleados.TabIndex = 3;
			// 
			// FrmListaEmpleados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 323);
			this.Controls.Add(this.BtnModificar);
			this.Controls.Add(this.BtnNuevo);
			this.Controls.Add(this.DgvEmpleados);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmListaEmpleados";
			this.Text = "Empleados de la Federación";
			this.Load += new System.EventHandler(this.FrmListaEmpleadosLoad);
			((System.ComponentModel.ISupportInitialize)(this.DgvEmpleados)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridView DgvEmpleados;
		private System.Windows.Forms.Button BtnNuevo;
		private System.Windows.Forms.Button BtnModificar;
	}
}
