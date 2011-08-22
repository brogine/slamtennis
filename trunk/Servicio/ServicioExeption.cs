using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio
{
    class ServicioExeption : SystemException
    {
        public ServicioExeption() { }
        
        public ServicioExeption(string Mensaje):base(Mensaje)
        {
            throw new Exception(Mensaje);
        }

        public ServicioExeption(string Mensaje, Exception Causa)
            : base(Mensaje, Causa)
        {
            throw new Exception(Mensaje, Causa);
        }
    }
}
