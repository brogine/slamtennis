using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public class ConexionException : SystemException
    {
        public ConexionException() { }

        public ConexionException(string Mensaje)
            : base(Mensaje)
        {
        }

        public ConexionException(string Mensaje, Exception causa)
            : base(Mensaje, causa)
        {
        }

    }
}
