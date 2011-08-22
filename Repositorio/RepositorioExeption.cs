using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public class RepositorioExeption : SystemException
    {
        public RepositorioExeption() { }
        public RepositorioExeption(string Mensaje)
            : base(Mensaje)
        {
            throw new Exception(Mensaje);
        }
        public RepositorioExeption(string Mensaje, Exception Causa)
            : base(Mensaje, Causa)
        {
            throw new Exception(Mensaje, Causa);
        }
    }
}
