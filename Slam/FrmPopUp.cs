using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Slam
{
    public partial class FrmPopUp : Form
    {
        bool DisposeAlFinalizar = false;
        bool Showing = true;
        bool ForceClose = false;
        DialogResult origDialogResult;
        int IdTorneoActual = 0;
        string ImplementaTorneos = "TorneoServicio";
        public FrmPopUp(int IdTorneo, string NombreTorneo, string NombreCategoria)
        {
            InitializeComponent();
            this.IdTorneoActual = IdTorneo;
            this.LblTorneo.Text = NombreTorneo;
            this.LblCategoria.Text = NombreCategoria;
        }

        private void FrmPopUp_Load(object sender, EventArgs e)
        {
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Opacity = 0.0;
            Showing = true;
            this.Location = new Point(Parent.Width - this.Width - 5, Parent.Height - this.Height - 5);
            Timer = new Timer(components);
            Timer.Interval = 3000;
            Timer.Enabled = true;
            Timer.Start();
            Timer.Tick += new EventHandler(Animate);
        }

        private void FrmPopUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ForceClose)
            {
                origDialogResult = this.DialogResult;
                e.Cancel = true;
                Showing = false;
                Timer.Start();
            }
            else
            {
                this.DialogResult = origDialogResult;
            }
        }

        private void Animate(object sender, EventArgs e)
        {
            if (Showing)
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.1;
                }
                else
                {
                    Timer.Stop();
                }
            }
            else
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.1;
                }
                else
                {
                    Timer.Stop();
                    ForceClose = true;
                    this.Close();
                    if (DisposeAlFinalizar)
                        this.Dispose();
                }
            }
        }

        private void BtnCompletar_Click(object sender, EventArgs e)
        {
            FrmListaPartidos listaPartidos = new FrmListaPartidos();
            listaPartidos.MdiParent = (FrmPrincipal)this.Parent;
            listaPartidos.Show();
            this.Close();
        }
    }
}
