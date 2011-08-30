using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Contacto
    {
        public Contacto(string telefono, string celular, string email)
        {
            this.telefono = telefono; this.celular = celular;
            this.email = email;
        }

        string telefono;
        string celular;
        string email;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Celular
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
