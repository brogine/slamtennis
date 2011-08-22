using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Contacto
    {
        public Contacto(int telefono, int celular, string email)
        {
            this.telefono = telefono; this.celular = celular;
            this.email = email;
        }

        int telefono;
        int celular;
        string email;

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public int Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
