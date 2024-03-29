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
using ApplicationContext;

namespace Slam
{
    public partial class FrmNuevaCategoria : Form, ICategoriaUI
    {
        int idCat = 0;
        string ImplementaCategorias = "CategoriaServicio";
        ICategoriaServicio ServicioCategoria;
        public FrmNuevaCategoria()
        {
            InitializeComponent();
            this.ChkEstado.Checked = true;
        }

        public FrmNuevaCategoria(int IdCat)
        {
            InitializeComponent();
            this.idCat = IdCat;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int Result = 0;
            if (TxtNombre.Text == "")
            {
                MessageBox.Show("El Nombre No Puede Estar En Blanco");
                return;
            } 
            if (TxtEdadMax.Text == "" && !int.TryParse(TxtEdadMax.Text, out Result))
            {
                MessageBox.Show("El Valor De La Edad Minima Debe Ser Numerico");
                return;
            }
            if (TxtEdadMin.Text == "" && !int.TryParse(TxtEdadMin.Text, out Result))
            {
                MessageBox.Show("El Valor De La Edad Minima Debe Ser Numerico");
                return;
            }
            try
            {
                if (ServicioCategoria.Existe(this.idCat))
                    ServicioCategoria.Modificar(this);
                else
                    ServicioCategoria.Agregar(this);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Los cambios fueron realizados con éxito");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Miembros de ICategoriaUI

        public int IdCategoria
        {
            get
            {
                return idCat;
            }
            set
            {
                idCat=value;
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

        public int EdadMinima
        {
            get
            {
                return int.Parse(TxtEdadMin.Text);
            }
            set
            {
                TxtEdadMin.Text = value.ToString();
            }
        }

        public int EdadMaxima
        {
            get
            {
               return int.Parse(TxtEdadMax.Text);
            }
            set
            {
                TxtEdadMax.Text = value.ToString();
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
                ChkEstado.Checked = value;
            }
        }

        #endregion

        private void FrmNuevaCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                ServicioCategoria = (ICategoriaServicio)AppContext.Instance.GetObject(ImplementaCategorias);
                if (idCat == 0)
                    this.Text = "Agregar Una Nueva Categoria";
                else
                {
                    this.Text = "Modificar Categoria";
                    ServicioCategoria.Buscar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Close();
        }
    }
}
