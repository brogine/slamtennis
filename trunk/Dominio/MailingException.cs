using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class MailingException: SystemException
    {
        public MailingException() { }

        public MailingException(string Mensaje)
            : base(Mensaje)
        {
        }

        public MailingException(string Mensaje, Exception causa)
            : base(Mensaje, causa)
        {
        }

    }
}
