using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Dominio
{
    public sealed class CuentaEmail
    {
        CuentaEmail() { }

        static CuentaEmail instance = null;

        public static CuentaEmail GetIntancia(){
            if (instance == null)
            {
                instance = new CuentaEmail();
            }
            return instance;
        }

        public string Nombre { get; set; }
        public ServidorSMTP SMTP { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }


    }
}
