﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servicio.InterfacesUI;
using Servicio;
using System.Collections;

namespace Slam
{
    public partial class FrmNuevaAfiliacion : Form, IAfiliacionUI
    {
        public FrmNuevaAfiliacion()
        {
            InitializeComponent();
        }

        private void FrmNuevaAfiliacion_Load(object sender, EventArgs e)
        {

        }

        #region Miembros de IAfiliacionUI

        public int IdClub
        {
            get
            {
                return Convert.ToInt32(((DictionaryEntry)CboListaClubes.SelectedItem).Value);
            }
            set
            {
               CboListaClubes.SelectedValue = value;
            }
        }

        public int Dni
        {
            get
            {
                return Convert.ToInt32(TxtDni.Text);
            }
            set
            {
                TxtDni.Text = value.ToString();
            }
        }

        public bool Estado
        {
            get
            {
                return ChkEstado.Checked;
            }
            set
            {
                ChkEstado.Checked = value ;
            }
        }

        #endregion
    }
}