﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Login
    {
        public Login(string usuario, string contraseña, int dni, bool estado)
        {
            this.usuario = usuario; this.password = contraseña; this.dni = dni; this.estado = estado;
        }

        string usuario;
        string password;
        int dni;
        bool estado;

        public String Usuario
        {
            get { return usuario; }
            set 
            {
                if (this.ValidarPalabrasInvalidas(value))
                    throw new DominioException("Caracteres inválidos en cadena ingresada.");
                usuario = value; 
            }
        }

        public String Password
        {
            get { return password; }
            set 
            {
                if (this.ValidarPalabrasInvalidas(value))
                    throw new DominioException("Caracteres inválidos en cadena ingresada.");
                password = value; 
            }
        }

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        bool ValidarPalabrasInvalidas(string cadena)
        {
            string[] invalidas = new string[] { "select", "delete", "drop", "count"};
            foreach (string palabra in invalidas)
            {
                if (cadena.Contains(palabra))
                    return true;
            }
            return false;
        }
    }
}
