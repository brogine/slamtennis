using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Login
    {
        string usuario;
        string password;
        bool estado;

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
