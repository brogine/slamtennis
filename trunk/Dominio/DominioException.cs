using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class DominioException : SystemException
    {
        public DominioException() { }

        public DominioException(string Mensaje)
            : base(Mensaje)
        {
            throw new Exception(Mensaje);
        }

        public DominioException(string Mensaje, Exception causa)
            : base(Mensaje, causa)
        {
            throw new Exception(Mensaje, causa);
        }

    }
}
