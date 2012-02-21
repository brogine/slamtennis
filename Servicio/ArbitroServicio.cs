﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Servicio
{
    class ArbitroServicio : IArbitroServicio, IListadoArbitrosServicio
    {
        IArbitroRepositorio ArbRepo;
        public ArbitroServicio()
        {
            ArbRepo = new ArbitroRepositorio();
        }

        #region Miembros de IArbitroServicio

        public void Agregar(IArbitroUI UI)
        {

            IUbicacionRepositorio Ubica = new UbicacionRepositorio();
            Pais Nacionalidad = Ubica.ObtenerPais(UI.Nacionalidad);
            Ubicacion Ubicacion = new Ubicacion(Ubica.ObtenerLocalidad(UI.Localidad), UI.Domicilio);
            Contacto Contacto = new Contacto(UI.Telefono, UI.Celular, UI.Email);
            Login Login = new Login(UI.Usuario, UI.Password, UI.Dni, true);
            Bitmap newImage = null;
            if (UI.Foto != null)
            {
                newImage = new Bitmap(100, 100);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(UI.Foto, new Rectangle(0, 0, 100, 100));
                }
            }
            Arbitro NuevoArb = new Arbitro(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac, Nacionalidad, UI.Sexo, Contacto, Ubicacion, UI.Badge, UI.Nivel, UI.Estado, newImage);
            NuevoArb.Login = Login;
            ArbRepo.Agregar(NuevoArb);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void Modificar(IArbitroUI UI)
        {
            Arbitro ModArb = ArbRepo.Buscar(UI.Dni);
            IUbicacionRepositorio UbicaRepo = new UbicacionRepositorio();

            ModArb.Apellido = UI.Apellido;
            ModArb.FechaNac = UI.FechaNac;
            Pais Nacionalidad = UbicaRepo.ObtenerPais(UI.Nacionalidad);
            ModArb.Nacionalidad = Nacionalidad;
            ModArb.Nombre = UI.Nombre;
            ModArb.Sexo = UI.Sexo;
            ModArb.Nivel = UI.Nivel;
            ModArb.Badge = UI.Badge;
            ModArb.Login.Usuario = UI.Usuario;
            ModArb.Login.Password = UI.Password;
            Bitmap newImage = null;
            if (UI.Foto != null)
            {
                newImage = new Bitmap(320, 240);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(UI.Foto, new Rectangle(0, 0, 320, 240));
                }
                ModArb.Foto = ModArb.ImagenABytes(newImage);
            }
            
            //Atributos de Value Object "Contacto"
            ModArb.Contacto.Celular = UI.Celular;
            ModArb.Contacto.Email = UI.Email;
            ModArb.Contacto.Telefono = UI.Telefono;

            //Atributos de Value Object "Ubicacion"
            ModArb.Ubicacion.Domicilio = UI.Domicilio;
            Localidad Localidad = UbicaRepo.ObtenerLocalidad(UI.Localidad);
            ModArb.Ubicacion.Localidad = Localidad;

            ArbRepo.Modificar(ModArb);
        }

        public bool Existe(int Dni)
        {
            return ArbRepo.Existe(Dni);
        }

        public void Buscar(IArbitroUI UI)
        {
            if (Existe(UI.Dni))
            {
                Arbitro BuscaArb = ArbRepo.Buscar(UI.Dni);
                UI.Dni = BuscaArb.Dni;
                UI.Apellido = BuscaArb.Apellido;
                UI.Nombre = BuscaArb.Nombre;
                UI.FechaNac = BuscaArb.FechaNac;
                UI.Nacionalidad = BuscaArb.Nacionalidad.IdPais;
                UI.Nivel = BuscaArb.Nivel;
                UI.Badge = BuscaArb.Badge;
                UI.Sexo = BuscaArb.Sexo;
                if (BuscaArb.Foto != null)
                    UI.Foto = BuscaArb.BytesAImagen(BuscaArb.Foto);

                // Value Object Login
                UI.Usuario = BuscaArb.Login.Usuario;
                UI.Password = BuscaArb.Login.Password;

                //Value Object Ubicacion
                UI.Pais = BuscaArb.Ubicacion.Localidad.Provincia.Pais.IdPais;
                UI.Provincia = BuscaArb.Ubicacion.Localidad.Provincia.IdProvincia;
                UI.Localidad = BuscaArb.Ubicacion.Localidad.IdLocalidad;
                UI.Domicilio = BuscaArb.Ubicacion.Domicilio;

                //Value Object Contacto
                UI.Telefono = BuscaArb.Contacto.Telefono;
                UI.Email = BuscaArb.Contacto.Email;
                UI.Celular = BuscaArb.Contacto.Celular;
            }
            else
                throw new ServicioException("El Arbitro con Dni " + UI.Dni + " No Existe.");
        }

        #endregion

        #region Miembros de IListadoArbitrosServicio

        public void Listar(IListadoArbitros UI)
        {
            List<Object> ListaUI = new List<object>();
            List<Arbitro> ListaArb = ArbRepo.Listar();
            foreach (Arbitro Arbitro in ListaArb)
            {
                Object Objeto = new object();
                Objeto = Arbitro.Dni + ",";
                Objeto += Arbitro.Apellido + " " + Arbitro.Nombre + ",";
                Objeto += Arbitro.Nivel + ",";
                Objeto += Arbitro.Badge + ",";
                ListaUI.Add(Objeto);
            }
            UI.ListarArbitros = ListaUI;
        }

        #endregion
    }
}
