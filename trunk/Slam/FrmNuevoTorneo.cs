using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;
using Servicio;
using System.Windows.Forms;

namespace Slam
{
    public partial class FrmNuevoTorneo : Form,ITorneoUI
    {
        int idtorneo;
        public FrmNuevoTorneo(int IdTorneo)
        {
            InitializeComponent();
            this.idtorneo = IdTorneo;
        }

        public FrmNuevoTorneo()
        {
            InitializeComponent();
        }

        private void FrmNuevoTorneo_Load(object sender, EventArgs e)
        {

        }

        #region Miembros de ITorneoUI

        public int IdTorneo
        {
            get
            {
                return idtorneo;
            }
            set
            {
                idtorneo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return TxtNombre.Text;
            }
            set
            {
                TxtNombre.Text = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return DTPInicioTorneo.Value;
            }
            set
            {
                DTPInicioTorneo.Value = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return DTPFinTorneo.Value;
            }
            set
            {
                DTPFinTorneo.Value = value;
            }
        }

        public DateTime FechaFinInscripcion
        {
            get
            {
                return DTPFinInscripciones.Value;
            }
            set
            {
                DTPFinInscripciones.Value = value;
            }
        }

        public DateTime FechaInicioInscripcion
        {
            get
            {
                return DTPInicioInscripciones.Value;
            }
            set
            {
                DTPInicioInscripciones.Value = value;
            }
        }

        public int Cupo
        {
            get
            {
               return int.Parse(TxtCupo.Text);
            }
            set
            {
                TxtCupo.Text = value.ToString();
            }
        }

        public string Sexo
        {
            get
            {
                if (RBMasculino.Checked)
                {
                    return "Masculino";
                }
                else if (RBFemenino.Checked)
                {
                    return "Femenino";
                }
                else
                {
                    return "Mixto";
                }
            }
            set
            {
                if (value == "Masculino")
                {
                    RBMasculino.Checked=true;
                }
                else if (value == "Femenino")
                {
                    RBFemenino.Checked = true;
                }
                else
                {
                    RBMixto.Checked = true;
                }
            }
        }

        public int Tipo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int IdClub
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int IdCategoria
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool TipoInscripcion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Superficie
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Estado
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
