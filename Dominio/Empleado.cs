﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Empleado : Persona
    {
        public Empleado(int dni, string nombre, string apellido, DateTime fechanac, Pais nacionalidad, string sexo,
            bool estado, Ubicacion ubicacion, Contacto contacto, string puesto, Sede sede)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido; this.FechaNac = fechanac; 
            this.Nacionalidad = nacionalidad; this.Sexo = sexo; this.estado = estado; this.Contacto = contacto; 
            this.Ubicacion = ubicacion; this.puesto = puesto; this.sede = sede;
        }

        bool estado;
        string puesto;
        Sede sede;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Puesto
        {
            get { return puesto; }
            set { puesto = value; }
        }

        public Sede Sede
        {
            get { return sede; }
            set { sede = value; }
        }
    }
}