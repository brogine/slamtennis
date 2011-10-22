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
        int IdTorneoActual = 0;
        public FrmPopUp(int IdTorneo, string NombreTorneo, string NombreCategoria)
        {
            InitializeComponent();
            this.IdTorneoActual = IdTorneo;
            this.LblTorneo.Text = NombreTorneo;
            this.LblCategoria.Text = NombreCategoria;
        }

        private void FrmPopUp_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Parent.Width - this.Width - 5, Parent.Height - this.Height - 5);
        }

        private void BtnCompletar_Click(object sender, EventArgs e)
        {
            FrmListaPartidos listaPartidos = new FrmListaPartidos(IdTorneoActual);
            listaPartidos.MdiParent = (FrmPrincipal)this.Parent.Parent;
            listaPartidos.Show();
            this.Close();
        }
    }
}
