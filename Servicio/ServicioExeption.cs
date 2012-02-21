using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
    public class ServicioException : SystemException
    {
        public ServicioException() { }
        
        public ServicioException(string Mensaje):base(Mensaje)
        {
            throw new Exception(Mensaje);
        }

        public ServicioException(string Mensaje, Exception Causa)
            : base(Mensaje, Causa)
        {
            throw new Exception(Mensaje, Causa);
        }
    }
}
